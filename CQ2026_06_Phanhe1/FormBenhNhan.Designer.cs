namespace CQ2026_06_Phanhe1
{
    partial class FormBenhNhan
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvBenhNhan = new System.Windows.Forms.DataGridView();
            this.grpUpdate = new System.Windows.Forms.GroupBox();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.txtPhai = new System.Windows.Forms.TextBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblPhai = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtTienSuBenhGD = new System.Windows.Forms.TextBox();
            this.txtTienSuBenh = new System.Windows.Forms.TextBox();
            this.txtTinhTP = new System.Windows.Forms.TextBox();
            this.txtTenDuong = new System.Windows.Forms.TextBox();
            this.txtDiUngThuoc = new System.Windows.Forms.TextBox();
            this.txtQuanHuyen = new System.Windows.Forms.TextBox();
            this.txtTenBN = new System.Windows.Forms.TextBox();
            this.txtMaBN = new System.Windows.Forms.TextBox();
            this.txtSoNha = new System.Windows.Forms.TextBox();
            this.lblDiUngThuoc = new System.Windows.Forms.Label();
            this.lblTienSuBenhGD = new System.Windows.Forms.Label();
            this.lblTienSuBenh = new System.Windows.Forms.Label();
            this.lblTinhTP = new System.Windows.Forms.Label();
            this.lblQuanHuyen = new System.Windows.Forms.Label();
            this.lblTenDuong = new System.Windows.Forms.Label();
            this.lblSoNha = new System.Windows.Forms.Label();
            this.lblTenBN = new System.Windows.Forms.Label();
            this.lblMaBN = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBenhNhan)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(431, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ THÔNG TIN BỆNH NHÂN";
            this.lblTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitle.Location = new System.Drawing.Point(27, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(381, 23);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Dữ liệu được lọc theo RBAC/VPD trong Oracle";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(486, 23);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(110, 36);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Tải dữ liệu";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(611, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvBenhNhan
            // 
            this.dgvBenhNhan.AllowUserToAddRows = false;
            this.dgvBenhNhan.AllowUserToDeleteRows = false;
            this.dgvBenhNhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvBenhNhan.BackgroundColor = System.Drawing.Color.White;
            this.dgvBenhNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBenhNhan.Location = new System.Drawing.Point(25, 90);
            this.dgvBenhNhan.MultiSelect = false;
            this.dgvBenhNhan.Name = "dgvBenhNhan";
            this.dgvBenhNhan.ReadOnly = true;
            this.dgvBenhNhan.RowHeadersWidth = 51;
            this.dgvBenhNhan.RowTemplate.Height = 24;
            this.dgvBenhNhan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBenhNhan.Size = new System.Drawing.Size(1012, 270);
            this.dgvBenhNhan.TabIndex = 4;
            this.dgvBenhNhan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBenhNhan_CellClick);
            this.dgvBenhNhan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBenhNhan_CellContentClick);
            // 
            // grpUpdate
            // 
            this.grpUpdate.Controls.Add(this.txtCCCD);
            this.grpUpdate.Controls.Add(this.txtNgaySinh);
            this.grpUpdate.Controls.Add(this.txtPhai);
            this.grpUpdate.Controls.Add(this.lblCCCD);
            this.grpUpdate.Controls.Add(this.lblNgaySinh);
            this.grpUpdate.Controls.Add(this.lblPhai);
            this.grpUpdate.Controls.Add(this.lblStatus);
            this.grpUpdate.Controls.Add(this.btnClose);
            this.grpUpdate.Controls.Add(this.btnUpdate);
            this.grpUpdate.Controls.Add(this.txtTienSuBenhGD);
            this.grpUpdate.Controls.Add(this.txtTienSuBenh);
            this.grpUpdate.Controls.Add(this.txtTinhTP);
            this.grpUpdate.Controls.Add(this.txtTenDuong);
            this.grpUpdate.Controls.Add(this.txtDiUngThuoc);
            this.grpUpdate.Controls.Add(this.txtQuanHuyen);
            this.grpUpdate.Controls.Add(this.txtTenBN);
            this.grpUpdate.Controls.Add(this.txtMaBN);
            this.grpUpdate.Controls.Add(this.txtSoNha);
            this.grpUpdate.Controls.Add(this.lblDiUngThuoc);
            this.grpUpdate.Controls.Add(this.lblTienSuBenhGD);
            this.grpUpdate.Controls.Add(this.lblTienSuBenh);
            this.grpUpdate.Controls.Add(this.lblTinhTP);
            this.grpUpdate.Controls.Add(this.lblQuanHuyen);
            this.grpUpdate.Controls.Add(this.lblTenDuong);
            this.grpUpdate.Controls.Add(this.lblSoNha);
            this.grpUpdate.Controls.Add(this.lblTenBN);
            this.grpUpdate.Controls.Add(this.lblMaBN);
            this.grpUpdate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grpUpdate.Location = new System.Drawing.Point(25, 380);
            this.grpUpdate.Name = "grpUpdate";
            this.grpUpdate.Size = new System.Drawing.Size(1012, 288);
            this.grpUpdate.TabIndex = 5;
            this.grpUpdate.TabStop = false;
            this.grpUpdate.Text = "Thông tin cập nhật";
            this.grpUpdate.Enter += new System.EventHandler(this.grpUpdate_Enter);
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(430, 78);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.ReadOnly = true;
            this.txtCCCD.Size = new System.Drawing.Size(160, 30);
            this.txtCCCD.TabIndex = 26;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Location = new System.Drawing.Point(125, 81);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.ReadOnly = true;
            this.txtNgaySinh.Size = new System.Drawing.Size(160, 30);
            this.txtNgaySinh.TabIndex = 25;
            // 
            // txtPhai
            // 
            this.txtPhai.Location = new System.Drawing.Point(771, 35);
            this.txtPhai.Name = "txtPhai";
            this.txtPhai.ReadOnly = true;
            this.txtPhai.Size = new System.Drawing.Size(160, 30);
            this.txtPhai.TabIndex = 24;
            // 
            // lblCCCD
            // 
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Location = new System.Drawing.Point(330, 81);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(54, 23);
            this.lblCCCD.TabIndex = 23;
            this.lblCCCD.Text = "CCCD";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(10, 81);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(89, 23);
            this.lblNgaySinh.TabIndex = 22;
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // lblPhai
            // 
            this.lblPhai.AutoSize = true;
            this.lblPhai.Location = new System.Drawing.Point(700, 35);
            this.lblPhai.Name = "lblPhai";
            this.lblPhai.Size = new System.Drawing.Size(44, 23);
            this.lblPhai.TabIndex = 21;
            this.lblPhai.Text = "Phái";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatus.Location = new System.Drawing.Point(526, 249);
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
            this.btnClose.Location = new System.Drawing.Point(871, 239);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
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
            this.btnUpdate.Location = new System.Drawing.Point(687, 239);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(174, 33);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Cập nhật thông tin";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtTienSuBenhGD
            // 
            this.txtTienSuBenhGD.Location = new System.Drawing.Point(700, 181);
            this.txtTienSuBenhGD.Multiline = true;
            this.txtTienSuBenhGD.Name = "txtTienSuBenhGD";
            this.txtTienSuBenhGD.Size = new System.Drawing.Size(250, 45);
            this.txtTienSuBenhGD.TabIndex = 17;
            // 
            // txtTienSuBenh
            // 
            this.txtTienSuBenh.Location = new System.Drawing.Point(700, 106);
            this.txtTienSuBenh.Multiline = true;
            this.txtTienSuBenh.Name = "txtTienSuBenh";
            this.txtTienSuBenh.Size = new System.Drawing.Size(250, 45);
            this.txtTienSuBenh.TabIndex = 16;
            // 
            // txtTinhTP
            // 
            this.txtTinhTP.Location = new System.Drawing.Point(430, 161);
            this.txtTinhTP.Name = "txtTinhTP";
            this.txtTinhTP.Size = new System.Drawing.Size(230, 30);
            this.txtTinhTP.TabIndex = 15;
            // 
            // txtTenDuong
            // 
            this.txtTenDuong.Location = new System.Drawing.Point(430, 121);
            this.txtTenDuong.Name = "txtTenDuong";
            this.txtTenDuong.Size = new System.Drawing.Size(230, 30);
            this.txtTenDuong.TabIndex = 14;
            // 
            // txtDiUngThuoc
            // 
            this.txtDiUngThuoc.Location = new System.Drawing.Point(125, 201);
            this.txtDiUngThuoc.Multiline = true;
            this.txtDiUngThuoc.Name = "txtDiUngThuoc";
            this.txtDiUngThuoc.Size = new System.Drawing.Size(535, 45);
            this.txtDiUngThuoc.TabIndex = 13;
            // 
            // txtQuanHuyen
            // 
            this.txtQuanHuyen.Location = new System.Drawing.Point(125, 161);
            this.txtQuanHuyen.Name = "txtQuanHuyen";
            this.txtQuanHuyen.Size = new System.Drawing.Size(160, 30);
            this.txtQuanHuyen.TabIndex = 12;
            // 
            // txtTenBN
            // 
            this.txtTenBN.Location = new System.Drawing.Point(430, 32);
            this.txtTenBN.Name = "txtTenBN";
            this.txtTenBN.ReadOnly = true;
            this.txtTenBN.Size = new System.Drawing.Size(230, 30);
            this.txtTenBN.TabIndex = 11;
            // 
            // txtMaBN
            // 
            this.txtMaBN.Location = new System.Drawing.Point(125, 32);
            this.txtMaBN.Name = "txtMaBN";
            this.txtMaBN.ReadOnly = true;
            this.txtMaBN.Size = new System.Drawing.Size(160, 30);
            this.txtMaBN.TabIndex = 10;
            // 
            // txtSoNha
            // 
            this.txtSoNha.Location = new System.Drawing.Point(125, 121);
            this.txtSoNha.Name = "txtSoNha";
            this.txtSoNha.Size = new System.Drawing.Size(160, 30);
            this.txtSoNha.TabIndex = 9;
            this.txtSoNha.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblDiUngThuoc
            // 
            this.lblDiUngThuoc.AutoSize = true;
            this.lblDiUngThuoc.Location = new System.Drawing.Point(6, 204);
            this.lblDiUngThuoc.Name = "lblDiUngThuoc";
            this.lblDiUngThuoc.Size = new System.Drawing.Size(115, 23);
            this.lblDiUngThuoc.TabIndex = 8;
            this.lblDiUngThuoc.Text = "Dị ứng thuốc";
            // 
            // lblTienSuBenhGD
            // 
            this.lblTienSuBenhGD.AutoSize = true;
            this.lblTienSuBenhGD.Location = new System.Drawing.Point(700, 156);
            this.lblTienSuBenhGD.Name = "lblTienSuBenhGD";
            this.lblTienSuBenhGD.Size = new System.Drawing.Size(97, 23);
            this.lblTienSuBenhGD.TabIndex = 7;
            this.lblTienSuBenhGD.Text = "Tiền sử GĐ";
            // 
            // lblTienSuBenh
            // 
            this.lblTienSuBenh.AutoSize = true;
            this.lblTienSuBenh.Location = new System.Drawing.Point(700, 81);
            this.lblTienSuBenh.Name = "lblTienSuBenh";
            this.lblTienSuBenh.Size = new System.Drawing.Size(112, 23);
            this.lblTienSuBenh.TabIndex = 6;
            this.lblTienSuBenh.Text = "Tiền sử bệnh";
            // 
            // lblTinhTP
            // 
            this.lblTinhTP.AutoSize = true;
            this.lblTinhTP.Location = new System.Drawing.Point(330, 164);
            this.lblTinhTP.Name = "lblTinhTP";
            this.lblTinhTP.Size = new System.Drawing.Size(73, 23);
            this.lblTinhTP.TabIndex = 5;
            this.lblTinhTP.Text = "Tỉnh/TP";
            // 
            // lblQuanHuyen
            // 
            this.lblQuanHuyen.AutoSize = true;
            this.lblQuanHuyen.Location = new System.Drawing.Point(10, 161);
            this.lblQuanHuyen.Name = "lblQuanHuyen";
            this.lblQuanHuyen.Size = new System.Drawing.Size(111, 23);
            this.lblQuanHuyen.TabIndex = 4;
            this.lblQuanHuyen.Text = "Quận/Huyện";
            // 
            // lblTenDuong
            // 
            this.lblTenDuong.AutoSize = true;
            this.lblTenDuong.Location = new System.Drawing.Point(330, 124);
            this.lblTenDuong.Name = "lblTenDuong";
            this.lblTenDuong.Size = new System.Drawing.Size(98, 23);
            this.lblTenDuong.TabIndex = 3;
            this.lblTenDuong.Text = "Tên Đường";
            // 
            // lblSoNha
            // 
            this.lblSoNha.AutoSize = true;
            this.lblSoNha.Location = new System.Drawing.Point(10, 124);
            this.lblSoNha.Name = "lblSoNha";
            this.lblSoNha.Size = new System.Drawing.Size(64, 23);
            this.lblSoNha.TabIndex = 2;
            this.lblSoNha.Text = "Số nhà";
            // 
            // lblTenBN
            // 
            this.lblTenBN.AutoSize = true;
            this.lblTenBN.Location = new System.Drawing.Point(330, 35);
            this.lblTenBN.Name = "lblTenBN";
            this.lblTenBN.Size = new System.Drawing.Size(64, 23);
            this.lblTenBN.TabIndex = 1;
            this.lblTenBN.Text = "Họ tên";
            // 
            // lblMaBN
            // 
            this.lblMaBN.AutoSize = true;
            this.lblMaBN.Location = new System.Drawing.Point(10, 35);
            this.lblMaBN.Name = "lblMaBN";
            this.lblMaBN.Size = new System.Drawing.Size(64, 23);
            this.lblMaBN.TabIndex = 0;
            this.lblMaBN.Text = "Mã BN";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(912, 23);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 36);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Nhập mới";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Location = new System.Drawing.Point(738, 23);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(159, 36);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "Thêm bệnh nhân";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // FormBenhNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1072, 696);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.grpUpdate);
            this.Controls.Add(this.dgvBenhNhan);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormBenhNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thông tin bệnh nhân";
            this.Click += new System.EventHandler(this.FormBenhNhanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBenhNhan)).EndInit();
            this.grpUpdate.ResumeLayout(false);
            this.grpUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvBenhNhan;
        private System.Windows.Forms.GroupBox grpUpdate;
        private System.Windows.Forms.Label lblDiUngThuoc;
        private System.Windows.Forms.Label lblTienSuBenhGD;
        private System.Windows.Forms.Label lblTienSuBenh;
        private System.Windows.Forms.Label lblTinhTP;
        private System.Windows.Forms.Label lblQuanHuyen;
        private System.Windows.Forms.Label lblTenDuong;
        private System.Windows.Forms.Label lblSoNha;
        private System.Windows.Forms.Label lblTenBN;
        private System.Windows.Forms.Label lblMaBN;
        private System.Windows.Forms.TextBox txtTienSuBenhGD;
        private System.Windows.Forms.TextBox txtTienSuBenh;
        private System.Windows.Forms.TextBox txtTinhTP;
        private System.Windows.Forms.TextBox txtTenDuong;
        private System.Windows.Forms.TextBox txtDiUngThuoc;
        private System.Windows.Forms.TextBox txtQuanHuyen;
        private System.Windows.Forms.TextBox txtTenBN;
        private System.Windows.Forms.TextBox txtMaBN;
        private System.Windows.Forms.TextBox txtSoNha;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.TextBox txtPhai;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblPhai;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInsert;
    }
}