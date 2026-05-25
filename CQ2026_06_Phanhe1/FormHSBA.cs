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
        public FormHSBA(string connStr)
        {
            InitializeComponent();
            _connStr = connStr;
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
            if (string.IsNullOrEmpty(txtMaHSBA.Text))
            {
                MessageBox.Show("Vui lòng chọn hồ sơ bệnh án cần cập nhật.");
                return;
            }

            string sql = @"
                UPDATE QLYTE_06.HSBA
                SET CHANDOAN = :chandoan,
                    DIEUTRI = :dieutri,
                    KETLUAN = :ketluan
                WHERE MAHSBA = :mahsba";
            try
            {
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
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi cập nhật HSBA:\n" + ex.Message +
                    "\n\nNếu ORA-01031: user không có quyền cập nhật.\n" +
                    "Nếu cập nhật 0 dòng: VPD có thể đã lọc hồ sơ này.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật HSBA:\n" + ex.Message);
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
    }
}
