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
    public partial class frmThongKeDoanhThu : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }
        private DataTable getTKDoanhThu()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        "prTKDoanhThu"
                        , con))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@Ngaybatdau", dtpNgayBatDau.Value.Date.ToString("yyyy/MM/dd"));
                        cm.Parameters.AddWithValue("@Ngayketthuc", dtpNgayKetThuc.Value.Date.ToString("yyyy/MM/dd"));
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                        {
                            using (DataTable dt = new DataTable("ThongKeDoanhThu"))
                            {
                                sda.Fill(dt);
                                return dt;
                            }
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

        
        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            dgv_DoanhThu.DataSource = getTKDoanhThu();
            dgv_DoanhThu.Columns[0].HeaderText = "Nhà cung cấp";
            dgv_DoanhThu.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_DoanhThu.Columns[2].HeaderText = "Số lượng bán ra";
            dgv_DoanhThu.Columns[3].HeaderText = "Doanh thu";
            dgv_DoanhThu.Columns[4].HeaderText = "Giảm giá";
            dgv_DoanhThu.Columns[5].HeaderText = "Doanh thu thực";
            dgv_DoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            dgv_DoanhThu.DataSource = getTKDoanhThu();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(@"H:\Csharp\BTL\crtDoanhThu.rpt");

            rd.SetParameterValue("@Ngaybatdau", dtpNgayBatDau.Value.Date.ToString("yyyy/MM/dd"));
            rd.SetParameterValue("@Ngayketthuc", dtpNgayKetThuc.Value.Date.ToString("yyyy/MM/dd"));
            crystalDoanhThu.ReportSource = rd;
            crystalDoanhThu.Refresh();


            tabControl1.SelectedTab = tabPage2;
        }
    }
}
