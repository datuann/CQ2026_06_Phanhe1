using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CQ2026_06_Phanhe1
{
    public partial class FormHSBA : Form
    {
        private readonly string _connStr;
        private readonly string _role;
        public FormHSBA(string connStr, string role)
        {
            InitializeComponent();
            _connStr = connStr;
            _role = role;

            ConfigureByRole();
        }
        private void ConfigureByRole()
        {
            bool isDieuPhoiVien = _role == "Điều phối viên";
            bool isBacSi = _role == "Bác sĩ/Y sĩ";

            // Điều phối viên được tạo HSBA, phân công bác sĩ/khoa
            btnInsertHSBA.Visible = isDieuPhoiVien;
            btnClear.Visible = isDieuPhoiVien;

            txtMaHSBA.ReadOnly = !isDieuPhoiVien;
            txtMaBN.ReadOnly = !isDieuPhoiVien;
            txtNgay.ReadOnly = !isDieuPhoiVien;

            txtMaBS.ReadOnly = !isDieuPhoiVien;
            txtMaKhoa.ReadOnly = !isDieuPhoiVien;

            // Bác sĩ được cập nhật chuyên môn
            txtChanDoan.ReadOnly = !isBacSi;
            txtDieuTri.ReadOnly = !isBacSi;
            txtKetLuan.ReadOnly = !isBacSi;

            // Điều phối viên dùng nút update để cập nhật MABS/MAKHOA
            if (isDieuPhoiVien)
            {
                txtChanDoan.ReadOnly = true;
                txtDieuTri.ReadOnly = true;
                txtKetLuan.ReadOnly = true;
                btnUpdate.Text = "Cập nhật phân công";
            }
            else if (isBacSi)
            {
                btnUpdate.Text = "Cập nhật hồ sơ";
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadHSBA();
        }
        private void FormHSBA_Load(object sender, EventArgs e)
        {
            LoadHSBA(); 
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadHSBA();
        }
        private void LoadHSBA()
        {
            string sql = @"
                SELECT MAHSBA,
                       MABN,
                       NGAY,
                       CHANDOAN,
                       DIEUTRI,
                       MABS,
                       MAKHOA,
                       KETLUAN
                FROM QLYTE_06.HSBA
                ORDER BY MAHSBA";
            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleDataAdapter da = new OracleDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvHSBA.DataSource = dt;
                    lblStatus.Text = $"Status: Đã tải {dt.Rows.Count} dòng.";

                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle khi tải HSBA:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải HSBA:\n" + ex.Message);
            }
        }

        private void dgvHSBA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHSBA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvHSBA.Rows[e.RowIndex];

            txtMaHSBA.Text = row.Cells["MAHSBA"].Value?.ToString();
            txtMaBN.Text = row.Cells["MABN"].Value?.ToString();
            txtNgay.Text = row.Cells["NGAY"].Value?.ToString();
            txtChanDoan.Text = row.Cells["CHANDOAN"].Value?.ToString();
            txtDieuTri.Text = row.Cells["DIEUTRI"].Value?.ToString();
            txtMaBS.Text = row.Cells["MABS"].Value?.ToString();
            txtMaKhoa.Text = row.Cells["MAKHOA"].Value?.ToString();
            txtKetLuan.Text = row.Cells["KETLUAN"].Value?.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHSBA.Text))
            {
                MessageBox.Show("Vui lòng chọn hồ sơ bệnh án cần cập nhật.");
                return;
            }

            try
            {
                if (_role == "Điều phối viên")
                {
                    UpdatePhanCongHSBA();
                }
                else if (_role == "Bác sĩ/Y sĩ")
                {
                    UpdateChuyenMonHSBA();
                }
                else
                {
                    MessageBox.Show("User hiện tại không được cập nhật hồ sơ bệnh án.");
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle khi cập nhật HSBA:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật HSBA:\n" + ex.Message);
            }
        }
            
        private void UpdateChuyenMonHSBA()
        {
            string sql = @"
                UPDATE QLYTE_06.HSBA
                SET CHANDOAN = :chandoan,
                    DIEUTRI = :dieutri,
                    KETLUAN = :ketluan
                WHERE MAHSBA = :mahsba";

            using (OracleConnection conn = new OracleConnection(_connStr))
            using (OracleCommand cmd = new OracleCommand(sql, conn))
            {
                conn.Open();
                cmd.BindByName = true;

                cmd.Parameters.Add(":chandoan", OracleDbType.NVarchar2).Value = txtChanDoan.Text;
                cmd.Parameters.Add(":dieutri", OracleDbType.NVarchar2).Value = txtDieuTri.Text;
                cmd.Parameters.Add(":ketluan", OracleDbType.NVarchar2).Value = txtKetLuan.Text;
                cmd.Parameters.Add(":mahsba", OracleDbType.Varchar2).Value = txtMaHSBA.Text.Trim();

                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show($"{rows} dòng được cập nhật.");
                lblStatus.Text = $"Status: Đã cập nhật {rows} dòng.";
                LoadHSBA();
            }
        }
        private void UpdatePhanCongHSBA()
        {
            string sql = @"
                UPDATE QLYTE_06.HSBA
                SET MABS = :mabs,
                    MAKHOA = :makhoa
                WHERE MAHSBA = :mahsba";

            using (OracleConnection conn = new OracleConnection(_connStr))
            using (OracleCommand cmd = new OracleCommand(sql, conn))
            {
                conn.Open();
                cmd.BindByName = true;

                cmd.Parameters.Add(":mabs", OracleDbType.Varchar2).Value = txtMaBS.Text.Trim();
                cmd.Parameters.Add(":makhoa", OracleDbType.Varchar2).Value = txtMaKhoa.Text.Trim();
                cmd.Parameters.Add(":mahsba", OracleDbType.Varchar2).Value = txtMaHSBA.Text.Trim();

                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show($"{rows} hồ sơ được phân công.");
                lblStatus.Text = $"Status: Đã cập nhật phân công {rows} dòng.";
                LoadHSBA();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearInput()
        {
            txtMaHSBA.Clear();
            txtMaBN.Clear();
            txtNgay.Clear();
            txtMaBS.Clear();
            txtMaKhoa.Clear();
            txtChanDoan.Clear();
            txtDieuTri.Clear();
            txtKetLuan.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaHSBA.Clear();
            txtMaBN.Clear();
            txtNgay.Clear();
            txtMaBS.Clear();
            txtMaKhoa.Clear();
            txtChanDoan.Clear();
            txtDieuTri.Clear();
            txtKetLuan.Clear();

            if (_role == "Điều phối viên")
            {
                txtMaHSBA.ReadOnly = false;
                txtMaBN.ReadOnly = false;
                txtNgay.ReadOnly = false;
                txtMaBS.ReadOnly = false;
                txtMaKhoa.ReadOnly = false;
                txtMaHSBA.Focus();
            }

            lblStatus.Text = "Status: Nhập hồ sơ bệnh án mới.";
        }

        private void btnInsertHSBA_Click(object sender, EventArgs e)
        {
            if (_role != "Điều phối viên")
            {
                MessageBox.Show("Chỉ Điều phối viên được tạo mới HSBA.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaHSBA.Text) ||
                string.IsNullOrWhiteSpace(txtMaBN.Text) ||
                string.IsNullOrWhiteSpace(txtNgay.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã HSBA, Mã BN và Ngày.");
                return;
            }

            string sql = @"
        INSERT INTO QLYTE_06.HSBA (
            MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN
        )
        VALUES (
            :mahsba, :mabn, :ngay, :chandoan, :dieutri, :mabs, :makhoa, :ketluan
        )";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.BindByName = true;

                    DateTime ngay;
                    if (!DateTime.TryParse(txtNgay.Text, out ngay))
                    {
                        MessageBox.Show("Ngày không hợp lệ.");
                        return;
                    }

                    cmd.Parameters.Add(":mahsba", OracleDbType.Varchar2).Value = txtMaHSBA.Text.Trim();
                    cmd.Parameters.Add(":mabn", OracleDbType.Varchar2).Value = txtMaBN.Text.Trim();
                    cmd.Parameters.Add(":ngay", OracleDbType.Date).Value = ngay;

                    // Khi tạo mới, có thể để trống chẩn đoán/điều trị/kết luận
                    cmd.Parameters.Add(":chandoan", OracleDbType.NVarchar2).Value =
                        string.IsNullOrWhiteSpace(txtChanDoan.Text) ? DBNull.Value : (object)txtChanDoan.Text;

                    cmd.Parameters.Add(":dieutri", OracleDbType.NVarchar2).Value =
                        string.IsNullOrWhiteSpace(txtDieuTri.Text) ? DBNull.Value : (object)txtDieuTri.Text;

                    cmd.Parameters.Add(":mabs", OracleDbType.Varchar2).Value =
                        string.IsNullOrWhiteSpace(txtMaBS.Text) ? DBNull.Value : (object)txtMaBS.Text.Trim();

                    cmd.Parameters.Add(":makhoa", OracleDbType.Varchar2).Value =
                        string.IsNullOrWhiteSpace(txtMaKhoa.Text) ? DBNull.Value : (object)txtMaKhoa.Text.Trim();

                    cmd.Parameters.Add(":ketluan", OracleDbType.NVarchar2).Value =
                        string.IsNullOrWhiteSpace(txtKetLuan.Text) ? DBNull.Value : (object)txtKetLuan.Text;

                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rows} hồ sơ bệnh án được thêm.");
                    lblStatus.Text = $"Status: Đã thêm {rows} HSBA.";
                    LoadHSBA();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle khi thêm HSBA:\n" + ex.Message);
            }
        }
    }
}
