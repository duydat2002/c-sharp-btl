using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace BTL
{
    public partial class frmThongKeQuanLyKinhDoanh : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        public frmThongKeQuanLyKinhDoanh()
        {
            InitializeComponent();
        }
       
        private void frmThongKeQuanLyKinhDoanh_Load(object sender, EventArgs e)
        {
            dgvDoanhThu.DataSource = getTKQuanLyKinhDoanh();
            dgvDoanhThu.Columns[0].HeaderText = "SẢN PHẨM";
            dgvDoanhThu.Columns[1].HeaderText = "SỐ LƯỢNG NHẬP";
            dgvDoanhThu.Columns[2].HeaderText = "GIÁ NHẬP";
            dgvDoanhThu.Columns[3].HeaderText = "SL BÁN";
            dgvDoanhThu.Columns[4].HeaderText = "GIÁ BÁN";
            dgvDoanhThu.Columns[5].HeaderText = "HÀNG TỒN";
            dgvDoanhThu.Columns[6].HeaderText = "TIỀN TỒN"; 
            dgvDoanhThu.Columns[7].HeaderText = "TIỀN LÃI";
            dgvDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DataTable getTKQuanLyKinhDoanh()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = cnn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "prTKTienSanPham";
                        cm.Parameters.AddWithValue("@Ngaybatdau", dtpNgayBatDau.Value.Date.ToString("yyyy/MM/dd"));
                        cm.Parameters.AddWithValue("@Ngayketthuc", dtpNgayKetThuc.Value.Date.ToString("yyyy/MM/dd"));
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("thongkequanlykinhdoanh");
                            da.Fill(dt);
                            return dt;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Có lỗi xảy ra! {e}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(@"H:\Csharp\BTL\crtThongKeQLKD.rpt");
            rd.SetParameterValue("@Ngaybatdau", dtpNgayBatDau.Value.Date.ToString("yyyy/MM/dd"));
            rd.SetParameterValue("@Ngayketthuc", dtpNgayKetThuc.Value.Date.ToString("yyyy/MM/dd"));
            crystalDoanhThu.ReportSource = rd;
            crystalDoanhThu.Refresh();

            tabControl1.SelectedTab = tabPage2;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            dgvDoanhThu.DataSource = getTKQuanLyKinhDoanh();
        }
    }
}
