namespace CQ2026_06_Phanhe1
{
    partial class MainForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtNewUsername = new System.Windows.Forms.TextBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblNewUserName = new System.Windows.Forms.Label();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnLoadUsers = new System.Windows.Forms.Button();
            this.tabRoles = new System.Windows.Forms.TabPage();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.btnCreateRole = new System.Windows.Forms.Button();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.btnLoadRoles = new System.Windows.Forms.Button();
            this.tabGrant = new System.Windows.Forms.TabPage();
            this.grpGrantRole = new System.Windows.Forms.GroupBox();
            this.btnGrantRole = new System.Windows.Forms.Button();
            this.chkAdminOption = new System.Windows.Forms.CheckBox();
            this.cmbUserReceiveRole = new System.Windows.Forms.ComboBox();
            this.cmbRoleToGrant = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.grpGrantPrivilege = new System.Windows.Forms.GroupBox();
            this.btnGrantPrivilege = new System.Windows.Forms.Button();
            this.chkGrantOption = new System.Windows.Forms.CheckBox();
            this.clbColumns = new System.Windows.Forms.CheckedListBox();
            this.lblColumns = new System.Windows.Forms.Label();
            this.cmbPrivilege = new System.Windows.Forms.ComboBox();
            this.lblPrivilege = new System.Windows.Forms.Label();
            this.cmbObjectName = new System.Windows.Forms.ComboBox();
            this.lblObjectName = new System.Windows.Forms.Label();
            this.cmbObjectType = new System.Windows.Forms.ComboBox();
            this.lblObjectType = new System.Windows.Forms.Label();
            this.cmbGranteeName = new System.Windows.Forms.ComboBox();
            this.lblGranteeName = new System.Windows.Forms.Label();
            this.cmbGranteeType = new System.Windows.Forms.ComboBox();
            this.lblGranteeType = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpRevokeRole = new System.Windows.Forms.GroupBox();
            this.btnRevokeRole = new System.Windows.Forms.Button();
            this.cmbRevokeUser = new System.Windows.Forms.ComboBox();
            this.cmbRevokeRole = new System.Windows.Forms.ComboBox();
            this.lblRevokeUser = new System.Windows.Forms.Label();
            this.lblRevokeRole = new System.Windows.Forms.Label();
            this.grpRevokePrivilege = new System.Windows.Forms.GroupBox();
            this.btnRevokePrivilege = new System.Windows.Forms.Button();
            this.cmbRevokePrivilege = new System.Windows.Forms.ComboBox();
            this.cmbRevokeObjectName = new System.Windows.Forms.ComboBox();
            this.lblRevokePrivilege = new System.Windows.Forms.Label();
            this.lblRevokeObjectName = new System.Windows.Forms.Label();
            this.cmbRevokeGranteeName = new System.Windows.Forms.ComboBox();
            this.lblRevokeGranteeName = new System.Windows.Forms.Label();
            this.cmbRevokeGranteeType = new System.Windows.Forms.ComboBox();
            this.lblRevokeGranteeType = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvRolePrivileges = new System.Windows.Forms.DataGridView();
            this.lblRolePrivileges = new System.Windows.Forms.Label();
            this.dgvSystemPrivileges = new System.Windows.Forms.DataGridView();
            this.lblSystemPrivileges = new System.Windows.Forms.Label();
            this.dgvObjectPrivileges = new System.Windows.Forms.DataGridView();
            this.lblObjectPrivileges = new System.Windows.Forms.Label();
            this.btnLoadPrivileges = new System.Windows.Forms.Button();
            this.cmbViewTargetName = new System.Windows.Forms.ComboBox();
            this.cmbViewTargetType = new System.Windows.Forms.ComboBox();
            this.lblViewTargetName = new System.Windows.Forms.Label();
            this.lblViewTargetType = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tabRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.tabGrant.SuspendLayout();
            this.grpGrantRole.SuspendLayout();
            this.grpGrantPrivilege.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpRevokeRole.SuspendLayout();
            this.grpRevokePrivilege.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRolePrivileges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemPrivileges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjectPrivileges)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUsers);
            this.tabControl1.Controls.Add(this.tabRoles);
            this.tabControl1.Controls.Add(this.tabGrant);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1301, 732);
            this.tabControl1.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.txtNewPassword);
            this.tabUsers.Controls.Add(this.txtNewUsername);
            this.tabUsers.Controls.Add(this.btnDeleteUser);
            this.tabUsers.Controls.Add(this.btnCreateUser);
            this.tabUsers.Controls.Add(this.lblNewPassword);
            this.tabUsers.Controls.Add(this.lblNewUserName);
            this.tabUsers.Controls.Add(this.dgvUsers);
            this.tabUsers.Controls.Add(this.btnLoadUsers);
            this.tabUsers.Location = new System.Drawing.Point(4, 25);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(1293, 703);
            this.tabUsers.TabIndex = 0;
            this.tabUsers.Text = "Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            this.tabUsers.Click += new System.EventHandler(this.tabUsers_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(123, 50);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(100, 22);
            this.txtNewPassword.TabIndex = 7;
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.TextChanged += new System.EventHandler(this.txtNewPassword_TextChanged);
            // 
            // txtNewUsername
            // 
            this.txtNewUsername.Location = new System.Drawing.Point(123, 13);
            this.txtNewUsername.Name = "txtNewUsername";
            this.txtNewUsername.Size = new System.Drawing.Size(100, 22);
            this.txtNewUsername.TabIndex = 6;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(145, 88);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(101, 27);
            this.btnDeleteUser.TabIndex = 5;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(37, 88);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(92, 27);
            this.btnCreateUser.TabIndex = 4;
            this.btnCreateUser.Text = "Create User";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(34, 50);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(64, 16);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "Password";
            this.lblNewPassword.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblNewUserName
            // 
            this.lblNewUserName.AutoSize = true;
            this.lblNewUserName.Location = new System.Drawing.Point(34, 16);
            this.lblNewUserName.Name = "lblNewUserName";
            this.lblNewUserName.Size = new System.Drawing.Size(66, 16);
            this.lblNewUserName.TabIndex = 2;
            this.lblNewUserName.Text = "Username";
            this.lblNewUserName.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(0, 138);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(633, 331);
            this.dgvUsers.TabIndex = 1;
            // 
            // btnLoadUsers
            // 
            this.btnLoadUsers.Location = new System.Drawing.Point(266, 88);
            this.btnLoadUsers.Name = "btnLoadUsers";
            this.btnLoadUsers.Size = new System.Drawing.Size(106, 27);
            this.btnLoadUsers.TabIndex = 0;
            this.btnLoadUsers.Text = "Load Users";
            this.btnLoadUsers.UseVisualStyleBackColor = true;
            this.btnLoadUsers.Click += new System.EventHandler(this.btnLoadUsers_Click);
            // 
            // tabRoles
            // 
            this.tabRoles.Controls.Add(this.btnDeleteRole);
            this.tabRoles.Controls.Add(this.txtRoleName);
            this.tabRoles.Controls.Add(this.btnCreateRole);
            this.tabRoles.Controls.Add(this.lblRoleName);
            this.tabRoles.Controls.Add(this.dgvRoles);
            this.tabRoles.Controls.Add(this.btnLoadRoles);
            this.tabRoles.Location = new System.Drawing.Point(4, 25);
            this.tabRoles.Name = "tabRoles";
            this.tabRoles.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoles.Size = new System.Drawing.Size(1293, 703);
            this.tabRoles.TabIndex = 1;
            this.tabRoles.Text = "Roles";
            this.tabRoles.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.Location = new System.Drawing.Point(306, 63);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(102, 32);
            this.btnDeleteRole.TabIndex = 5;
            this.btnDeleteRole.Text = "Delete Role";
            this.btnDeleteRole.UseVisualStyleBackColor = true;
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(143, 16);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(86, 22);
            this.txtRoleName.TabIndex = 4;
            // 
            // btnCreateRole
            // 
            this.btnCreateRole.Location = new System.Drawing.Point(39, 64);
            this.btnCreateRole.Name = "btnCreateRole";
            this.btnCreateRole.Size = new System.Drawing.Size(111, 31);
            this.btnCreateRole.TabIndex = 3;
            this.btnCreateRole.Text = "Create Role";
            this.btnCreateRole.UseVisualStyleBackColor = true;
            this.btnCreateRole.Click += new System.EventHandler(this.btnCreateRole_Click);
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Location = new System.Drawing.Point(36, 21);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(71, 16);
            this.lblRoleName.TabIndex = 2;
            this.lblRoleName.Text = "Role Name";
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoles.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Location = new System.Drawing.Point(0, 139);
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.RowHeadersWidth = 51;
            this.dgvRoles.RowTemplate.Height = 24;
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.Size = new System.Drawing.Size(633, 327);
            this.dgvRoles.TabIndex = 1;
            // 
            // btnLoadRoles
            // 
            this.btnLoadRoles.Location = new System.Drawing.Point(168, 65);
            this.btnLoadRoles.Name = "btnLoadRoles";
            this.btnLoadRoles.Size = new System.Drawing.Size(96, 30);
            this.btnLoadRoles.TabIndex = 0;
            this.btnLoadRoles.Text = "Load Roles";
            this.btnLoadRoles.UseVisualStyleBackColor = true;
            this.btnLoadRoles.Click += new System.EventHandler(this.btnLoadRoles_Click);
            // 
            // tabGrant
            // 
            this.tabGrant.Controls.Add(this.grpGrantRole);
            this.tabGrant.Controls.Add(this.grpGrantPrivilege);
            this.tabGrant.Location = new System.Drawing.Point(4, 25);
            this.tabGrant.Name = "tabGrant";
            this.tabGrant.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrant.Size = new System.Drawing.Size(1293, 703);
            this.tabGrant.TabIndex = 2;
            this.tabGrant.Text = "Grant";
            this.tabGrant.UseVisualStyleBackColor = true;
            // 
            // grpGrantRole
            // 
            this.grpGrantRole.Controls.Add(this.btnGrantRole);
            this.grpGrantRole.Controls.Add(this.chkAdminOption);
            this.grpGrantRole.Controls.Add(this.cmbUserReceiveRole);
            this.grpGrantRole.Controls.Add(this.cmbRoleToGrant);
            this.grpGrantRole.Controls.Add(this.lblUser);
            this.grpGrantRole.Controls.Add(this.lblRole);
            this.grpGrantRole.Location = new System.Drawing.Point(774, 122);
            this.grpGrantRole.Name = "grpGrantRole";
            this.grpGrantRole.Size = new System.Drawing.Size(258, 235);
            this.grpGrantRole.TabIndex = 1;
            this.grpGrantRole.TabStop = false;
            this.grpGrantRole.Text = "Grant Role To User";
            this.grpGrantRole.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnGrantRole
            // 
            this.btnGrantRole.Location = new System.Drawing.Point(76, 195);
            this.btnGrantRole.Name = "btnGrantRole";
            this.btnGrantRole.Size = new System.Drawing.Size(110, 24);
            this.btnGrantRole.TabIndex = 5;
            this.btnGrantRole.Text = "Grant Role";
            this.btnGrantRole.UseVisualStyleBackColor = true;
            this.btnGrantRole.Click += new System.EventHandler(this.btnGrantRole_Click);
            // 
            // chkAdminOption
            // 
            this.chkAdminOption.AutoSize = true;
            this.chkAdminOption.Location = new System.Drawing.Point(35, 128);
            this.chkAdminOption.Name = "chkAdminOption";
            this.chkAdminOption.Size = new System.Drawing.Size(161, 20);
            this.chkAdminOption.TabIndex = 4;
            this.chkAdminOption.Text = "WITH GRANT OPTION";
            this.chkAdminOption.UseVisualStyleBackColor = true;
            // 
            // cmbUserReceiveRole
            // 
            this.cmbUserReceiveRole.FormattingEnabled = true;
            this.cmbUserReceiveRole.Location = new System.Drawing.Point(101, 77);
            this.cmbUserReceiveRole.Name = "cmbUserReceiveRole";
            this.cmbUserReceiveRole.Size = new System.Drawing.Size(121, 24);
            this.cmbUserReceiveRole.TabIndex = 3;
            // 
            // cmbRoleToGrant
            // 
            this.cmbRoleToGrant.FormattingEnabled = true;
            this.cmbRoleToGrant.Location = new System.Drawing.Point(101, 42);
            this.cmbRoleToGrant.Name = "cmbRoleToGrant";
            this.cmbRoleToGrant.Size = new System.Drawing.Size(121, 24);
            this.cmbRoleToGrant.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(21, 77);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(34, 16);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "User";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(21, 46);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(33, 16);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Role";
            // 
            // grpGrantPrivilege
            // 
            this.grpGrantPrivilege.Controls.Add(this.btnGrantPrivilege);
            this.grpGrantPrivilege.Controls.Add(this.chkGrantOption);
            this.grpGrantPrivilege.Controls.Add(this.clbColumns);
            this.grpGrantPrivilege.Controls.Add(this.lblColumns);
            this.grpGrantPrivilege.Controls.Add(this.cmbPrivilege);
            this.grpGrantPrivilege.Controls.Add(this.lblPrivilege);
            this.grpGrantPrivilege.Controls.Add(this.cmbObjectName);
            this.grpGrantPrivilege.Controls.Add(this.lblObjectName);
            this.grpGrantPrivilege.Controls.Add(this.cmbObjectType);
            this.grpGrantPrivilege.Controls.Add(this.lblObjectType);
            this.grpGrantPrivilege.Controls.Add(this.cmbGranteeName);
            this.grpGrantPrivilege.Controls.Add(this.lblGranteeName);
            this.grpGrantPrivilege.Controls.Add(this.cmbGranteeType);
            this.grpGrantPrivilege.Controls.Add(this.lblGranteeType);
            this.grpGrantPrivilege.Location = new System.Drawing.Point(248, 122);
            this.grpGrantPrivilege.Name = "grpGrantPrivilege";
            this.grpGrantPrivilege.Size = new System.Drawing.Size(324, 447);
            this.grpGrantPrivilege.TabIndex = 0;
            this.grpGrantPrivilege.TabStop = false;
            this.grpGrantPrivilege.Text = "Grant Object Privilege";
            this.grpGrantPrivilege.Enter += new System.EventHandler(this.grpGrantPrivilege_Enter);
            // 
            // btnGrantPrivilege
            // 
            this.btnGrantPrivilege.Location = new System.Drawing.Point(92, 406);
            this.btnGrantPrivilege.Name = "btnGrantPrivilege";
            this.btnGrantPrivilege.Size = new System.Drawing.Size(143, 35);
            this.btnGrantPrivilege.TabIndex = 13;
            this.btnGrantPrivilege.Text = "Grant Privilege";
            this.btnGrantPrivilege.UseVisualStyleBackColor = true;
            this.btnGrantPrivilege.Click += new System.EventHandler(this.btnGrantPrivilege_Click);
            // 
            // chkGrantOption
            // 
            this.chkGrantOption.AutoSize = true;
            this.chkGrantOption.Location = new System.Drawing.Point(31, 365);
            this.chkGrantOption.Name = "chkGrantOption";
            this.chkGrantOption.Size = new System.Drawing.Size(161, 20);
            this.chkGrantOption.TabIndex = 12;
            this.chkGrantOption.Text = "WITH GRANT OPTION";
            this.chkGrantOption.UseVisualStyleBackColor = true;
            // 
            // clbColumns
            // 
            this.clbColumns.FormattingEnabled = true;
            this.clbColumns.Location = new System.Drawing.Point(24, 238);
            this.clbColumns.Name = "clbColumns";
            this.clbColumns.Size = new System.Drawing.Size(199, 106);
            this.clbColumns.TabIndex = 11;
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(21, 215);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(58, 16);
            this.lblColumns.TabIndex = 10;
            this.lblColumns.Text = "Columns";
            // 
            // cmbPrivilege
            // 
            this.cmbPrivilege.FormattingEnabled = true;
            this.cmbPrivilege.Location = new System.Drawing.Point(116, 180);
            this.cmbPrivilege.Name = "cmbPrivilege";
            this.cmbPrivilege.Size = new System.Drawing.Size(132, 24);
            this.cmbPrivilege.TabIndex = 9;
            this.cmbPrivilege.SelectedIndexChanged += new System.EventHandler(this.cmbPrivilege_SelectedIndexChanged);
            // 
            // lblPrivilege
            // 
            this.lblPrivilege.AutoSize = true;
            this.lblPrivilege.Location = new System.Drawing.Point(21, 180);
            this.lblPrivilege.Name = "lblPrivilege";
            this.lblPrivilege.Size = new System.Drawing.Size(55, 16);
            this.lblPrivilege.TabIndex = 8;
            this.lblPrivilege.Text = "Privilege";
            // 
            // cmbObjectName
            // 
            this.cmbObjectName.FormattingEnabled = true;
            this.cmbObjectName.Location = new System.Drawing.Point(116, 145);
            this.cmbObjectName.Name = "cmbObjectName";
            this.cmbObjectName.Size = new System.Drawing.Size(132, 24);
            this.cmbObjectName.TabIndex = 7;
            this.cmbObjectName.SelectedIndexChanged += new System.EventHandler(this.cmbObjectName_SelectedIndexChanged);
            // 
            // lblObjectName
            // 
            this.lblObjectName.AutoSize = true;
            this.lblObjectName.Location = new System.Drawing.Point(21, 145);
            this.lblObjectName.Name = "lblObjectName";
            this.lblObjectName.Size = new System.Drawing.Size(83, 16);
            this.lblObjectName.TabIndex = 6;
            this.lblObjectName.Text = "Object Name";
            // 
            // cmbObjectType
            // 
            this.cmbObjectType.FormattingEnabled = true;
            this.cmbObjectType.Location = new System.Drawing.Point(116, 109);
            this.cmbObjectType.Name = "cmbObjectType";
            this.cmbObjectType.Size = new System.Drawing.Size(132, 24);
            this.cmbObjectType.TabIndex = 5;
            this.cmbObjectType.SelectedIndexChanged += new System.EventHandler(this.cmbObjectType_SelectedIndexChanged);
            // 
            // lblObjectType
            // 
            this.lblObjectType.AutoSize = true;
            this.lblObjectType.Location = new System.Drawing.Point(21, 109);
            this.lblObjectType.Name = "lblObjectType";
            this.lblObjectType.Size = new System.Drawing.Size(76, 16);
            this.lblObjectType.TabIndex = 4;
            this.lblObjectType.Text = "Object Type";
            // 
            // cmbGranteeName
            // 
            this.cmbGranteeName.FormattingEnabled = true;
            this.cmbGranteeName.Location = new System.Drawing.Point(116, 73);
            this.cmbGranteeName.Name = "cmbGranteeName";
            this.cmbGranteeName.Size = new System.Drawing.Size(132, 24);
            this.cmbGranteeName.TabIndex = 3;
            // 
            // lblGranteeName
            // 
            this.lblGranteeName.AutoSize = true;
            this.lblGranteeName.Location = new System.Drawing.Point(21, 77);
            this.lblGranteeName.Name = "lblGranteeName";
            this.lblGranteeName.Size = new System.Drawing.Size(91, 16);
            this.lblGranteeName.TabIndex = 2;
            this.lblGranteeName.Text = "Grantee Name";
            // 
            // cmbGranteeType
            // 
            this.cmbGranteeType.FormattingEnabled = true;
            this.cmbGranteeType.Location = new System.Drawing.Point(116, 39);
            this.cmbGranteeType.Name = "cmbGranteeType";
            this.cmbGranteeType.Size = new System.Drawing.Size(132, 24);
            this.cmbGranteeType.TabIndex = 1;
            this.cmbGranteeType.SelectedIndexChanged += new System.EventHandler(this.cmbGranteeType_SelectedIndexChanged);
            // 
            // lblGranteeType
            // 
            this.lblGranteeType.AutoSize = true;
            this.lblGranteeType.Location = new System.Drawing.Point(21, 42);
            this.lblGranteeType.Name = "lblGranteeType";
            this.lblGranteeType.Size = new System.Drawing.Size(84, 16);
            this.lblGranteeType.TabIndex = 0;
            this.lblGranteeType.Text = "Grantee Type";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpRevokeRole);
            this.tabPage1.Controls.Add(this.grpRevokePrivilege);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1293, 703);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Revoke";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpRevokeRole
            // 
            this.grpRevokeRole.Controls.Add(this.btnRevokeRole);
            this.grpRevokeRole.Controls.Add(this.cmbRevokeUser);
            this.grpRevokeRole.Controls.Add(this.cmbRevokeRole);
            this.grpRevokeRole.Controls.Add(this.lblRevokeUser);
            this.grpRevokeRole.Controls.Add(this.lblRevokeRole);
            this.grpRevokeRole.Location = new System.Drawing.Point(779, 110);
            this.grpRevokeRole.Name = "grpRevokeRole";
            this.grpRevokeRole.Size = new System.Drawing.Size(254, 420);
            this.grpRevokeRole.TabIndex = 1;
            this.grpRevokeRole.TabStop = false;
            this.grpRevokeRole.Text = "Revoke Role From User";
            // 
            // btnRevokeRole
            // 
            this.btnRevokeRole.Location = new System.Drawing.Point(77, 297);
            this.btnRevokeRole.Name = "btnRevokeRole";
            this.btnRevokeRole.Size = new System.Drawing.Size(100, 35);
            this.btnRevokeRole.TabIndex = 4;
            this.btnRevokeRole.Text = "Revoke Role";
            this.btnRevokeRole.UseVisualStyleBackColor = true;
            this.btnRevokeRole.Click += new System.EventHandler(this.btnRevokeRole_Click);
            // 
            // cmbRevokeUser
            // 
            this.cmbRevokeUser.FormattingEnabled = true;
            this.cmbRevokeUser.Location = new System.Drawing.Point(116, 96);
            this.cmbRevokeUser.Name = "cmbRevokeUser";
            this.cmbRevokeUser.Size = new System.Drawing.Size(121, 24);
            this.cmbRevokeUser.TabIndex = 3;
            // 
            // cmbRevokeRole
            // 
            this.cmbRevokeRole.FormattingEnabled = true;
            this.cmbRevokeRole.Location = new System.Drawing.Point(116, 40);
            this.cmbRevokeRole.Name = "cmbRevokeRole";
            this.cmbRevokeRole.Size = new System.Drawing.Size(121, 24);
            this.cmbRevokeRole.TabIndex = 2;
            // 
            // lblRevokeUser
            // 
            this.lblRevokeUser.AutoSize = true;
            this.lblRevokeUser.Location = new System.Drawing.Point(48, 99);
            this.lblRevokeUser.Name = "lblRevokeUser";
            this.lblRevokeUser.Size = new System.Drawing.Size(34, 16);
            this.lblRevokeUser.TabIndex = 1;
            this.lblRevokeUser.Text = "User";
            // 
            // lblRevokeRole
            // 
            this.lblRevokeRole.AutoSize = true;
            this.lblRevokeRole.Location = new System.Drawing.Point(48, 43);
            this.lblRevokeRole.Name = "lblRevokeRole";
            this.lblRevokeRole.Size = new System.Drawing.Size(33, 16);
            this.lblRevokeRole.TabIndex = 0;
            this.lblRevokeRole.Text = "Role";
            // 
            // grpRevokePrivilege
            // 
            this.grpRevokePrivilege.Controls.Add(this.btnRevokePrivilege);
            this.grpRevokePrivilege.Controls.Add(this.cmbRevokePrivilege);
            this.grpRevokePrivilege.Controls.Add(this.cmbRevokeObjectName);
            this.grpRevokePrivilege.Controls.Add(this.lblRevokePrivilege);
            this.grpRevokePrivilege.Controls.Add(this.lblRevokeObjectName);
            this.grpRevokePrivilege.Controls.Add(this.cmbRevokeGranteeName);
            this.grpRevokePrivilege.Controls.Add(this.lblRevokeGranteeName);
            this.grpRevokePrivilege.Controls.Add(this.cmbRevokeGranteeType);
            this.grpRevokePrivilege.Controls.Add(this.lblRevokeGranteeType);
            this.grpRevokePrivilege.Location = new System.Drawing.Point(281, 110);
            this.grpRevokePrivilege.Name = "grpRevokePrivilege";
            this.grpRevokePrivilege.Size = new System.Drawing.Size(311, 420);
            this.grpRevokePrivilege.TabIndex = 0;
            this.grpRevokePrivilege.TabStop = false;
            this.grpRevokePrivilege.Text = "Revoke Object Privilege";
            // 
            // btnRevokePrivilege
            // 
            this.btnRevokePrivilege.Location = new System.Drawing.Point(97, 297);
            this.btnRevokePrivilege.Name = "btnRevokePrivilege";
            this.btnRevokePrivilege.Size = new System.Drawing.Size(118, 35);
            this.btnRevokePrivilege.TabIndex = 8;
            this.btnRevokePrivilege.Text = "Revoke Privilege";
            this.btnRevokePrivilege.UseVisualStyleBackColor = true;
            this.btnRevokePrivilege.Click += new System.EventHandler(this.btnRevokePrivilege_Click);
            // 
            // cmbRevokePrivilege
            // 
            this.cmbRevokePrivilege.FormattingEnabled = true;
            this.cmbRevokePrivilege.Location = new System.Drawing.Point(119, 185);
            this.cmbRevokePrivilege.Name = "cmbRevokePrivilege";
            this.cmbRevokePrivilege.Size = new System.Drawing.Size(122, 24);
            this.cmbRevokePrivilege.TabIndex = 7;
            // 
            // cmbRevokeObjectName
            // 
            this.cmbRevokeObjectName.FormattingEnabled = true;
            this.cmbRevokeObjectName.Location = new System.Drawing.Point(119, 139);
            this.cmbRevokeObjectName.Name = "cmbRevokeObjectName";
            this.cmbRevokeObjectName.Size = new System.Drawing.Size(122, 24);
            this.cmbRevokeObjectName.TabIndex = 6;
            // 
            // lblRevokePrivilege
            // 
            this.lblRevokePrivilege.AutoSize = true;
            this.lblRevokePrivilege.Location = new System.Drawing.Point(35, 188);
            this.lblRevokePrivilege.Name = "lblRevokePrivilege";
            this.lblRevokePrivilege.Size = new System.Drawing.Size(55, 16);
            this.lblRevokePrivilege.TabIndex = 5;
            this.lblRevokePrivilege.Text = "Privilege";
            this.lblRevokePrivilege.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblRevokeObjectName
            // 
            this.lblRevokeObjectName.AutoSize = true;
            this.lblRevokeObjectName.Location = new System.Drawing.Point(20, 139);
            this.lblRevokeObjectName.Name = "lblRevokeObjectName";
            this.lblRevokeObjectName.Size = new System.Drawing.Size(83, 16);
            this.lblRevokeObjectName.TabIndex = 4;
            this.lblRevokeObjectName.Text = "Object Name";
            this.lblRevokeObjectName.Click += new System.EventHandler(this.lblRevokeObjectName_Click);
            // 
            // cmbRevokeGranteeName
            // 
            this.cmbRevokeGranteeName.FormattingEnabled = true;
            this.cmbRevokeGranteeName.Location = new System.Drawing.Point(119, 93);
            this.cmbRevokeGranteeName.Name = "cmbRevokeGranteeName";
            this.cmbRevokeGranteeName.Size = new System.Drawing.Size(122, 24);
            this.cmbRevokeGranteeName.TabIndex = 3;
            // 
            // lblRevokeGranteeName
            // 
            this.lblRevokeGranteeName.AutoSize = true;
            this.lblRevokeGranteeName.Location = new System.Drawing.Point(20, 96);
            this.lblRevokeGranteeName.Name = "lblRevokeGranteeName";
            this.lblRevokeGranteeName.Size = new System.Drawing.Size(91, 16);
            this.lblRevokeGranteeName.TabIndex = 2;
            this.lblRevokeGranteeName.Text = "Grantee Name";
            this.lblRevokeGranteeName.Click += new System.EventHandler(this.lblRevokeGranteeName_Click);
            // 
            // cmbRevokeGranteeType
            // 
            this.cmbRevokeGranteeType.FormattingEnabled = true;
            this.cmbRevokeGranteeType.Location = new System.Drawing.Point(119, 45);
            this.cmbRevokeGranteeType.Name = "cmbRevokeGranteeType";
            this.cmbRevokeGranteeType.Size = new System.Drawing.Size(122, 24);
            this.cmbRevokeGranteeType.TabIndex = 1;
            this.cmbRevokeGranteeType.SelectedIndexChanged += new System.EventHandler(this.cmbRevokeGranteeType_SelectedIndexChanged);
            // 
            // lblRevokeGranteeType
            // 
            this.lblRevokeGranteeType.AutoSize = true;
            this.lblRevokeGranteeType.Location = new System.Drawing.Point(20, 48);
            this.lblRevokeGranteeType.Name = "lblRevokeGranteeType";
            this.lblRevokeGranteeType.Size = new System.Drawing.Size(84, 16);
            this.lblRevokeGranteeType.TabIndex = 0;
            this.lblRevokeGranteeType.Text = "Grantee Type";
            this.lblRevokeGranteeType.Click += new System.EventHandler(this.lblRevokeGranteeType_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvRolePrivileges);
            this.tabPage2.Controls.Add(this.lblRolePrivileges);
            this.tabPage2.Controls.Add(this.dgvSystemPrivileges);
            this.tabPage2.Controls.Add(this.lblSystemPrivileges);
            this.tabPage2.Controls.Add(this.dgvObjectPrivileges);
            this.tabPage2.Controls.Add(this.lblObjectPrivileges);
            this.tabPage2.Controls.Add(this.btnLoadPrivileges);
            this.tabPage2.Controls.Add(this.cmbViewTargetName);
            this.tabPage2.Controls.Add(this.cmbViewTargetType);
            this.tabPage2.Controls.Add(this.lblViewTargetName);
            this.tabPage2.Controls.Add(this.lblViewTargetType);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1293, 703);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "View Privilege";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // dgvRolePrivileges
            // 
            this.dgvRolePrivileges.AllowUserToAddRows = false;
            this.dgvRolePrivileges.AllowUserToDeleteRows = false;
            this.dgvRolePrivileges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRolePrivileges.BackgroundColor = System.Drawing.Color.White;
            this.dgvRolePrivileges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRolePrivileges.Location = new System.Drawing.Point(875, 243);
            this.dgvRolePrivileges.MultiSelect = false;
            this.dgvRolePrivileges.Name = "dgvRolePrivileges";
            this.dgvRolePrivileges.ReadOnly = true;
            this.dgvRolePrivileges.RowHeadersWidth = 51;
            this.dgvRolePrivileges.RowTemplate.Height = 24;
            this.dgvRolePrivileges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRolePrivileges.Size = new System.Drawing.Size(408, 321);
            this.dgvRolePrivileges.TabIndex = 10;
            // 
            // lblRolePrivileges
            // 
            this.lblRolePrivileges.AutoSize = true;
            this.lblRolePrivileges.Location = new System.Drawing.Point(1053, 221);
            this.lblRolePrivileges.Name = "lblRolePrivileges";
            this.lblRolePrivileges.Size = new System.Drawing.Size(92, 16);
            this.lblRolePrivileges.TabIndex = 9;
            this.lblRolePrivileges.Text = "Role Privileges";
            // 
            // dgvSystemPrivileges
            // 
            this.dgvSystemPrivileges.AllowUserToAddRows = false;
            this.dgvSystemPrivileges.AllowUserToDeleteRows = false;
            this.dgvSystemPrivileges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSystemPrivileges.BackgroundColor = System.Drawing.Color.White;
            this.dgvSystemPrivileges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSystemPrivileges.Location = new System.Drawing.Point(451, 243);
            this.dgvSystemPrivileges.MultiSelect = false;
            this.dgvSystemPrivileges.Name = "dgvSystemPrivileges";
            this.dgvSystemPrivileges.RowHeadersWidth = 51;
            this.dgvSystemPrivileges.RowTemplate.Height = 24;
            this.dgvSystemPrivileges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSystemPrivileges.Size = new System.Drawing.Size(394, 321);
            this.dgvSystemPrivileges.TabIndex = 8;
            this.dgvSystemPrivileges.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // lblSystemPrivileges
            // 
            this.lblSystemPrivileges.AutoSize = true;
            this.lblSystemPrivileges.Location = new System.Drawing.Point(577, 221);
            this.lblSystemPrivileges.Name = "lblSystemPrivileges";
            this.lblSystemPrivileges.Size = new System.Drawing.Size(111, 16);
            this.lblSystemPrivileges.TabIndex = 7;
            this.lblSystemPrivileges.Text = "System Privileges";
            this.lblSystemPrivileges.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // dgvObjectPrivileges
            // 
            this.dgvObjectPrivileges.AllowUserToAddRows = false;
            this.dgvObjectPrivileges.AllowUserToDeleteRows = false;
            this.dgvObjectPrivileges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvObjectPrivileges.BackgroundColor = System.Drawing.Color.White;
            this.dgvObjectPrivileges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjectPrivileges.Location = new System.Drawing.Point(0, 243);
            this.dgvObjectPrivileges.MultiSelect = false;
            this.dgvObjectPrivileges.Name = "dgvObjectPrivileges";
            this.dgvObjectPrivileges.ReadOnly = true;
            this.dgvObjectPrivileges.RowHeadersWidth = 51;
            this.dgvObjectPrivileges.RowTemplate.Height = 24;
            this.dgvObjectPrivileges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvObjectPrivileges.Size = new System.Drawing.Size(391, 321);
            this.dgvObjectPrivileges.TabIndex = 6;
            // 
            // lblObjectPrivileges
            // 
            this.lblObjectPrivileges.AutoSize = true;
            this.lblObjectPrivileges.Location = new System.Drawing.Point(178, 224);
            this.lblObjectPrivileges.Name = "lblObjectPrivileges";
            this.lblObjectPrivileges.Size = new System.Drawing.Size(104, 16);
            this.lblObjectPrivileges.TabIndex = 5;
            this.lblObjectPrivileges.Text = "Object Privileges";
            this.lblObjectPrivileges.Click += new System.EventHandler(this.lblObjectPrivileges_Click);
            // 
            // btnLoadPrivileges
            // 
            this.btnLoadPrivileges.Location = new System.Drawing.Point(541, 137);
            this.btnLoadPrivileges.Name = "btnLoadPrivileges";
            this.btnLoadPrivileges.Size = new System.Drawing.Size(121, 37);
            this.btnLoadPrivileges.TabIndex = 4;
            this.btnLoadPrivileges.Text = "Load Privilege";
            this.btnLoadPrivileges.UseVisualStyleBackColor = true;
            this.btnLoadPrivileges.Click += new System.EventHandler(this.btnLoadPrivileges_Click);
            // 
            // cmbViewTargetName
            // 
            this.cmbViewTargetName.FormattingEnabled = true;
            this.cmbViewTargetName.Location = new System.Drawing.Point(541, 90);
            this.cmbViewTargetName.Name = "cmbViewTargetName";
            this.cmbViewTargetName.Size = new System.Drawing.Size(121, 24);
            this.cmbViewTargetName.TabIndex = 3;
            // 
            // cmbViewTargetType
            // 
            this.cmbViewTargetType.FormattingEnabled = true;
            this.cmbViewTargetType.Location = new System.Drawing.Point(541, 42);
            this.cmbViewTargetType.Name = "cmbViewTargetType";
            this.cmbViewTargetType.Size = new System.Drawing.Size(121, 24);
            this.cmbViewTargetType.TabIndex = 2;
            this.cmbViewTargetType.SelectedIndexChanged += new System.EventHandler(this.cmbViewTargetType_SelectedIndexChanged);
            // 
            // lblViewTargetName
            // 
            this.lblViewTargetName.AutoSize = true;
            this.lblViewTargetName.Location = new System.Drawing.Point(427, 93);
            this.lblViewTargetName.Name = "lblViewTargetName";
            this.lblViewTargetName.Size = new System.Drawing.Size(80, 16);
            this.lblViewTargetName.TabIndex = 1;
            this.lblViewTargetName.Text = "Target Name";
            // 
            // lblViewTargetType
            // 
            this.lblViewTargetType.AutoSize = true;
            this.lblViewTargetType.Location = new System.Drawing.Point(427, 45);
            this.lblViewTargetType.Name = "lblViewTargetType";
            this.lblViewTargetType.Size = new System.Drawing.Size(73, 16);
            this.lblViewTargetType.TabIndex = 0;
            this.lblViewTargetType.Text = "Target Type";
            this.lblViewTargetType.Click += new System.EventHandler(this.label1_Click_3);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 730);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tabRoles.ResumeLayout(false);
            this.tabRoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.tabGrant.ResumeLayout(false);
            this.grpGrantRole.ResumeLayout(false);
            this.grpGrantRole.PerformLayout();
            this.grpGrantPrivilege.ResumeLayout(false);
            this.grpGrantPrivilege.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.grpRevokeRole.ResumeLayout(false);
            this.grpRevokeRole.PerformLayout();
            this.grpRevokePrivilege.ResumeLayout(false);
            this.grpRevokePrivilege.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRolePrivileges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemPrivileges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjectPrivileges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.Button btnLoadUsers;
        private System.Windows.Forms.TabPage tabRoles;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button btnLoadRoles;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtNewUsername;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblNewUserName;
        private System.Windows.Forms.Button btnCreateRole;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.TabPage tabGrant;
        private System.Windows.Forms.GroupBox grpGrantPrivilege;
        private System.Windows.Forms.Label lblGranteeType;
        private System.Windows.Forms.Label lblObjectName;
        private System.Windows.Forms.ComboBox cmbObjectType;
        private System.Windows.Forms.Label lblObjectType;
        private System.Windows.Forms.ComboBox cmbGranteeName;
        private System.Windows.Forms.Label lblGranteeName;
        private System.Windows.Forms.ComboBox cmbGranteeType;
        private System.Windows.Forms.ComboBox cmbPrivilege;
        private System.Windows.Forms.Label lblPrivilege;
        private System.Windows.Forms.ComboBox cmbObjectName;
        private System.Windows.Forms.CheckedListBox clbColumns;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.CheckBox chkGrantOption;
        private System.Windows.Forms.GroupBox grpGrantRole;
        private System.Windows.Forms.Button btnGrantPrivilege;
        private System.Windows.Forms.Button btnGrantRole;
        private System.Windows.Forms.CheckBox chkAdminOption;
        private System.Windows.Forms.ComboBox cmbUserReceiveRole;
        private System.Windows.Forms.ComboBox cmbRoleToGrant;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox grpRevokeRole;
        private System.Windows.Forms.GroupBox grpRevokePrivilege;
        private System.Windows.Forms.ComboBox cmbRevokeGranteeType;
        private System.Windows.Forms.Label lblRevokeGranteeType;
        private System.Windows.Forms.ComboBox cmbRevokePrivilege;
        private System.Windows.Forms.ComboBox cmbRevokeObjectName;
        private System.Windows.Forms.Label lblRevokePrivilege;
        private System.Windows.Forms.Label lblRevokeObjectName;
        private System.Windows.Forms.ComboBox cmbRevokeGranteeName;
        private System.Windows.Forms.Label lblRevokeGranteeName;
        private System.Windows.Forms.Button btnRevokePrivilege;
        private System.Windows.Forms.Button btnRevokeRole;
        private System.Windows.Forms.ComboBox cmbRevokeUser;
        private System.Windows.Forms.ComboBox cmbRevokeRole;
        private System.Windows.Forms.Label lblRevokeUser;
        private System.Windows.Forms.Label lblRevokeRole;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblViewTargetType;
        private System.Windows.Forms.DataGridView dgvObjectPrivileges;
        private System.Windows.Forms.Label lblObjectPrivileges;
        private System.Windows.Forms.Button btnLoadPrivileges;
        private System.Windows.Forms.ComboBox cmbViewTargetName;
        private System.Windows.Forms.ComboBox cmbViewTargetType;
        private System.Windows.Forms.Label lblViewTargetName;
        private System.Windows.Forms.DataGridView dgvSystemPrivileges;
        private System.Windows.Forms.Label lblSystemPrivileges;
        private System.Windows.Forms.DataGridView dgvRolePrivileges;
        private System.Windows.Forms.Label lblRolePrivileges;
    }
}
