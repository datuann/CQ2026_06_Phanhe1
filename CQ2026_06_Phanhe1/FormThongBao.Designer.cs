namespace CQ2026_06_Phanhe1
{
    partial class FormThongBao
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
            this.dgvThongBao = new System.Windows.Forms.DataGridView();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.txtNgayGio = new System.Windows.Forms.TextBox();
            this.txtMaTB = new System.Windows.Forms.TextBox();
            this.txtDiaDiem = new System.Windows.Forms.TextBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.lblDiaDiem = new System.Windows.Forms.Label();
            this.lblNgayGio = new System.Windows.Forms.Label();
            this.lblMaTB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).BeginInit();
            this.grpDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(894, 38);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 38);
            this.btnRefresh.TabIndex = 13;
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
            this.btnLoad.Location = new System.Drawing.Point(764, 38);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(115, 38);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "Tải dữ liệu";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitle.Location = new System.Drawing.Point(29, 63);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(357, 23);
            this.lblSubtitle.TabIndex = 11;
            this.lblSubtitle.Text = "Dữ liệu được lọc theo Oracle Label Security";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.Location = new System.Drawing.Point(27, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(332, 35);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "THÔNG BÁO NỘI BỘ - OLS";
            // 
            // dgvThongBao
            // 
            this.dgvThongBao.AllowUserToAddRows = false;
            this.dgvThongBao.AllowUserToDeleteRows = false;
            this.dgvThongBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongBao.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongBao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongBao.Location = new System.Drawing.Point(33, 120);
            this.dgvThongBao.MultiSelect = false;
            this.dgvThongBao.Name = "dgvThongBao";
            this.dgvThongBao.ReadOnly = true;
            this.dgvThongBao.RowHeadersWidth = 51;
            this.dgvThongBao.RowTemplate.Height = 24;
            this.dgvThongBao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongBao.Size = new System.Drawing.Size(976, 180);
            this.dgvThongBao.TabIndex = 14;
            this.dgvThongBao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongBao_CellClick);
            this.dgvThongBao.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongBao_CellContentClick);
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.lblStatus);
            this.grpDetail.Controls.Add(this.btnClose);
            this.grpDetail.Controls.Add(this.txtNoiDung);
            this.grpDetail.Controls.Add(this.txtNgayGio);
            this.grpDetail.Controls.Add(this.txtMaTB);
            this.grpDetail.Controls.Add(this.txtDiaDiem);
            this.grpDetail.Controls.Add(this.lblNoiDung);
            this.grpDetail.Controls.Add(this.lblDiaDiem);
            this.grpDetail.Controls.Add(this.lblNgayGio);
            this.grpDetail.Controls.Add(this.lblMaTB);
            this.grpDetail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grpDetail.Location = new System.Drawing.Point(33, 353);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(976, 210);
            this.grpDetail.TabIndex = 15;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Chi tiết thông báo";
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
            this.btnClose.Location = new System.Drawing.Point(739, 151);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 36);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(125, 116);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.ReadOnly = true;
            this.txtNoiDung.Size = new System.Drawing.Size(540, 38);
            this.txtNoiDung.TabIndex = 14;
            // 
            // txtNgayGio
            // 
            this.txtNgayGio.Location = new System.Drawing.Point(445, 32);
            this.txtNgayGio.Name = "txtNgayGio";
            this.txtNgayGio.ReadOnly = true;
            this.txtNgayGio.Size = new System.Drawing.Size(220, 30);
            this.txtNgayGio.TabIndex = 11;
            // 
            // txtMaTB
            // 
            this.txtMaTB.Location = new System.Drawing.Point(125, 32);
            this.txtMaTB.Name = "txtMaTB";
            this.txtMaTB.ReadOnly = true;
            this.txtMaTB.Size = new System.Drawing.Size(170, 30);
            this.txtMaTB.TabIndex = 10;
            // 
            // txtDiaDiem
            // 
            this.txtDiaDiem.Location = new System.Drawing.Point(125, 72);
            this.txtDiaDiem.Name = "txtDiaDiem";
            this.txtDiaDiem.ReadOnly = true;
            this.txtDiaDiem.Size = new System.Drawing.Size(540, 30);
            this.txtDiaDiem.TabIndex = 9;
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new System.Drawing.Point(25, 119);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(85, 23);
            this.lblNoiDung.TabIndex = 3;
            this.lblNoiDung.Text = "Nội dung";
            // 
            // lblDiaDiem
            // 
            this.lblDiaDiem.AutoSize = true;
            this.lblDiaDiem.Location = new System.Drawing.Point(25, 75);
            this.lblDiaDiem.Name = "lblDiaDiem";
            this.lblDiaDiem.Size = new System.Drawing.Size(83, 23);
            this.lblDiaDiem.TabIndex = 2;
            this.lblDiaDiem.Text = "Địa điểm";
            // 
            // lblNgayGio
            // 
            this.lblNgayGio.AutoSize = true;
            this.lblNgayGio.Location = new System.Drawing.Point(330, 35);
            this.lblNgayGio.Name = "lblNgayGio";
            this.lblNgayGio.Size = new System.Drawing.Size(84, 23);
            this.lblNgayGio.TabIndex = 1;
            this.lblNgayGio.Text = "Ngày giờ";
            // 
            // lblMaTB
            // 
            this.lblMaTB.AutoSize = true;
            this.lblMaTB.Location = new System.Drawing.Point(25, 35);
            this.lblMaTB.Name = "lblMaTB";
            this.lblMaTB.Size = new System.Drawing.Size(61, 23);
            this.lblMaTB.TabIndex = 0;
            this.lblMaTB.Text = "Mã TB";
            // 
            // FormThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 613);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.dgvThongBao);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormThongBao";
            this.Text = "Thông báo nội bộ";
            this.Click += new System.EventHandler(this.FormThongBao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvThongBao;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.TextBox txtNgayGio;
        private System.Windows.Forms.TextBox txtMaTB;
        private System.Windows.Forms.TextBox txtDiaDiem;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Label lblDiaDiem;
        private System.Windows.Forms.Label lblNgayGio;
        private System.Windows.Forms.Label lblMaTB;
    }
}