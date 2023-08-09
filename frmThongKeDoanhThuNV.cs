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
    public partial class frmThongKeDoanhThuNV : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        public frmThongKeDoanhThuNV()
        {
            InitializeComponent();
        }

        private void frmThongKeDoanhThuNV_Load(object sender, EventArgs e)
        {
            dgvDoanhThuNV.DataSource = getTKDoanhThuNhanVien();

            dgvDoanhThuNV.Columns[0].HeaderText = "NHÂN VIÊN";
            dgvDoanhThuNV.Columns[1].HeaderText = "SỐ ĐƠN BÁN";
            dgvDoanhThuNV.Columns[2].HeaderText = "SP BÁN";
            dgvDoanhThuNV.Columns[3].HeaderText = "TỔNG BÁN";
            dgvDoanhThuNV.Columns[4].HeaderText = "GIẢM  GIÁ";
            dgvDoanhThuNV.Columns[5].HeaderText = "DOANH THU";

            dgvDoanhThuNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DataTable getTKDoanhThuNhanVien()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = cnn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "prTKDoanhThuNhanVien";
                        cm.Parameters.AddWithValue("@Ngaybatdau", dtpNgayBatDau.Value.Date.ToString("yyyy/MM/dd"));
                        cm.Parameters.AddWithValue("@Ngayketthuc", dtpNgayKetThuc.Value.Date.ToString("yyyy/MM/dd"));
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("ThongKeDoanhThuNhanVien");
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

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            dgvDoanhThuNV.DataSource = getTKDoanhThuNhanVien();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
          
            ReportDocument rd = new ReportDocument();
            rd.Load(@"H:\Csharp\BTL\CryBaoCaoDoanhThuNhanVien.rpt");
            rd.SetParameterValue("@Ngaybatdau", dtpNgayBatDau.Value.Date.ToString("yyyy/MM/dd"));
            rd.SetParameterValue("@Ngayketthuc", dtpNgayKetThuc.Value.Date.ToString("yyyy/MM/dd"));
            crystalDoanhThu.ReportSource = rd;
            crystalDoanhThu.Refresh();
            tabControl1.SelectedTab = tabPage2;
        }
    }
}
