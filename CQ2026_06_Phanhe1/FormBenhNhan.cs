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
    public partial class FormBenhNhan : Form
    {
        private readonly string _connStr;
        private readonly string _role;
        public FormBenhNhan(string connStr, string role)
        {
            InitializeComponent();
            _connStr = connStr;
            _role = role;

            ConfigureByRole();
        }
        private void ConfigureByRole()
        {
            bool isDieuPhoiVien = _role == "Điều phối viên";

            txtMaBN.ReadOnly = !isDieuPhoiVien;
            txtTenBN.ReadOnly = !isDieuPhoiVien;
            txtPhai.ReadOnly = !isDieuPhoiVien;
            txtNgaySinh.ReadOnly = !isDieuPhoiVien;
            txtCCCD.ReadOnly = !isDieuPhoiVien;

            // DP được thêm bệnh nhân
            btnInsert.Visible = isDieuPhoiVien;

            // BN vẫn được sửa một số thông tin cá nhân
            btnUpdate.Visible = true;
        }
        private void FormBenhNhanh_Load(object sender, EventArgs e)
        {
            LoadBenhNhan();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadBenhNhan();
        }

        private void LoadBenhNhan()
        {
            string sql = @"
                SELECT MABN, TENBN, PHAI, NGAYSINH, CCCD, 
                       SONHA, TENDUONG, QUANHUYEN, TINHTP,
                       TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC, USERNAME
                FROM QLYTE_06.BENHNHAN
                ORDER BY MABN";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleDataAdapter da = new OracleDataAdapter (sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBenhNhan.DataSource = dt;

                    lblStatus.Text = $"Đã tải {dt.Rows.Count} dòng.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load bệnh nhân: " + ex.Message);
            }
        }

        private void dgvBenhNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvBenhNhan.Rows[e.RowIndex];

            txtMaBN.Text = row.Cells["MABN"].Value?.ToString();
            txtTenBN.Text = row.Cells["TENBN"].Value?.ToString();
            txtPhai.Text = row.Cells["PHAI"].Value?.ToString();
            txtNgaySinh.Text = row.Cells["NGAYSINH"].Value?.ToString();
            txtCCCD.Text = row.Cells["CCCD"].Value?.ToString();

            txtSoNha.Text = row.Cells["SONHA"].Value?.ToString();
            txtTenDuong.Text = row.Cells["TENDUONG"].Value?.ToString();
            txtQuanHuyen.Text = row.Cells["QUANHUYEN"].Value?.ToString();
            txtTinhTP.Text = row.Cells["TINHTP"].Value?.ToString();
            txtTienSuBenh.Text = row.Cells["TIENSUBENH"].Value?.ToString();
            txtTienSuBenhGD.Text = row.Cells["TIENSUBENHGD"].Value?.ToString();
            txtDiUngThuoc.Text = row.Cells["DIUNGTHUOC"].Value?.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBN.Text))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần cập nhật.");
                return;
            }

            try
            {
                if (_role == "Điều phối viên")
                {
                    UpdateBenhNhanFull();
                }
                else
                {
                    UpdateBenhNhanLimited();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi cập nhật bệnh nhân:\n" + ex.Message +
                    "\n\nGợi ý: Nếu ORA-01031 là không đủ quyền. Nếu 0 dòng cập nhật, có thể VPD đã lọc dòng.");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật bệnh nhân." + ex.Message);
            }

        }
        private void UpdateBenhNhanFull()
        {
            string sql = @"
                UPDATE QLYTE_06.BENHNHAN
                SET TENBN = :tenbn,
                    PHAI = :phai,
                    NGAYSINH = :ngaysinh,
                    CCCD = :cccd,
                    SONHA = :sonha,
                    TENDUONG = :tenduong,
                    QUANHUYEN = :quanhuyen,
                    TINHTP = :tinhtp,
                    TIENSUBENH = :tiensubenh,
                    TIENSUBENHGD = :tiensubenhgd,
                    DIUNGTHUOC = :diungthuoc
                WHERE MABN = :mabn";

            using (OracleConnection conn = new OracleConnection(_connStr))
            using (OracleCommand cmd = new OracleCommand(sql, conn))
            {
                conn.Open();
                cmd.BindByName = true;

                cmd.Parameters.Add(":tenbn", OracleDbType.NVarchar2).Value = txtTenBN.Text;
                cmd.Parameters.Add(":phai", OracleDbType.NVarchar2).Value = txtPhai.Text;

                DateTime ngaySinh;
                if (!DateTime.TryParse(txtNgaySinh.Text, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ.");
                    return;
                }

                cmd.Parameters.Add(":ngaysinh", OracleDbType.Date).Value = ngaySinh;
                cmd.Parameters.Add(":cccd", OracleDbType.Varchar2).Value = txtCCCD.Text;
                cmd.Parameters.Add(":sonha", OracleDbType.NVarchar2).Value = txtSoNha.Text;
                cmd.Parameters.Add(":tenduong", OracleDbType.NVarchar2).Value = txtTenDuong.Text;
                cmd.Parameters.Add(":quanhuyen", OracleDbType.NVarchar2).Value = txtQuanHuyen.Text;
                cmd.Parameters.Add(":tinhtp", OracleDbType.NVarchar2).Value = txtTinhTP.Text;
                cmd.Parameters.Add(":tiensubenh", OracleDbType.NVarchar2).Value = txtTienSuBenh.Text;
                cmd.Parameters.Add(":tiensubenhgd", OracleDbType.NVarchar2).Value = txtTienSuBenhGD.Text;
                cmd.Parameters.Add(":diungthuoc", OracleDbType.NVarchar2).Value = txtDiUngThuoc.Text;
                cmd.Parameters.Add(":mabn", OracleDbType.Varchar2).Value = txtMaBN.Text.Trim();

                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show($"{rows} dòng được cập nhật.");
                LoadBenhNhan();
            }
        }
        private void UpdateBenhNhanLimited()
        {
            if (string.IsNullOrEmpty(txtMaBN.Text))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần cập nhật.");
                return;
            }

            string sql = @"
                UPDATE QLYTE_06.BENHNHAN
                SET SONHA = :sonha,
                    TENDUONG = :tenduong,
                    QUANHUYEN = :quanhuyen,
                    TINHTP = :tinhtp,
                    TIENSUBENH = :tiensubenh,
                    TIENSUBENHGD = :tiensubenhgd,
                    DIUNGTHUOC = :diungthuoc
                WHERE MABN = :mabn";
            using (OracleConnection conn = new OracleConnection(_connStr))
            using (OracleCommand cmd = new OracleCommand(sql, conn))
            {
                conn.Open();

                cmd.BindByName = true;


                cmd.Parameters.Add(":sonha", OracleDbType.NVarchar2).Value = txtSoNha.Text;
                cmd.Parameters.Add(":tenduong", OracleDbType.NVarchar2).Value = txtTenDuong.Text;
                cmd.Parameters.Add(":quanhuyen", OracleDbType.NVarchar2).Value = txtQuanHuyen.Text;
                cmd.Parameters.Add(":tinhtp", OracleDbType.NVarchar2).Value = txtTinhTP.Text;
                cmd.Parameters.Add(":tiensubenh", OracleDbType.NVarchar2).Value = txtTienSuBenh.Text;
                cmd.Parameters.Add(":tiensubenhgd", OracleDbType.NVarchar2).Value = txtTienSuBenhGD.Text;
                cmd.Parameters.Add(":diungthuoc", OracleDbType.NVarchar2).Value = txtDiUngThuoc.Text;
                cmd.Parameters.Add(":mabn", OracleDbType.Varchar2).Value = txtMaBN.Text.Trim();

                int rows = cmd.ExecuteNonQuery();

                MessageBox.Show($"{rows} dòng được cập nhật.");

                LoadBenhNhan();
            }

        }
        private void grpUpdate_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadBenhNhan();
        }
        private void ClearInput()
        {
            txtMaBN.Clear();
            txtSoNha.Clear();
            txtTenDuong.Clear();
            txtQuanHuyen.Clear();
            txtTinhTP.Clear();
            txtTienSuBenh.Clear();
            txtTienSuBenhGD.Clear();
            txtDiUngThuoc.Clear();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (_role != "Điều phối viên")
            {
                MessageBox.Show("Chỉ Điều phối viên được thêm bệnh nhân.");
                return;
            }

            string sql = @"
        INSERT INTO QLYTE_06.BENHNHAN (
            MABN, TENBN, PHAI, NGAYSINH, CCCD,
            SONHA, TENDUONG, QUANHUYEN, TINHTP,
            TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC, USERNAME
        )
        VALUES (
            :mabn, :tenbn, :phai, :ngaysinh, :cccd,
            :sonha, :tenduong, :quanhuyen, :tinhtp,
            :tiensubenh, :tiensubenhgd, :diungthuoc, :username
        )";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.BindByName = true;

                    DateTime ngaySinh;
                    if (!DateTime.TryParse(txtNgaySinh.Text, out ngaySinh))
                    {
                        MessageBox.Show("Ngày sinh không hợp lệ.");
                        return;
                    }

                    string maBN = txtMaBN.Text.Trim();

                    cmd.Parameters.Add(":mabn", OracleDbType.Varchar2).Value = maBN;
                    cmd.Parameters.Add(":tenbn", OracleDbType.NVarchar2).Value = txtTenBN.Text;
                    cmd.Parameters.Add(":phai", OracleDbType.NVarchar2).Value = txtPhai.Text;
                    cmd.Parameters.Add(":ngaysinh", OracleDbType.Date).Value = ngaySinh;
                    cmd.Parameters.Add(":cccd", OracleDbType.Varchar2).Value = txtCCCD.Text;
                    cmd.Parameters.Add(":sonha", OracleDbType.NVarchar2).Value = txtSoNha.Text;
                    cmd.Parameters.Add(":tenduong", OracleDbType.NVarchar2).Value = txtTenDuong.Text;
                    cmd.Parameters.Add(":quanhuyen", OracleDbType.NVarchar2).Value = txtQuanHuyen.Text;
                    cmd.Parameters.Add(":tinhtp", OracleDbType.NVarchar2).Value = txtTinhTP.Text;
                    cmd.Parameters.Add(":tiensubenh", OracleDbType.NVarchar2).Value = txtTienSuBenh.Text;
                    cmd.Parameters.Add(":tiensubenhgd", OracleDbType.NVarchar2).Value = txtTienSuBenhGD.Text;
                    cmd.Parameters.Add(":diungthuoc", OracleDbType.NVarchar2).Value = txtDiUngThuoc.Text;

                    // Tùy dữ liệu của bạn, username có thể đặt bằng MABN hoặc để nhập riêng.
                    cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = maBN;

                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rows} bệnh nhân được thêm.");
                    LoadBenhNhan();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle khi thêm bệnh nhân:\n" + ex.Message);
            }
        }
    }
}
