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
        private readonly string _role;
        private string _oldTenThuoc = "";
        public FormDonThuoc(string connStr, string role)
        {
            InitializeComponent();
            _connStr = connStr;
            _role = role;

            ConfigureByRole();
        }
        private void ConfigureByRole()
        {
            bool isBacSi = _role == "Bác sĩ/Y sĩ";

            btnInsertDonThuoc.Visible = isBacSi;
            btnDeleteDonThuoc.Visible = isBacSi;
            btnUpdate.Visible = isBacSi;

            txtMaHSBA.ReadOnly = true;
            txtNgayDT.ReadOnly = true;

            txtTenThuoc.ReadOnly = !isBacSi;
            txtLieuDung.ReadOnly = !isBacSi;

            if (isBacSi)
            {
                btnUpdate.Text = "Cập nhật đơn thuốc";
            }
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

            _oldTenThuoc = txtTenThuoc.Text;

            // Khi chọn dòng có sẵn, không cho sửa khóa MAHSBA/NGAYDT
            txtMaHSBA.ReadOnly = true;
            txtNgayDT.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(_role != "Bác sĩ/Y sĩ")
            {
                MessageBox.Show("Chỉ Bác sĩ/Y sĩ được cập nhật đơn thuốc.");
                return;
            }
            if(string.IsNullOrWhiteSpace(txtMaHSBA.Text) ||
                string.IsNullOrWhiteSpace(txtNgayDT.Text) ||
                string.IsNullOrWhiteSpace(txtTenThuoc.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn thuốc cần cập nhật.");
                return;
            }

            string sql = @"
                UPDATE QLYTE_06.DONTHUOC
                SET TENTHUOC = :tenthuoc_new,
                    LIEUDUNG = :lieudung
                WHERE MAHSBA = :mahsba
                  AND NGAYDT = :ngaydt
                  AND TENTHUOC = :tenthuoc_old";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.BindByName = true;

                    DateTime ngayDT;
                    if(!DateTime.TryParse(txtNgayDT.Text, out ngayDT))
                    {
                        MessageBox.Show("Ngày ĐT không hợp lệ.");
                        return;
                    }

                    cmd.Parameters.Add(":tenthuoc_new", OracleDbType.NVarchar2).Value = txtTenThuoc.Text.Trim();
                    cmd.Parameters.Add(":lieudung", OracleDbType.NVarchar2).Value = txtLieuDung.Text;
                    cmd.Parameters.Add(":mahsba", OracleDbType.Varchar2).Value = txtMaHSBA.Text.Trim();
                    cmd.Parameters.Add(":ngaydt", OracleDbType.Date).Value = ngayDT;
                    cmd.Parameters.Add(":tenthuoc_old", OracleDbType.NVarchar2).Value = _oldTenThuoc;

                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rows} đơn thuốc được cập nhật.");
                    lblStatus.Text = $"Status: Đã cập nhật {rows} đơn thuốc.";

                    LoadDonThuoc();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi cập nhật DONTHUOC:\n" + ex.Message +
                    "\n\nGợi ý:\n" +
                    "- ORA-01031: thiếu quyền UPDATE(TENTHUOC, LIEUDUNG).\n" +
                    "- ORA-00001: tên thuốc mới bị trùng khóa.\n" +
                    "- 0 dòng: VPD chặn hoặc dòng không thuộc HSBA của bác sĩ.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật DONTHUOC:\n" + ex.Message);
            }
        }
        private void UpdateDonThuoc()
        {
            if (_role != "Bác sĩ/Y sĩ")
            {
                MessageBox.Show("Chỉ Bác sĩ/Y sĩ được cập nhật đơn thuốc.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaHSBA.Text) ||
                string.IsNullOrWhiteSpace(txtNgayDT.Text) ||
                string.IsNullOrWhiteSpace(_oldTenThuoc))
            {
                MessageBox.Show("Vui lòng chọn đơn thuốc cần cập nhật.");
                return;
            }

            string sql = @"
                UPDATE QLYTE_06.DONTHUOC
                SET TENTHUOC = :tenthuoc_new,
                    LIEUDUNG = :lieudung
                WHERE MAHSBA = :mahsba
                  AND NGAYDT = :ngaydt
                  AND TENTHUOC = :tenthuoc_old";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.BindByName = true;

                    DateTime ngayDT;
                    if (!DateTime.TryParse(txtNgayDT.Text, out ngayDT))
                    {
                        MessageBox.Show("Ngày ĐT không hợp lệ.");
                        return;
                    }

                    cmd.Parameters.Add(":tenthuoc_new", OracleDbType.NVarchar2).Value = txtTenThuoc.Text.Trim();
                    cmd.Parameters.Add(":lieudung", OracleDbType.NVarchar2).Value = txtLieuDung.Text;
                    cmd.Parameters.Add(":mahsba", OracleDbType.Varchar2).Value = txtMaHSBA.Text.Trim();
                    cmd.Parameters.Add(":ngaydt", OracleDbType.Date).Value = ngayDT;
                    cmd.Parameters.Add(":tenthuoc_old", OracleDbType.NVarchar2).Value = _oldTenThuoc;

                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rows} đơn thuốc được cập nhật.");
                    lblStatus.Text = $"Status: Đã cập nhật {rows} đơn thuốc.";

                    LoadDonThuoc();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi cập nhật DONTHUOC:\n" + ex.Message +
                    "\n\nGợi ý:\n" +
                    "- ORA-01031: thiếu quyền UPDATE(TENTHUOC, LIEUDUNG).\n" +
                    "- ORA-00001: tên thuốc mới bị trùng khóa.\n" +
                    "- 0 dòng: VPD chặn hoặc dòng không thuộc HSBA của bác sĩ.");
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

        private void btnInsertDonThuoc_Click(object sender, EventArgs e)
        {
            if (_role != "Bác sĩ/Y sĩ")
            {
                MessageBox.Show("Chỉ Bác sĩ/Y sĩ được thêm đơn thuốc.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMaHSBA.Text) ||
                string.IsNullOrWhiteSpace(txtNgayDT.Text) ||
                string.IsNullOrWhiteSpace(txtTenThuoc.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã HSBA, Ngày ĐT và Tên thuốc.");
                return;
            }
            string sql = @"
                INSERT INTO QLYTE_06.DONTHUOC (
                    MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG
                )
                VALUES (
                    :mahsba, :ngaydt, :tenthuoc, :lieudung
                )";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    cmd.BindByName = true;

                    DateTime ngayDT;
                    if (!DateTime.TryParse(txtNgayDT.Text, out ngayDT))
                    {
                        MessageBox.Show("Ngày ĐT không hợp lệ.");
                        return;
                    }

                    cmd.Parameters.Add(":mahsba", OracleDbType.Varchar2).Value = txtMaHSBA.Text.Trim();
                    cmd.Parameters.Add(":ngaydt", OracleDbType.Date).Value = ngayDT;
                    cmd.Parameters.Add(":tenthuoc", OracleDbType.NVarchar2).Value = txtTenThuoc.Text.Trim();
                    cmd.Parameters.Add(":lieudung", OracleDbType.NVarchar2).Value = txtLieuDung.Text;

                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rows} đơn thuốc được thêm.");
                    lblStatus.Text = $"Status: Đã thêm {rows} đơn thuốc.";

                    LoadDonThuoc();
                }
            }

            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi cập nhật DONTHUOC:\n" + ex.Message +
                    "\n\nGợi ý:\n" +
                    "- ORA-01031: thiếu quyền UPDATE(TENTHUOC, LIEUDUNG).\n" +
                    "- ORA-00001: tên thuốc mới bị trùng khóa.\n" +
                    "- 0 dòng: VPD chặn hoặc dòng không thuộc HSBA của bác sĩ.");
            }
        }

        private void btnDeleteDonThuoc_Click(object sender, EventArgs e)
        {
            if (_role != "Bác sĩ/Y sĩ")
            {
                MessageBox.Show("Chỉ Bác sĩ/Y sĩ được xóa đơn thuốc.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaHSBA.Text) ||
                string.IsNullOrWhiteSpace(txtNgayDT.Text) ||
                string.IsNullOrWhiteSpace(txtTenThuoc.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn thuốc cần xóa.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa đơn thuốc này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            string sql = @"
                DELETE FROM QLYTE_06.DONTHUOC
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

                    DateTime ngayDT;
                    if (!DateTime.TryParse(txtNgayDT.Text, out ngayDT))
                    {
                        MessageBox.Show("Ngày ĐT không hợp lệ.");
                        return;
                    }

                    cmd.Parameters.Add(":mahsba", OracleDbType.Varchar2).Value = txtMaHSBA.Text.Trim();
                    cmd.Parameters.Add(":ngaydt", OracleDbType.Date).Value = ngayDT;
                    cmd.Parameters.Add(":tenthuoc", OracleDbType.NVarchar2).Value = txtTenThuoc.Text.Trim();

                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rows} đơn thuốc được xóa.");
                    lblStatus.Text = $"Status: Đã xóa {rows} đơn thuốc.";

                    LoadDonThuoc();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Lỗi Oracle khi xóa DONTHUOC:\n" + ex.Message +
                    "\n\nGợi ý:\n" +
                    "- ORA-01031: thiếu quyền DELETE.\n" +
                    "- 0 dòng: VPD chặn hoặc dòng không thuộc HSBA của bác sĩ.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaHSBA.Clear();
            txtNgayDT.Clear();
            txtTenThuoc.Clear();
            txtLieuDung.Clear();

            _oldTenThuoc = "";

            if (_role == "Bác sĩ/Y sĩ")
            {
                txtMaHSBA.ReadOnly = false;
                txtNgayDT.ReadOnly = false;
                txtTenThuoc.ReadOnly = false;
                txtLieuDung.ReadOnly = false;

                txtMaHSBA.Focus();
                lblStatus.Text = "Status: Nhập đơn thuốc mới.";
            }
        }
    }
}
