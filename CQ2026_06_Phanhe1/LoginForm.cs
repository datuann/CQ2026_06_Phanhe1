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

            ConnectionString = $"User Id={username};Password={password};Data Source={dataSource};";

            try
            {
                using (OracleConnection conn = new OracleConnection(ConnectionString))
                {
                    conn.Open();
                    lblStatus.Text = "Kết nối thành công";
                    MessageBox.Show("Đăng nhập Oracle thành công!");
                    MainForm frm = new MainForm();
                    frm.Show();
                    this.Hide(); // Ẩn Login
                }
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
        
    }
}
