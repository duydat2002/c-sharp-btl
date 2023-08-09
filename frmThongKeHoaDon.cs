using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
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
    public partial class frmThongKeHoaDon : Form
    {
        public frmThongKeHoaDon()
        {
            InitializeComponent();
        }

        private void frmBaoCaoHoaDon_Load(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(@"H:\Csharp\BTL\crtTKHoaDonBan.rpt");
            crpHoaDonBan.ReportSource = rd;
            crpHoaDonBan.Refresh();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(@"H:\Csharp\BTL\crtTKHoaDonBan.rpt");

            rd.RecordSelectionFormula = $"({{tblHoaDonBan.iMaHDB}} = {txtMaHDB.Text})";
            crpHoaDonBan.ReportSource = rd;
            crpHoaDonBan.Refresh();
        }
    }
}
