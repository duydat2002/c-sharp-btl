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
using System.Text.RegularExpressions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BTL
{
    public partial class frmHoaDonBan : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        public frmHoaDonBan()
        {
            InitializeComponent();
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = getDSHDB();
            dgvHoaDon.Columns[0].HeaderText = "Mã HDB";
            dgvHoaDon.Columns[1].HeaderText = "Mã nhân viên";
            dgvHoaDon.Columns[2].HeaderText = "Tên nhân viên";
            dgvHoaDon.Columns[3].HeaderText = "Mã khách hàng";
            dgvHoaDon.Columns[4].HeaderText = "Tên khách hàng";
            dgvHoaDon.Columns[5].HeaderText = "Ngày bán";
            dgvHoaDon.Columns[6].HeaderText = "Số lượng nhập";
            dgvHoaDon.Columns[7].HeaderText = "Tổng tiền";
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCTHoaDon.DataSource = getDSCT_HDB();
            dgvCTHoaDon.Columns[0].HeaderText = "Mã HĐB";
            dgvCTHoaDon.Columns[1].HeaderText = "Mã sản phẩm";
            dgvCTHoaDon.Columns[2].HeaderText = "Tên sản phẩm";
            dgvCTHoaDon.Columns[3].HeaderText = "Số lượng bán";
            dgvCTHoaDon.Columns[4].HeaderText = "Giá bán";
            dgvCTHoaDon.Columns[5].HeaderText = "Giảm giá";
            dgvCTHoaDon.Columns[6].HeaderText = "TGBH";
            dgvCTHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnLuuHD.Enabled = false;
            btnSuaHD.Enabled = false;
            btnXoaHD.Enabled = false;
            btnLuuCT.Enabled = false;
            btnSuaCT.Enabled = false;
            btnXoaCT.Enabled = false;
            dtpNgayBanSFrom.Value = dtpNgayBanSFrom.MinDate;
            dtpBaoHanhSFrom.Value = dtpNgayBanSFrom.MinDate;
            dtpBaoHanhSTo.Value = dtpBaoHanhSTo.MaxDate;

            cboTenNV.DataSource = new DataView(getDSNV(), "", "sMaNV", DataViewRowState.CurrentRows);
            cboTenNV.DisplayMember = "sTenNV";
            cboTenNV.ValueMember = "sMaNV";
           

            cboMaKH.DataSource = new DataView(getDSKH(), "", "sMaKH", DataViewRowState.CurrentRows);
            cboMaKH.DisplayMember = "sMaKH";
            cboMaKH.ValueMember = "sMaKH";

            cboMaSP.DataSource = new DataView(getDSSP(), "", "sMaSP", DataViewRowState.CurrentRows);
            cboMaSP.DisplayMember = "sMaSP";
            cboMaSP.ValueMember = "sMaSP";

            resetValueHD();
            resetValueCT();

            txtMaHDB.Enabled = false;
            //txtTenNV.Enabled = false;
            txtTenKH.Enabled = false;
            mtxtTGBH.Enabled = false;
            txtTenSP.Enabled = false;

            lblCountHD.Text = dgvHoaDon.RowCount.ToString();
            lblCountCT.Text = dgvCTHoaDon.RowCount.ToString();
        }

        private DataTable getDSHDB()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT tblHoaDonBan.iMaHDB, tblHoaDonBan.sMaNV, sTenNV, tblHoaDonBan.sMaKH, sTenKH, dNgayBan, 
	                            ISNULL(t1.[Số Lượng Bán], 0) [Số Lượng Bán], 
	                            ISNULL(t1.[Tổng Tiền], 0) [Tổng Tiền]
                            FROM dbo.tblHoaDonBan
                            LEFT JOIN dbo.tblKhachHang ON tblKhachHang.sMaKH = tblHoaDonBan.sMaKH
                            LEFT JOIN dbo.tblNhanVien ON tblNhanVien.sMaNV = tblHoaDonBan.sMaNV
                            LEFT JOIN (
	                            SELECT iMaHDB, SUM(iSLBan) [Số Lượng Bán], SUM(iSLBan*fGiaBan*(1-fMucGiamGia)) [Tổng Tiền] 
	                            FROM dbo.tblCT_HoaDonBan
	                            GROUP BY iMaHDB
                            ) t1 ON t1.iMaHDB = tblHoaDonBan.iMaHDB
                            WHERE tblHoaDonBan.isDeleted = 0"
                        , cnn))
                    {
                        cm.CommandType = CommandType.Text;
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblHoaDonBan");
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable getDSHDB(List<string> MaHDBs)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT tblHoaDonBan.iMaHDB, tblHoaDonBan.sMaNV, sTenNV, tblHoaDonBan.sMaKH, sTenKH, dNgayBan, 
	                            ISNULL(t1.[Số Lượng Bán], 0) [Số Lượng Bán], 
	                            ISNULL(t1.[Tổng Tiền], 0) [Tổng Tiền]
                            FROM dbo.tblHoaDonBan
                            LEFT JOIN dbo.tblKhachHang ON tblKhachHang.sMaKH = tblHoaDonBan.sMaKH
                            LEFT JOIN dbo.tblNhanVien ON tblNhanVien.sMaNV = tblHoaDonBan.sMaNV
                            LEFT JOIN (
	                            SELECT iMaHDB, SUM(iSLBan) [Số Lượng Bán], SUM(iSLBan*fGiaBan*(1-fMucGiamGia)) [Tổng Tiền] 
	                            FROM dbo.tblCT_HoaDonBan
	                            GROUP BY iMaHDB
                            ) t1 ON t1.iMaHDB = tblHoaDonBan.iMaHDB
                            WHERE tblHoaDonBan.iMaHDB IN ({(MaHDBs.Count == 0 ? "-1" : string.Join(",", MaHDBs))})
                            AND tblHoaDonBan.isDeleted = 0"
                        , cnn))
                    {
                        cm.CommandType = CommandType.Text;
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblHoaDonBan");
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable getDSCT_HDB()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT iMaHDB, tblCT_HoaDonBan.sMaSP, sTenSP, iSLBan, fGiaBan, fMucGiamGia, dTGBaoHanh
                            FROM dbo.tblCT_HoaDonBan
                            INNER JOIN dbo.tblSanPham ON tblSanPham.sMaSP = tblCT_HoaDonBan.sMaSP
                            WHERE isDeleted = 0"
                        , cnn))
                    {
                        cm.CommandType = CommandType.Text;
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblCT_HoaDonBan");
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable getDSCT_HDB(int MaHDB)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT iMaHDB, tblCT_HoaDonBan.sMaSP, sTenSP, iSLBan, fGiaBan, fMucGiamGia, dTGBaoHanh
                            FROM dbo.tblCT_HoaDonBan
                            INNER JOIN dbo.tblSanPham ON tblSanPham.sMaSP = tblCT_HoaDonBan.sMaSP
                            WHERE iMaHDB = @MaHDB"
                        , cnn))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaHDB", MaHDB);
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblCT_HoaDonBan");
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable getDSNV()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT sMaNV, sTenNV FROM dbo.tblNhanVien"
                        , cnn))
                    {
                        cm.CommandType = CommandType.Text;
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblNhanVien");
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable getDSKH()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT sMaKH, sTenKH FROM dbo.tblKhachHang"
                        , cnn))
                    {
                        cm.CommandType = CommandType.Text;
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblKhachHang");
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable getDSSP()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT sMaSP, sTenSP FROM dbo.tblSanPham"
                        , cnn))
                    {
                        cm.CommandType = CommandType.Text;
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblSanPham");
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private void resetValueHD()
        {
            txtMaHDB.Text = "";
            cboTenNV.Text = "";
            cboMaKH.Text = "";
            dtpNgayBan.Text = "";
            //txtTenNV.Text = "";
            txtTenKH.Text = "";
        }

        private void resetValueCT()
        {
            cboMaSP.Text = "";
            txtSLBan.Text = "";
            txtGiaBan.Text = "";
            txtTenSP.Text = "";
            txtGiamGia.Text = "";
            mtxtTGBH.Text = "";
        }

        private void resetValueHDS()
        {
            cboMaHDBS.Text = "";
            cboMaNVS.Text = "";
            cboMaKHS.Text = "";
            cboTenNVS.Text = "";
            cboTenKHS.Text = "";
            dtpNgayBanSFrom.Value = dtpNgayBanSFrom.MinDate;
        }

        private void resetValueCTS()
        {
            cboMaSPS.Text = "";
            cboTenSPS.Text = "";
            txtSLBanSFrom.Text = "";
            txtSLBanSTo.Text = "";
            txtGiaBanSFrom.Text = "";
            txtGiaBanSTo.Text = "";
            txtGiamGiaSFrom.Text = "";
            txtGiamGiaSTo.Text = "";
            dtpBaoHanhSFrom.Value = dtpBaoHanhSFrom.MinDate;
            dtpBaoHanhSTo.Value = dtpBaoHanhSTo.MaxDate;
        }

        private bool checkValueHD()
        {
            bool check = true;

            if (cboTenNV.Text.Trim() == "")
            {
                errCheck.SetError(cboTenNV, "Không được để trống!");
                check = false;
            }
            else if (cboTenNV.SelectedItem == null)
            {
                bool existItem = false;
                for (int i = 0; i < cboTenNV.Items.Count; i++)
                {
                    if (cboTenNV.Text == cboTenNV.GetItemText(cboTenNV.Items[i]))
                    {
                        existItem = true;
                        break;
                    }
                }

                if (!existItem)
                {
                    errCheck.SetError(cboTenNV, "Không tồn tại nhân viên này!");
                    check = false;
                }
                else
                    errCheck.SetError(cboTenNV, "");
            }
            else
            {
                errCheck.SetError(cboTenNV, "");
            }

            if (cboMaKH.Text.Trim() == "")
            {
                errCheck.SetError(cboMaKH, "Không được để trống!");
                check = false;
            }
            else if (cboMaKH.SelectedItem == null)
            {
                bool existItem = false;
                for (int i = 0; i < cboMaKH.Items.Count; i++)
                {
                    if (cboMaKH.Text == cboMaKH.GetItemText(cboMaKH.Items[i]))
                    {
                        existItem = true;
                        break;
                    }
                }

                if (!existItem)
                {
                    errCheck.SetError(cboMaKH, "Không tồn tại khách hàng này!");
                    check = false;
                }
                else
                    errCheck.SetError(cboMaKH, "");
            }
            else
            {
                errCheck.SetError(cboMaKH, "");
            }

            if (dtpNgayBan.Value > DateTime.Now)
            {
                errCheck.SetError(dtpNgayBan, "Ngày bán không được lớn hơn ngày hiện tại!");
                check = false;
            } 
            else
            {
                errCheck.SetError(dtpNgayBan, "");
            }


            return check;
        }

        private bool checkValueCT()
        {
            bool check = true;
            Regex isInt = new Regex(@"^\d+$"),
                  isFloat = new Regex(@"^\d(.\d){0,1}\d*$");

            if (cboMaSP.Text.Trim() == "")
            {
                errCheck.SetError(cboMaSP, "Không được để trống!");
                check = false;
            }
            else if (cboMaSP.SelectedItem == null)
            {
                bool existItem = false;
                for (int i = 0; i < cboMaSP.Items.Count; i++)
                {
                    if (cboMaSP.Text == cboMaSP.GetItemText(cboMaSP.Items[i]))
                    {
                        existItem = true;
                        break;
                    }
                }

                if (!existItem)
                {
                    errCheck.SetError(cboMaSP, "Không tồn tại sản phẩm này!");
                    check = false;
                }
                else
                    errCheck.SetError(cboMaSP, "");
            }
            else
            {
                errCheck.SetError(cboMaSP, "");
            }

            if (txtSLBan.Text.Trim() == "")
            {
                errCheck.SetError(txtSLBan, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isInt.IsMatch(txtSLBan.Text.Trim()))
                {
                    errCheck.SetError(txtSLBan, "Số lượng bán không hợp lệ!");
                    check = false;
                }
                else if (int.Parse(txtSLBan.Text.Trim()) <= 0)
                {
                    errCheck.SetError(txtSLBan, "Số lượng bán phải lớn hơn 0!");
                    check = false;
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cm = new SqlCommand(
                            $@"SELECT iTongSL FROM tblSanPham WHERE sMaSP = '{cboMaSP.Text}'"
                            , con))
                        {
                            cm.CommandType = CommandType.Text;
                            con.Open();
                            if ((int)cm.ExecuteScalar() < int.Parse(txtSLBan.Text.Trim()))
                            {
                                errCheck.SetError(txtSLBan, "Số lượng bán phải nhỏ hơn số lượng sản phẩm hiện có!");
                                check = false;
                            }
                            else
                                errCheck.SetError(txtSLBan, "");
                        }
                    }
                } 
            }

            if (txtGiaBan.Text.Trim() == "")
            {
                errCheck.SetError(txtGiaBan, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isFloat.IsMatch(txtGiaBan.Text.Trim()))
                {
                    errCheck.SetError(txtGiaBan, "Giá bán không hợp lệ!");
                    check = false;
                }
                else if (float.Parse(txtGiaBan.Text.Trim()) <= 0)
                {
                    errCheck.SetError(txtGiaBan, "Giá bán phải lớn hơn 0!");
                    check = false;
                }
                else
                    errCheck.SetError(txtGiaBan, "");
            }

            if (txtGiamGia.Text.Trim() == "")
            {
                errCheck.SetError(txtGiamGia, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isFloat.IsMatch(txtGiamGia.Text.Trim()))
                {
                    errCheck.SetError(txtGiamGia, "Mức giảm giá không hợp lệ!");
                    check = false;
                }
                else if (float.Parse(txtGiamGia.Text.Trim()) < 0 || float.Parse(txtGiamGia.Text.Trim()) > 1)
                {
                    errCheck.SetError(txtGiamGia, "Mức giảm giá phải nằm trong khoảng 0 - 1!");
                    check = false;
                }
                else
                    errCheck.SetError(txtGiamGia, "");
            }

            return check;
        }

        private bool checkValueHDS()
        {
            bool check = true;
            
            if (dtpNgayBanSFrom.Value.Date > dtpNgayBanSTo.Value.Date)
            {
                errCheck.SetError(dtpNgayBanSTo, "Ngày bắt đầu không được lớn hơn ngày kết thúc!");
                check = false;
            } 
            else
            {
                errCheck.SetError(dtpNgayBanSTo, "");
            }

            return check;
        }

        private bool checkValueCTS()
        {
            bool check = true;
            Regex isInt = new Regex(@"^\d+$"),
                  isFloat = new Regex(@"^(\d+(.\d){0,1}\d*)+$");

            if ((txtSLBanSFrom.Text.Trim() != "" && !isInt.IsMatch(txtSLBanSFrom.Text.Trim()))
                || (txtSLBanSTo.Text.Trim() != "" && !isInt.IsMatch(txtSLBanSTo.Text.Trim())))
            {
                errCheck.SetError(txtSLBanSTo, "Số lượng bán không hợp lệ!");
                check = false;
            }
            else
            {
                if (isInt.IsMatch(txtSLBanSFrom.Text.Trim()) && isInt.IsMatch(txtSLBanSTo.Text.Trim())
                && (int.Parse(txtSLBanSFrom.Text.Trim()) > int.Parse(txtSLBanSTo.Text.Trim())))
                {
                    errCheck.SetError(txtSLBanSTo, "Giá trị trước không được lớn hơn giá trị sau!");
                    check = false;
                }
                else
                    errCheck.SetError(txtSLBanSTo, "");
            }

            if ((txtGiaBanSFrom.Text.Trim() != "" && !isFloat.IsMatch(txtGiaBanSFrom.Text.Trim()))
                || (txtGiaBanSTo.Text.Trim() != "" && !isFloat.IsMatch(txtGiaBanSTo.Text.Trim())))
            {
                errCheck.SetError(txtGiaBanSTo, "Giá bán không hợp lệ!");
                check = false;
            }
            else
            {
                if (isFloat.IsMatch(txtGiaBanSFrom.Text.Trim()) && isFloat.IsMatch(txtGiaBanSTo.Text.Trim())
                && (float.Parse(txtGiaBanSFrom.Text.Trim()) > float.Parse(txtGiaBanSTo.Text.Trim())))
                {
                    errCheck.SetError(txtGiaBanSTo, "Giá trị trước không được lớn hơn giá trị sau!");
                    check = false;
                }
                else
                    errCheck.SetError(txtGiaBanSTo, "");
            }

            if ((txtGiamGiaSFrom.Text.Trim() != "" && !isFloat.IsMatch(txtGiamGiaSFrom.Text.Trim()))
                || (txtGiamGiaSTo.Text.Trim() != "" && !isFloat.IsMatch(txtGiamGiaSTo.Text.Trim())))
            {
                errCheck.SetError(txtGiamGiaSTo, "Mức giảm giá không hợp lệ!");
                check = false;
            }
            else
            {
                if (isFloat.IsMatch(txtGiamGiaSFrom.Text.Trim()) && isFloat.IsMatch(txtGiamGiaSTo.Text.Trim())
                && (float.Parse(txtGiamGiaSFrom.Text.Trim()) > float.Parse(txtGiamGiaSTo.Text.Trim())))
                {
                    errCheck.SetError(txtGiamGiaSTo, "Giá trị trước không được lớn hơn giá trị sau!");
                    check = false;
                }
                else
                    errCheck.SetError(txtGiamGiaSTo, "");
            }

            if (dtpBaoHanhSFrom.Value.Date > dtpBaoHanhSTo.Value.Date)
            {
                errCheck.SetError(dtpBaoHanhSTo, "Ngày bắt đầu không được lớn hơn ngày kết thúc!");
                check = false;
            }
            else
            {
                errCheck.SetError(dtpBaoHanhSTo, "");
            }

            return check;
        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenNV.Text != "")
            {
                //txtTenNV.Text = (string)getDSNV().Rows[cboTenNV.SelectedIndex]["sTenNV"];
            }
        }

        private void cboMaNV_Leave(object sender, EventArgs e)
        {
            int index = cboTenNV.FindStringExact(cboTenNV.Text);
            if (index != -1)
            {
                cboTenNV.SelectedIndex = index;
            }
            else
            {
                //txtTenNV.Text = "";
            }
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaKH.Text != "")
            {
                txtTenKH.Text = (string)getDSKH().Rows[cboMaKH.SelectedIndex]["sTenKH"];
            }
        }

        private void cboMaKH_Leave(object sender, EventArgs e)
        {
            int index = cboMaKH.FindStringExact(cboMaKH.Text);
            if (index != -1)
            {
                cboMaKH.SelectedIndex = index;
            }
            else
            {
                txtTenKH.Text = "";
            }
        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaSP.Text != "")
            {
                txtTenSP.Text = (string)getDSSP().Rows[cboMaSP.SelectedIndex]["sTenSP"];
            }
        }

        private void cboMaSP_Leave(object sender, EventArgs e)
        {
            int index = cboMaSP.FindStringExact(cboMaSP.Text);
            if (index != -1)
            {
                cboMaSP.SelectedIndex = index;
            }
            else
            {
                txtTenSP.Text = "";
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThemHD.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (e.RowIndex == -1)
                return;

            DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
            txtMaHDB.Text = row.Cells["iMaHDB"].Value.ToString();
            cboTenNV.Text = row.Cells["sMaNV"].Value.ToString();
            cboMaKH.Text = row.Cells["sMaKH"].Value.ToString();
            dtpNgayBan.Text = row.Cells["dNgayBan"].Value.ToString();
            //txtTenNV.Text = row.Cells["sTenNV"].Value.ToString();
            txtTenKH.Text = row.Cells["sTenKH"].Value.ToString();
            resetValueCT();

            dgvCTHoaDon.DataSource = getDSCT_HDB(int.Parse(txtMaHDB.Text));

            if (btnThemHD.Enabled == true)
            {
                btnSuaHD.Enabled = true;
                btnXoaHD.Enabled = true;

                txtMaHDB.Enabled = false;
            }
        }

        private void dgvCTHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThemCT.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (e.RowIndex == -1)
                return;

            DataGridViewRow row = dgvCTHoaDon.Rows[e.RowIndex];
            txtMaHDB.Text = row.Cells["iMaHDB"].Value.ToString();
            cboMaSP.Text = row.Cells["sMaSP"].Value.ToString();
            txtTenSP.Text = row.Cells["sTenSP"].Value.ToString();
            txtSLBan.Text = row.Cells["iSLBan"].Value.ToString();
            txtGiaBan.Text = row.Cells["fGiaBan"].Value.ToString();
            txtGiamGia.Text = row.Cells["fMucGiamGia"].Value.ToString();
            mtxtTGBH.Text = row.Cells["dTGBaoHanh"].Value.ToString();

            if (btnThemCT.Enabled == true)
            {
                btnSuaCT.Enabled = true;
                btnXoaCT.Enabled = true;
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            if (btnSuaHD.Enabled == true)
                resetValueHD();

            btnThemHD.Enabled = false;
            btnLuuHD.Enabled = true;
            btnSuaHD.Enabled = false;
            btnXoaHD.Enabled = false;
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            if (checkValueHD())
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"INSERT INTO dbo.tblHoaDonBan(sMaNV, sMaKH, dNgayBan)
                            VALUES(@MaNV, @MaKH, @NgayBan)"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaNV", cboTenNV.SelectedValue);
                        cm.Parameters.AddWithValue("@MaKH", cboMaKH.Text.Trim());
                        cm.Parameters.AddWithValue("@NgayBan", dtpNgayBan.Value.Date.ToString("yyyy-MM-dd"));
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                btnThemHD.Enabled = true;
                btnLuuHD.Enabled = false;

                resetValueHD();

                dgvHoaDon.DataSource = getDSHDB();
            }
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            if (checkValueHD())
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"UPDATE dbo.tblHoaDonBan
                            SET sMaNV = @MaNV,
	                            sMaKH = @MaKH, 
	                            dNgayBan = @NgayBan
                            WHERE iMaHDB = @MaHDB"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaHDB", txtMaHDB.Text);
                        cm.Parameters.AddWithValue("@MaNV", cboTenNV.SelectedValue);
                        cm.Parameters.AddWithValue("@MaKH", cboMaKH.Text.Trim());
                        cm.Parameters.AddWithValue("@NgayBan", dtpNgayBan.Value.Date.ToString("yyyy-MM-dd"));
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                resetValueHD();

                dgvHoaDon.DataSource = getDSHDB();
            }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn bán có mã {txtMaHDB.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        "UPDATE tblHoaDonBan SET isDeleted = 1 WHERE iMaHDB = @MaHDB"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaHDB", txtMaHDB.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                resetValueHD();

                dgvHoaDon.DataSource = getDSHDB();
            }
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            errCheck.Clear();

            btnXoaHD.Enabled = false;
            btnSuaHD.Enabled = false;
            if (btnThemHD.Enabled == false)
            {
                btnThemHD.Enabled = true;
                btnLuuHD.Enabled = false;
            }

            resetValueHD();
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if (txtMaHDB.Text == "")
            {
                MessageBox.Show($"Bạn phải chọn hóa đơn cần thêm chi tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (btnSuaCT.Enabled == true)
                    resetValueCT();

                btnThemCT.Enabled = false;
                btnLuuCT.Enabled = true;
                btnSuaCT.Enabled = false;
                btnXoaCT.Enabled = false;

                cboMaSP.Focus();
            }
        }

        private void btnLuuCT_Click(object sender, EventArgs e)
        {
            if (checkValueCT())
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"INSERT INTO dbo.tblCT_HoaDonBan(iMaHDB, sMaSP, iSLBan, fGiaBan, fMucGiamGia)
                            VALUES(@MaHDB, @MaSP, @SLBan, @GiaBan, @MucGiamGia)"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaHDB", txtMaHDB.Text);
                        cm.Parameters.AddWithValue("@MaSP", cboMaSP.Text.Trim());
                        cm.Parameters.AddWithValue("@SLBan", txtSLBan.Text.Trim());
                        cm.Parameters.AddWithValue("@GiaBan", txtGiaBan.Text.Trim());
                        cm.Parameters.AddWithValue("@MucGiamGia", txtGiamGia.Text.Trim());
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                btnThemCT.Enabled = true;
                btnLuuCT.Enabled = false;

                resetValueCT();

                dgvCTHoaDon.DataSource = getDSCT_HDB(int.Parse(txtMaHDB.Text));
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            if (checkValueCT())
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"UPDATE dbo.tblCT_HoaDonBan
                            SET sMaSP = @MaSP,
	                            iSLBan = @SLBan,
	                            fGiaBan = @GiaBan,
	                            fMucGiamGia = @MucGiamGia
                            WHERE iMaHDB = @MaHDB"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaHDB", txtMaHDB.Text);
                        cm.Parameters.AddWithValue("@MaSP", cboMaSP.Text.Trim());
                        cm.Parameters.AddWithValue("@SLBan", txtSLBan.Text.Trim());
                        cm.Parameters.AddWithValue("@GiaBan", txtGiaBan.Text.Trim());
                        cm.Parameters.AddWithValue("@MucGiamGia", txtGiamGia.Text.Trim());
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                resetValueCT();

                dgvCTHoaDon.DataSource = getDSCT_HDB(int.Parse(txtMaHDB.Text));
            }
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa chi tiết hóa đơn bán {txtMaHDB.Text} - {cboMaSP.Text.Trim()}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        "DELETE FROM tblCT_HoaDonBan WHERE iMaHDB = @MaHDB AND sMaSP = @MaSP"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaHDB", txtMaHDB.Text);
                        cm.Parameters.AddWithValue("@MaSP", cboMaSP.Text.Trim());
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                resetValueCT();

                dgvCTHoaDon.DataSource = getDSCT_HDB(int.Parse(txtMaHDB.Text));
            }
        }

        private void btnHuyCT_Click(object sender, EventArgs e)
        {
            errCheck.Clear();

            btnXoaCT.Enabled = false;
            btnSuaCT.Enabled = false;
            if (btnThemCT.Enabled == false)
            {
                btnThemCT.Enabled = true;
                btnLuuCT.Enabled = false;
            }

            resetValueCT();
        }

        private void btnTimKiemHD_Click(object sender, EventArgs e)
        {
            if (checkValueHDS())
            {
                string condition = "1=1 ";

                if (cboMaHDBS.Text.Trim() != "")
                    condition += $"AND tblHoaDonBan.iMaHDB = '{cboMaHDBS.Text.Replace("'", "''")}' ";
                if (cboMaNVS.Text.Trim() != "")
                    condition += $"AND tblHoaDonBan.sMaNV = '{cboMaNVS.Text.Replace("'", "''")}' ";
                if (cboMaKHS.Text.Trim() != "")
                    condition += $"AND tblHoaDonBan.sMaKH = '{cboMaKHS.Text.Replace("'", "''")}' ";
                if (cboTenNVS.Text.Trim() != "")
                    condition += $"AND sTenNV LIKE N'%{cboTenNVS.Text.Replace("'", "''")}%' ";
                if (cboTenKHS.Text.Trim() != "")
                    condition += $"AND sTenKH LIKE N'%{cboTenKHS.Text.Replace("'", "''")}%' ";
                condition += $"AND dNgayBan BETWEEN '{dtpNgayBanSFrom.Value.Date.ToString("yyyy/MM/dd")}' AND '{dtpNgayBanSTo.Value.Date.ToString("yyyy/MM/dd")}' ";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT tblHoaDonBan.iMaHDB, tblHoaDonBan.sMaNV, sTenNV, tblHoaDonBan.sMaKH, sTenKH, dNgayBan, 
	                            ISNULL(t1.[Số Lượng Bán], 0) [Số Lượng Bán], 
	                            ISNULL(t1.[Tổng Tiền], 0) [Tổng Tiền]
                            FROM dbo.tblHoaDonBan
                            LEFT JOIN dbo.tblKhachHang ON tblKhachHang.sMaKH = tblHoaDonBan.sMaKH
                            LEFT JOIN dbo.tblNhanVien ON tblNhanVien.sMaNV = tblHoaDonBan.sMaNV
                            LEFT JOIN (
	                            SELECT iMaHDB, SUM(iSLBan) [Số Lượng Bán], SUM(iSLBan*fGiaBan*(1-fMucGiamGia)) [Tổng Tiền] 
	                            FROM dbo.tblCT_HoaDonBan
	                            GROUP BY iMaHDB
                            ) t1 ON t1.iMaHDB = tblHoaDonBan.iMaHDB
                            WHERE {condition}"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                        {
                            using (DataTable dt = new DataTable("tblHoaDonBan"))
                            {
                                sda.Fill(dt);
                                dgvHoaDon.DataSource = dt;
                            }
                        }
                    }
                }

                lblCountHD.Text = dgvHoaDon.RowCount.ToString();
            }
        }

        private void btnHienTatCaHD_Click(object sender, EventArgs e)
        {
            resetValueHDS();

            dgvHoaDon.DataSource = getDSHDB();

            lblCountHD.Text = dgvHoaDon.RowCount.ToString();
        }

        private void btnTimKiemCT_Click(object sender, EventArgs e)
        {
            if (checkValueCTS())
            {
                string condition = "1=1 ";

                if (cboMaSPS.Text.Trim() != "")
                    condition += $"AND tblCT_HoaDonBan.sMaSP = '{cboMaSPS.Text.Replace("'", "''")}' ";
                if (cboTenSPS.Text.Trim() != "")
                    condition += $"AND sTenSP LIKE N'%{cboTenSPS.Text.Replace("'", "''")}%' ";
                if (txtSLBanSFrom.Text.Trim() != "" || txtSLBanSTo.Text.Trim() != "")
                {
                    string fromValue = txtSLBanSFrom.Text.Trim() != "" ? txtSLBanSFrom.Text.Trim() : "0",
                           toValue = txtSLBanSTo.Text.Trim() != "" ? txtSLBanSTo.Text.Trim() : int.MaxValue.ToString();

                    condition += $"AND iSLBan BETWEEN {fromValue} AND {toValue} ";
                }
                if (txtGiaBanSFrom.Text.Trim() != "" || txtGiaBanSTo.Text.Trim() != "")
                {
                    string fromValue = txtGiaBanSFrom.Text.Trim() != "" ? txtGiaBanSFrom.Text.Trim() : "0",
                           toValue = txtGiaBanSTo.Text.Trim() != "" ? txtGiaBanSTo.Text.Trim() : float.MaxValue.ToString();

                    condition += $"AND fGiaBan BETWEEN {fromValue} AND {toValue} ";
                }
                if (txtGiamGiaSFrom.Text.Trim() != "" || txtGiamGiaSTo.Text.Trim() != "")
                {
                    string fromValue = txtGiamGiaSFrom.Text.Trim() != "" ? txtGiamGiaSFrom.Text.Trim() : "0",
                           toValue = txtGiamGiaSTo.Text.Trim() != "" ? txtGiamGiaSTo.Text.Trim() : "1";

                    condition += $"AND fMucGiamGia BETWEEN {fromValue} AND {toValue} ";
                }
                condition += $"AND dTGBaoHanh BETWEEN '{dtpBaoHanhSFrom.Value.Date.ToString("yyyy/MM/dd")}' AND '{dtpBaoHanhSTo.Value.Date.ToString("yyyy/MM/dd")}' ";
                
                List<string> MaHDBs = new List<string>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT iMaHDB, tblCT_HoaDonBan.sMaSP, sTenSP, iSLBan, fGiaBan, fMucGiamGia, dTGBaoHanh
                            FROM dbo.tblCT_HoaDonBan
                            INNER JOIN dbo.tblSanPham ON tblSanPham.sMaSP = tblCT_HoaDonBan.sMaSP
                            WHERE {condition}"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                        {
                            using (DataTable dt = new DataTable("tblCT_HoaDonBan"))
                            {
                                sda.Fill(dt);
                                dgvCTHoaDon.DataSource = dt;
                                foreach (DataRow row in dt.Rows)
                                    MaHDBs.Add(row["iMaHDB"].ToString());
                            }
                        }
                    }
                }

                lblCountCT.Text = dgvCTHoaDon.RowCount.ToString();

                dgvHoaDon.DataSource = getDSHDB(MaHDBs);
                lblCountHD.Text = dgvHoaDon.RowCount.ToString();
            }
        }

        private void btnHienTatCaCT_Click(object sender, EventArgs e)
        {
            resetValueCTS();

            dgvCTHoaDon.DataSource = getDSCT_HDB();

            lblCountCT.Text = dgvCTHoaDon.RowCount.ToString();
        }

        private void tabContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabContainer.SelectedTab == tpTimKiem)
            {
                string oldMaHDB = cboMaHDBS.Text,
                       oldMaNV = cboMaNVS.Text,
                       oldTenNV = cboTenNVS.Text,
                       oldMaKH = cboMaKHS.Text,
                       oldTenKH = cboTenKHS.Text,
                       oldMaSP = cboMaSPS.Text,
                       oldTenSP = cboTenSPS.Text;

                cboMaHDBS.DataSource = new DataView(getDSHDB(), "", "iMaHDB", DataViewRowState.CurrentRows);
                cboMaHDBS.DisplayMember = "iMaHDB";
                cboMaHDBS.ValueMember = "iMaHDB";
                cboMaHDBS.Text = oldMaHDB;

                cboMaNVS.DataSource = new DataView(getDSNV(), "", "sMaNV", DataViewRowState.CurrentRows);
                cboMaNVS.DisplayMember = "sMaNV";
                cboMaNVS.ValueMember = "sMaNV";
                cboMaNVS.Text = oldMaNV;

                cboTenNVS.DataSource = new DataView(getDSNV().DefaultView.ToTable(true, "sTenNV"), "", "sTenNV", DataViewRowState.CurrentRows);
                cboTenNVS.DisplayMember = "sTenNV";
                cboTenNVS.ValueMember = "sTenNV";
                cboTenNVS.Text = oldTenNV;

                cboMaKHS.DataSource = new DataView(getDSKH(), "", "sMaKH", DataViewRowState.CurrentRows);
                cboMaKHS.DisplayMember = "sMaKH";
                cboMaKHS.ValueMember = "sMaKH";
                cboMaKHS.Text = oldMaKH;

                cboTenKHS.DataSource = new DataView(getDSKH().DefaultView.ToTable(true, "sTenKH"), "", "sTenKH", DataViewRowState.CurrentRows);
                cboTenKHS.DisplayMember = "sTenKH";
                cboTenKHS.ValueMember = "sTenKH";
                cboTenKHS.Text = oldTenKH;

                cboMaSPS.DataSource = new DataView(getDSSP(), "", "sMaSP", DataViewRowState.CurrentRows);
                cboMaSPS.DisplayMember = "sMaSP";
                cboMaSPS.ValueMember = "sMaSP";
                cboMaSPS.Text = oldMaSP;

                cboTenSPS.DataSource = new DataView(getDSSP().DefaultView.ToTable(true, "sTenSP"), "", "sTenSP", DataViewRowState.CurrentRows);
                cboTenSPS.DisplayMember = "sTenSP";
                cboTenSPS.ValueMember = "sTenSP";
                cboTenSPS.Text = oldTenSP;
            }
        }

        private void frmHoaDonBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show($"Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}
