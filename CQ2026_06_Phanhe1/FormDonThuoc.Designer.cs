namespace CQ2026_06_Phanhe1
{
    partial class FormDonThuoc
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvDonThuoc = new System.Windows.Forms.DataGridView();
            this.grpUpdate = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtLieuDung = new System.Windows.Forms.TextBox();
            this.txtNgayDT = new System.Windows.Forms.TextBox();
            this.txtMaHSBA = new System.Windows.Forms.TextBox();
            this.txtTenThuoc = new System.Windows.Forms.TextBox();
            this.lblLieuDung = new System.Windows.Forms.Label();
            this.lblTenThuoc = new System.Windows.Forms.Label();
            this.lblNgayDT = new System.Windows.Forms.Label();
            this.lblMaHSBA = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonThuoc)).BeginInit();
            this.grpUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(892, 31);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 38);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(762, 31);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(115, 38);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "Tải dữ liệu";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitle.Location = new System.Drawing.Point(27, 56);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(600, 23);
            this.lblSubtitle.TabIndex = 7;
            this.lblSubtitle.Text = "Dữ liệu được lọc theo RBAC/VPD, thao tác cập nhật được audit bằng FGA";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(282, 35);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "QUẢN LÝ ĐƠN THUỐC";
            // 
            // dgvDonThuoc
            // 
            this.dgvDonThuoc.AllowUserToAddRows = false;
            this.dgvDonThuoc.AllowUserToDeleteRows = false;
            this.dgvDonThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonThuoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvDonThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonThuoc.Location = new System.Drawing.Point(31, 102);
            this.dgvDonThuoc.MultiSelect = false;
            this.dgvDonThuoc.Name = "dgvDonThuoc";
            this.dgvDonThuoc.ReadOnly = true;
            this.dgvDonThuoc.RowHeadersWidth = 51;
            this.dgvDonThuoc.RowTemplate.Height = 24;
            this.dgvDonThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonThuoc.Size = new System.Drawing.Size(976, 180);
            this.dgvDonThuoc.TabIndex = 10;
            this.dgvDonThuoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonThuoc_CellClick);
            this.dgvDonThuoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonThuoc_CellContentClick);
            // 
            // grpUpdate
            // 
            this.grpUpdate.Controls.Add(this.lblStatus);
            this.grpUpdate.Controls.Add(this.btnClose);
            this.grpUpdate.Controls.Add(this.btnUpdate);
            this.grpUpdate.Controls.Add(this.txtLieuDung);
            this.grpUpdate.Controls.Add(this.txtNgayDT);
            this.grpUpdate.Controls.Add(this.txtMaHSBA);
            this.grpUpdate.Controls.Add(this.txtTenThuoc);
            this.grpUpdate.Controls.Add(this.lblLieuDung);
            this.grpUpdate.Controls.Add(this.lblTenThuoc);
            this.grpUpdate.Controls.Add(this.lblNgayDT);
            this.grpUpdate.Controls.Add(this.lblMaHSBA);
            this.grpUpdate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grpUpdate.Location = new System.Drawing.Point(31, 358);
            this.grpUpdate.Name = "grpUpdate";
            this.grpUpdate.Size = new System.Drawing.Size(976, 210);
            this.grpUpdate.TabIndex = 14;
            this.grpUpdate.TabStop = false;
            this.grpUpdate.Text = "Thông tin dịch vụ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatus.Location = new System.Drawing.Point(25, 158);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 23);
            this.lblStatus.TabIndex = 21;
            this.lblStatus.Text = "Status";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(861, 122);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 36);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(671, 119);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(176, 39);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Cập nhật liều dùng";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtLieuDung
            // 
            this.txtLieuDung.Location = new System.Drawing.Point(125, 116);
            this.txtLieuDung.Multiline = true;
            this.txtLieuDung.Name = "txtLieuDung";
            this.txtLieuDung.Size = new System.Drawing.Size(540, 38);
            this.txtLieuDung.TabIndex = 14;
            // 
            // txtNgayDT
            // 
            this.txtNgayDT.Location = new System.Drawing.Point(445, 32);
            this.txtNgayDT.Name = "txtNgayDT";
            this.txtNgayDT.ReadOnly = true;
            this.txtNgayDT.Size = new System.Drawing.Size(220, 30);
            this.txtNgayDT.TabIndex = 11;
            // 
            // txtMaHSBA
            // 
            this.txtMaHSBA.Location = new System.Drawing.Point(125, 32);
            this.txtMaHSBA.Name = "txtMaHSBA";
            this.txtMaHSBA.ReadOnly = true;
            this.txtMaHSBA.Size = new System.Drawing.Size(170, 30);
            this.txtMaHSBA.TabIndex = 10;
            // 
            // txtTenThuoc
            // 
            this.txtTenThuoc.Location = new System.Drawing.Point(125, 72);
            this.txtTenThuoc.Name = "txtTenThuoc";
            this.txtTenThuoc.ReadOnly = true;
            this.txtTenThuoc.Size = new System.Drawing.Size(540, 30);
            this.txtTenThuoc.TabIndex = 9;
            // 
            // lblLieuDung
            // 
            this.lblLieuDung.AutoSize = true;
            this.lblLieuDung.Location = new System.Drawing.Point(25, 119);
            this.lblLieuDung.Name = "lblLieuDung";
            this.lblLieuDung.Size = new System.Drawing.Size(92, 23);
            this.lblLieuDung.TabIndex = 3;
            this.lblLieuDung.Text = "Liều Dùng";
            // 
            // lblTenThuoc
            // 
            this.lblTenThuoc.AutoSize = true;
            this.lblTenThuoc.Location = new System.Drawing.Point(25, 75);
            this.lblTenThuoc.Name = "lblTenThuoc";
            this.lblTenThuoc.Size = new System.Drawing.Size(87, 23);
            this.lblTenThuoc.TabIndex = 2;
            this.lblTenThuoc.Text = "Tên thuốc";
            // 
            // lblNgayDT
            // 
            this.lblNgayDT.AutoSize = true;
            this.lblNgayDT.Location = new System.Drawing.Point(330, 35);
            this.lblNgayDT.Name = "lblNgayDT";
            this.lblNgayDT.Size = new System.Drawing.Size(80, 23);
            this.lblNgayDT.TabIndex = 1;
            this.lblNgayDT.Text = "Ngày ĐT";
            // 
            // lblMaHSBA
            // 
            this.lblMaHSBA.AutoSize = true;
            this.lblMaHSBA.Location = new System.Drawing.Point(25, 35);
            this.lblMaHSBA.Name = "lblMaHSBA";
            this.lblMaHSBA.Size = new System.Drawing.Size(86, 23);
            this.lblMaHSBA.TabIndex = 0;
            this.lblMaHSBA.Text = "Mã HSBA";
            // 
            // FormDonThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 612);
            this.Controls.Add(this.grpUpdate);
            this.Controls.Add(this.dgvDonThuoc);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormDonThuoc";
            this.Text = "Quản lý đơn thuốc";
            this.Click += new System.EventHandler(this.FormDonThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonThuoc)).EndInit();
            this.grpUpdate.ResumeLayout(false);
            this.grpUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvDonThuoc;
        private System.Windows.Forms.GroupBox grpUpdate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtLieuDung;
        private System.Windows.Forms.TextBox txtNgayDT;
        private System.Windows.Forms.TextBox txtMaHSBA;
        private System.Windows.Forms.TextBox txtTenThuoc;
        private System.Windows.Forms.Label lblLieuDung;
        private System.Windows.Forms.Label lblTenThuoc;
        private System.Windows.Forms.Label lblNgayDT;
        private System.Windows.Forms.Label lblMaHSBA;
    }
}