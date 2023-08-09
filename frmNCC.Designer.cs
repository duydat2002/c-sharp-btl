namespace BTL
{
    partial class frmNCC
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
            this.components = new System.ComponentModel.Container();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvNCC = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.errCheck = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tpChinhSua = new System.Windows.Forms.TabPage();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.tpTimKiem = new System.Windows.Forms.TabPage();
            this.cboMaS = new System.Windows.Forms.ComboBox();
            this.btnHienTatCa = new System.Windows.Forms.Button();
            this.txtEmailS = new System.Windows.Forms.TextBox();
            this.lblEmailS = new System.Windows.Forms.Label();
            this.txtSDTS = new System.Windows.Forms.TextBox();
            this.lblSDTS = new System.Windows.Forms.Label();
            this.txtDiaChiS = new System.Windows.Forms.TextBox();
            this.lblDiaChiS = new System.Windows.Forms.Label();
            this.txtTenS = new System.Windows.Forms.TextBox();
            this.lblTenS = new System.Windows.Forms.Label();
            this.lblMaS = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCheck)).BeginInit();
            this.tabContainer.SuspendLayout();
            this.tpChinhSua.SuspendLayout();
            this.tpTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(589, 49);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(153, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(339, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DANH MỤC NHÀ CUNG CẤP";
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDanhSach.Controls.Add(this.dgvNCC);
            this.grpDanhSach.Location = new System.Drawing.Point(21, 262);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(548, 130);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách nhà cung cấp";
            // 
            // dgvNCC
            // 
            this.dgvNCC.AllowUserToAddRows = false;
            this.dgvNCC.AllowUserToDeleteRows = false;
            this.dgvNCC.AllowUserToResizeColumns = false;
            this.dgvNCC.AllowUserToResizeRows = false;
            this.dgvNCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNCC.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvNCC.Location = new System.Drawing.Point(3, 16);
            this.dgvNCC.Name = "dgvNCC";
            this.dgvNCC.RowHeadersVisible = false;
            this.dgvNCC.RowTemplate.Height = 25;
            this.dgvNCC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNCC.Size = new System.Drawing.Size(542, 111);
            this.dgvNCC.TabIndex = 0;
            this.dgvNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNCC_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThem.Location = new System.Drawing.Point(23, 419);
            this.btnThem.Margin = new System.Windows.Forms.Padding(0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(69, 26);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSua.Location = new System.Drawing.Point(261, 419);
            this.btnSua.Margin = new System.Windows.Forms.Padding(0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(69, 26);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoa.Location = new System.Drawing.Point(381, 419);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(69, 26);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLuu.Location = new System.Drawing.Point(142, 419);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(0);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(69, 26);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHuy.Location = new System.Drawing.Point(500, 419);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(0);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(69, 26);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // errCheck
            // 
            this.errCheck.BlinkRate = 0;
            this.errCheck.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errCheck.ContainerControl = this;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(454, 139);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(0);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(69, 26);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // tabContainer
            // 
            this.tabContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabContainer.Controls.Add(this.tpChinhSua);
            this.tabContainer.Controls.Add(this.tpTimKiem);
            this.tabContainer.Location = new System.Drawing.Point(20, 55);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(549, 199);
            this.tabContainer.TabIndex = 10;
            this.tabContainer.SelectedIndexChanged += new System.EventHandler(this.tabContainer_SelectedIndexChanged);
            // 
            // tpChinhSua
            // 
            this.tpChinhSua.Controls.Add(this.txtEmail);
            this.tpChinhSua.Controls.Add(this.lblEmail);
            this.tpChinhSua.Controls.Add(this.txtSDT);
            this.tpChinhSua.Controls.Add(this.lblSDT);
            this.tpChinhSua.Controls.Add(this.txtDiaChi);
            this.tpChinhSua.Controls.Add(this.lblDiaChi);
            this.tpChinhSua.Controls.Add(this.txtTen);
            this.tpChinhSua.Controls.Add(this.lblTen);
            this.tpChinhSua.Controls.Add(this.txtMa);
            this.tpChinhSua.Controls.Add(this.lblMa);
            this.tpChinhSua.Location = new System.Drawing.Point(4, 22);
            this.tpChinhSua.Name = "tpChinhSua";
            this.tpChinhSua.Padding = new System.Windows.Forms.Padding(3);
            this.tpChinhSua.Size = new System.Drawing.Size(541, 173);
            this.tpChinhSua.TabIndex = 0;
            this.tpChinhSua.Text = "Chỉnh sửa";
            this.tpChinhSua.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(356, 58);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(168, 20);
            this.txtEmail.TabIndex = 19;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(303, 61);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "Email";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(356, 19);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(0);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(168, 20);
            this.txtSDT.TabIndex = 17;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(303, 22);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(29, 13);
            this.lblSDT.TabIndex = 16;
            this.lblSDT.Text = "SDT";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(80, 103);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(0);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(444, 20);
            this.txtDiaChi.TabIndex = 15;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(12, 106);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(40, 13);
            this.lblDiaChi.TabIndex = 14;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(80, 58);
            this.txtTen.Margin = new System.Windows.Forms.Padding(0);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(153, 20);
            this.txtTen.TabIndex = 13;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(12, 61);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(51, 13);
            this.lblTen.TabIndex = 12;
            this.lblTen.Text = "Tên NCC";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(80, 19);
            this.txtMa.Margin = new System.Windows.Forms.Padding(0);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(153, 20);
            this.txtMa.TabIndex = 11;
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(12, 22);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(47, 13);
            this.lblMa.TabIndex = 10;
            this.lblMa.Text = "Mã NCC";
            // 
            // tpTimKiem
            // 
            this.tpTimKiem.Controls.Add(this.cboMaS);
            this.tpTimKiem.Controls.Add(this.btnHienTatCa);
            this.tpTimKiem.Controls.Add(this.txtEmailS);
            this.tpTimKiem.Controls.Add(this.btnTimKiem);
            this.tpTimKiem.Controls.Add(this.lblEmailS);
            this.tpTimKiem.Controls.Add(this.txtSDTS);
            this.tpTimKiem.Controls.Add(this.lblSDTS);
            this.tpTimKiem.Controls.Add(this.txtDiaChiS);
            this.tpTimKiem.Controls.Add(this.lblDiaChiS);
            this.tpTimKiem.Controls.Add(this.txtTenS);
            this.tpTimKiem.Controls.Add(this.lblTenS);
            this.tpTimKiem.Controls.Add(this.lblMaS);
            this.tpTimKiem.Location = new System.Drawing.Point(4, 22);
            this.tpTimKiem.Name = "tpTimKiem";
            this.tpTimKiem.Padding = new System.Windows.Forms.Padding(3);
            this.tpTimKiem.Size = new System.Drawing.Size(541, 173);
            this.tpTimKiem.TabIndex = 1;
            this.tpTimKiem.Text = "Tìm kiếm";
            this.tpTimKiem.UseVisualStyleBackColor = true;
            // 
            // cboMaS
            // 
            this.cboMaS.FormattingEnabled = true;
            this.cboMaS.Location = new System.Drawing.Point(80, 19);
            this.cboMaS.Name = "cboMaS";
            this.cboMaS.Size = new System.Drawing.Size(153, 21);
            this.cboMaS.TabIndex = 32;
            // 
            // btnHienTatCa
            // 
            this.btnHienTatCa.Location = new System.Drawing.Point(352, 139);
            this.btnHienTatCa.Margin = new System.Windows.Forms.Padding(0);
            this.btnHienTatCa.Name = "btnHienTatCa";
            this.btnHienTatCa.Size = new System.Drawing.Size(69, 26);
            this.btnHienTatCa.TabIndex = 31;
            this.btnHienTatCa.Text = "Hiện Tất Cả";
            this.btnHienTatCa.UseVisualStyleBackColor = true;
            this.btnHienTatCa.Click += new System.EventHandler(this.btnHienTatCa_Click);
            // 
            // txtEmailS
            // 
            this.txtEmailS.Location = new System.Drawing.Point(356, 58);
            this.txtEmailS.Margin = new System.Windows.Forms.Padding(0);
            this.txtEmailS.Name = "txtEmailS";
            this.txtEmailS.Size = new System.Drawing.Size(168, 20);
            this.txtEmailS.TabIndex = 29;
            // 
            // lblEmailS
            // 
            this.lblEmailS.AutoSize = true;
            this.lblEmailS.Location = new System.Drawing.Point(303, 61);
            this.lblEmailS.Name = "lblEmailS";
            this.lblEmailS.Size = new System.Drawing.Size(32, 13);
            this.lblEmailS.TabIndex = 28;
            this.lblEmailS.Text = "Email";
            // 
            // txtSDTS
            // 
            this.txtSDTS.Location = new System.Drawing.Point(356, 19);
            this.txtSDTS.Margin = new System.Windows.Forms.Padding(0);
            this.txtSDTS.Name = "txtSDTS";
            this.txtSDTS.Size = new System.Drawing.Size(168, 20);
            this.txtSDTS.TabIndex = 27;
            // 
            // lblSDTS
            // 
            this.lblSDTS.AutoSize = true;
            this.lblSDTS.Location = new System.Drawing.Point(303, 22);
            this.lblSDTS.Name = "lblSDTS";
            this.lblSDTS.Size = new System.Drawing.Size(29, 13);
            this.lblSDTS.TabIndex = 26;
            this.lblSDTS.Text = "SDT";
            // 
            // txtDiaChiS
            // 
            this.txtDiaChiS.Location = new System.Drawing.Point(80, 103);
            this.txtDiaChiS.Margin = new System.Windows.Forms.Padding(0);
            this.txtDiaChiS.Name = "txtDiaChiS";
            this.txtDiaChiS.Size = new System.Drawing.Size(444, 20);
            this.txtDiaChiS.TabIndex = 25;
            // 
            // lblDiaChiS
            // 
            this.lblDiaChiS.AutoSize = true;
            this.lblDiaChiS.Location = new System.Drawing.Point(12, 106);
            this.lblDiaChiS.Name = "lblDiaChiS";
            this.lblDiaChiS.Size = new System.Drawing.Size(40, 13);
            this.lblDiaChiS.TabIndex = 24;
            this.lblDiaChiS.Text = "Địa chỉ";
            // 
            // txtTenS
            // 
            this.txtTenS.Location = new System.Drawing.Point(80, 58);
            this.txtTenS.Margin = new System.Windows.Forms.Padding(0);
            this.txtTenS.Name = "txtTenS";
            this.txtTenS.Size = new System.Drawing.Size(153, 20);
            this.txtTenS.TabIndex = 23;
            // 
            // lblTenS
            // 
            this.lblTenS.AutoSize = true;
            this.lblTenS.Location = new System.Drawing.Point(12, 61);
            this.lblTenS.Name = "lblTenS";
            this.lblTenS.Size = new System.Drawing.Size(51, 13);
            this.lblTenS.TabIndex = 22;
            this.lblTenS.Text = "Tên NCC";
            // 
            // lblMaS
            // 
            this.lblMaS.AutoSize = true;
            this.lblMaS.Location = new System.Drawing.Point(12, 22);
            this.lblMaS.Name = "lblMaS";
            this.lblMaS.Size = new System.Drawing.Size(47, 13);
            this.lblMaS.TabIndex = 20;
            this.lblMaS.Text = "Mã NCC";
            // 
            // frmNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 465);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.pnlTitle);
            this.Name = "frmNCC";
            this.Text = "Quản lý nhà cung cấp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNCC_FormClosing);
            this.Load += new System.EventHandler(this.frmNCC_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCheck)).EndInit();
            this.tabContainer.ResumeLayout(false);
            this.tpChinhSua.ResumeLayout(false);
            this.tpChinhSua.PerformLayout();
            this.tpTimKiem.ResumeLayout(false);
            this.tpTimKiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvNCC;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ErrorProvider errCheck;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tpChinhSua;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TabPage tpTimKiem;
        private System.Windows.Forms.TextBox txtEmailS;
        private System.Windows.Forms.Label lblEmailS;
        private System.Windows.Forms.TextBox txtSDTS;
        private System.Windows.Forms.Label lblSDTS;
        private System.Windows.Forms.TextBox txtDiaChiS;
        private System.Windows.Forms.Label lblDiaChiS;
        private System.Windows.Forms.TextBox txtTenS;
        private System.Windows.Forms.Label lblTenS;
        private System.Windows.Forms.Label lblMaS;
        private System.Windows.Forms.Button btnHienTatCa;
        private System.Windows.Forms.ComboBox cboMaS;
    }
}