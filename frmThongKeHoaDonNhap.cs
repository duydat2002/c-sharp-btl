using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class frmThongKeHoaDonNhap : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public frmThongKeHoaDonNhap()
        {
            InitializeComponent();
        }

        private DataTable getDSNCC()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        "SELECT sMaNCC, sTenNCC FROM tblNhaCungCap"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                        {
                            using (DataTable dt = new DataTable("tblNhaCungCap"))
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

        private void Form1_Load(object sender, EventArgs e)
        {
            cboTenNCC.DataSource = new DataView(getDSNCC(), "", "sTenNCC", DataViewRowState.CurrentRows);
            cboTenNCC.DisplayMember = "sTenNCC";
            cboTenNCC.ValueMember = "sTenNCC";

            dtpNgayBatDau.Value = dtpNgayBatDau.MinDate;
            dtpNgayKetThuc.Value = dtpNgayKetThuc.MaxDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string formula = "1=1 ";

            if (cboTenNCC.Text.Trim() != "")
            { 
                formula += $"AND ({{tblNhaCungCap.sTenNCC}} = \"{cboTenNCC.Text.Trim()}\") ";
            }

            formula += $"AND ({{tblHoaDonNhap.dNgayNhapHang}} in \"{dtpNgayBatDau.Value.Date.ToString("yyyy/MM/dd")}\" to \"{dtpNgayKetThuc.Value.Date.ToString("yyyy/MM/dd")}\")";

            ReportDocument rd = new ReportDocument();
            rd.Load(@"H:\Csharp\BTL\crtTKHoaDonNhap.rpt");

            rd.RecordSelectionFormula = formula;

            crystalReportViewer1.ReportSource = rd;
            crystalReportViewer1.Refresh();
        }

        private void test()
        {
            //ReportDocument cryRpt = new ReportDocument();
            //cryRpt.Load("PUT CRYSTAL REPORT PATH HERE\CrystalReport1.rpt");

            //ParameterFieldDefinitions crParameterFieldDefinitions;
            //ParameterFieldDefinition crParameterFieldDefinition;
            //ParameterValues crParameterValues = new ParameterValues();
            //ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            //crParameterDiscreteValue.Value = textBox1.Text;
            //crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            //crParameterFieldDefinition = crParameterFieldDefinitions["Orderdate"];
            //crParameterValues = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();
            //crParameterValues.Add(crParameterDiscreteValue);
            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            //crystalReportViewer1.ReportSource = cryRpt;
            //crystalReportViewer1.Refresh();
        }
    }
}
