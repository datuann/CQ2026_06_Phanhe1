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
    public partial class FormNhanVienCaNhan : Form
    {
        private readonly string _connStr;
        public FormNhanVienCaNhan(string connStr)
        {
            InitializeComponent();
            _connStr = connStr;
        }
        private void FormNhanVienCaNhan_Load(object sender, EventArgs e)
        {
            LoadNhanVienCaNhan();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadNhanVienCaNhan();
        }
        private void LoadNhanVienCaNhan()
        {
            string sql = @"
                SELECT MANV,
                       HOTEN,
                       PHAI,
                       NGAYSINH,
                       CMND,
                       QUEQUAN,
                       SODT,
                       VAITRO,
                       CHUYENKHOA,
                       USERNAME
                FROM QLYTE_06.NHANVIEN";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtMaNV.Text = reader["MANV"]?.ToString();
                            txtHoTen.Text = reader["HOTEN"]?.ToString();
                            txtPhai.Text = reader["PHAI"]?.ToString();
                            txtNgaySinh.Text = reader["NGAYSINH"]?.ToString();
                            txtCMND.Text = reader["CMND"]?.ToString();
                            txtQueQuan.Text = reader["QUEQUAN"]?.ToString();
                            txtSDT.Text = reader["SODT"]?.ToString();
                            txtVaiTro.Text = reader["VAITRO"]?.ToString();
                            txtChuyenKhoa.Text = reader["CHUYENKHOA"]?.ToString();

                            lblStatus.Text = "Status: Đã tải thông tin cá nhân.";
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin nhân viên cho user hiện tại.");
                            lblStatus.Text = "Status: Không tìm thấy dữ liệu.";
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi tải thông tin nhân viên:\n" + ex.Message +
                    "\n\nSQL:\n" + sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin nhân viên:\n" + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = @"
                UPDATE QLYTE_06.NHANVIEN
                SET QUEQUAN = :quequan,
                    SODT = :sodt
                WHERE USERNAME = SYS_CONTEXT('USERENV', 'SESSION_USER')";
            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleCommand cmd = new OracleCommand (sql, conn))
                {
                    conn.Open();
                    cmd.BindByName = true;

                    cmd.Parameters.Add(":quequan", OracleDbType.NVarchar2).Value = txtQueQuan.Text;
                    cmd.Parameters.Add(":sodt", OracleDbType.Varchar2).Value = txtSDT.Text;

                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rows} dòng được cập nhật.");
                    lblStatus.Text = $"Status: Đã cập nhật {rows} dòng.";

                    LoadNhanVienCaNhan();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi cập nhật thông tin nhân viên:\n" + ex.Message +
                    "\n\nNếu ORA-01031: user không có quyền cập nhật hoặc đang sửa cột không được phép.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin nhân viên:\n" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
