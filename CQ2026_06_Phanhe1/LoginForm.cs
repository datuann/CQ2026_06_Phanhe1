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
    public partial class LoginForm : Form
    {
        public static string ConnectionString = "";
        public LoginForm()
        {
            InitializeComponent();
            cboSubsystem.Items.Clear();
            cboSubsystem.Items.Add("Phân hệ 1 - Quản trị Oracle");
            cboSubsystem.Items.Add("Phân hệ 2 - Quản lý y tế");
            cboSubsystem.SelectedIndex = 0;
        }

        private void txtDatasource_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string dataSource = txtDataSource.Text.Trim();

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(dataSource))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username, Password và Data Source.");
                return;
            }

            if (username.ToUpper() == "SYS")
            {
                ConnectionString =
                    $"User Id={username};Password={password};Data Source={dataSource};DBA Privilege=SYSDBA;";
            }
            else
            {
                ConnectionString =
                    $"User Id={username};Password={password};Data Source={dataSource};";
            }

            try
            {
                string currentUser = "";
                string role = "";

                using (OracleConnection conn = new OracleConnection(ConnectionString))
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(
                        "SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') FROM DUAL", conn))
                    {
                        currentUser = Convert.ToString(cmd.ExecuteScalar());
                    }   
                }
                lblStatus.Text = "Kết nối thành công";

                string selectedSubsystem = cboSubsystem.SelectedItem?.ToString();

                if(selectedSubsystem == "Phân hệ 1 - Quản trị Oracle")
                {
                    MessageBox.Show("Đăng nhập Phân hệ 1 thành công!");
                    MainForm_v2 frm = new MainForm_v2();
                    frm.Show();
                    this.Hide(); // Ẩn Login
                    return;
                }
                if(selectedSubsystem == "Phân hệ 2 - Quản lý y tế")
                {
                    role = GetPH2Role();

                    MessageBox.Show($"Đăng nhập Phân hệ 2 thành công!\nUser: {currentUser}\nVai trò: {role}");

                    FormPH2Main frm = new FormPH2Main(ConnectionString, currentUser, role);
                    frm.Show();
                    this.Hide();
                    return;
                }

                MessageBox.Show("Vui lòng chọn Phân hệ đăng nhập");           
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Kết nối thất bại";
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }
        private string GetPH2Role()
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                conn.Open();

                string sqlCurrentUser =
                    "SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') FROM DUAL";

                string user = "";

                using (OracleCommand cmd = new OracleCommand(sqlCurrentUser, conn))
                {
                    user = Convert.ToString(cmd.ExecuteScalar());
                }

                if (string.IsNullOrEmpty(user))
                    return "Không xác định";

                user = user.ToUpper();
                // SYS, SYSTEM
                if (user == "SYS" || user == "SYSTEM")
                    return "Quản trị dữ liệu y tế";

                // User OLS: U1, U2, ..., U8
                if (user.StartsWith("U"))
                    return "Người dùng OLS";

                // Bệnh nhân: BN001, BN002, ...
                if (user.StartsWith("BN"))
                {
                    string sqlBenhNhan =
                        "SELECT 'BENH_NHAN' " +
                        "FROM QLYTE_06.BENHNHAN " +
                        "WHERE USERNAME = SYS_CONTEXT('USERENV', 'SESSION_USER')";

                    using (OracleCommand cmd = new OracleCommand(sqlBenhNhan, conn))
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                            return "Bệnh nhân";
                    }

                    return "Bệnh nhân";
                }

                // Nhân viên: BS001, KT001, DP001, ...
                string sqlNhanVien =
                    "SELECT VAITRO " +
                    "FROM QLYTE_06.NHANVIEN " +
                    "WHERE USERNAME = SYS_CONTEXT('USERENV', 'SESSION_USER')";

                using (OracleCommand cmd = new OracleCommand(sqlNhanVien, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        return result.ToString();
                }

                if (user == "QLYTE_06")
                    return "Quản trị dữ liệu y tế";

                return "Không xác định";
            }
        }
    }
}
