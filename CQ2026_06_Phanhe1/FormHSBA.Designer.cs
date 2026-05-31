namespace CQ2026_06_Phanhe1
{
    partial class FormHSBA
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.dgvHSBA = new System.Windows.Forms.DataGridView();
            this.grpUpdate = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtKetLuan = new System.Windows.Forms.TextBox();
            this.txtNgay = new System.Windows.Forms.TextBox();
            this.txtDieuTri = new System.Windows.Forms.TextBox();
            this.txtMaKhoa = new System.Windows.Forms.TextBox();
            this.txtChanDoan = new System.Windows.Forms.TextBox();
            this.txtMaBN = new System.Windows.Forms.TextBox();
            this.txtMaHSBA = new System.Windows.Forms.TextBox();
            this.txtMaBS = new System.Windows.Forms.TextBox();
            this.lblKetLuan = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblDieuTri = new System.Windows.Forms.Label();
            this.lblChanDoan = new System.Windows.Forms.Label();
            this.lblMaKhoa = new System.Windows.Forms.Label();
            this.lbMaBS = new System.Windows.Forms.Label();
            this.lblMaBN = new System.Windows.Forms.Label();
            this.lblMaHSBA = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInsertHSBA = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHSBA)).BeginInit();
            this.grpUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(329, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ HỒ SƠ BỆNH ÁN";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitle.Location = new System.Drawing.Point(27, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(381, 23);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Dữ liệu được lọc theo RBAC/VPD trong Oracle";
            // 
            // dgvHSBA
            // 
            this.dgvHSBA.AllowUserToAddRows = false;
            this.dgvHSBA.AllowUserToDeleteRows = false;
            this.dgvHSBA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvHSBA.BackgroundColor = System.Drawing.Color.White;
            this.dgvHSBA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHSBA.Location = new System.Drawing.Point(25, 90);
            this.dgvHSBA.MultiSelect = false;
            this.dgvHSBA.Name = "dgvHSBA";
            this.dgvHSBA.ReadOnly = true;
            this.dgvHSBA.RowHeadersWidth = 51;
            this.dgvHSBA.RowTemplate.Height = 24;
            this.dgvHSBA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHSBA.Size = new System.Drawing.Size(1020, 270);
            this.dgvHSBA.TabIndex = 6;
            this.dgvHSBA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHSBA_CellClick);
            this.dgvHSBA.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHSBA_CellContentClick);
            // 
            // grpUpdate
            // 
            this.grpUpdate.Controls.Add(this.lblStatus);
            this.grpUpdate.Controls.Add(this.btnClose);
            this.grpUpdate.Controls.Add(this.btnUpdate);
            this.grpUpdate.Controls.Add(this.txtKetLuan);
            this.grpUpdate.Controls.Add(this.txtNgay);
            this.grpUpdate.Controls.Add(this.txtDieuTri);
            this.grpUpdate.Controls.Add(this.txtMaKhoa);
            this.grpUpdate.Controls.Add(this.txtChanDoan);
            this.grpUpdate.Controls.Add(this.txtMaBN);
            this.grpUpdate.Controls.Add(this.txtMaHSBA);
            this.grpUpdate.Controls.Add(this.txtMaBS);
            this.grpUpdate.Controls.Add(this.lblKetLuan);
            this.grpUpdate.Controls.Add(this.lblNgay);
            this.grpUpdate.Controls.Add(this.lblDieuTri);
            this.grpUpdate.Controls.Add(this.lblChanDoan);
            this.grpUpdate.Controls.Add(this.lblMaKhoa);
            this.grpUpdate.Controls.Add(this.lbMaBS);
            this.grpUpdate.Controls.Add(this.lblMaBN);
            this.grpUpdate.Controls.Add(this.lblMaHSBA);
            this.grpUpdate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grpUpdate.Location = new System.Drawing.Point(25, 380);
            this.grpUpdate.Name = "grpUpdate";
            this.grpUpdate.Size = new System.Drawing.Size(1020, 260);
            this.grpUpdate.TabIndex = 7;
            this.grpUpdate.TabStop = false;
            this.grpUpdate.Text = "Thông tin cập nhật";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatus.Location = new System.Drawing.Point(530, 217);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 23);
            this.lblStatus.TabIndex = 20;
            this.lblStatus.Text = "Status";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(910, 210);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 36);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(720, 210);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(175, 36);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Cập nhật hồ sơ";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtKetLuan
            // 
            this.txtKetLuan.Location = new System.Drawing.Point(825, 115);
            this.txtKetLuan.Multiline = true;
            this.txtKetLuan.Name = "txtKetLuan";
            this.txtKetLuan.Size = new System.Drawing.Size(170, 70);
            this.txtKetLuan.TabIndex = 17;
            // 
            // txtNgay
            // 
            this.txtNgay.Location = new System.Drawing.Point(720, 32);
            this.txtNgay.Multiline = true;
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.ReadOnly = true;
            this.txtNgay.Size = new System.Drawing.Size(180, 30);
            this.txtNgay.TabIndex = 16;
            // 
            // txtDieuTri
            // 
            this.txtDieuTri.Location = new System.Drawing.Point(490, 115);
            this.txtDieuTri.Multiline = true;
            this.txtDieuTri.Name = "txtDieuTri";
            this.txtDieuTri.Size = new System.Drawing.Size(240, 70);
            this.txtDieuTri.TabIndex = 15;
            // 
            // txtMaKhoa
            // 
            this.txtMaKhoa.Location = new System.Drawing.Point(430, 72);
            this.txtMaKhoa.Name = "txtMaKhoa";
            this.txtMaKhoa.ReadOnly = true;
            this.txtMaKhoa.Size = new System.Drawing.Size(160, 30);
            this.txtMaKhoa.TabIndex = 14;
            // 
            // txtChanDoan
            // 
            this.txtChanDoan.Location = new System.Drawing.Point(125, 115);
            this.txtChanDoan.Multiline = true;
            this.txtChanDoan.Name = "txtChanDoan";
            this.txtChanDoan.Size = new System.Drawing.Size(260, 70);
            this.txtChanDoan.TabIndex = 12;
            // 
            // txtMaBN
            // 
            this.txtMaBN.Location = new System.Drawing.Point(430, 32);
            this.txtMaBN.Name = "txtMaBN";
            this.txtMaBN.ReadOnly = true;
            this.txtMaBN.Size = new System.Drawing.Size(160, 30);
            this.txtMaBN.TabIndex = 11;
            // 
            // txtMaHSBA
            // 
            this.txtMaHSBA.Location = new System.Drawing.Point(125, 32);
            this.txtMaHSBA.Name = "txtMaHSBA";
            this.txtMaHSBA.ReadOnly = true;
            this.txtMaHSBA.Size = new System.Drawing.Size(160, 30);
            this.txtMaHSBA.TabIndex = 10;
            // 
            // txtMaBS
            // 
            this.txtMaBS.Location = new System.Drawing.Point(125, 72);
            this.txtMaBS.Name = "txtMaBS";
            this.txtMaBS.ReadOnly = true;
            this.txtMaBS.Size = new System.Drawing.Size(160, 30);
            this.txtMaBS.TabIndex = 9;
            // 
            // lblKetLuan
            // 
            this.lblKetLuan.AutoSize = true;
            this.lblKetLuan.Location = new System.Drawing.Point(755, 120);
            this.lblKetLuan.Name = "lblKetLuan";
            this.lblKetLuan.Size = new System.Drawing.Size(76, 23);
            this.lblKetLuan.TabIndex = 7;
            this.lblKetLuan.Text = "Kết luận";
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(635, 35);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(52, 23);
            this.lblNgay.TabIndex = 6;
            this.lblNgay.Text = "Ngày";
            // 
            // lblDieuTri
            // 
            this.lblDieuTri.AutoSize = true;
            this.lblDieuTri.Location = new System.Drawing.Point(410, 120);
            this.lblDieuTri.Name = "lblDieuTri";
            this.lblDieuTri.Size = new System.Drawing.Size(71, 23);
            this.lblDieuTri.TabIndex = 5;
            this.lblDieuTri.Text = "Điều trị";
            // 
            // lblChanDoan
            // 
            this.lblChanDoan.AutoSize = true;
            this.lblChanDoan.Location = new System.Drawing.Point(25, 120);
            this.lblChanDoan.Name = "lblChanDoan";
            this.lblChanDoan.Size = new System.Drawing.Size(95, 23);
            this.lblChanDoan.TabIndex = 4;
            this.lblChanDoan.Text = "Chẩn đoán";
            // 
            // lblMaKhoa
            // 
            this.lblMaKhoa.AutoSize = true;
            this.lblMaKhoa.Location = new System.Drawing.Point(330, 75);
            this.lblMaKhoa.Name = "lblMaKhoa";
            this.lblMaKhoa.Size = new System.Drawing.Size(80, 23);
            this.lblMaKhoa.TabIndex = 3;
            this.lblMaKhoa.Text = "Mã Khoa";
            // 
            // lbMaBS
            // 
            this.lbMaBS.AutoSize = true;
            this.lbMaBS.Location = new System.Drawing.Point(25, 75);
            this.lbMaBS.Name = "lbMaBS";
            this.lbMaBS.Size = new System.Drawing.Size(61, 23);
            this.lbMaBS.TabIndex = 2;
            this.lbMaBS.Text = "Mã BS";
            // 
            // lblMaBN
            // 
            this.lblMaBN.AutoSize = true;
            this.lblMaBN.Location = new System.Drawing.Point(330, 35);
            this.lblMaBN.Name = "lblMaBN";
            this.lblMaBN.Size = new System.Drawing.Size(64, 23);
            this.lblMaBN.TabIndex = 1;
            this.lblMaBN.Text = "Mã BN";
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
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(859, 23);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 36);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Nhập mới";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInsertHSBA
            // 
            this.btnInsertHSBA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnInsertHSBA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertHSBA.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnInsertHSBA.ForeColor = System.Drawing.Color.White;
            this.btnInsertHSBA.Location = new System.Drawing.Point(716, 23);
            this.btnInsertHSBA.Name = "btnInsertHSBA";
            this.btnInsertHSBA.Size = new System.Drawing.Size(122, 36);
            this.btnInsertHSBA.TabIndex = 10;
            this.btnInsertHSBA.Text = "Thêm HSBA";
            this.btnInsertHSBA.UseVisualStyleBackColor = false;
            this.btnInsertHSBA.Click += new System.EventHandler(this.btnInsertHSBA_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(589, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(463, 23);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(110, 36);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "Tải dữ liệu";
            this.btnLoad.UseVisualStyleBackColor = false;
            // 
            // FormHSBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnInsertHSBA);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.grpUpdate);
            this.Controls.Add(this.dgvHSBA);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormHSBA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hồ sơ bệnh án";
            this.Click += new System.EventHandler(this.FormHSBA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHSBA)).EndInit();
            this.grpUpdate.ResumeLayout(false);
            this.grpUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.DataGridView dgvHSBA;
        private System.Windows.Forms.GroupBox grpUpdate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtKetLuan;
        private System.Windows.Forms.TextBox txtNgay;
        private System.Windows.Forms.TextBox txtDieuTri;
        private System.Windows.Forms.TextBox txtMaKhoa;
        private System.Windows.Forms.TextBox txtChanDoan;
        private System.Windows.Forms.TextBox txtMaBN;
        private System.Windows.Forms.TextBox txtMaHSBA;
        private System.Windows.Forms.TextBox txtMaBS;
        private System.Windows.Forms.Label lblKetLuan;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.Label lblDieuTri;
        private System.Windows.Forms.Label lblChanDoan;
        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.Label lbMaBS;
        private System.Windows.Forms.Label lblMaBN;
        private System.Windows.Forms.Label lblMaHSBA;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInsertHSBA;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLoad;
    }
}