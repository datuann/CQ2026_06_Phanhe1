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
    public partial class FormDonThuoc : Form
    {
        private readonly string _connStr;
        public FormDonThuoc(string connStr)
        {
            InitializeComponent();
            _connStr = connStr;
        }
        private void FormDonThuoc_Load(object sender, EventArgs e)
        {
            LoadDonThuoc();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDonThuoc();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadDonThuoc();
        }
        private void LoadDonThuoc()
        {
            string sql = @"
                SELECT MAHSBA,
                       NGAYDT,
                       TENTHUOC,
                       LIEUDUNG
                FROM QLYTE_06.DONTHUOC
                ORDER BY MAHSBA, NGAYDT, TENTHUOC";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleDataAdapter da = new OracleDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDonThuoc.DataSource = dt;
                    lblStatus.Text = $"Status: Đã tải {dt.Rows.Count} dòng.";
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi tải DONTHUOC:\n" + ex.Message +
                    "\n\nSQL:\n" + sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải DONTHUOC:\n" + ex.Message);
            }
        }

        private void dgvDonThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDonThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvDonThuoc.Rows[e.RowIndex];

            txtMaHSBA.Text = row.Cells["MAHSBA"].Value?.ToString();
            txtNgayDT.Text = row.Cells["NGAYDT"].Value?.ToString();
            txtTenThuoc.Text = row.Cells["TENTHUOC"].Value?.ToString();
            txtLieuDung.Text = row.Cells["LIEUDUNG"].Value?.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtMaHSBA.Text) ||
                string.IsNullOrWhiteSpace(txtNgayDT.Text) ||
                string.IsNullOrWhiteSpace(txtTenThuoc.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn thuốc cần cập nhật.");
                return;
            }

            string sql = @"
                UPDATE QLYTE_06.DONTHUOC
                SET LIEUDUNG = :lieudung
                WHERE MAHSBA = :mahsba
                  AND NGAYDT = :ngaydt
                  AND TENTHUOC = :tenthuoc";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.BindByName = true;

                    cmd.Parameters.Add(":lieudung", OracleDbType.NVarchar2).Value = txtLieuDung.Text;
                    cmd.Parameters.Add(":mahsba", OracleDbType.NVarchar2).Value = txtMaHSBA.Text.Trim();

                    DateTime ngayDT;
                    if(!DateTime.TryParse(txtNgayDT.Text, out ngayDT))
                    {
                        MessageBox.Show("Ngày ĐT không hợp lệ.");
                        return;
                    }

                    cmd.Parameters.Add(":ngaydt", OracleDbType.Date).Value = ngayDT;
                    cmd.Parameters.Add(":tenthuoc", OracleDbType.NVarchar2).Value = txtTenThuoc.Text.Trim();

                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rows} dòng được cập nhật.");
                    lblStatus.Text = $"Status: Đã cập nhật {rows} dòng.";

                    LoadDonThuoc();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi cập nhật DONTHUOC:\n" + ex.Message +
                    "\n\nNếu ORA-01031: user không có quyền cập nhật.\n" +
                    "Nếu cập nhật 0 dòng: VPD có thể đã lọc dòng.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật DONTHUOC:\n" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearInput()
        {
            txtLieuDung.Clear();
            txtMaHSBA.Clear();
            txtTenThuoc.Clear();
            txtNgayDT.Clear();
        }
    }
}
