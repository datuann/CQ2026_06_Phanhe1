namespace CQ2026_06_Phanhe1
{
    partial class FormPH2Main
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pblUserInfo = new System.Windows.Forms.Panel();
            this.lblCurrentRole = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBenhNhan = new System.Windows.Forms.Button();
            this.btnHSBA = new System.Windows.Forms.Button();
            this.btnHSBADV = new System.Windows.Forms.Button();
            this.btnDonThuoc = new System.Windows.Forms.Button();
            this.btnThongBao = new System.Windows.Forms.Button();
            this.btnAudit = new System.Windows.Forms.Button();
            this.lblSecutityNote = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pblUserInfo.SuspendLayout();
            this.flpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1147, 102);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogout.Location = new System.Drawing.Point(918, 38);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(168, 50);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(38, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(507, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ Y TẾ - PHÂN HỆ 2";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubtitle.Location = new System.Drawing.Point(41, 60);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(249, 28);
            this.lblSubtitle.TabIndex = 0;
            this.lblSubtitle.Text = "An toàn và bảo mật dữ liệu";
            // 
            // pblUserInfo
            // 
            this.pblUserInfo.BackColor = System.Drawing.Color.White;
            this.pblUserInfo.Controls.Add(this.lblCurrentRole);
            this.pblUserInfo.Controls.Add(this.lblCurrentUser);
            this.pblUserInfo.Controls.Add(this.lblWelcome);
            this.pblUserInfo.Location = new System.Drawing.Point(43, 164);
            this.pblUserInfo.Name = "pblUserInfo";
            this.pblUserInfo.Size = new System.Drawing.Size(1023, 113);
            this.pblUserInfo.TabIndex = 1;
            // 
            // lblCurrentRole
            // 
            this.lblCurrentRole.AutoSize = true;
            this.lblCurrentRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCurrentRole.Location = new System.Drawing.Point(51, 71);
            this.lblCurrentRole.Name = "lblCurrentRole";
            this.lblCurrentRole.Size = new System.Drawing.Size(78, 28);
            this.lblCurrentRole.TabIndex = 2;
            this.lblCurrentRole.Text = "Vai trò: ";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCurrentUser.Location = new System.Drawing.Point(51, 38);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(55, 28);
            this.lblCurrentUser.TabIndex = 1;
            this.lblCurrentUser.Text = "User:";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblWelcome.Location = new System.Drawing.Point(51, 10);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(87, 28);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Xin chào";
            // 
            // flpMenu
            // 
            this.flpMenu.BackColor = System.Drawing.Color.Transparent;
            this.flpMenu.Controls.Add(this.btnBenhNhan);
            this.flpMenu.Controls.Add(this.btnHSBA);
            this.flpMenu.Controls.Add(this.btnHSBADV);
            this.flpMenu.Controls.Add(this.btnDonThuoc);
            this.flpMenu.Controls.Add(this.btnThongBao);
            this.flpMenu.Controls.Add(this.btnAudit);
            this.flpMenu.Location = new System.Drawing.Point(43, 301);
            this.flpMenu.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(1023, 315);
            this.flpMenu.TabIndex = 2;
            // 
            // btnBenhNhan
            // 
            this.btnBenhNhan.BackColor = System.Drawing.Color.White;
            this.btnBenhNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBenhNhan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBenhNhan.Location = new System.Drawing.Point(10, 10);
            this.btnBenhNhan.Margin = new System.Windows.Forms.Padding(10);
            this.btnBenhNhan.Name = "btnBenhNhan";
            this.btnBenhNhan.Size = new System.Drawing.Size(237, 101);
            this.btnBenhNhan.TabIndex = 0;
            this.btnBenhNhan.Text = "Bệnh nhân";
            this.btnBenhNhan.UseVisualStyleBackColor = false;
            this.btnBenhNhan.Click += new System.EventHandler(this.btnBenhNhan_Click);
            // 
            // btnHSBA
            // 
            this.btnHSBA.BackColor = System.Drawing.Color.White;
            this.btnHSBA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHSBA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHSBA.Location = new System.Drawing.Point(267, 10);
            this.btnHSBA.Margin = new System.Windows.Forms.Padding(10);
            this.btnHSBA.Name = "btnHSBA";
            this.btnHSBA.Size = new System.Drawing.Size(235, 101);
            this.btnHSBA.TabIndex = 1;
            this.btnHSBA.Text = "Hồ sơ bệnh án";
            this.btnHSBA.UseVisualStyleBackColor = false;
            this.btnHSBA.Click += new System.EventHandler(this.btnHSBA_Click);
            // 
            // btnHSBADV
            // 
            this.btnHSBADV.BackColor = System.Drawing.Color.White;
            this.btnHSBADV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHSBADV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHSBADV.Location = new System.Drawing.Point(522, 10);
            this.btnHSBADV.Margin = new System.Windows.Forms.Padding(10);
            this.btnHSBADV.Name = "btnHSBADV";
            this.btnHSBADV.Size = new System.Drawing.Size(237, 101);
            this.btnHSBADV.TabIndex = 2;
            this.btnHSBADV.Text = "Dịch vụ kỹ thuật";
            this.btnHSBADV.UseVisualStyleBackColor = false;
            this.btnHSBADV.Click += new System.EventHandler(this.btnHSBADV_Click);
            // 
            // btnDonThuoc
            // 
            this.btnDonThuoc.BackColor = System.Drawing.Color.White;
            this.btnDonThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonThuoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDonThuoc.Location = new System.Drawing.Point(10, 131);
            this.btnDonThuoc.Margin = new System.Windows.Forms.Padding(10);
            this.btnDonThuoc.Name = "btnDonThuoc";
            this.btnDonThuoc.Size = new System.Drawing.Size(237, 101);
            this.btnDonThuoc.TabIndex = 3;
            this.btnDonThuoc.Text = "Đơn thuốc";
            this.btnDonThuoc.UseVisualStyleBackColor = false;
            this.btnDonThuoc.Click += new System.EventHandler(this.btnDonThuoc_Click);
            // 
            // btnThongBao
            // 
            this.btnThongBao.BackColor = System.Drawing.Color.White;
            this.btnThongBao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongBao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongBao.Location = new System.Drawing.Point(267, 131);
            this.btnThongBao.Margin = new System.Windows.Forms.Padding(10);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Size = new System.Drawing.Size(235, 101);
            this.btnThongBao.TabIndex = 4;
            this.btnThongBao.Text = "Thông báo OLS";
            this.btnThongBao.UseVisualStyleBackColor = false;
            this.btnThongBao.Click += new System.EventHandler(this.btnThongBao_Click);
            // 
            // btnAudit
            // 
            this.btnAudit.BackColor = System.Drawing.Color.White;
            this.btnAudit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAudit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAudit.Location = new System.Drawing.Point(522, 131);
            this.btnAudit.Margin = new System.Windows.Forms.Padding(10);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(237, 101);
            this.btnAudit.TabIndex = 5;
            this.btnAudit.Text = "Audit Log";
            this.btnAudit.UseVisualStyleBackColor = false;
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // lblSecutityNote
            // 
            this.lblSecutityNote.AutoSize = true;
            this.lblSecutityNote.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSecutityNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSecutityNote.Location = new System.Drawing.Point(43, 648);
            this.lblSecutityNote.Name = "lblSecutityNote";
            this.lblSecutityNote.Size = new System.Drawing.Size(481, 25);
            this.lblSecutityNote.TabIndex = 3;
            this.lblSecutityNote.Text = "Dữ liệu được lọc trực tiếp bởi RBAC/VPD/OLS trong Oracle.";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatus.Location = new System.Drawing.Point(43, 680);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 25);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // FormPH2Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1147, 721);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSecutityNote);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pblUserInfo);
            this.Controls.Add(this.flpMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FormPH2Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý y tế - PH2";
            this.Load += new System.EventHandler(this.FormPH2Main_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pblUserInfo.ResumeLayout(false);
            this.pblUserInfo.PerformLayout();
            this.flpMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pblUserInfo;
        private System.Windows.Forms.Label lblCurrentRole;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.Button btnBenhNhan;
        private System.Windows.Forms.Button btnHSBA;
        private System.Windows.Forms.Button btnHSBADV;
        private System.Windows.Forms.Button btnDonThuoc;
        private System.Windows.Forms.Button btnThongBao;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.Label lblSecutityNote;
        private System.Windows.Forms.Label lblStatus;
    }
}