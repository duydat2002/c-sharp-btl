﻿
namespace BTL
{
    partial class frmThongKeDoanhThuNV
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDoanhThuNV = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crystalDoanhThu = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThuNV)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(22, 236);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1416, 472);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDoanhThuNV);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1408, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thống Kê";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDoanhThuNV
            // 
            this.dgvDoanhThuNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThuNV.Location = new System.Drawing.Point(0, 0);
            this.dgvDoanhThuNV.Name = "dgvDoanhThuNV";
            this.dgvDoanhThuNV.RowHeadersWidth = 51;
            this.dgvDoanhThuNV.RowTemplate.Height = 24;
            this.dgvDoanhThuNV.Size = new System.Drawing.Size(1408, 438);
            this.dgvDoanhThuNV.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crystalDoanhThu);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1408, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CrytalPrint";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crystalDoanhThu
            // 
            this.crystalDoanhThu.ActiveViewIndex = -1;
            this.crystalDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalDoanhThu.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalDoanhThu.Location = new System.Drawing.Point(3, 3);
            this.crystalDoanhThu.Name = "crystalDoanhThu";
            this.crystalDoanhThu.Size = new System.Drawing.Size(1402, 435);
            this.crystalDoanhThu.TabIndex = 0;
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(1098, 169);
            this.btnIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(100, 28);
            this.btnIn.TabIndex = 30;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(955, 169);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(100, 28);
            this.btnThongKe.TabIndex = 29;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(608, 170);
            this.dtpNgayKetThuc.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(265, 22);
            this.dtpNgayKetThuc.TabIndex = 28;
            this.dtpNgayKetThuc.Value = new System.DateTime(2022, 3, 9, 0, 0, 0, 0);
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKetThuc.Location = new System.Drawing.Point(502, 170);
            this.lblNgayKetThuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(98, 18);
            this.lblNgayKetThuc.TabIndex = 27;
            this.lblNgayKetThuc.Text = "Ngày kết thúc";
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(172, 169);
            this.dtpNgayBatDau.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(265, 22);
            this.dtpNgayBatDau.TabIndex = 26;
            this.dtpNgayBatDau.Value = new System.DateTime(2022, 3, 9, 0, 0, 0, 0);
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBatDau.Location = new System.Drawing.Point(70, 169);
            this.lblNgayBatDau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(94, 18);
            this.lblNgayBatDau.TabIndex = 25;
            this.lblNgayBatDau.Text = "Ngày bắt đầu";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(475, 83);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(452, 29);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "BÁO CÁO DOANH THU NHÂN VIÊN";
            // 
            // frmThongKeDoanhThuNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 785);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dtpNgayKetThuc);
            this.Controls.Add(this.lblNgayKetThuc);
            this.Controls.Add(this.dtpNgayBatDau);
            this.Controls.Add(this.lblNgayBatDau);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmThongKeDoanhThuNV";
            this.Text = "frmThongKeDoanhThuNV";
            this.Load += new System.EventHandler(this.frmThongKeDoanhThuNV_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThuNV)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvDoanhThuNV;
        private System.Windows.Forms.TabPage tabPage2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalDoanhThu;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.Label lblTitle;
    }
}