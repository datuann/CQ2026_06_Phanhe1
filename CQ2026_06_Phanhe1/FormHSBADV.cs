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
        public FormHSBADV(string connStr)
        {
            InitializeComponent();
            _connStr = connStr;
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
            if(string.IsNullOrWhiteSpace(txtMaHSBA.Text) || 
                string.IsNullOrWhiteSpace(txtLoaiDV.Text) ||
                string.IsNullOrWhiteSpace(txtNgayDV.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ kỹ thuật cần cập nhật.");
                return;
            }

            string sql = @"
                UPDATE QLYTE_06.HSBA_DV
                SET KETQUA = :ketqua
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


                    cmd.Parameters.Add(":ketqua", OracleDbType.NVarchar2).Value = txtKetQua.Text;
                    cmd.Parameters.Add(":mahsba", OracleDbType.Varchar2).Value = txtMaHSBA.Text.Trim(); 
                    cmd.Parameters.Add(":loaidv", OracleDbType.NVarchar2).Value = txtLoaiDV.Text.Trim();

                    DateTime ngayDV;
                    if(!DateTime.TryParse(txtNgayDV.Text, out ngayDV))
                    {
                        MessageBox.Show("Ngày dịch vụ không hợp lệ.");
                        return;
                    }
                    
                    cmd.Parameters.Add(":ngaydv", OracleDbType.Date).Value = ngayDV;

                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rows} dòng được cập nhật.");
                    lblStatus.Text = $"Status: Đã cập nhật {rows} dòng.";

                    LoadHSBADV();
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
    }
}
