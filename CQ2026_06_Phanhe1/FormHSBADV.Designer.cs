namespace CQ2026_06_Phanhe1
{
    partial class FormHSBADV
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
            this.grpUpdate = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtMaKT = new System.Windows.Forms.TextBox();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.txtLoaiDV = new System.Windows.Forms.TextBox();
            this.txtMaHSBA = new System.Windows.Forms.TextBox();
            this.txtNgayDV = new System.Windows.Forms.TextBox();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.lblMaKT = new System.Windows.Forms.Label();
            this.lblNgayDV = new System.Windows.Forms.Label();
            this.lblLoaiDV = new System.Windows.Forms.Label();
            this.lblMaHSBA = new System.Windows.Forms.Label();
            this.dgvHSBADV = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnDeleteDV = new System.Windows.Forms.Button();
            this.btnInsertDV = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHSBADV)).BeginInit();
            this.SuspendLayout();
            // 
            // grpUpdate
            // 
            this.grpUpdate.Controls.Add(this.lblStatus);
            this.grpUpdate.Controls.Add(this.btnClose);
            this.grpUpdate.Controls.Add(this.btnUpdate);
            this.grpUpdate.Controls.Add(this.txtMaKT);
            this.grpUpdate.Controls.Add(this.txtKetQua);
            this.grpUpdate.Controls.Add(this.txtLoaiDV);
            this.grpUpdate.Controls.Add(this.txtMaHSBA);
            this.grpUpdate.Controls.Add(this.txtNgayDV);
            this.grpUpdate.Controls.Add(this.lblKetQua);
            this.grpUpdate.Controls.Add(this.lblMaKT);
            this.grpUpdate.Controls.Add(this.lblNgayDV);
            this.grpUpdate.Controls.Add(this.lblLoaiDV);
            this.grpUpdate.Controls.Add(this.lblMaHSBA);
            this.grpUpdate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grpUpdate.Location = new System.Drawing.Point(25, 397);
            this.grpUpdate.Name = "grpUpdate";
            this.grpUpdate.Size = new System.Drawing.Size(990, 210);
            this.grpUpdate.TabIndex = 13;
            this.grpUpdate.TabStop = false;
            this.grpUpdate.Text = "Thông tin dịch vụ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatus.Location = new System.Drawing.Point(671, 175);
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
            this.btnClose.Location = new System.Drawing.Point(849, 121);
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
            this.btnUpdate.Location = new System.Drawing.Point(675, 120);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(159, 39);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Cập nhật kết quả";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtMaKT
            // 
            this.txtMaKT.Location = new System.Drawing.Point(445, 74);
            this.txtMaKT.Name = "txtMaKT";
            this.txtMaKT.ReadOnly = true;
            this.txtMaKT.Size = new System.Drawing.Size(220, 30);
            this.txtMaKT.TabIndex = 14;
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(121, 116);
            this.txtKetQua.Multiline = true;
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(544, 60);
            this.txtKetQua.TabIndex = 12;
            // 
            // txtLoaiDV
            // 
            this.txtLoaiDV.Location = new System.Drawing.Point(445, 32);
            this.txtLoaiDV.Name = "txtLoaiDV";
            this.txtLoaiDV.ReadOnly = true;
            this.txtLoaiDV.Size = new System.Drawing.Size(220, 30);
            this.txtLoaiDV.TabIndex = 11;
            // 
            // txtMaHSBA
            // 
            this.txtMaHSBA.Location = new System.Drawing.Point(125, 32);
            this.txtMaHSBA.Name = "txtMaHSBA";
            this.txtMaHSBA.ReadOnly = true;
            this.txtMaHSBA.Size = new System.Drawing.Size(170, 30);
            this.txtMaHSBA.TabIndex = 10;
            // 
            // txtNgayDV
            // 
            this.txtNgayDV.Location = new System.Drawing.Point(125, 72);
            this.txtNgayDV.Name = "txtNgayDV";
            this.txtNgayDV.ReadOnly = true;
            this.txtNgayDV.Size = new System.Drawing.Size(170, 30);
            this.txtNgayDV.TabIndex = 9;
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(25, 120);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(72, 23);
            this.lblKetQua.TabIndex = 4;
            this.lblKetQua.Text = "Kết quả";
            // 
            // lblMaKT
            // 
            this.lblMaKT.AutoSize = true;
            this.lblMaKT.Location = new System.Drawing.Point(330, 75);
            this.lblMaKT.Name = "lblMaKT";
            this.lblMaKT.Size = new System.Drawing.Size(61, 23);
            this.lblMaKT.TabIndex = 3;
            this.lblMaKT.Text = "Mã KT";
            // 
            // lblNgayDV
            // 
            this.lblNgayDV.AutoSize = true;
            this.lblNgayDV.Location = new System.Drawing.Point(25, 75);
            this.lblNgayDV.Name = "lblNgayDV";
            this.lblNgayDV.Size = new System.Drawing.Size(81, 23);
            this.lblNgayDV.TabIndex = 2;
            this.lblNgayDV.Text = "Ngày DV";
            // 
            // lblLoaiDV
            // 
            this.lblLoaiDV.AutoSize = true;
            this.lblLoaiDV.Location = new System.Drawing.Point(330, 35);
            this.lblLoaiDV.Name = "lblLoaiDV";
            this.lblLoaiDV.Size = new System.Drawing.Size(72, 23);
            this.lblLoaiDV.TabIndex = 1;
            this.lblLoaiDV.Text = "Loại DV";
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
            // dgvHSBADV
            // 
            this.dgvHSBADV.AllowUserToAddRows = false;
            this.dgvHSBADV.AllowUserToDeleteRows = false;
            this.dgvHSBADV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvHSBADV.BackgroundColor = System.Drawing.Color.White;
            this.dgvHSBADV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHSBADV.Location = new System.Drawing.Point(25, 85);
            this.dgvHSBADV.MultiSelect = false;
            this.dgvHSBADV.Name = "dgvHSBADV";
            this.dgvHSBADV.ReadOnly = true;
            this.dgvHSBADV.RowHeadersWidth = 51;
            this.dgvHSBADV.RowTemplate.Height = 24;
            this.dgvHSBADV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHSBADV.Size = new System.Drawing.Size(990, 280);
            this.dgvHSBADV.TabIndex = 12;
            this.dgvHSBADV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHSBADV_CellClick);
            this.dgvHSBADV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHSBADV_CellContentClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(531, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 38);
            this.btnRefresh.TabIndex = 11;
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
            this.btnLoad.Location = new System.Drawing.Point(410, 11);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(115, 38);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Tải dữ liệu";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitle.Location = new System.Drawing.Point(8, 41);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(381, 23);
            this.lblSubtitle.TabIndex = 9;
            this.lblSubtitle.Text = "Dữ liệu được lọc theo RBAC/VPD trong Oracle";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.Location = new System.Drawing.Point(6, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(364, 35);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "QUẢN LÝ DỊCH VỤ KỸ THUẬT";
            // 
            // btnDeleteDV
            // 
            this.btnDeleteDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnDeleteDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDV.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDeleteDV.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDV.Location = new System.Drawing.Point(797, 11);
            this.btnDeleteDV.Name = "btnDeleteDV";
            this.btnDeleteDV.Size = new System.Drawing.Size(110, 36);
            this.btnDeleteDV.TabIndex = 15;
            this.btnDeleteDV.Text = "Xóa dịch vụ";
            this.btnDeleteDV.UseVisualStyleBackColor = false;
            this.btnDeleteDV.Click += new System.EventHandler(this.btnDeleteDV_Click);
            // 
            // btnInsertDV
            // 
            this.btnInsertDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnInsertDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertDV.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnInsertDV.ForeColor = System.Drawing.Color.White;
            this.btnInsertDV.Location = new System.Drawing.Point(652, 11);
            this.btnInsertDV.Name = "btnInsertDV";
            this.btnInsertDV.Size = new System.Drawing.Size(137, 36);
            this.btnInsertDV.TabIndex = 14;
            this.btnInsertDV.Text = "Thêm dịch vụ";
            this.btnInsertDV.UseVisualStyleBackColor = false;
            this.btnInsertDV.Click += new System.EventHandler(this.btnInsertDV_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(913, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 36);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Nhập mới";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FormHSBADV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 633);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDeleteDV);
            this.Controls.Add(this.btnInsertDV);
            this.Controls.Add(this.grpUpdate);
            this.Controls.Add(this.dgvHSBADV);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormHSBADV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý dịch vụ kỹ thuật";
            this.Click += new System.EventHandler(this.FormHSBADV_Load);
            this.grpUpdate.ResumeLayout(false);
            this.grpUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHSBADV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUpdate;
        private System.Windows.Forms.TextBox txtMaKT;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.TextBox txtLoaiDV;
        private System.Windows.Forms.TextBox txtMaHSBA;
        private System.Windows.Forms.TextBox txtNgayDV;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Label lblMaKT;
        private System.Windows.Forms.Label lblNgayDV;
        private System.Windows.Forms.Label lblLoaiDV;
        private System.Windows.Forms.Label lblMaHSBA;
        private System.Windows.Forms.DataGridView dgvHSBADV;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnDeleteDV;
        private System.Windows.Forms.Button btnInsertDV;
        private System.Windows.Forms.Button btnClear;
    }
}