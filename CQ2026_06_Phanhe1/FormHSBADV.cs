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
using static System.Net.Mime.MediaTypeNames;

namespace CQ2026_06_Phanhe1
{
    public partial class FormHSBADV : Form
    {
        private readonly string _connStr;
        private readonly string _role;
        public FormHSBADV(string connStr, string role)
        {
            InitializeComponent();
            _connStr = connStr;
            _role = role;

            ConfigureByRole();
        }
        private void ConfigureByRole()
        {
            bool isBacSi = _role == "Bác sĩ/Y sĩ";
            bool isDieuPhoiVien = _role == "Điều phối viên";
            bool isKyThuatVien = _role == "Kỹ thuật viên";

            // Mặc định khóa hết các ô quan trọng
            txtMaHSBA.ReadOnly = true;
            txtLoaiDV.ReadOnly = true;
            txtNgayDV.ReadOnly = true;
            txtMaKT.ReadOnly = true;
            txtKetQua.ReadOnly = true;

            // Mặc định ẩn chức năng thêm/xóa
            btnInsertDV.Visible = false;
            btnDeleteDV.Visible = false;

            if (isBacSi)
            {
                // Bác sĩ được thêm/xóa dịch vụ trên HSBA mình phụ trách
                btnInsertDV.Visible = true;
                btnDeleteDV.Visible = true;

                // Khi bấm Nhập mới thì mở các ô này
                txtMaHSBA.ReadOnly = false;
                txtLoaiDV.ReadOnly = false;
                txtNgayDV.ReadOnly = false;

                // Bác sĩ không cập nhật MAKT/KETQUA
                txtMaKT.ReadOnly = true;
                txtKetQua.ReadOnly = true;

                btnUpdate.Visible = false;
            }
            else if (isDieuPhoiVien)
            {
                // Điều phối viên chỉ phân công kỹ thuật viên
                txtMaKT.ReadOnly = false;
                txtKetQua.ReadOnly = true;

                btnUpdate.Visible = true;
                btnUpdate.Text = "Phân công KTV";
            }
            else if (isKyThuatVien)
            {
                // KTV chỉ cập nhật kết quả
                txtMaKT.ReadOnly = true;
                txtKetQua.ReadOnly = false;

                btnUpdate.Visible = true;
                btnUpdate.Text = "Cập nhật kết quả";
            }
        }
        private void FormHSBADV_Load(object sender, EventArgs e)
        {
            LoadHSBADV();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadHSBADV();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadHSBADV();
        }
        private void LoadHSBADV()
        {
            string sql = @"
                SELECT MAHSBA,
                       LOAIDV,
                       NGAYDV, 
                       MAKT,
                       KETQUA
                FROM QLYTE_06.HSBA_DV
                ORDER BY MAHSBA, NGAYDV";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleDataAdapter da = new OracleDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvHSBADV.DataSource = dt;
                    lblStatus.Text = $"Status: Đã tải {dt.Rows.Count} dòng.";

                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi tải HSBA_DV:\n" + ex.Message +
                    "\n\nSQL:\n" + sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải HSBA_DV:\n" + ex.Message);
            }
        }

        private void dgvHSBADV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHSBADV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvHSBADV.Rows[e.RowIndex];

            txtMaHSBA.Text = row.Cells["MAHSBA"].Value?.ToString();
            txtLoaiDV.Text = row.Cells["LOAIDV"].Value?.ToString();
            txtNgayDV.Text = row.Cells["NGAYDV"].Value?.ToString();
            txtMaKT.Text = row.Cells["MAKT"].Value?.ToString();
            txtKetQua.Text = row.Cells["KETQUA"].Value?.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHSBA.Text) ||
                string.IsNullOrWhiteSpace(txtLoaiDV.Text) ||
                string.IsNullOrWhiteSpace(txtNgayDV.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng dịch vụ kỹ thuật cần cập nhật.");
                return;
            }

            try
            {
                if (_role == "Điều phối viên")
                {
                    UpdatePhanCongKTV();
                }
                else if (_role == "Kỹ thuật viên")
                {
                    UpdateKetQuaDV();
                }
                else
                {
                    MessageBox.Show("User hiện tại không được cập nhật dịch vụ kỹ thuật.");
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi cập nhật HSBA_DV:\n" + ex.Message +
                    "\n\nNếu ORA-01031: user không có quyền cập nhật.\n" +
                    "Nếu cập nhật 0 dòng: VPD có thể đã lọc dòng.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật HSBA_DV:\n" + ex.Message);
            }
        }

        private void UpdateKetQuaDV()
        {
            string sql = @"
                UPDATE QLYTE_06.HSBA_DV
                SET KETQUA = :ketqua
                WHERE MAHSBA = :mahsba
                  AND LOAIDV = :loaidv
                  AND NGAYDV = :ngaydv";

            using (OracleConnection conn = new OracleConnection(_connStr))
            using (OracleCommand cmd = new OracleCommand(sql, conn))
            {
                conn.Open();
                cmd.BindByName = true;

                DateTime ngayDV;
                if (!DateTime.TryParse(txtNgayDV.Text, out ngayDV))
                {
                    MessageBox.Show("Ngày DV không hợp lệ.");
                    return;
                }

                cmd.Parameters.Add(":ketqua", OracleDbType.NVarchar2).Value = txtKetQua.Text;
                cmd.Parameters.Add(":mahsba", OracleDbType.Varchar2).Value = txtMaHSBA.Text.Trim();
                cmd.Parameters.Add(":loaidv", OracleDbType.NVarchar2).Value = txtLoaiDV.Text.Trim();
                cmd.Parameters.Add(":ngaydv", OracleDbType.Date).Value = ngayDV;

                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show($"{rows} dòng được cập nhật.");
                lblStatus.Text = $"Status: Đã cập nhật kết quả {rows} dòng.";
                LoadHSBADV();
            }
        }
        private void UpdatePhanCongKTV()
        {
            string sql = @"
                UPDATE QLYTE_06.HSBA_DV
                SET MAKT = :makt
                WHERE MAHSBA = :mahsba
                  AND LOAIDV = :loaidv
                  AND NGAYDV = :ngaydv";

            using (OracleConnection conn = new OracleConnection(_connStr))
            using (OracleCommand cmd = new OracleCommand(sql, conn))
            {
                conn.Open();
                cmd.BindByName = true;

                DateTime ngayDV;
                if (!DateTime.TryParse(txtNgayDV.Text, out ngayDV))
                {
                    MessageBox.Show("Ngày DV không hợp lệ.");
                    return;
                }

                cmd.Parameters.Add(":makt", OracleDbType.Varchar2).Value = txtMaKT.Text.Trim();
                cmd.Parameters.Add(":mahsba", OracleDbType.Varchar2).Value = txtMaHSBA.Text.Trim();
                cmd.Parameters.Add(":loaidv", OracleDbType.NVarchar2).Value = txtLoaiDV.Text.Trim();
                cmd.Parameters.Add(":ngaydv", OracleDbType.Date).Value = ngayDV;

                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show($"{rows} dịch vụ được phân công kỹ thuật viên.");
                lblStatus.Text = $"Status: Đã phân công KTV cho {rows} dòng.";
                LoadHSBADV();
            }
        }
        private void InsertHSBADV()
        {
            if (_role != "Bác sĩ/Y sĩ")
            {
                MessageBox.Show("Chỉ Bác sĩ/Y sĩ được thêm dịch vụ kỹ thuật.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaHSBA.Text) ||
                string.IsNullOrWhiteSpace(txtLoaiDV.Text) ||
                string.IsNullOrWhiteSpace(txtNgayDV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã HSBA, Loại DV và Ngày DV.");
                return;
            }

            string sql = @"
                INSERT INTO QLYTE_06.HSBA_DV (
                    MAHSBA, LOAIDV, NGAYDV, MAKT, KETQUA
                )
                VALUES (
                    :mahsba, :loaidv, :ngaydv, NULL, NULL
                )";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.BindByName = true;

                    DateTime ngayDV;
                    if (!DateTime.TryParse(txtNgayDV.Text, out ngayDV))
                    {
                        MessageBox.Show("Ngày DV không hợp lệ.");
                        return;
                    }

                    cmd.Parameters.Add(":mahsba", OracleDbType.Varchar2).Value = txtMaHSBA.Text.Trim();
                    cmd.Parameters.Add(":loaidv", OracleDbType.NVarchar2).Value = txtLoaiDV.Text.Trim();
                    cmd.Parameters.Add(":ngaydv", OracleDbType.Date).Value = ngayDV;

                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rows} dịch vụ được thêm.");
                    lblStatus.Text = $"Status: Đã thêm {rows} dịch vụ.";
                    LoadHSBADV();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi thêm HSBA_DV:\n" + ex.Message +
                    "\n\nGợi ý:\n" +
                    "- ORA-01031: thiếu quyền INSERT.\n" +
                    "- ORA-28115/ORA-28113: VPD chặn hoặc predicate sai.\n" +
                    "- ORA-00001: trùng khóa chính, hãy đổi Loại DV hoặc Ngày DV.");
            }
        }
        private void DeleteHSBADV()
        {
            if (_role != "Bác sĩ/Y sĩ")
            {
                MessageBox.Show("Chỉ Bác sĩ/Y sĩ được xóa dịch vụ kỹ thuật.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaHSBA.Text) ||
                string.IsNullOrWhiteSpace(txtLoaiDV.Text) ||
                string.IsNullOrWhiteSpace(txtNgayDV.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ kỹ thuật cần xóa.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa dịch vụ kỹ thuật này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            string sql = @"
        DELETE FROM QLYTE_06.HSBA_DV
        WHERE MAHSBA = :mahsba
          AND LOAIDV = :loaidv
          AND NGAYDV = :ngaydv";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.BindByName = true;

                    DateTime ngayDV;
                    if (!DateTime.TryParse(txtNgayDV.Text, out ngayDV))
                    {
                        MessageBox.Show("Ngày DV không hợp lệ.");
                        return;
                    }

                    cmd.Parameters.Add(":mahsba", OracleDbType.Varchar2).Value = txtMaHSBA.Text.Trim();
                    cmd.Parameters.Add(":loaidv", OracleDbType.NVarchar2).Value = txtLoaiDV.Text.Trim();
                    cmd.Parameters.Add(":ngaydv", OracleDbType.Date).Value = ngayDV;

                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rows} dịch vụ được xóa.");
                    lblStatus.Text = $"Status: Đã xóa {rows} dịch vụ.";
                    LoadHSBADV();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi xóa HSBA_DV:\n" + ex.Message +
                    "\n\nGợi ý:\n" +
                    "- ORA-01031: thiếu quyền DELETE.\n" +
                    "- 0 dòng: VPD chặn hoặc dòng không thuộc HSBA của bác sĩ.");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearInput()
        {
            txtKetQua.Clear();
            txtMaHSBA.Clear();
            txtLoaiDV.Clear();
            txtNgayDV.Clear();
            txtMaKT.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaHSBA.Clear();
            txtLoaiDV.Clear();
            txtNgayDV.Clear();
            txtMaKT.Clear();
            txtKetQua.Clear();

            if (_role == "Bác sĩ/Y sĩ")
            {
                txtMaHSBA.ReadOnly = false;
                txtLoaiDV.ReadOnly = false;
                txtNgayDV.ReadOnly = false;

                txtMaHSBA.Focus();
                lblStatus.Text = "Status: Nhập dịch vụ mới cho hồ sơ bệnh án.";
            }
        }

        private void btnInsertDV_Click(object sender, EventArgs e)
        {
            InsertHSBADV();
        }

        private void btnDeleteDV_Click(object sender, EventArgs e)
        {
            DeleteHSBADV();
        }
    }
}
