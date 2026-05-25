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
    public partial class FormThongBao : Form
    {
        private readonly string _connStr;
        public FormThongBao(string connStr)
        {
            InitializeComponent();
            _connStr = connStr;
        }
        private void FormThongBao_Load(object sender, EventArgs e)
        {
            LoadThongBao();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadThongBao();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadThongBao();
        }
        private void LoadThongBao()
        {
            string sql = @"
                SELECT MATB,
                       NOIDUNG,
                       NGAYGIO,
                       DIADIEM
                FROM QLYTE_06.THONGBAO
                ORDER BY MATB";
            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleDataAdapter da = new OracleDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvThongBao.DataSource = dt;
                    lblStatus.Text = $"Status: Đã tải {dt.Rows.Count} thông báo.";

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show(
                            "Không có thông báo phù hợp với nhãn bảo mật của user hiện tại.",
                            "OLS",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi tải THONGBAO:\n" + ex.Message +
                    "\n\nSQL:\n" + sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải THONGBAO:\n" + ex.Message);
            }
        }

        private void dgvThongBao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvThongBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvThongBao.Rows[e.RowIndex];

            txtMaTB.Text = row.Cells["MATB"].Value?.ToString();
            txtNoiDung.Text = row.Cells["NOIDUNG"].Value?.ToString();
            txtNgayGio.Text = row.Cells["NGAYGIO"].Value?.ToString();
            txtDiaDiem.Text = row.Cells["DIADIEM"].Value?.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        private void ClearInput()
        {
            txtMaTB.Clear();
            txtNoiDung.Clear();
            txtDiaDiem.Clear();
            txtNgayGio.Clear();
        }
    }
}
