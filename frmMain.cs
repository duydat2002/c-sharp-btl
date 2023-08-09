using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class frmMain : Form
    {
        

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Program.role == "admin")
            {
                tsmiNhanVien.Visible = true;
            }
            else
            {
                tsmiNhanVien.Visible = false;
            }
        }

        private void tsmiDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            Close();
        }

        private void tsmiNCC_Click(object sender, EventArgs e)
        {
            frmNCC frm = new frmNCC();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiHDB_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frm = new frmHoaDonBan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiHDN_Click(object sender, EventArgs e)
        {
            frmHoaDonNhap frm = new frmHoaDonNhap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiTK_HoaDon_Click(object sender, EventArgs e)
        {
            frmThongKeTest frm = new frmThongKeTest();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiTK_DoanhThu_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu frm = new frmThongKeDoanhThu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiTK_QLKinhDoanh_Click(object sender, EventArgs e)
        {
            frmThongKeQuanLyKinhDoanh frm = new frmThongKeQuanLyKinhDoanh();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiTK_DoanhThuNV_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThuNV frm = new frmThongKeDoanhThuNV();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiTK_HDN_Click(object sender, EventArgs e)
        {
            frmThongKeHoaDonNhap frm = new frmThongKeHoaDonNhap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tHIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
