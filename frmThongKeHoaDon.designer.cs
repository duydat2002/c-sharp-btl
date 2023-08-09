
namespace BTL
{
    partial class frmThongKeHoaDon
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
            this.crpHoaDonBan = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblMaHDB = new System.Windows.Forms.Label();
            this.txtMaHDB = new System.Windows.Forms.TextBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crpHoaDonBan
            // 
            this.crpHoaDonBan.ActiveViewIndex = -1;
            this.crpHoaDonBan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crpHoaDonBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crpHoaDonBan.Cursor = System.Windows.Forms.Cursors.Default;
            this.crpHoaDonBan.Location = new System.Drawing.Point(12, 55);
            this.crpHoaDonBan.Name = "crpHoaDonBan";
            this.crpHoaDonBan.Size = new System.Drawing.Size(1015, 396);
            this.crpHoaDonBan.TabIndex = 0;
            // 
            // lblMaHDB
            // 
            this.lblMaHDB.AutoSize = true;
            this.lblMaHDB.Location = new System.Drawing.Point(13, 13);
            this.lblMaHDB.Name = "lblMaHDB";
            this.lblMaHDB.Size = new System.Drawing.Size(48, 13);
            this.lblMaHDB.TabIndex = 1;
            this.lblMaHDB.Text = "Mã HDB";
            // 
            // txtMaHDB
            // 
            this.txtMaHDB.Location = new System.Drawing.Point(67, 10);
            this.txtMaHDB.Name = "txtMaHDB";
            this.txtMaHDB.Size = new System.Drawing.Size(100, 20);
            this.txtMaHDB.TabIndex = 2;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(182, 8);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 23);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // frmThongKeHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 463);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.txtMaHDB);
            this.Controls.Add(this.lblMaHDB);
            this.Controls.Add(this.crpHoaDonBan);
            this.Name = "frmThongKeHoaDon";
            this.Text = "frmBaoCaoHoaDon";
            this.Load += new System.EventHandler(this.frmBaoCaoHoaDon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crpHoaDonBan;
        private System.Windows.Forms.Label lblMaHDB;
        private System.Windows.Forms.TextBox txtMaHDB;
        private System.Windows.Forms.Button btnLoc;
    }
}