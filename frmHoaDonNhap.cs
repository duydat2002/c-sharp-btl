using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class frmHoaDonNhap : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public frmHoaDonNhap()
        {
            InitializeComponent();
        }

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = getDSHDN();
            dgvHoaDon.Columns[0].HeaderText = "Mã HDN";
            dgvHoaDon.Columns[1].HeaderText = "Mã nhân viên";
            dgvHoaDon.Columns[2].HeaderText = "Tên nhân viên";
            dgvHoaDon.Columns[3].HeaderText = "Mã NCC";
            dgvHoaDon.Columns[4].HeaderText = "Tên NCC";
            dgvHoaDon.Columns[5].HeaderText = "Ngày nhập";
            dgvHoaDon.Columns[6].HeaderText = "Số lượng nhập";
            dgvHoaDon.Columns[7].HeaderText = "Tổng tiền";
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCTHoaDon.DataSource = getDSCT_HDN();
            dgvCTHoaDon.Columns[0].HeaderText = "Mã HDN";
            dgvCTHoaDon.Columns[1].HeaderText = "Mã sản phẩm";
            dgvCTHoaDon.Columns[2].HeaderText = "Tên sản phẩm";
            dgvCTHoaDon.Columns[3].HeaderText = "Số lượng nhập";
            dgvCTHoaDon.Columns[4].HeaderText = "Giá nhập";
            dgvCTHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnLuuHD.Enabled = false;
            btnSuaHD.Enabled = false;
            btnXoaHD.Enabled = false;
            btnLuuCT.Enabled = false;
            btnSuaCT.Enabled = false;
            btnXoaCT.Enabled = false;
            dtpNgayNhapSFrom.Value = dtpNgayNhapSFrom.MinDate;

            cboMaNV.DataSource = new DataView(getDSNV(), "", "sMaNV", DataViewRowState.CurrentRows);
            cboMaNV.DisplayMember = "sMaNV";
            cboMaNV.ValueMember = "sMaNV";

            cboMaNCC.DataSource = new DataView(getDSNCC(), "", "sMaNCC", DataViewRowState.CurrentRows);
            cboMaNCC.DisplayMember = "sMaNCC";
            cboMaNCC.ValueMember = "sMaNCC";

            cboMaSP.DataSource = new DataView(getDSSP(), "", "sMaSP", DataViewRowState.CurrentRows);
            cboMaSP.DisplayMember = "sMaSP";
            cboMaSP.ValueMember = "sMaSP";

            resetValueHD();
            resetValueCT();

            txtMaHDN.Enabled = false;
            txtTenNV.Enabled = false;
            txtTenNCC.Enabled = false;
            txtTenSP.Enabled = false;

            lblCountHD.Text = dgvHoaDon.RowCount.ToString();
            lblCountCT.Text = dgvCTHoaDon.RowCount.ToString();
        }

        private DataTable getDSHDN()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT tblHoaDonNhap.iMaHDN, tblHoaDonNhap.sMaNV, sTenNV, tblHoaDonNhap.sMaNCC, sTenNCC, dNgayNhapHang, 
	                            ISNULL(t1.[Số Lượng Nhập], 0) [Số Lượng Nhập], 
	                            ISNULL(t1.[Tổng Tiền], 0) [Tổng Tiền]
                            FROM dbo.tblHoaDonNhap
                            LEFT JOIN dbo.tblNhanVien ON tblNhanVien.sMaNV = tblHoaDonNhap.sMaNV
                            LEFT JOIN dbo.tblNhaCungCap ON tblNhaCungCap.sMaNCC = tblHoaDonNhap.sMaNCC
                            LEFT JOIN (
	                            SELECT iMaHDN, SUM(iSLNhap) [Số Lượng Nhập], SUM(iSLNhap*fGiaNhap) [Tổng Tiền] 
	                            FROM dbo.tblCT_HoaDonNhap
	                            GROUP BY iMaHDN
                            ) t1 ON t1.iMaHDN = tblHoaDonNhap.iMaHDN
                            WHERE tblHoaDonNhap.isDeleted = 0"
                        , cnn))
                    {
                        cm.CommandType = CommandType.Text;
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblHoaDonNhap");
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

        private DataTable getDSHDN(List<string> MaHDNs)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT tblHoaDonNhap.iMaHDN, tblHoaDonNhap.sMaNV, sTenNV, tblHoaDonNhap.sMaNCC, sTenNCC, dNgayNhapHang, 
	                            ISNULL(t1.[Số Lượng Nhập], 0) [Số Lượng Nhập], 
	                            ISNULL(t1.[Tổng Tiền], 0) [Tổng Tiền]
                            FROM dbo.tblHoaDonNhap
                            LEFT JOIN dbo.tblNhanVien ON tblNhanVien.sMaNV = tblHoaDonNhap.sMaNV
                            LEFT JOIN dbo.tblNhaCungCap ON tblNhaCungCap.sMaNCC = tblHoaDonNhap.sMaNCC
                            LEFT JOIN (
	                            SELECT iMaHDN, SUM(iSLNhap) [Số Lượng Nhập], SUM(iSLNhap*fGiaNhap) [Tổng Tiền] 
	                            FROM dbo.tblCT_HoaDonNhap
	                            GROUP BY iMaHDN
                            ) t1 ON t1.iMaHDN = tblHoaDonNhap.iMaHDN
                            WHERE tblHoaDonNhap.iMaHDN IN ({(MaHDNs.Count == 0 ? "-1" : string.Join(",", MaHDNs))})
                            AND tblHoaDonNhap.isDeleted = 0"
                        , cnn))
                    {
                        cm.CommandType = CommandType.Text;
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblHoaDonNhap");
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

        private DataTable getDSCT_HDN()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT iMaHDN, tblCT_HoaDonNhap.sMaSP, sTenSP, iSLNhap, fGiaNhap
                            FROM dbo.tblCT_HoaDonNhap
                            INNER JOIN dbo.tblSanPham ON tblSanPham.sMaSP = tblCT_HoaDonNhap.sMaSP"
                        , cnn))
                    {
                        cm.CommandType = CommandType.Text;
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblCT_HoaDonNhap");
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

        private DataTable getDSCT_HDN(int MaHDN)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT iMaHDN, tblCT_HoaDonNhap.sMaSP, sTenSP, iSLNhap, fGiaNhap
                            FROM dbo.tblCT_HoaDonNhap
                            INNER JOIN dbo.tblSanPham ON tblSanPham.sMaSP = tblCT_HoaDonNhap.sMaSP
                            WHERE iMaHDN = @MaHDN"
                        , cnn))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaHDN", MaHDN);
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblCT_HoaDonNhap");
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

        private DataTable getDSNCC()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT sMaNCC, sTenNCC FROM dbo.tblNhaCungCap"
                        , cnn))
                    {
                        cm.CommandType = CommandType.Text;
                        cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblNhaCungCap");
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
            txtMaHDN.Text = "";
            cboMaNV.Text = "";
            cboMaNCC.Text = "";
            dtpNgayNhap.Text = "";
            txtTenNV.Text = "";
            txtTenNCC.Text = "";
        }

        private void resetValueCT()
        {
            cboMaSP.Text = "";
            txtSLNhap.Text = "";
            txtGiaNhap.Text = "";
            txtTenSP.Text = "";
        }

        private void resetValueHDS()
        {
            cboMaHDNS.Text = "";
            cboMaNVS.Text = "";
            cboMaNCCS.Text = "";
            cboTenNVS.Text = "";
            cboTenNCCS.Text = "";
            dtpNgayNhapSFrom.Value = dtpNgayNhapSFrom.MinDate;
        }

        private void resetValueCTS()
        {
            cboMaSPS.Text = "";
            cboTenSPS.Text = "";
            txtSLNhapSFrom.Text = "";
            txtSLNhapSTo.Text = "";
            txtGiaNhapSFrom.Text = "";
            txtGiaNhapSTo.Text = "";
        }

        private bool checkValueHD()
        {
            bool check = true;

            if (cboMaNV.Text.Trim() == "")
            {
                errCheck.SetError(cboMaNV, "Không được để trống!");
                check = false;
            }
            else if (cboMaNV.SelectedItem == null)
            {
                bool existItem = false;
                for (int i = 0; i < cboMaNV.Items.Count; i++)
                {
                    if (cboMaNV.Text == cboMaNV.GetItemText(cboMaNV.Items[i]))
                    {
                        existItem = true;
                        break;
                    }
                }

                if (!existItem)
                {
                    errCheck.SetError(cboMaNV, "Không tồn tại nhân viên này!");
                    check = false;
                }
                else
                    errCheck.SetError(cboMaNV, "");
            }
            else
            {
                errCheck.SetError(cboMaNV, "");
            }

            if (cboMaNCC.Text.Trim() == "")
            {
                errCheck.SetError(cboMaNCC, "Không được để trống!");
                check = false;
            }
            else if (cboMaNCC.SelectedItem == null)
            {
                bool existItem = false;
                for (int i = 0; i < cboMaNCC.Items.Count; i++)
                {
                    if (cboMaNCC.Text == cboMaNCC.GetItemText(cboMaNCC.Items[i]))
                    {
                        existItem = true;
                        break;
                    }
                }

                if (!existItem)
                {
                    errCheck.SetError(cboMaNCC, "Không tồn tại nhà cung cấp này!");
                    check = false;
                }
                else
                    errCheck.SetError(cboMaNCC, "");
            }
            else
            {
                errCheck.SetError(cboMaNCC, "");
            }

            if (dtpNgayNhap.Value > DateTime.Now)
            {
                errCheck.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn ngày hiện tại!");
                check = false;
            }
            else
            {
                errCheck.SetError(dtpNgayNhap, "");
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

            if (txtSLNhap.Text.Trim() == "")
            {
                errCheck.SetError(txtSLNhap, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isInt.IsMatch(txtSLNhap.Text.Trim()))
                {
                    errCheck.SetError(txtSLNhap, "Số lượng nhập không hợp lệ!");
                    check = false;
                }
                else if (int.Parse(txtSLNhap.Text.Trim()) <= 0)
                {
                    errCheck.SetError(txtSLNhap, "Số lượng nhập phải lớn hơn 0!");
                    check = false;
                }
                else
                    errCheck.SetError(txtSLNhap, "");
            }

            if (txtGiaNhap.Text.Trim() == "")
            {
                errCheck.SetError(txtGiaNhap, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isFloat.IsMatch(txtGiaNhap.Text.Trim()))
                {
                    errCheck.SetError(txtGiaNhap, "Giá nhập không hợp lệ!");
                    check = false;
                }
                else if (float.Parse(txtGiaNhap.Text.Trim()) <= 0)
                {
                    errCheck.SetError(txtGiaNhap, "Giá nhập phải lớn hơn 0!");
                    check = false;
                }
                else
                    errCheck.SetError(txtGiaNhap, "");
            }

            return check;
        }

        private bool checkValueHDS()
        {
            bool check = true;

            if (dtpNgayNhapSFrom.Value.Date > dtpNgayNhapSTo.Value.Date)
            {
                errCheck.SetError(dtpNgayNhapSTo, "Ngày bắt đầu không được lớn hơn ngày kết thúc!");
                check = false;
            }
            else
            {
                errCheck.SetError(dtpNgayNhapSTo, "");
            }

            return check;
        }

        private bool checkValueCTS()
        {
            bool check = true;
            Regex isInt = new Regex(@"^\d+$"),
                  isFloat = new Regex(@"^(\d+(.\d){0,1}\d*)+$");

            if ((txtSLNhapSFrom.Text.Trim() != "" && !isInt.IsMatch(txtSLNhapSFrom.Text.Trim()))
                || (txtSLNhapSTo.Text.Trim() != "" && !isInt.IsMatch(txtSLNhapSTo.Text.Trim())))
            {
                errCheck.SetError(txtSLNhapSTo, "Số lượng nhập không hợp lệ!");
                check = false;
            }
            else
            {
                if (isInt.IsMatch(txtSLNhapSFrom.Text.Trim()) && isInt.IsMatch(txtSLNhapSTo.Text.Trim())
                && (int.Parse(txtSLNhapSFrom.Text.Trim()) > int.Parse(txtSLNhapSTo.Text.Trim())))
                {
                    errCheck.SetError(txtSLNhapSTo, "Giá trị trước không được lớn hơn giá trị sau!");
                    check = false;
                }
                else
                    errCheck.SetError(txtSLNhapSTo, "");
            }

            if ((txtGiaNhapSFrom.Text.Trim() != "" && !isFloat.IsMatch(txtGiaNhapSFrom.Text.Trim()))
                || (txtGiaNhapSTo.Text.Trim() != "" && !isFloat.IsMatch(txtGiaNhapSTo.Text.Trim())))
            {
                errCheck.SetError(txtGiaNhapSTo, "Giá nhập không hợp lệ!");
                check = false;
            }
            else
            {
                if (isFloat.IsMatch(txtGiaNhapSFrom.Text.Trim()) && isFloat.IsMatch(txtGiaNhapSTo.Text.Trim())
                && (float.Parse(txtGiaNhapSFrom.Text.Trim()) > float.Parse(txtGiaNhapSTo.Text.Trim())))
                {
                    errCheck.SetError(txtGiaNhapSTo, "Giá trị trước không được lớn hơn giá trị sau!");
                    check = false;
                }
                else
                    errCheck.SetError(txtGiaNhapSTo, "");
            }

            return check;
        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNV.Text != "")
            {
                txtTenNV.Text = (string)getDSNV().Rows[cboMaNV.SelectedIndex]["sTenNV"];
            }
        }

        private void cboMaNV_Leave(object sender, EventArgs e)
        {
            int index = cboMaNV.FindStringExact(cboMaNV.Text);
            if (index != -1)
            {
                cboMaNV.SelectedIndex = index;
            }
            else
            {
                txtTenNV.Text = "";
            }
        }

        private void cboMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNCC.Text != "")
            {
                txtTenNCC.Text = (string)getDSNCC().Rows[cboMaNCC.SelectedIndex]["sTenNCC"];
            }
        }

        private void cboMaNCC_Leave(object sender, EventArgs e)
        {
            int index = cboMaNCC.FindStringExact(cboMaNCC.Text);
            if (index != -1)
            {
                cboMaNCC.SelectedIndex = index;
            }
            else
            {
                txtTenNCC.Text = "";
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
            txtMaHDN.Text = row.Cells["iMaHDN"].Value.ToString();
            cboMaNV.Text = row.Cells["sMaNV"].Value.ToString();
            cboMaNCC.Text = row.Cells["sMaNCC"].Value.ToString();
            dtpNgayNhap.Text = row.Cells["dNgayNhapHang"].Value.ToString();
            txtTenNV.Text = row.Cells["sTenNV"].Value.ToString();
            txtTenNCC.Text = row.Cells["sTenNCC"].Value.ToString();
            resetValueCT();

            dgvCTHoaDon.DataSource = getDSCT_HDN(int.Parse(txtMaHDN.Text));

            if (btnThemHD.Enabled == true)
            {
                btnSuaHD.Enabled = true;
                btnXoaHD.Enabled = true;

                txtMaHDN.Enabled = false;
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
            txtMaHDN.Text = row.Cells["iMaHDN"].Value.ToString();
            cboMaSP.Text = row.Cells["sMaSP"].Value.ToString();
            txtTenSP.Text = row.Cells["sTenSP"].Value.ToString();
            txtSLNhap.Text = row.Cells["iSLNhap"].Value.ToString();
            txtGiaNhap.Text = row.Cells["fGiaNhap"].Value.ToString();

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
                        $@"INSERT INTO dbo.tblHoaDonNhap(sMaNV, sMaNCC, dNgayNhapHang)
                            VALUES(@MaNV, @MaNCC, @NgayNhapHang)"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaNV", cboMaNV.Text.Trim());
                        cm.Parameters.AddWithValue("@MaNCC", cboMaNCC.Text.Trim());
                        cm.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value.Date.ToString("yyyy-MM-dd"));
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                btnThemHD.Enabled = true;
                btnLuuHD.Enabled = false;

                resetValueHD();

                dgvHoaDon.DataSource = getDSHDN();
            }
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            if (checkValueHD())
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"UPDATE dbo.tblHoaDonNhap
                            SET sMaNV = @MaNV,
                                sMaNCC = @MaNCC,
                                dNgayNhapHang = @NgayNhapHang
                            WHERE iMaHDN = @MaHDN"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaHDN", txtMaHDN.Text);
                        cm.Parameters.AddWithValue("@MaNV", cboMaNV.Text.Trim());
                        cm.Parameters.AddWithValue("@MaNCC", cboMaNCC.Text.Trim());
                        cm.Parameters.AddWithValue("@dNgayNhapHang", dtpNgayNhap.Value.Date.ToString("yyyy-MM-dd"));
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                resetValueHD();

                dgvHoaDon.DataSource = getDSHDN();
            }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn nhập có mã {txtMaHDN.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        "UPDATE tblHoaDonNhap SET isDeleted = 1 WHERE iMaHDN = @MaHDN"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaHDN", txtMaHDN.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                resetValueHD();

                dgvHoaDon.DataSource = getDSHDN();
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
            if (txtMaHDN.Text == "")
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
                        $@"INSERT INTO dbo.tblCT_HoaDonNhap(iMaHDN, sMaSP, iSLNhap, fGiaNhap)
                            VALUES(@MaHDN, @MaSP, @SLNhap, @GiaNhap)"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaHDN", txtMaHDN.Text);
                        cm.Parameters.AddWithValue("@MaSP", cboMaSP.Text.Trim());
                        cm.Parameters.AddWithValue("@SLNhap", txtSLNhap.Text.Trim());
                        cm.Parameters.AddWithValue("@GiaNhap", txtGiaNhap.Text.Trim());
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                btnThemCT.Enabled = true;
                btnLuuCT.Enabled = false;

                resetValueCT();

                dgvCTHoaDon.DataSource = getDSCT_HDN(int.Parse(txtMaHDN.Text));
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            if (checkValueCT())
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"UPDATE dbo.tblCT_HoaDonNhap
                            SET sMaSP = @MaSP,
	                            iSLNhap = SLNhap,
	                            fGiaNhap = @GiaNhap
                            WHERE iMaHDN = @MaHDN"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaHDN", txtMaHDN.Text);
                        cm.Parameters.AddWithValue("@MaSP", cboMaSP.Text.Trim());
                        cm.Parameters.AddWithValue("@SLNhap", txtSLNhap.Text.Trim());
                        cm.Parameters.AddWithValue("@GiaNhap", txtGiaNhap.Text.Trim());
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                resetValueCT();

                dgvCTHoaDon.DataSource = getDSCT_HDN(int.Parse(txtMaHDN.Text));
            }
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa chi tiết hóa đơn nhập {txtMaHDN.Text} - {cboMaSP.Text.Trim()}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        "DELETE FROM tblCT_HoaDonNhap WHERE iMaHDN = @MaHDN AND sMaSP = @MaSP"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaHDN", txtMaHDN.Text);
                        cm.Parameters.AddWithValue("@MaSP", cboMaSP.Text.Trim());
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                resetValueCT();

                dgvCTHoaDon.DataSource = getDSCT_HDN(int.Parse(txtMaHDN.Text));
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

                if (cboMaHDNS.Text.Trim() != "")
                    condition += $"AND tblHoaDonNhap.iMaHDN = '{cboMaHDNS.Text.Replace("'", "''")}' ";
                if (cboMaNVS.Text.Trim() != "")
                    condition += $"AND tblHoaDonNhap.sMaNV = '{cboMaNVS.Text.Replace("'", "''")}' ";
                if (cboMaNCCS.Text.Trim() != "")
                    condition += $"AND tblHoaDonNhap.sMaNCC = '{cboMaNCCS.Text.Replace("'", "''")}' ";
                if (cboTenNVS.Text.Trim() != "")
                    condition += $"AND sTenNV LIKE N'%{cboTenNVS.Text.Replace("'", "''")}%' ";
                if (cboTenNCCS.Text.Trim() != "")
                    condition += $"AND sTenNCC LIKE N'%{cboTenNCCS.Text.Replace("'", "''")}%' ";
                condition += $"AND dNgayNhapHang BETWEEN '{dtpNgayNhapSFrom.Value.Date.ToString("yyyy/MM/dd")}' AND '{dtpNgayNhapSTo.Value.Date.ToString("yyyy/MM/dd")}' ";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT tblHoaDonNhap.iMaHDN, tblHoaDonNhap.sMaNV, sTenNV, tblHoaDonNhap.sMaNCC, sTenNCC, dNgayNhapHang, 
	                            ISNULL(t1.[Số Lượng Nhập], 0) [Số Lượng Nhập], 
	                            ISNULL(t1.[Tổng Tiền], 0) [Tổng Tiền]
                            FROM dbo.tblHoaDonNhap
                            LEFT JOIN dbo.tblNhanVien ON tblNhanVien.sMaNV = tblHoaDonNhap.sMaNV
                            LEFT JOIN dbo.tblNhaCungCap ON tblNhaCungCap.sMaNCC = tblHoaDonNhap.sMaNCC
                            LEFT JOIN (
	                            SELECT iMaHDN, SUM(iSLNhap) [Số Lượng Nhập], SUM(iSLNhap*fGiaNhap) [Tổng Tiền] 
	                            FROM dbo.tblCT_HoaDonNhap
	                            GROUP BY iMaHDN
                            ) t1 ON t1.iMaHDN = tblHoaDonNhap.iMaHDN
                            WHERE {condition}"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                        {
                            using (DataTable dt = new DataTable("tblHoaDonNhap"))
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

            dgvHoaDon.DataSource = getDSHDN();

            lblCountHD.Text = dgvHoaDon.RowCount.ToString();
        }

        private void btnTimKiemCT_Click(object sender, EventArgs e)
        {
            if (checkValueCTS())
            {
                string condition = "1=1 ";

                if (cboMaSPS.Text.Trim() != "")
                    condition += $"AND tblCT_HoaDonNhap.sMaSP = '{cboMaSPS.Text.Replace("'", "''")}' ";
                if (cboTenSPS.Text.Trim() != "")
                    condition += $"AND sTenSP LIKE N'%{cboTenSPS.Text.Replace("'", "''")}%' ";
                if (txtSLNhapSFrom.Text.Trim() != "" || txtSLNhapSTo.Text.Trim() != "")
                {
                    string fromValue = txtSLNhapSFrom.Text.Trim() != "" ? txtSLNhapSFrom.Text.Trim() : "0",
                           toValue = txtSLNhapSTo.Text.Trim() != "" ? txtSLNhapSTo.Text.Trim() : int.MaxValue.ToString();

                    condition += $"AND iSLNhap BETWEEN {fromValue} AND {toValue} ";
                }
                if (txtGiaNhapSFrom.Text.Trim() != "" || txtGiaNhapSTo.Text.Trim() != "")
                {
                    string fromValue = txtGiaNhapSFrom.Text.Trim() != "" ? txtGiaNhapSFrom.Text.Trim() : "0",
                           toValue = txtGiaNhapSTo.Text.Trim() != "" ? txtGiaNhapSTo.Text.Trim() : float.MaxValue.ToString();

                    condition += $"AND fGiaNhap BETWEEN {fromValue} AND {toValue} ";
                }

                List<string> MaHDNs = new List<string>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT iMaHDN, tblCT_HoaDonNhap.sMaSP, sTenSP, iSLNhap, fGiaNhap
                            FROM dbo.tblCT_HoaDonNhap
                            INNER JOIN dbo.tblSanPham ON tblSanPham.sMaSP = tblCT_HoaDonNhap.sMaSP
                            WHERE {condition}"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                        {
                            using (DataTable dt = new DataTable("tblCT_HoaDonNhap"))
                            {
                                sda.Fill(dt);
                                dgvCTHoaDon.DataSource = dt;
                                foreach (DataRow row in dt.Rows)
                                    MaHDNs.Add(row["iMaHDN"].ToString());
                            }
                        }
                    }
                }

                lblCountCT.Text = dgvCTHoaDon.RowCount.ToString();

                dgvHoaDon.DataSource = getDSHDN(MaHDNs);
                lblCountHD.Text = dgvHoaDon.RowCount.ToString();
            }
        }

        private void btnHienTatCaCT_Click(object sender, EventArgs e)
        {
            resetValueCTS();

            dgvCTHoaDon.DataSource = getDSCT_HDN();

            lblCountCT.Text = dgvCTHoaDon.RowCount.ToString();
        }

        private void tabContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabContainer.SelectedTab == tpTimKiem)
            {
                string oldMaHDN = cboMaHDNS.Text,
                       oldMaNV = cboMaNVS.Text,
                       oldTenNV = cboTenNVS.Text,
                       oldMaNCC = cboMaNCCS.Text,
                       oldTenKH = cboTenNCCS.Text,
                       oldMaSP = cboMaSPS.Text,
                       oldTenSP = cboTenSPS.Text;

                cboMaHDNS.DataSource = new DataView(getDSHDN(), "", "iMaHDN", DataViewRowState.CurrentRows);
                cboMaHDNS.DisplayMember = "iMaHDN";
                cboMaHDNS.ValueMember = "iMaHDN";
                cboMaHDNS.Text = oldMaHDN;

                cboMaNVS.DataSource = new DataView(getDSNV(), "", "sMaNV", DataViewRowState.CurrentRows);
                cboMaNVS.DisplayMember = "sMaNV";
                cboMaNVS.ValueMember = "sMaNV";
                cboMaNVS.Text = oldMaNV;

                cboTenNVS.DataSource = new DataView(getDSNV().DefaultView.ToTable(true, "sTenNV"), "", "sTenNV", DataViewRowState.CurrentRows);
                cboTenNVS.DisplayMember = "sTenNV";
                cboTenNVS.ValueMember = "sTenNV";
                cboTenNVS.Text = oldTenNV;

                cboMaNCCS.DataSource = new DataView(getDSNCC(), "", "sMaNCC", DataViewRowState.CurrentRows);
                cboMaNCCS.DisplayMember = "sMaNCC";
                cboMaNCCS.ValueMember = "sMaNCC";
                cboMaNCCS.Text = oldMaNCC;

                cboTenNCCS.DataSource = new DataView(getDSNCC().DefaultView.ToTable(true, "sTenNCC"), "", "sTenNCC", DataViewRowState.CurrentRows);
                cboTenNCCS.DisplayMember = "sTenNCC";
                cboTenNCCS.ValueMember = "sTenNCC";
                cboTenNCCS.Text = oldTenKH;

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

        private void frmHoaDonNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show($"Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}
