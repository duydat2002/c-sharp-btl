
namespace BTL
{
    partial class frmThongKeHoaDonNhap
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
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.btnLoc = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblNgayNhapS = new System.Windows.Forms.Label();
            this.cboTenNCC = new System.Windows.Forms.ComboBox();
            this.lblTenNCC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(400, 20);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(111, 20);
            this.dtpNgayBatDau.TabIndex = 0;
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(539, 20);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(111, 20);
            this.dtpNgayKetThuc.TabIndex = 1;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(713, 20);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 20);
            this.btnLoc.TabIndex = 2;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.button1_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(13, 64);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(775, 374);
            this.crystalReportViewer1.TabIndex = 3;
            // 
            // lblNgayNhapS
            // 
            this.lblNgayNhapS.AutoSize = true;
            this.lblNgayNhapS.Location = new System.Drawing.Point(334, 21);
            this.lblNgayNhapS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayNhapS.Name = "lblNgayNhapS";
            this.lblNgayNhapS.Size = new System.Drawing.Size(61, 13);
            this.lblNgayNhapS.TabIndex = 29;
            this.lblNgayNhapS.Text = "Ngày Nhập";
            // 
            // cboTenNCC
            // 
            this.cboTenNCC.FormattingEnabled = true;
            this.cboTenNCC.Location = new System.Drawing.Point(88, 18);
            this.cboTenNCC.Name = "cboTenNCC";
            this.cboTenNCC.Size = new System.Drawing.Size(180, 21);
            this.cboTenNCC.TabIndex = 127;
            // 
            // lblTenNCC
            // 
            this.lblTenNCC.AutoSize = true;
            this.lblTenNCC.Location = new System.Drawing.Point(20, 20);
            this.lblTenNCC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenNCC.Name = "lblTenNCC";
            this.lblTenNCC.Size = new System.Drawing.Size(51, 13);
            this.lblTenNCC.TabIndex = 126;
            this.lblTenNCC.Text = "Tên NCC";
            // 
            // frmThongKeHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cboTenNCC);
            this.Controls.Add(this.lblTenNCC);
            this.Controls.Add(this.lblNgayNhapS);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.dtpNgayKetThuc);
            this.Controls.Add(this.dtpNgayBatDau);
            this.Name = "frmThongKeHoaDonNhap";
            this.Text = "Thống Kê Hóa Đơn Nhập";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.Button btnLoc;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label lblNgayNhapS;
        private System.Windows.Forms.ComboBox cboTenNCC;
        private System.Windows.Forms.Label lblTenNCC;
    }
}