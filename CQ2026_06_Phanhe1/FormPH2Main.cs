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
    public partial class FormPH2Main : Form
    {
        private readonly string _connStr;
        private readonly string _currentUser;
        private readonly string _role;
        public FormPH2Main(string connStr, string currentUser, string role)
        {
            InitializeComponent();

            _connStr = connStr;
            _currentUser = currentUser;
            _role = role;

            lblWelcome.Text = $"Xin chào, {_currentUser}";
            lblCurrentUser.Text = $"Oracel user: {_currentUser}";
            lblCurrentRole.Text = $"Vai trò: {_role}";
            lblStatus.Text = "Trạng thái: Đăng nhập thành công bằng Oracle user thật.";

            ConfigureMenuByRole();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormPH2Main_Load(object sender, EventArgs e)
        {

        }
       

        private void ConfigureMenuByRole()
        {
            btnBenhNhan.Visible = false;
            btnHSBA.Visible = false;
            btnHSBADV.Visible = false;
            btnDonThuoc.Visible = false;
            btnThongBao.Visible = false;
            btnAudit.Visible = false;

            if (_role == "Điều phối viên")
            {
                btnBenhNhan.Visible = true;
                btnHSBA.Visible = true;
                btnHSBADV.Visible = true;
            }
            else if (_role == "Bác sĩ/Y sĩ")
            {
                btnBenhNhan.Visible = true;
                btnHSBA.Visible = true;
                btnHSBADV.Visible = true;
                btnDonThuoc.Visible = true;
            }
            else if (_role == "Kỹ thuật viên")
            {
                btnHSBADV.Visible = true;
            }
            else if (_role == "Bệnh nhân")
            {
                btnBenhNhan.Visible = true;
            }
            else if (_role == "Người dùng OLS")
            {
                btnThongBao.Visible = true;
            }
            else if (_role == "Quản trị dữ liệu y tế")
            {
                btnBenhNhan.Visible = true;
                btnHSBA.Visible = true;
                btnHSBADV.Visible = true;
                btnDonThuoc.Visible = true;
                btnThongBao.Visible = true;
                btnAudit.Visible = true;
            }
            else
            {
                MessageBox.Show("Không xác định được vai trò. Chỉ hiển thị chức năng thông báo nếu có quyền.");
                btnThongBao.Visible = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm.ConnectionString = "";

            LoginForm login = new LoginForm();
            login.Show();

            this.Close();
        }

        private void btnBenhNhan_Click(object sender, EventArgs e)
        {
            FormBenhNhan frm = new FormBenhNhan(_connStr);
            frm.ShowDialog();
        }

        private void btnHSBA_Click(object sender, EventArgs e)
        {
        
            FormHSBA frm = new FormHSBA(_connStr);
            frm.ShowDialog();
        }

        private void btnHSBADV_Click(object sender, EventArgs e)
        {
            FormHSBADV frm = new FormHSBADV(_connStr);
            frm.ShowDialog();
        }

        private void btnDonThuoc_Click(object sender, EventArgs e)
        {
            FormDonThuoc frm = new FormDonThuoc(_connStr);
            frm.ShowDialog();
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            FormThongBao frm = new FormThongBao(_connStr);
            frm.ShowDialog();
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            FormAuditLog frm = new FormAuditLog(_connStr);
            frm.ShowDialog();
        }
    }
}
