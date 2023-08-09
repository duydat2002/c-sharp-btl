
namespace BTL
{
    partial class frmThongKeTest
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
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.lbl_TenNV = new System.Windows.Forms.Label();
            this.btn_IN = new System.Windows.Forms.Button();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(97, 23);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(173, 20);
            this.txtTenNV.TabIndex = 3;
            // 
            // lbl_TenNV
            // 
            this.lbl_TenNV.AutoSize = true;
            this.lbl_TenNV.Location = new System.Drawing.Point(15, 27);
            this.lbl_TenNV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_TenNV.Name = "lbl_TenNV";
            this.lbl_TenNV.Size = new System.Drawing.Size(79, 13);
            this.lbl_TenNV.TabIndex = 2;
            this.lbl_TenNV.Text = "Tên Nhân Viên";
            // 
            // btn_IN
            // 
            this.btn_IN.Location = new System.Drawing.Point(287, 23);
            this.btn_IN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_IN.Name = "btn_IN";
            this.btn_IN.Size = new System.Drawing.Size(74, 20);
            this.btn_IN.TabIndex = 4;
            this.btn_IN.Text = "IN";
            this.btn_IN.UseVisualStyleBackColor = true;
            this.btn_IN.Click += new System.EventHandler(this.btn_IN_Click);
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReport.Location = new System.Drawing.Point(3, 67);
            this.crvReport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.crvReport.Name = "crvReport";
            this.crvReport.Size = new System.Drawing.Size(952, 544);
            this.crvReport.TabIndex = 5;
            this.crvReport.ToolPanelWidth = 150;
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(414, 22);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(114, 20);
            this.dtpNgayBatDau.TabIndex = 6;
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(556, 23);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(114, 20);
            this.dtpNgayKetThuc.TabIndex = 7;
            // 
            // frmThongKeHoaDonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 609);
            this.Controls.Add(this.dtpNgayKetThuc);
            this.Controls.Add(this.dtpNgayBatDau);
            this.Controls.Add(this.crvReport);
            this.Controls.Add(this.btn_IN);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.lbl_TenNV);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmThongKeHoaDonBan";
            this.Text = "frmThongKeHoaDonBan";
            this.Load += new System.EventHandler(this.frmThongKeHoaDonBan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label lbl_TenNV;
        private System.Windows.Forms.Button btn_IN;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
    }
}