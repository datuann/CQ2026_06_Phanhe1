namespace CQ2026_06_Phanhe1
{
    partial class LoginForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblDatasource = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.cboSubsystem = new System.Windows.Forms.ComboBox();
            this.lblPhanHe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblUsername.Location = new System.Drawing.Point(179, 67);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(87, 23);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPassword.Location = new System.Drawing.Point(179, 121);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(80, 23);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            // 
            // lblDatasource
            // 
            this.lblDatasource.AutoSize = true;
            this.lblDatasource.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDatasource.Location = new System.Drawing.Point(179, 175);
            this.lblDatasource.Name = "lblDatasource";
            this.lblDatasource.Size = new System.Drawing.Size(103, 23);
            this.lblDatasource.TabIndex = 2;
            this.lblDatasource.Text = "Data Source";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtUsername.Location = new System.Drawing.Point(291, 67);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(126, 30);
            this.txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPassword.Location = new System.Drawing.Point(291, 118);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(193, 30);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtDataSource
            // 
            this.txtDataSource.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtDataSource.Location = new System.Drawing.Point(291, 172);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(193, 30);
            this.txtDataSource.TabIndex = 5;
            this.txtDataSource.TextChanged += new System.EventHandler(this.txtDatasource_TextChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblStatus.Location = new System.Drawing.Point(330, 278);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(107, 23);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Chưa kết nối";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogin.Location = new System.Drawing.Point(183, 273);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(127, 35);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cboSubsystem
            // 
            this.cboSubsystem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboSubsystem.FormattingEnabled = true;
            this.cboSubsystem.Location = new System.Drawing.Point(291, 221);
            this.cboSubsystem.Name = "cboSubsystem";
            this.cboSubsystem.Size = new System.Drawing.Size(226, 31);
            this.cboSubsystem.TabIndex = 8;
            // 
            // lblPhanHe
            // 
            this.lblPhanHe.AutoSize = true;
            this.lblPhanHe.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPhanHe.Location = new System.Drawing.Point(179, 222);
            this.lblPhanHe.Name = "lblPhanHe";
            this.lblPhanHe.Size = new System.Drawing.Size(75, 23);
            this.lblPhanHe.TabIndex = 9;
            this.lblPhanHe.Text = "Phân Hệ";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPhanHe);
            this.Controls.Add(this.cboSubsystem);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtDataSource);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblDatasource);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Name = "LoginForm";
            this.Text = "Đăng nhập Oracle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblDatasource;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox cboSubsystem;
        private System.Windows.Forms.Label lblPhanHe;
    }
}

