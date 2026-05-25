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
        public FormBenhNhan(string connStr)
        {
            InitializeComponent();
            _connStr = connStr;
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
            if(string .IsNullOrEmpty(txtMaBN.Text))
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
            try
            {
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
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi cập nhật bệnh nhân:\n" + ex.Message +
                    "\n\nGợi ý: Nếu ORA-01031 là không đủ quyền. Nếu 0 dòng cập nhật, có thể VPD đã lọc dòng.");
            }

            catch ( Exception ex )
            {
                MessageBox.Show("Lỗi cập nhật bệnh nhân." + ex.Message );
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
    }
}
