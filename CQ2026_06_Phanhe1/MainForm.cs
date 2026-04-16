using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace CQ2026_06_Phanhe1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeGrantControls();
            InitializeRevokeControls();
            InitializeViewPrivilegesControls();
        }
        private bool UserExists(string username)
        {
            using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
            {
                conn.Open();

                string sql = "SELECT COUNT(*) FROM DBA_USERS WHERE USERNAME = :username";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = username.ToUpper();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        private bool RoleExists(string roleName)
        {
            using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
            {
                conn.Open();

                string sql = "SELECT COUNT(*) FROM DBA_ROLES WHERE ROLE = :roleName";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":roleName", OracleDbType.Varchar2).Value = roleName.ToUpper();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        private void InitializeGrantControls()
        {
            cmbGranteeType.Items.Clear();
            cmbGranteeType.Items.Add("USER");
            cmbGranteeType.Items.Add("ROLE");

            cmbObjectType.Items.Clear();
            cmbObjectType.Items.Add("TABLE");
            cmbObjectType.Items.Add("VIEW");
            cmbObjectType.Items.Add("PROCEDURE");
            cmbObjectType.Items.Add("FUNCTION");

            LoadRolesToComboBox(cmbRoleToGrant);
            LoadUsersToComboBox(cmbUserReceiveRole);


        }

        private void InitializeRevokeControls()
        {
            cmbRevokeGranteeType.Items.Clear();
            cmbRevokeGranteeType.Items.Add("USER");
            cmbRevokeGranteeType.Items.Add("ROLE");

            LoadRolesToComboBox(cmbRevokeRole);
            LoadUsersToComboBox(cmbRevokeUser);
            LoadAllObjectNames(cmbRevokeObjectName);
            LoadRevokePrivileges();
        }

        private void InitializeViewPrivilegesControls()
        {
            cmbViewTargetType.Items.Clear();
            cmbViewTargetType.Items.Add("USER");
            cmbViewTargetType.Items.Add("ROLE");
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadUsers_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT USERNAME, ACCOUNT_STATUS, CREATED 
                           FROM DBA_USERS
                           ORDER BY USERNAME";

                    OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUsers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load user: " + ex.Message);
            }
        }

        private void btnLoadRoles_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
                {
                    conn.Open();

                    string sql = @"SELECT ROLE 
                           FROM DBA_ROLES
                           ORDER BY ROLE";

                    OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvRoles.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load role: " + ex.Message);
            }

        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRoles_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabUsers_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text.Trim().ToUpper();
            string password = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password.");
                return;
            }

            try
            {
                if (UserExists(username))
                {
                    MessageBox.Show("Username đã tồn tại.");
                    return;
                }
                using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
                {
                    conn.Open();
                    string createUserSql = $"CREATE USER {username} IDENTIFIED BY \"{password}\"";
                    using (OracleCommand cmd = new OracleCommand(createUserSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    string grantSessionSql = $"GRANT CREATE SESSION TO {username}";
                    using (OracleCommand cmd = new OracleCommand(grantSessionSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Tạo User thành công.");
                    txtNewUsername.Clear();
                    txtNewPassword.Clear();

                    btnLoadUsers_Click(null, null);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo User: " + ex.Message);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn User cần xóa.");
                return;
            }
            string username = dgvUsers.CurrentRow.Cells["USERNAME"].Value.ToString();

            if (username == "SYS" || username == "SYSTEM")
            {
                MessageBox.Show("Không được xóa User hệ thống.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa user {username} không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;
            try
            {
                using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
                {
                    conn.Open();
                    string sql = $"DROP USER {username} CASCADE";
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Xóa User thành công.");

                }
                btnLoadUsers_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa user: " + ex.Message);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }


        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn Role cần xóa.");
                return;
            }

            string roleName = dgvRoles.CurrentRow.Cells["ROLE"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa Role {roleName} không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;
            try
            {
                using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
                {
                    conn.Open();
                    string sql = $"DROP ROLE {roleName}";
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Xóa Role thành công");
                }
                btnLoadRoles_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa Role: " + ex.Message);
            }


        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            string roleName = txtRoleName.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(roleName))
            {
                MessageBox.Show("Vui lòng nhập tên Role.");
                return;
            }

            try
            {
                if (RoleExists(roleName))
                {
                    MessageBox.Show("Role đã tồn tại.");
                    return;
                }

                using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
                {
                    conn.Open();

                    string sql = $"CREATE ROLE {roleName}";
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Tạo Role thành công.");
                }

                txtRoleName.Clear();
                btnLoadRoles_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo Role: " + ex.Message);
            }
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void grpGrantPrivilege_Enter(object sender, EventArgs e)
        {

        }

        // Load danh sách User vào ComboBox
        private void LoadUsersToComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT USERNAME FROM DBA_USERS ORDER BY USERNAME";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["USERNAME"].ToString());
                    }
                }
            }
        }
        // Load danh sách Role vào ComboBox
        private void LoadRolesToComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT ROLE FROM DBA_ROLES ORDER BY ROLE";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["ROLE"].ToString());
                    }
                }
            }
        }

        // Load cột khi chọn Object
        private void LoadColumns(string tableName)
        {
            clbColumns.Items.Clear();
            using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT COLUMN_NAME
                               FROM USER_TAB_COLUMNS
                               WHERE TABLE_NAME = :tableName
                               ORDER BY COLUMN_ID";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":tableName", OracleDbType.Varchar2).Value = tableName.ToUpper();
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clbColumns.Items.Add(reader["COLUMN_NAME"].ToString());
                        }
                    }
                }
            }
        }

        // Load Object name để Revoke
        private void LoadAllObjectNames(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT OBJECT_NAME
                               FROM USER_OBJECTS
                               WHERE OBJECT_TYPE IN ('TABLE','VIEW', 'PROCEDURE', 'FUNCTION')
                               ORDER BY OBJECT_NAME";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["OBJECT_NAME"].ToString());
                    }
                }
            }
        }

        // Nạp danh sách Privilege cho Revoke
        private void LoadRevokePrivileges()
        {
            cmbRevokePrivilege.Items.Clear();
            cmbRevokePrivilege.Items.Add("SELECT");
            cmbRevokePrivilege.Items.Add("INSERT");
            cmbRevokePrivilege.Items.Add("UPDATE");
            cmbRevokePrivilege.Items.Add("DELETE");
            cmbRevokePrivilege.Items.Add("EXECUTE");
        }
        private void LoadObjectsByType(string objectType, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
            {
                conn.Open();

                string sql = "";
                if (objectType == "TABLE" || objectType == "VIEW")
                {
                    sql = @"SELECT OBJECT_NAME
                            FROM USER_OBJECTS
                            WHERE OBJECT_TYPE = :objectType 
                            ORDER BY OBJECT_NAME";
                }
                else if (objectType == "PROCEDURE" || objectType == "FUNCTION")
                {
                    sql = @"SELECT OBJECT_NAME
                            FROM USER_OBJECTS
                            WHERE OBJECT_TYPE = :objectType
                            ORDER BY OBJECT_NAME";
                }
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":objectType", OracleDbType.Varchar2).Value = objectType.ToUpper();
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox.Items.Add(reader["OBJECT_NAME"].ToString());
                        }
                    }
                }
            }
        }

        private void LoadObjectPrivileges(string grantee)
        {
            using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
            {
                conn.Open();

                string sql = @"SELECT GRANTEE, OWNER, TABLE_NAME, PRIVILEGE, GRANTABLE
                               FROM DBA_TAB_PRIVS
                               WHERE GRANTEE = :grantee
                               ORDER BY TABLE_NAME, PRIVILEGE";
                using (OracleDataAdapter da = new OracleDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.Add(":grantee", OracleDbType.Varchar2).Value = grantee.ToUpper();

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvObjectPrivileges.DataSource = dt;
                }
            }
        }

        private void LoadSystemPrivileges(string grantee)
        {
            using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
            {
                conn.Open();

                string sql = @"SELECT GRANTEE, PRIVILEGE, ADMIN_OPTION
                               FROM DBA_SYS_PRIVS
                               WHERE GRANTEE = :grantee
                               ORDER BY PRIVILEGE";
                using (OracleDataAdapter da = new OracleDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.Add(":grantee", OracleDbType.Varchar2).Value = grantee.ToUpper();   

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSystemPrivileges.DataSource = dt;
                }
            }
        }

        private void LoadGrantedRoles(string grantee)
        {
            using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
            {
                conn.Open();

                string sql = @"SELECT GRANTEE, GRANTED_ROLE, ADMIN_OPTION
                               FROM DBA_ROLE_PRIVS
                               WHERE GRANTEE = :grantee
                               ORDER BY GRANTED_ROLE";
                using (OracleDataAdapter da = new OracleDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.Add(":grantee", OracleDbType.Varchar2).Value = grantee.ToUpper();

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSystemPrivileges.DataSource = dt;
                }
            }
        }
        private void cmbGranteeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string type = cmbGranteeType.Text;
                if (type == "USER")
                {
                    LoadUsersToComboBox(cmbGranteeName);
                }
                else if (type == "ROLE")
                {
                    LoadRolesToComboBox(cmbGranteeName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Load Grantee: " + ex.Message);
            }
        }

        private void cmbObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string objectType = cmbObjectType.Text;
                LoadObjectsByType(objectType, cmbObjectName);

                cmbPrivilege.Items.Clear();

                if (objectType == "TABLE" || objectType == "VIEW")
                {
                    cmbPrivilege.Items.Add("SELECT");
                    cmbPrivilege.Items.Add("INSERT");
                    cmbPrivilege.Items.Add("UPDATE");
                    cmbPrivilege.Items.Add("DELETE");
                }
                else if (objectType == "PROCEDURE" || objectType == "FUNCTION")
                {
                    cmbPrivilege.Items.Add("EXECUTE");
                }
                clbColumns.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Load Object Type: " + ex.Message);
            }
        }

        private void cmbObjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbObjectType.Text == "TABLE" || cmbObjectType.Text == "VIEW")
            {
                LoadColumns(cmbObjectName.Text);
            }
        }

        private void cmbPrivilege_SelectedIndexChanged(object sender, EventArgs e)
        {
            string privilege = cmbPrivilege.Text;
            if (privilege == "SELECT" || privilege == "UPDATE")
            {
                clbColumns.Enabled = true;
            }
            else
            {
                clbColumns.Enabled = false;
                for (int i = 0; i < clbColumns.Items.Count; i++)
                {
                    clbColumns.SetItemChecked(i, false);
                }
            }
        }

        private void btnGrantPrivilege_Click(object sender, EventArgs e)
        {
            string grantee = cmbGranteeName.Text.Trim().ToUpper();
            string objectName = cmbObjectName.Text.Trim().ToUpper();
            string privilege = cmbPrivilege.Text.Trim().ToUpper();
            bool withGrantOption = chkGrantOption.Checked;

            if (string.IsNullOrEmpty(grantee) ||
                string.IsNullOrEmpty(objectName) ||
                string.IsNullOrEmpty(privilege))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin Grant.");
                return;
            }
            try
            {
                string sql = "";

                if (privilege == "SELECT" || privilege == "UPDATE")
                {
                    List<string> selectedColumns = new List<string>();
                    foreach (var item in clbColumns.CheckedItems)
                    {
                        selectedColumns.Add(item.ToString().ToUpper());
                    }
                    if (selectedColumns.Count() > 0)
                    {
                        string columnList = string.Join(", ", selectedColumns);
                        sql = $"GRANT {privilege} ({columnList}) ON {objectName} TO {grantee}";
                    }
                    else
                    {
                        sql = $"GRANT {privilege} ON {objectName} TO {grantee}";
                    }

                }
                else
                {
                    sql = $"GRANT {privilege} ON {objectName} TO {grantee}";
                }
                if (withGrantOption)
                {
                    sql += " WITH GRANT OPTION";
                }
                using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Grant Privilege thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Grant Privilege: " + ex.Message);
            }
        }

        private void btnGrantRole_Click(object sender, EventArgs e)
        {
            string roleName = cmbRoleToGrant.Text.Trim().ToUpper();
            string userName = cmbUserReceiveRole.Text.Trim().ToUpper();
            bool withAdminOption = chkAdminOption.Checked;

            if (string.IsNullOrEmpty(roleName) || string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Vui lòng chọn Role và User.");
                return;
            }
            try
            {
                string sql = $"GRANT {roleName} TO {userName}";
                if (withAdminOption)
                {
                    sql += " WITH ADMIN OPTION";
                }
                using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Grant Role cho User thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Grant Role: " + ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblRevokeGranteeType_Click(object sender, EventArgs e)
        {

        }

        private void lblRevokeGranteeName_Click(object sender, EventArgs e)
        {

        }

        private void lblRevokeObjectName_Click(object sender, EventArgs e)
        {

        }

        private void cmbRevokeGranteeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string type = cmbRevokeGranteeType.Text;
                if (type == "USER")
                {
                    LoadUsersToComboBox(cmbRevokeGranteeName);
                }
                else if (type == "ROLE")
                {
                    LoadRolesToComboBox(cmbRevokeGranteeName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Load Revoke Grantee: " + ex.Message);
            }

        }

        private void btnRevokePrivilege_Click(object sender, EventArgs e)
        {
            string grantee = cmbRevokeGranteeName.Text.Trim().ToUpper();
            string objectName = cmbRevokeObjectName.Text.Trim().ToUpper();
            string privilege = cmbRevokePrivilege.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(grantee) || string.IsNullOrEmpty(objectName) || string.IsNullOrEmpty(privilege))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin để Revoke Privilege.");
                return;
            }
            try
            {
                string sql = $"REVOKE {privilege} ON {objectName} FROM {grantee}";
                using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Revoke Privilege thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Revoke Privilege: " + ex.Message);
            }
        }

        private void btnRevokeRole_Click(object sender, EventArgs e)
        {
            string roleName = cmbRevokeRole.Text.Trim().ToUpper();
            string userName = cmbRevokeUser.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(roleName) || string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin để Revoke Role.");
                return;
            }
            try
            {
                string sql = $"REVOKE {roleName} FROM {userName}";
                using (OracleConnection conn = new OracleConnection(LoginForm.ConnectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Revoke Role thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Revoke Role: " + ex.Message);
            }
        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void cmbViewTargetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string type = cmbViewTargetType.Text;

                if (type == "USER")
                {
                    LoadUsersToComboBox(cmbViewTargetName);
                }
                else if (type == "ROLE")
                {
                    LoadRolesToComboBox(cmbViewTargetName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Load Target Name: " + ex.Message);
            }
        }

        private void btnLoadPrivileges_Click(object sender, EventArgs e)
        {
            string targetName = cmbViewTargetName.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(targetName))
            {
                MessageBox.Show("Vui lòng chọn User hoặc Role cần xem quyền.");
                return;
            }
            try
            {
                LoadObjectPrivileges(targetName);
                LoadSystemPrivileges(targetName);
                LoadGrantedRoles(targetName);

                MessageBox.Show("Đã tải danh sách quyền.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Load Privilege: " + ex.Message);
            }
        }

        private void lblObjectPrivileges_Click(object sender, EventArgs e)
        {

        }
    }
}
