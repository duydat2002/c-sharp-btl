namespace BTL
{
    partial class frmKhachHang
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
            this.errCheck = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvKhachhang = new System.Windows.Forms.DataGridView();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnHienTatCa = new System.Windows.Forms.Button();
            this.tpTimKiem = new System.Windows.Forms.TabPage();
            this.chkNgaySinhS = new System.Windows.Forms.CheckBox();
            this.dtpNgaySinhS = new System.Windows.Forms.DateTimePicker();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblTongKH = new System.Windows.Forms.Label();
            this.txtCMNDS = new System.Windows.Forms.TextBox();
            this.lblCMNDS = new System.Windows.Forms.Label();
            this.mxtxNgaySinhS = new System.Windows.Forms.Label();
            this.txtDiaChiS = new System.Windows.Forms.TextBox();
            this.txtEmailS = new System.Windows.Forms.TextBox();
            this.txtSDTS = new System.Windows.Forms.TextBox();
            this.txtTenKHS = new System.Windows.Forms.TextBox();
            this.txtMaKHS = new System.Windows.Forms.TextBox();
            this.lblDiaChiS = new System.Windows.Forms.Label();
            this.lblEmailS = new System.Windows.Forms.Label();
            this.lblSDTS = new System.Windows.Forms.Label();
            this.lblTenKHS = new System.Windows.Forms.Label();
            this.lblMaKHS = new System.Windows.Forms.Label();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tpChinhSua = new System.Windows.Forms.TabPage();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.lblCMND = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errCheck)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachhang)).BeginInit();
            this.tpTimKiem.SuspendLayout();
            this.tabContainer.SuspendLayout();
            this.tpChinhSua.SuspendLayout();
            this.SuspendLayout();
            // 
            // errCheck
            // 
            this.errCheck.ContainerControl = this;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(349, 574);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(82, 34);
            this.btnSua.TabIndex = 14;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(502, 574);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(82, 34);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyBo.Location = new System.Drawing.Point(655, 574);
            this.btnHuyBo.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(82, 34);
            this.btnHuyBo.TabIndex = 12;
            this.btnHuyBo.Text = "Hủy";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btn_huyBo_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(43, 574);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(82, 34);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(39, 345);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(702, 210);
            this.tabControl2.TabIndex = 11;
            this.tabControl2.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvKhachhang);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(694, 182);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh sách khách hàng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvKhachhang
            // 
            this.dgvKhachhang.AllowUserToAddRows = false;
            this.dgvKhachhang.AllowUserToDeleteRows = false;
            this.dgvKhachhang.AllowUserToResizeRows = false;
            this.dgvKhachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachhang.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvKhachhang.Location = new System.Drawing.Point(2, 2);
            this.dgvKhachhang.Margin = new System.Windows.Forms.Padding(2);
            this.dgvKhachhang.Name = "dgvKhachhang";
            this.dgvKhachhang.RowHeadersVisible = false;
            this.dgvKhachhang.RowHeadersWidth = 51;
            this.dgvKhachhang.RowTemplate.Height = 24;
            this.dgvKhachhang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachhang.Size = new System.Drawing.Size(694, 219);
            this.dgvKhachhang.TabIndex = 0;
            this.dgvKhachhang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgr_Khachhang_CellClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(196, 574);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(82, 34);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(545, 192);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(82, 26);
            this.btnTimKiem.TabIndex = 20;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // btnHienTatCa
            // 
            this.btnHienTatCa.Location = new System.Drawing.Point(434, 192);
            this.btnHienTatCa.Margin = new System.Windows.Forms.Padding(2);
            this.btnHienTatCa.Name = "btnHienTatCa";
            this.btnHienTatCa.Size = new System.Drawing.Size(82, 26);
            this.btnHienTatCa.TabIndex = 8;
            this.btnHienTatCa.Text = "Hiện tất cả";
            this.btnHienTatCa.UseVisualStyleBackColor = true;
            this.btnHienTatCa.Click += new System.EventHandler(this.btn_displayAll_Click);
            // 
            // tpTimKiem
            // 
            this.tpTimKiem.Controls.Add(this.chkNgaySinhS);
            this.tpTimKiem.Controls.Add(this.dtpNgaySinhS);
            this.tpTimKiem.Controls.Add(this.lblSoLuong);
            this.tpTimKiem.Controls.Add(this.lblTongKH);
            this.tpTimKiem.Controls.Add(this.txtCMNDS);
            this.tpTimKiem.Controls.Add(this.lblCMNDS);
            this.tpTimKiem.Controls.Add(this.mxtxNgaySinhS);
            this.tpTimKiem.Controls.Add(this.txtDiaChiS);
            this.tpTimKiem.Controls.Add(this.txtEmailS);
            this.tpTimKiem.Controls.Add(this.txtSDTS);
            this.tpTimKiem.Controls.Add(this.txtTenKHS);
            this.tpTimKiem.Controls.Add(this.txtMaKHS);
            this.tpTimKiem.Controls.Add(this.lblDiaChiS);
            this.tpTimKiem.Controls.Add(this.lblEmailS);
            this.tpTimKiem.Controls.Add(this.lblSDTS);
            this.tpTimKiem.Controls.Add(this.lblTenKHS);
            this.tpTimKiem.Controls.Add(this.lblMaKHS);
            this.tpTimKiem.Controls.Add(this.btnTimKiem);
            this.tpTimKiem.Controls.Add(this.btnHienTatCa);
            this.tpTimKiem.Location = new System.Drawing.Point(4, 24);
            this.tpTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.tpTimKiem.Name = "tpTimKiem";
            this.tpTimKiem.Padding = new System.Windows.Forms.Padding(2);
            this.tpTimKiem.Size = new System.Drawing.Size(697, 237);
            this.tpTimKiem.TabIndex = 1;
            this.tpTimKiem.Text = "Tìm Kiếm";
            this.tpTimKiem.UseVisualStyleBackColor = true;
            // 
            // chkNgaySinhS
            // 
            this.chkNgaySinhS.AutoSize = true;
            this.chkNgaySinhS.Location = new System.Drawing.Point(111, 110);
            this.chkNgaySinhS.Name = "chkNgaySinhS";
            this.chkNgaySinhS.Size = new System.Drawing.Size(15, 14);
            this.chkNgaySinhS.TabIndex = 62;
            this.chkNgaySinhS.UseVisualStyleBackColor = true;
            this.chkNgaySinhS.CheckedChanged += new System.EventHandler(this.chkNgaySinhS_CheckedChanged);
            // 
            // dtpNgaySinhS
            // 
            this.dtpNgaySinhS.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinhS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinhS.Location = new System.Drawing.Point(149, 108);
            this.dtpNgaySinhS.Name = "dtpNgaySinhS";
            this.dtpNgaySinhS.Size = new System.Drawing.Size(156, 21);
            this.dtpNgaySinhS.TabIndex = 37;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(149, 201);
            this.lblSoLuong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(0, 15);
            this.lblSoLuong.TabIndex = 36;
            // 
            // lblTongKH
            // 
            this.lblTongKH.AutoSize = true;
            this.lblTongKH.Location = new System.Drawing.Point(50, 201);
            this.lblTongKH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongKH.Name = "lblTongKH";
            this.lblTongKH.Size = new System.Drawing.Size(105, 15);
            this.lblTongKH.TabIndex = 35;
            this.lblTongKH.Text = "Tổng khách hàng:";
            // 
            // txtCMNDS
            // 
            this.txtCMNDS.Location = new System.Drawing.Point(433, 106);
            this.txtCMNDS.Margin = new System.Windows.Forms.Padding(2);
            this.txtCMNDS.Multiline = true;
            this.txtCMNDS.Name = "txtCMNDS";
            this.txtCMNDS.Size = new System.Drawing.Size(194, 24);
            this.txtCMNDS.TabIndex = 34;
            // 
            // lblCMNDS
            // 
            this.lblCMNDS.AutoSize = true;
            this.lblCMNDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCMNDS.Location = new System.Drawing.Point(382, 110);
            this.lblCMNDS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCMNDS.Name = "lblCMNDS";
            this.lblCMNDS.Size = new System.Drawing.Size(47, 15);
            this.lblCMNDS.TabIndex = 33;
            this.lblCMNDS.Text = "CMND:";
            // 
            // mxtxNgaySinhS
            // 
            this.mxtxNgaySinhS.AutoSize = true;
            this.mxtxNgaySinhS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mxtxNgaySinhS.Location = new System.Drawing.Point(40, 109);
            this.mxtxNgaySinhS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mxtxNgaySinhS.Name = "mxtxNgaySinhS";
            this.mxtxNgaySinhS.Size = new System.Drawing.Size(66, 15);
            this.mxtxNgaySinhS.TabIndex = 31;
            this.mxtxNgaySinhS.Text = "Ngày Sinh:";
            // 
            // txtDiaChiS
            // 
            this.txtDiaChiS.Location = new System.Drawing.Point(111, 149);
            this.txtDiaChiS.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChiS.Multiline = true;
            this.txtDiaChiS.Name = "txtDiaChiS";
            this.txtDiaChiS.Size = new System.Drawing.Size(516, 26);
            this.txtDiaChiS.TabIndex = 30;
            // 
            // txtEmailS
            // 
            this.txtEmailS.Location = new System.Drawing.Point(433, 63);
            this.txtEmailS.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailS.Multiline = true;
            this.txtEmailS.Name = "txtEmailS";
            this.txtEmailS.Size = new System.Drawing.Size(194, 24);
            this.txtEmailS.TabIndex = 29;
            // 
            // txtSDTS
            // 
            this.txtSDTS.Location = new System.Drawing.Point(433, 20);
            this.txtSDTS.Margin = new System.Windows.Forms.Padding(2);
            this.txtSDTS.Multiline = true;
            this.txtSDTS.Name = "txtSDTS";
            this.txtSDTS.Size = new System.Drawing.Size(194, 24);
            this.txtSDTS.TabIndex = 28;
            // 
            // txtTenKHS
            // 
            this.txtTenKHS.Location = new System.Drawing.Point(111, 64);
            this.txtTenKHS.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenKHS.Multiline = true;
            this.txtTenKHS.Name = "txtTenKHS";
            this.txtTenKHS.Size = new System.Drawing.Size(194, 24);
            this.txtTenKHS.TabIndex = 27;
            // 
            // txtMaKHS
            // 
            this.txtMaKHS.Location = new System.Drawing.Point(111, 20);
            this.txtMaKHS.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaKHS.Multiline = true;
            this.txtMaKHS.Name = "txtMaKHS";
            this.txtMaKHS.Size = new System.Drawing.Size(194, 24);
            this.txtMaKHS.TabIndex = 26;
            // 
            // lblDiaChiS
            // 
            this.lblDiaChiS.AutoSize = true;
            this.lblDiaChiS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChiS.Location = new System.Drawing.Point(47, 156);
            this.lblDiaChiS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiaChiS.Name = "lblDiaChiS";
            this.lblDiaChiS.Size = new System.Drawing.Size(50, 15);
            this.lblDiaChiS.TabIndex = 25;
            this.lblDiaChiS.Text = "Địa Chỉ:";
            // 
            // lblEmailS
            // 
            this.lblEmailS.AutoSize = true;
            this.lblEmailS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailS.Location = new System.Drawing.Point(384, 67);
            this.lblEmailS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailS.Name = "lblEmailS";
            this.lblEmailS.Size = new System.Drawing.Size(42, 15);
            this.lblEmailS.TabIndex = 24;
            this.lblEmailS.Text = "Email:";
            // 
            // lblSDTS
            // 
            this.lblSDTS.AutoSize = true;
            this.lblSDTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDTS.Location = new System.Drawing.Point(384, 22);
            this.lblSDTS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSDTS.Name = "lblSDTS";
            this.lblSDTS.Size = new System.Drawing.Size(34, 15);
            this.lblSDTS.TabIndex = 23;
            this.lblSDTS.Text = "SDT:";
            // 
            // lblTenKHS
            // 
            this.lblTenKHS.AutoSize = true;
            this.lblTenKHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKHS.Location = new System.Drawing.Point(47, 67);
            this.lblTenKHS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenKHS.Name = "lblTenKHS";
            this.lblTenKHS.Size = new System.Drawing.Size(51, 15);
            this.lblTenKHS.TabIndex = 22;
            this.lblTenKHS.Text = "Tên KH:";
            // 
            // lblMaKHS
            // 
            this.lblMaKHS.AutoSize = true;
            this.lblMaKHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKHS.Location = new System.Drawing.Point(47, 22);
            this.lblMaKHS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaKHS.Name = "lblMaKHS";
            this.lblMaKHS.Size = new System.Drawing.Size(48, 15);
            this.lblMaKHS.TabIndex = 21;
            this.lblMaKHS.Text = "Mã KH:";
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tpChinhSua);
            this.tabContainer.Controls.Add(this.tpTimKiem);
            this.tabContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabContainer.Location = new System.Drawing.Point(36, 65);
            this.tabContainer.Margin = new System.Windows.Forms.Padding(2);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(705, 265);
            this.tabContainer.TabIndex = 10;
            // 
            // tpChinhSua
            // 
            this.tpChinhSua.Controls.Add(this.dtpNgaySinh);
            this.tpChinhSua.Controls.Add(this.txtCMND);
            this.tpChinhSua.Controls.Add(this.lblCMND);
            this.tpChinhSua.Controls.Add(this.lblNgaySinh);
            this.tpChinhSua.Controls.Add(this.txtDiaChi);
            this.tpChinhSua.Controls.Add(this.txtEmail);
            this.tpChinhSua.Controls.Add(this.txtSDT);
            this.tpChinhSua.Controls.Add(this.txtTenKH);
            this.tpChinhSua.Controls.Add(this.txtMaKH);
            this.tpChinhSua.Controls.Add(this.lblDiaChi);
            this.tpChinhSua.Controls.Add(this.lblEmail);
            this.tpChinhSua.Controls.Add(this.lblSDT);
            this.tpChinhSua.Controls.Add(this.lblTenKH);
            this.tpChinhSua.Controls.Add(this.lblMaKH);
            this.tpChinhSua.Location = new System.Drawing.Point(4, 24);
            this.tpChinhSua.Margin = new System.Windows.Forms.Padding(2);
            this.tpChinhSua.Name = "tpChinhSua";
            this.tpChinhSua.Padding = new System.Windows.Forms.Padding(2);
            this.tpChinhSua.Size = new System.Drawing.Size(697, 237);
            this.tpChinhSua.TabIndex = 0;
            this.tpChinhSua.Text = "Chỉnh Sửa";
            this.tpChinhSua.UseVisualStyleBackColor = true;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(111, 109);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(194, 21);
            this.dtpNgaySinh.TabIndex = 15;
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(433, 107);
            this.txtCMND.Margin = new System.Windows.Forms.Padding(2);
            this.txtCMND.Multiline = true;
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(194, 24);
            this.txtCMND.TabIndex = 14;
            // 
            // lblCMND
            // 
            this.lblCMND.AutoSize = true;
            this.lblCMND.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCMND.Location = new System.Drawing.Point(384, 110);
            this.lblCMND.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(47, 15);
            this.lblCMND.TabIndex = 13;
            this.lblCMND.Text = "CMND:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.Location = new System.Drawing.Point(40, 110);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(66, 15);
            this.lblNgaySinh.TabIndex = 10;
            this.lblNgaySinh.Text = "Ngày Sinh:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(111, 151);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(516, 26);
            this.txtDiaChi.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(433, 63);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(194, 24);
            this.txtEmail.TabIndex = 8;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(433, 19);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(2);
            this.txtSDT.Multiline = true;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(194, 24);
            this.txtSDT.TabIndex = 7;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(111, 64);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenKH.Multiline = true;
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(194, 24);
            this.txtTenKH.TabIndex = 6;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(111, 19);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaKH.Multiline = true;
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(194, 24);
            this.txtMaKH.TabIndex = 5;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(48, 156);
            this.lblDiaChi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(50, 15);
            this.lblDiaChi.TabIndex = 4;
            this.lblDiaChi.Text = "Địa Chỉ:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(384, 67);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 15);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email:";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(384, 21);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(34, 15);
            this.lblSDT.TabIndex = 2;
            this.lblSDT.Text = "SDT:";
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKH.Location = new System.Drawing.Point(47, 66);
            this.lblTenKH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(51, 15);
            this.lblTenKH.TabIndex = 1;
            this.lblTenKH.Text = "Tên KH:";
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKH.Location = new System.Drawing.Point(47, 21);
            this.lblMaKH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(48, 15);
            this.lblMaKH.TabIndex = 0;
            this.lblMaKH.Text = "Mã KH:";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(229, 20);
            this.Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(321, 29);
            this.Title.TabIndex = 9;
            this.Title.Text = "DANH MỤC KHÁCH HÀNG";
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 617);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.Title);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmKhachHang";
            this.Text = "KhachHang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKhachHang_FormClosing);
            this.Load += new System.EventHandler(this.KhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errCheck)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachhang)).EndInit();
            this.tpTimKiem.ResumeLayout(false);
            this.tpTimKiem.PerformLayout();
            this.tabContainer.ResumeLayout(false);
            this.tpChinhSua.ResumeLayout(false);
            this.tpChinhSua.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errCheck;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvKhachhang;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tpChinhSua;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.TabPage tpTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnHienTatCa;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label lblCMND;
        private System.Windows.Forms.TextBox txtCMNDS;
        private System.Windows.Forms.Label lblCMNDS;
        private System.Windows.Forms.Label mxtxNgaySinhS;
        private System.Windows.Forms.TextBox txtDiaChiS;
        private System.Windows.Forms.TextBox txtEmailS;
        private System.Windows.Forms.TextBox txtSDTS;
        private System.Windows.Forms.TextBox txtTenKHS;
        private System.Windows.Forms.TextBox txtMaKHS;
        private System.Windows.Forms.Label lblDiaChiS;
        private System.Windows.Forms.Label lblEmailS;
        private System.Windows.Forms.Label lblSDTS;
        private System.Windows.Forms.Label lblTenKHS;
        private System.Windows.Forms.Label lblMaKHS;
        private System.Windows.Forms.Label lblTongKH;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinhS;
        private System.Windows.Forms.CheckBox chkNgaySinhS;
    }
}