using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CQ2026_06_Phanhe1
{
    public partial class FormAuditLog : Form
    {
        private readonly string _connStr;
        private string _currentMode;
        public FormAuditLog(string connStr)
        {
            InitializeComponent();
            _connStr = connStr;
        }
        private void FormAuditLog_Load(object sender, EventArgs e)
        {
            LoadFgaAudit();
        }
        private void btnStandardAudit_Click(object sender, EventArgs e)
        {
            _currentMode = "Standard";
            LoadStandardAudit();
        }

        private void btnFgaAudit_Click(object sender, EventArgs e)
        {
            _currentMode = "FGA";
            LoadFgaAudit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_currentMode == "STANDARD")
            {
                LoadStandardAudit();
            }
            else LoadFgaAudit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadStandardAudit()
        {
            string sql = @"
                SELECT USERNAME,
                       OWNER,
                       OBJ_NAME,
                       ACTION_NAME,
                       TIMESTAMP
                FROM DBA_AUDIT_TRAIL
                WHERE OWNER = 'QLYTE_06'
                  AND OBJ_NAME IN ('BENHNHAN', 'HSBA', 'HSBA_DV', 'DONTHUOC', 'THONGBAO')
                ORDER BY TIMESTAMP DESC";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleDataAdapter da = new OracleDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvAuditLog.DataSource = dt;
                    lblStatus.Text = $"Status: Standard Audit - đã tải {dt.Rows.Count} dòng.";
                }
            }
            
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Không thể xem Standard Audit bằng user hiện tại.\n" +
                    "Hãy đăng nhập bằng SYS/SYSTEM hoặc user có quyền xem DBA_AUDIT_TRAIL.\n\n" +
                    "Chi tiết:\n" + ex.Message);
            }
            
        }
        private void LoadFgaAudit()
        {
            string sql = @"
                SELECT DB_USER,
                       OBJECT_SCHEMA,
                       OBJECT_NAME,
                       POLICY_NAME,
                       STATEMENT_TYPE,
                       SQL_TEXT,
                       TIMESTAMP
                FROM DBA_FGA_AUDIT_TRAIL
                WHERE OBJECT_SCHEMA = 'QLYTE_06'
                  AND OBJECT_NAME IN ('DONTHUOC', 'HSBA', 'HSBA_DV')
                ORDER BY TIMESTAMP DESC";

            try
            {
                using (OracleConnection conn = new OracleConnection(_connStr))
                using (OracleDataAdapter da = new OracleDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvAuditLog.DataSource = dt;
                    lblStatus.Text = $"Status: FGA Audit - đã tải {dt.Rows.Count} dòng.";
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    "Không thể xem FGA Audit bằng user hiện tại.\n" +
                    "Hãy đăng nhập bằng SYS/SYSTEM hoặc user có quyền xem DBA_FGA_AUDIT_TRAIL.\n\n" +
                    "Chi tiết:\n" + ex.Message);
            }
        }
    }
}
