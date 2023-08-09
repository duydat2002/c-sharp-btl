using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace BTL
{
    public partial class frmThongKeTest : Form
    {
        public frmThongKeTest()
        {
            InitializeComponent();
        }

        private void btn_IN_Click(object sender, EventArgs e)
        {
            string formula = "1=1 ";

            if (txtTenNV.Text.Trim() != "")
            {
                formula += $"AND ({{tblNhanVien.sTenNV}} = \"{txtTenNV.Text.Trim()}\") ";
            }

            formula += $"AND ({{tblHoaDonBan.dNgayBan}} in \"{dtpNgayBatDau.Value.Date.ToString("yyyy/MM/dd")}\" to \"{dtpNgayKetThuc.Value.Date.ToString("yyyy/MM/dd")}\")";


            ReportDocument rd = new ReportDocument();
            rd.Load(@"H:\Csharp\BTL\crtTKHoaDonBan.rpt");

            rd.RecordSelectionFormula = formula;

            crvReport.ReportSource = rd;
            crvReport.Refresh();
        }

        private void frmThongKeHoaDonBan_Load(object sender, EventArgs e)
        {
            string formula = "1=1 ";

            if (txtTenNV.Text.Trim() != "")
            {
                formula += $"AND ({{tblNhanVien.sTenNV}} = \"{txtTenNV.Text.Trim()}\") ";
            }

            formula += $"AND ({{tblHoaDonBan.dNgayBan}} in \"{dtpNgayBatDau.Value.Date.ToString("yyyy/MM/dd")}\" to \"{dtpNgayKetThuc.Value.Date.ToString("yyyy/MM/dd")}\")";


            ReportDocument rd = new ReportDocument();
            rd.Load(@"H:\Csharp\BTL\crtTKHoaDonBan.rpt");

            rd.RecordSelectionFormula = formula;

            crvReport.ReportSource = rd;
            crvReport.Refresh();

            dtpNgayBatDau.Value = dtpNgayBatDau.MinDate;
            dtpNgayKetThuc.Value = dtpNgayKetThuc.MaxDate;
        }
    }
}
