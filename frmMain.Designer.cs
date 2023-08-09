
namespace BTL
{
    partial class frmMain
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
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNCC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHDN = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTK_HoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTK_HDN = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTK_DoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTK_QLKinhDoanh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTK_DoanhThuNV = new System.Windows.Forms.ToolStripMenuItem();
            this.tHIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHeThong,
            this.tsmiQuanLy,
            this.tsmiHoaDon,
            this.tsmiThongKe});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.msMain.Size = new System.Drawing.Size(686, 24);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiHeThong
            // 
            this.tsmiHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDangXuat});
            this.tsmiHeThong.Name = "tsmiHeThong";
            this.tsmiHeThong.Size = new System.Drawing.Size(71, 20);
            this.tsmiHeThong.Text = "Hệ Thống";
            // 
            // tsmiDangXuat
            // 
            this.tsmiDangXuat.Name = "tsmiDangXuat";
            this.tsmiDangXuat.Size = new System.Drawing.Size(128, 22);
            this.tsmiDangXuat.Text = "Đăng xuất";
            this.tsmiDangXuat.Click += new System.EventHandler(this.tsmiDangXuat_Click);
            // 
            // tsmiQuanLy
            // 
            this.tsmiQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNCC,
            this.tsmiSanPham,
            this.tsmiNhanVien,
            this.tsmiKhachHang});
            this.tsmiQuanLy.Name = "tsmiQuanLy";
            this.tsmiQuanLy.Size = new System.Drawing.Size(74, 20);
            this.tsmiQuanLy.Text = "Danh Mục";
            // 
            // tsmiNCC
            // 
            this.tsmiNCC.Name = "tsmiNCC";
            this.tsmiNCC.Size = new System.Drawing.Size(152, 22);
            this.tsmiNCC.Text = "Nhà Cung Cấp";
            this.tsmiNCC.Click += new System.EventHandler(this.tsmiNCC_Click);
            // 
            // tsmiSanPham
            // 
            this.tsmiSanPham.Name = "tsmiSanPham";
            this.tsmiSanPham.Size = new System.Drawing.Size(152, 22);
            this.tsmiSanPham.Text = "Sản Phẩm";
            this.tsmiSanPham.Click += new System.EventHandler(this.tsmiSanPham_Click);
            // 
            // tsmiNhanVien
            // 
            this.tsmiNhanVien.Name = "tsmiNhanVien";
            this.tsmiNhanVien.Size = new System.Drawing.Size(152, 22);
            this.tsmiNhanVien.Text = "Nhân Viên";
            this.tsmiNhanVien.Click += new System.EventHandler(this.tsmiNhanVien_Click);
            // 
            // tsmiKhachHang
            // 
            this.tsmiKhachHang.Name = "tsmiKhachHang";
            this.tsmiKhachHang.Size = new System.Drawing.Size(152, 22);
            this.tsmiKhachHang.Text = "Khách Hàng";
            this.tsmiKhachHang.Click += new System.EventHandler(this.tsmiKhachHang_Click);
            // 
            // tsmiHoaDon
            // 
            this.tsmiHoaDon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHDB,
            this.tsmiHDN});
            this.tsmiHoaDon.Name = "tsmiHoaDon";
            this.tsmiHoaDon.Size = new System.Drawing.Size(66, 20);
            this.tsmiHoaDon.Text = "Hóa Đơn";
            // 
            // tsmiHDB
            // 
            this.tsmiHDB.Name = "tsmiHDB";
            this.tsmiHDB.Size = new System.Drawing.Size(153, 22);
            this.tsmiHDB.Text = "Hóa Đơn Bán";
            this.tsmiHDB.Click += new System.EventHandler(this.tsmiHDB_Click);
            // 
            // tsmiHDN
            // 
            this.tsmiHDN.Name = "tsmiHDN";
            this.tsmiHDN.Size = new System.Drawing.Size(153, 22);
            this.tsmiHDN.Text = "Hóa Đơn Nhập";
            this.tsmiHDN.Click += new System.EventHandler(this.tsmiHDN_Click);
            // 
            // tsmiThongKe
            // 
            this.tsmiThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTK_HoaDon,
            this.tsmiTK_HDN,
            this.tsmiTK_DoanhThu,
            this.tsmiTK_QLKinhDoanh,
            this.tsmiTK_DoanhThuNV,
            this.tHIToolStripMenuItem});
            this.tsmiThongKe.Name = "tsmiThongKe";
            this.tsmiThongKe.Size = new System.Drawing.Size(69, 20);
            this.tsmiThongKe.Text = "Thống Kê";
            // 
            // tsmiTK_HoaDon
            // 
            this.tsmiTK_HoaDon.Name = "tsmiTK_HoaDon";
            this.tsmiTK_HoaDon.Size = new System.Drawing.Size(190, 22);
            this.tsmiTK_HoaDon.Text = "Hóa Đơn Bán";
            this.tsmiTK_HoaDon.Click += new System.EventHandler(this.tsmiTK_HoaDon_Click);
            // 
            // tsmiTK_HDN
            // 
            this.tsmiTK_HDN.Name = "tsmiTK_HDN";
            this.tsmiTK_HDN.Size = new System.Drawing.Size(190, 22);
            this.tsmiTK_HDN.Text = "Hóa Đơn Nhập";
            this.tsmiTK_HDN.Click += new System.EventHandler(this.tsmiTK_HDN_Click);
            // 
            // tsmiTK_DoanhThu
            // 
            this.tsmiTK_DoanhThu.Name = "tsmiTK_DoanhThu";
            this.tsmiTK_DoanhThu.Size = new System.Drawing.Size(190, 22);
            this.tsmiTK_DoanhThu.Text = "Doanh Thu";
            this.tsmiTK_DoanhThu.Click += new System.EventHandler(this.tsmiTK_DoanhThu_Click);
            // 
            // tsmiTK_QLKinhDoanh
            // 
            this.tsmiTK_QLKinhDoanh.Name = "tsmiTK_QLKinhDoanh";
            this.tsmiTK_QLKinhDoanh.Size = new System.Drawing.Size(190, 22);
            this.tsmiTK_QLKinhDoanh.Text = "Quản Lý Kinh Doanh";
            this.tsmiTK_QLKinhDoanh.Click += new System.EventHandler(this.tsmiTK_QLKinhDoanh_Click);
            // 
            // tsmiTK_DoanhThuNV
            // 
            this.tsmiTK_DoanhThuNV.Name = "tsmiTK_DoanhThuNV";
            this.tsmiTK_DoanhThuNV.Size = new System.Drawing.Size(190, 22);
            this.tsmiTK_DoanhThuNV.Text = "Doanh Thu Nhân Viên";
            this.tsmiTK_DoanhThuNV.Click += new System.EventHandler(this.tsmiTK_DoanhThuNV_Click);
            // 
            // tHIToolStripMenuItem
            // 
            this.tHIToolStripMenuItem.Name = "tHIToolStripMenuItem";
            this.tHIToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.tHIToolStripMenuItem.Text = "THI";
            this.tHIToolStripMenuItem.Click += new System.EventHandler(this.tHIToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.msMain);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương trình quản lý kinh doanh điện thoại";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeThong;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuanLy;
        private System.Windows.Forms.ToolStripMenuItem tsmiNCC;
        private System.Windows.Forms.ToolStripMenuItem tsmiSanPham;
        private System.Windows.Forms.ToolStripMenuItem tsmiNhanVien;
        private System.Windows.Forms.ToolStripMenuItem tsmiKhachHang;
        private System.Windows.Forms.ToolStripMenuItem tsmiHoaDon;
        private System.Windows.Forms.ToolStripMenuItem tsmiHDB;
        private System.Windows.Forms.ToolStripMenuItem tsmiHDN;
        private System.Windows.Forms.ToolStripMenuItem tsmiThongKe;
        private System.Windows.Forms.ToolStripMenuItem tsmiTK_HoaDon;
        private System.Windows.Forms.ToolStripMenuItem tsmiTK_DoanhThu;
        private System.Windows.Forms.ToolStripMenuItem tsmiTK_QLKinhDoanh;
        private System.Windows.Forms.ToolStripMenuItem tsmiTK_DoanhThuNV;
        private System.Windows.Forms.ToolStripMenuItem tsmiDangXuat;
        private System.Windows.Forms.ToolStripMenuItem tsmiTK_HDN;
        private System.Windows.Forms.ToolStripMenuItem tHIToolStripMenuItem;
    }
}