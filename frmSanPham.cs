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
    public partial class frmSanPham : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        private List<string> checkedMauSac = new List<string>(),
                             checkedRam = new List<string>(),
                             checkedBoNhoTrong = new List<string>(),
                             checkedBaoHanh = new List<string>();

        public frmSanPham()
        {
            InitializeComponent();
        }

        private DataTable getDSSP()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT sMaSP, sTenSP, sMaNCC, iTongSL, fGiaSP, sMauSac, fKichThuoc, iRAM, iBoNhoTrong, iTGBaoHanh 
                            FROM tblSanPham WHERE isDeleted = 0"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                        {
                            using (DataTable dt = new DataTable("tblSanPham"))
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

        private void resetValue()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            cboMaNCC.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtMauSac.Text = "";
            txtKichThuoc.Text = "";
            txtRam.Text = "";
            txtBoNhoTrong.Text = "";
            txtBaoHanh.Text = "";
        }

        private void resetValueS()
        {
            cboMaSPS.Text = "";
            txtTenSPS.Text = "";
            cboTenNCCS.Text = "";
            txtSoLuongSFrom.Text = "";
            txtSoLuongSTo.Text = "";
            txtDonGiaSFrom.Text = "";
            txtDonGiaSTo.Text = "";
            txtMauSacS.Text = "";
            checkedMauSac.Clear();
            while (cklMauSacS.CheckedIndices.Count > 0)
                cklMauSacS.SetItemChecked(cklMauSacS.CheckedIndices[0], false);
            txtKichThuocSFrom.Text = "";
            txtKichThuocSTo.Text = "";
            txtRamS.Text = "";
            checkedRam.Clear();
            while (cklRamS.CheckedIndices.Count > 0)
                cklRamS.SetItemChecked(cklRamS.CheckedIndices[0], false);
            txtBoNhoTrongS.Text = "";
            checkedBoNhoTrong.Clear();
            while (cklBoNhoTrongS.CheckedIndices.Count > 0)
                cklBoNhoTrongS.SetItemChecked(cklBoNhoTrongS.CheckedIndices[0], false);
            txtBaoHanhS.Text = "";
            checkedBaoHanh.Clear();
            while (cklBaoHanhS.CheckedIndices.Count > 0)
                cklBaoHanhS.SetItemChecked(cklBaoHanhS.CheckedIndices[0], false);
        }

        private bool checkValue(bool checkMa)
        {
            bool check = true;
            Regex isInt = new Regex(@"^\d+$"),
                  isFloat = new Regex(@"^\d(.\d){0,1}\d*$");

            if (checkMa)
            {
                if (txtMaSP.Text.Trim() == "")
                {
                    errCheck.SetError(txtMaSP, "Không được để trống!");
                    check = false;
                }
                else if (!Regex.IsMatch(txtMaSP.Text.Trim(), @"^[A-z,0-9]+$"))
                {
                    errCheck.SetError(txtMaSP, "Mã không hợp lệ!");
                    check = false;
                }
                else
                {
                    errCheck.SetError(txtMaSP, "");
                    //using (SqlConnection con = new SqlConnection(connectionString))
                    //{
                    //    using (SqlCommand cm = new SqlCommand(
                    //        "SELECT COUNT(sMaSP) FROM tblSanPham " +
                    //        "WHERE sMaSP = @MaSP"
                    //        , con))
                    //    {
                    //        cm.CommandType = CommandType.Text;
                    //        cm.Parameters.AddWithValue("@MaSP", txtMaSP.Text);
                    //        con.Open();
                    //        if ((int)cm.ExecuteScalar() != 0)
                    //        {
                    //            errCheck.SetError(txtMaSP, "Mã sản phẩm đã có trong dữ liệu!");
                    //            check = false;
                    //        }
                    //        else
                    //            errCheck.SetError(txtMaSP, "");
                    //    }
                    //}
                }
            }

            if (txtTenSP.Text.Trim() == "")
            {
                errCheck.SetError(txtTenSP, "Không được để trống!");
                check = false;
            }
            else
            {
                errCheck.SetError(txtTenSP, "");
            }

            if (cboMaNCC.Text.Trim() == "")
            {
                errCheck.SetError(cboMaNCC, "Không được để trống!");
                check = false;
            }
            else if (cboMaNCC.SelectedItem == null)
            {
                bool existMaNCC = false;
                for (int i = 0; i < cboMaNCC.Items.Count; i++)
                {
                    if (cboMaNCC.Text == cboMaNCC.GetItemText(cboMaNCC.Items[i]))
                    {
                        existMaNCC = true;
                        break;
                    }
                }
                                
                if (!existMaNCC)
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

            if (txtSoLuong.Text.Trim() == "")
            {
                errCheck.SetError(txtSoLuong, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isInt.IsMatch(txtSoLuong.Text.Trim()))
                {
                    errCheck.SetError(txtSoLuong, "Số lượng không hợp lệ!");
                    check = false;
                }
                else if (int.Parse(txtSoLuong.Text.Trim()) <= 0)
                {
                    errCheck.SetError(txtSoLuong, "Số lượng phải lớn hơn 0!");
                    check = false;
                }
                else 
                    errCheck.SetError(txtSoLuong, "");
            }

            if (txtDonGia.Text.Trim() == "")
            {
                errCheck.SetError(txtDonGia, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isFloat.IsMatch(txtDonGia.Text.Trim()))
                {
                    errCheck.SetError(txtDonGia, "Đơn giá không hợp lệ!");
                    check = false;
                }
                else if (float.Parse(txtDonGia.Text.Trim()) <= 0)
                {
                    errCheck.SetError(txtDonGia, "Đơn giá phải lớn hơn 0!");
                    check = false;
                }
                else
                    errCheck.SetError(txtDonGia, "");
            }

            if (txtMauSac.Text.Trim() == "")
            {
                errCheck.SetError(txtMauSac, "Không được để trống!");
                check = false;
            }
            else
            {
                errCheck.SetError(txtMauSac, "");
            }

            if (txtKichThuoc.Text.Trim() == "")
            {
                errCheck.SetError(txtKichThuoc, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isFloat.IsMatch(txtKichThuoc.Text.Trim()))
                {
                    errCheck.SetError(txtKichThuoc, "Kích thước không hợp lệ!");
                    check = false;
                }
                else if (float.Parse(txtKichThuoc.Text.Trim()) <= 0)
                {
                    errCheck.SetError(txtKichThuoc, "Kích thước phải lớn hơn 0!");
                    check = false;
                }
                else
                    errCheck.SetError(txtKichThuoc, "");
            }

            if (txtRam.Text.Trim() == "")
            {
                errCheck.SetError(txtRam, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isInt.IsMatch(txtRam.Text.Trim()))
                {
                    errCheck.SetError(txtRam, "Kích thước RAM không hợp lệ!");
                    check = false;
                }
                else if (int.Parse(txtRam.Text.Trim()) <= 0)
                {
                    errCheck.SetError(txtRam, "Kích thước RAM phải lớn hơn 0!");
                    check = false;
                }
                else
                    errCheck.SetError(txtRam, "");
            }

            if (txtBoNhoTrong.Text.Trim() == "")
            {
                errCheck.SetError(txtBoNhoTrong, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isInt.IsMatch(txtBoNhoTrong.Text.Trim()))
                {
                    errCheck.SetError(txtBoNhoTrong, "Bộ nhớ trong không hợp lệ!");
                    check = false;
                }
                else if (int.Parse(txtBoNhoTrong.Text.Trim()) <= 0)
                {
                    errCheck.SetError(txtBoNhoTrong, "Bộ nhớ trong phải lớn hơn 0!");
                    check = false;
                }
                else
                    errCheck.SetError(txtBoNhoTrong, "");
            }

            if (txtBaoHanh.Text.Trim() == "")
            {
                errCheck.SetError(txtBaoHanh, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isInt.IsMatch(txtBaoHanh.Text.Trim()))
                {
                    errCheck.SetError(txtBaoHanh, "Thời gian bảo hành không hợp lệ!");
                    check = false;
                }
                else if (int.Parse(txtBaoHanh.Text.Trim()) <= 0)
                {
                    errCheck.SetError(txtBaoHanh, "Thời gian bảo hành phải lớn hơn 0!");
                    check = false;
                }
                else
                    errCheck.SetError(txtBaoHanh, "");
            }

            return check;
        }

        private bool checkValueS()
        {
            bool check = true;
            Regex isInt = new Regex(@"^\d+$"),
                  isFloat = new Regex(@"^(\d+(.\d){0,1}\d*)+$");
            
            if ((txtSoLuongSFrom.Text.Trim() != "" && !isInt.IsMatch(txtSoLuongSFrom.Text.Trim()))
                || (txtSoLuongSTo.Text.Trim() != "" && !isInt.IsMatch(txtSoLuongSTo.Text.Trim())))
            {
                errCheck.SetError(txtSoLuongSTo, "Số lượng không hợp lệ!");
                check = false;
            }
            else
            {
                if (isInt.IsMatch(txtSoLuongSFrom.Text.Trim()) && isInt.IsMatch(txtSoLuongSTo.Text.Trim())
                && (int.Parse(txtSoLuongSFrom.Text.Trim()) > int.Parse(txtSoLuongSTo.Text.Trim())))
                {
                    errCheck.SetError(txtSoLuongSTo, "Giá trị trước không được lớn hơn giá trị sau!");
                    check = false;
                }
                else
                    errCheck.SetError(txtSoLuongSTo, "");
            }

            if ((txtDonGiaSFrom.Text.Trim() != "" && !isFloat.IsMatch(txtDonGiaSFrom.Text.Trim()))
                || (txtDonGiaSTo.Text.Trim() != "" && !isFloat.IsMatch(txtDonGiaSTo.Text.Trim())))
            {
                errCheck.SetError(txtDonGiaSTo, "Đơn giá không hợp lệ!");
                check = false;
            }
            else
            {
                if (isFloat.IsMatch(txtDonGiaSFrom.Text.Trim()) && isFloat.IsMatch(txtDonGiaSTo.Text.Trim())
                && (float.Parse(txtDonGiaSFrom.Text.Trim()) > float.Parse(txtDonGiaSTo.Text.Trim())))
                {
                    errCheck.SetError(txtDonGiaSTo, "Giá trị trước không được lớn hơn giá trị sau!");
                    check = false;
                }
                else
                    errCheck.SetError(txtDonGiaSTo, "");
            }

            if ((txtKichThuocSFrom.Text.Trim() != "" && !isFloat.IsMatch(txtKichThuocSFrom.Text.Trim()))
                || (txtKichThuocSTo.Text.Trim() != "" && !isFloat.IsMatch(txtKichThuocSTo.Text.Trim())))
            {
                errCheck.SetError(txtKichThuocSTo, "Kích thước không hợp lệ!");
                check = false;
            }
            else
            {
                if (isFloat.IsMatch(txtKichThuocSFrom.Text.Trim()) && isFloat.IsMatch(txtKichThuocSTo.Text.Trim())
                && (float.Parse(txtKichThuocSFrom.Text.Trim()) > float.Parse(txtKichThuocSTo.Text.Trim())))
                {
                    errCheck.SetError(txtKichThuocSTo, "Giá trị trước không được lớn hơn giá trị sau!");
                    check = false;
                }
                else
                    errCheck.SetError(txtKichThuocSTo, "");
            }

            bool checkListNumber = true;
            if (txtRamS.Text.Trim() != "")
            {
                foreach (string item in txtRamS.Text.Split(','))
                {
                    if (!isInt.IsMatch(item.Trim()))
                    {
                        errCheck.SetError(txtRamS, "Kích thước RAM phải là số nguyên!");
                        checkListNumber = false;
                        check = false;
                        break;
                    }
                }
            }
            if (checkListNumber)
                errCheck.SetError(txtRamS, "");

            checkListNumber = true;
            if (txtBoNhoTrongS.Text.Trim() != "")
            {
                foreach (string item in txtBoNhoTrongS.Text.Split(','))
                {
                    if (!isInt.IsMatch(item.Trim()))
                    {
                        errCheck.SetError(txtBoNhoTrongS, "Kích thước RAM phải là số nguyên!");
                        checkListNumber = false;
                        check = false;
                        break;
                    }
                }
            }
            if (checkListNumber)
                errCheck.SetError(txtBoNhoTrongS, "");

            checkListNumber = true;
            if (txtBaoHanhS.Text.Trim() != "")
            {
                foreach (string item in txtBaoHanhS.Text.Split(','))
                {
                    if (!isInt.IsMatch(item.Trim()))
                    {
                        errCheck.SetError(txtBaoHanhS, "Kích thước RAM phải là số nguyên!");
                        checkListNumber = false;
                        check = false;
                        break;
                    }
                }
            }
            if (checkListNumber)
                errCheck.SetError(txtBaoHanhS, "");

            return check;
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            DataTable tblSP = getDSSP();
            dgvSP.DataSource = tblSP;
            dgvSP.Columns[0].HeaderText = "Mã sản phẩm";
            dgvSP.Columns[1].HeaderText = "Tên sản phẩm";
            dgvSP.Columns[2].HeaderText = "Mã NCC";
            dgvSP.Columns[3].HeaderText = "Số lượng";
            dgvSP.Columns[4].HeaderText = "Đơn giá";
            dgvSP.Columns[5].HeaderText = "Màu sắc";
            dgvSP.Columns[6].HeaderText = "Kích thước (inch)";
            dgvSP.Columns[7].HeaderText = "RAM (GB)";
            dgvSP.Columns[8].HeaderText = "Bộ nhớ trong (BG)";
            dgvSP.Columns[9].HeaderText = "Thời gian bảo hành (tháng)";
            dgvSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtMaSP.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            tabContainer.SelectedTab = tpChinhSua;

            cboMaNCC.DataSource = new DataView(tblSP, "", "sMaNCC", DataViewRowState.CurrentRows);
            cboMaNCC.DisplayMember = "sMaNCC";
            cboMaNCC.ValueMember = "sMaNCC";

            DataView dvSP = tblSP.DefaultView;

            cklMauSacS.DataSource = new DataView(dvSP.ToTable(true, "sMauSac"), "", "sMauSac", DataViewRowState.CurrentRows);
            cklMauSacS.DisplayMember = "sMauSac";
            cklMauSacS.ValueMember = "sMauSac";

            cklRamS.DataSource = new DataView(dvSP.ToTable(true, "iRAM"), "", "iRAM", DataViewRowState.CurrentRows);
            cklRamS.DisplayMember = "iRAM";
            cklRamS.ValueMember = "iRAM";

            cklBoNhoTrongS.DataSource = new DataView(dvSP.ToTable(true, "iBoNhoTrong"), "", "iBoNhoTrong", DataViewRowState.CurrentRows);
            cklBoNhoTrongS.DisplayMember = "iBoNhoTrong";
            cklBoNhoTrongS.ValueMember = "iBoNhoTrong";

            cklBaoHanhS.DataSource = new DataView(dvSP.ToTable(true, "iTGBaoHanh"), "", "iTGBaoHanh", DataViewRowState.CurrentRows);
            cklBaoHanhS.DisplayMember = "iTGBaoHanh";
            cklBaoHanhS.ValueMember = "iTGBaoHanh";

            resetValue();
        }

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false && tabContainer.SelectedTab == tpChinhSua)
            {
                MessageBox.Show("Đang ở chế độ thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (e.RowIndex == -1)
                return;

            DataGridViewRow row = dgvSP.Rows[e.RowIndex];
            txtMaSP.Text = row.Cells["sMaSP"].Value.ToString();
            txtTenSP.Text = row.Cells["sTenSP"].Value.ToString();
            cboMaNCC.Text = row.Cells["sMaNCC"].Value.ToString();
            txtSoLuong.Text = row.Cells["iTongSL"].Value.ToString();
            txtDonGia.Text = row.Cells["fGiaSP"].Value.ToString();
            txtMauSac.Text = row.Cells["sMauSac"].Value.ToString();
            txtKichThuoc.Text = row.Cells["fKichThuoc"].Value.ToString();
            txtRam.Text = row.Cells["iRAM"].Value.ToString();
            txtBoNhoTrong.Text = row.Cells["iBoNhoTrong"].Value.ToString();
            txtBaoHanh.Text = row.Cells["iTGBaoHanh"].Value.ToString();

            if (btnThem.Enabled == true)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                txtMaSP.Enabled = false;
            }
        }

        private string createMa()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand(
                    $@"SELECT COUNT(sMaSP) FROM tblSanPham"
                    , con))
                {
                    cm.CommandType = CommandType.Text;
                    con.Open();
                    int count = (int)cm.ExecuteScalar() + 1;
                    return $"SP{count.ToString("000")}";
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string oldMaNCC = cboMaNCC.Text;
            int indexItem = cboMaNCC.FindStringExact(oldMaNCC);
            if (indexItem == -1)
                cboMaNCC.SelectedItem = null;
            else
                cboMaNCC.SelectedItem = indexItem;
            cboMaNCC.Text = oldMaNCC;

            if (btnSua.Enabled == true)
                resetValue();

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaSP.Text = createMa();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkValue(true))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        "INSERT INTO tblSanPham(sMaSP, sTenSP, sMaNCC, iTongSL, fGiaSP, sMauSac, fKichThuoc, iRam, iBoNhoTrong, iTGBaoHanh) " +
                        "VALUES (@MaSP, @TenSP, @MaNCC, @TongSL, @GiaSP, @MauSac, @KichThuoc, @Ram, @BoNhoTrong, @TGBaoHanh)"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                        cm.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                        cm.Parameters.AddWithValue("@MaNCC", cboMaNCC.Text);
                        cm.Parameters.AddWithValue("@TongSL", txtSoLuong.Text.Trim());
                        cm.Parameters.AddWithValue("@GiaSP", txtDonGia.Text.Trim());
                        cm.Parameters.AddWithValue("@MauSac", txtMauSac.Text.Trim());
                        cm.Parameters.AddWithValue("@KichThuoc", txtKichThuoc.Text.Trim());
                        cm.Parameters.AddWithValue("@Ram", txtRam.Text.Trim());
                        cm.Parameters.AddWithValue("@BoNhoTrong", txtBoNhoTrong.Text.Trim());
                        cm.Parameters.AddWithValue("@TGBaoHanh", txtBaoHanh.Text.Trim());
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                btnThem.Enabled = true;
                btnLuu.Enabled = false;

                resetValue();

                dgvSP.DataSource = getDSSP();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkValue(false))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"UPDATE tblSanPham " +
                        "SET sTenSP = @TenSP, " +
                        "sMaNCC = @MaNCC, " +
                        "iTongSL = @TongSL, " +
                        "fGiaSP = @GiaSP, " +
                        "sMauSac = @MauSac, " +
                        "fKichThuoc = @KichThuoc, " +
                        "iRAM = @RAM, " +
                        "iBoNhoTrong = @BoNhoTrong, " +
                        "iTGBaoHanh = @TGBaoHanh " +
                        "WHERE sMaSP = @MaSP"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                        cm.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                        cm.Parameters.AddWithValue("@MaNCC", cboMaNCC.SelectedValue);
                        cm.Parameters.AddWithValue("@TongSL", txtSoLuong.Text.Trim());
                        cm.Parameters.AddWithValue("@GiaSP", txtDonGia.Text.Trim());
                        cm.Parameters.AddWithValue("@MauSac", txtMauSac.Text.Trim());
                        cm.Parameters.AddWithValue("@KichThuoc", txtKichThuoc.Text.Trim());
                        cm.Parameters.AddWithValue("@Ram", txtRam.Text.Trim());
                        cm.Parameters.AddWithValue("@BoNhoTrong", txtBoNhoTrong.Text.Trim());
                        cm.Parameters.AddWithValue("@TGBaoHanh", txtBaoHanh.Text.Trim());
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                resetValue();

                dgvSP.DataSource = getDSSP();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm có mã {txtMaSP.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"UPDATE dbo.tblSanPham
                            SET isDeleted = 1
                            WHERE sMaSP = @MaSP"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                resetValue();

                dgvSP.DataSource = getDSSP();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            errCheck.Clear();

            txtMaSP.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            if (btnThem.Enabled == false && tabContainer.SelectedTab == tpChinhSua)
            {
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
            }

            if (tabContainer.SelectedTab == tpTimKiem)
            {
                //tabContainer.SelectedTab = tpChinhSua;

                resetValueS();

                //dgvSP.DataSource = getDSSP();
            }

            resetValue();
        }

        private string getMaNCCs(string tenNCC)
        {
            DataTable dtMaNCC;
            string maNCCs = "";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand(
                    $"SELECT sMaNCC FROM tblNhaCungCap WHERE sTenNCC LIKE N'%' + @TenNCC + '%'"
                    , con))
                {
                    cm.CommandType = CommandType.Text;
                    cm.Parameters.AddWithValue("@TenNCC", tenNCC);
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                    {
                        using (DataTable dt = new DataTable("tblMaNCCs"))
                        {
                            sda.Fill(dt);
                            dtMaNCC = dt;
                        }
                    }
                }
            }

            foreach (DataRow row in dtMaNCC.Rows)
            {
                maNCCs += $",'{row[0].ToString()}'";
            }

            return maNCCs.Length > 0 ? maNCCs.Substring(1) : "'!'";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (checkValueS())
            {
                setChecked(checkedMauSac, txtMauSacS, cklMauSacS);
                setChecked(checkedRam, txtRamS, cklRamS);
                setChecked(checkedBoNhoTrong, txtBoNhoTrongS, cklBoNhoTrongS);
                setChecked(checkedBaoHanh, txtBaoHanhS, cklBaoHanhS);

                string condition = "isDeleted = 0 ";

                if (cboMaSPS.Text.Trim() != "")
                    condition += $"AND sMaSP = '{cboMaSPS.Text.Replace("'", "''")}' ";
                if (txtTenSPS.Text.Trim() != "")
                    condition += $"AND sTenSP LIKE N'%{txtTenSPS.Text.Replace("'", "''")}%' ";
                if (cboTenNCCS.Text.Trim() != "")
                    condition += $"AND sMaNCC IN ({getMaNCCs(cboTenNCCS.Text.Trim())}) ";
                if (txtSoLuongSFrom.Text.Trim() != "" || txtSoLuongSTo.Text.Trim() != "")
                {
                    string fromValue = txtSoLuongSFrom.Text.Trim() != "" ? txtSoLuongSFrom.Text.Trim() : "0",
                           toValue = txtSoLuongSTo.Text.Trim() != "" ? txtSoLuongSTo.Text.Trim() : int.MaxValue.ToString();

                    condition += $"AND iTongSL BETWEEN {fromValue} AND {toValue} ";
                }
                if (txtDonGiaSFrom.Text.Trim() != "" || txtDonGiaSTo.Text.Trim() != "")
                {
                    string fromValue = txtDonGiaSFrom.Text.Trim() != "" ? txtDonGiaSFrom.Text.Trim() : "0", 
                           toValue = txtDonGiaSTo.Text.Trim() != "" ? txtDonGiaSTo.Text.Trim() : float.MaxValue.ToString();

                    condition += $"AND fGiaSP BETWEEN {fromValue} AND {toValue} ";
                }
                if (txtMauSacS.Text.Trim() != "")
                    condition += $"AND sMauSac IN (N'{string.Join("', N'", checkedMauSac)}')";
                if (txtKichThuocSFrom.Text.Trim() != "" || txtKichThuocSTo.Text.Trim() != "")
                {
                    string fromValue = txtKichThuocSFrom.Text.Trim() != "" ? txtKichThuocSFrom.Text.Trim() : "0",
                           toValue = txtKichThuocSTo.Text.Trim() != "" ? txtKichThuocSTo.Text.Trim() : float.MaxValue.ToString();

                    condition += $"AND fKichThuoc BETWEEN {fromValue} AND {toValue} ";
                }
                if (txtRamS.Text.Trim() != "")
                    condition += $"AND iRam IN (N'{string.Join("', N'", checkedRam)}')";
                if (txtBoNhoTrongS.Text.Trim() != "")
                    condition += $"AND iBoNhoTrong IN (N'{string.Join("', N'", checkedBoNhoTrong)}')";
                if (txtBaoHanhS.Text.Trim() != "")
                    condition += $"AND iTGBaoHanh IN (N'{string.Join("', N'", checkedBaoHanh)}')";

                //MessageBox.Show($"{condition}");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT sMaSP, sTenSP, sMaNCC, iTongSL, fGiaSP, sMauSac, fKichThuoc, iRAM, iBoNhoTrong, iTGBaoHanh 
                            FROM tblSanPham WHERE {condition}"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                        {
                            using (DataTable dt = new DataTable("tblSanPham"))
                            {
                                sda.Fill(dt);
                                dgvSP.DataSource = dt;
                            }
                        }
                    }
                }

                cklMauSacS.Visible = false;
                cklRamS.Visible = false;
                cklBoNhoTrongS.Visible = false;
                cklBaoHanhS.Visible = false;

                lblCount.Text = dgvSP.RowCount.ToString();
            }
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            resetValueS();

            dgvSP.DataSource = getDSSP();

            lblCount.Text = dgvSP.RowCount.ToString();
        }

        private void tabContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabContainer.SelectedTab == tpChinhSua)
            {
                btnThem.Enabled = true;
            }
            if (tabContainer.SelectedTab == tpTimKiem)
            {
                string oldMaSP = cboMaSPS.Text,
                       oldMaNCC = cboTenNCCS.Text;

                cboMaSPS.DataSource = new DataView(getDSSP(), "", "sMaSP", DataViewRowState.CurrentRows);
                cboMaSPS.DisplayMember = "sMaSP";
                cboMaSPS.ValueMember = "sMaSP";
                cboMaSPS.Text = oldMaSP;

                cboTenNCCS.DataSource = new DataView(getDSNCC(), "", "sTenNCC", DataViewRowState.CurrentRows);
                cboTenNCCS.DisplayMember = "sTenNCC";
                cboTenNCCS.ValueMember = "sTenNCC";
                cboTenNCCS.Text = oldMaNCC;

                cklMauSacS.Visible = false;
                cklRamS.Visible = false;
                cklBoNhoTrongS.Visible = false;
                cklBaoHanhS.Visible = false;

                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                lblCount.Text = dgvSP.RowCount.ToString();
            }
        }

        private void setChecked(List<string> ls, TextBox txt, CheckedListBox ckl)
        {
            ls.Clear();
            foreach (string item in txt.Text.Split(','))
            {
                ls.Add(item.Trim().ToLower());
            }

            for (int i = 0; i < ckl.Items.Count; i++)
            {
                string color = ckl.GetItemText(ckl.Items[i]).ToLower();
                int c = ls.IndexOf(color);
                if (c != -1)
                {
                    ckl.SetItemChecked(i, true);
                }
                else
                {
                    ckl.SetItemChecked(i, false);
                }
            }
        }

        private void ckl_SelectedChanged(string column, TextBox txt, CheckedListBox ckl)
        {
            string text = "";
            foreach (DataRowView row in ckl.CheckedItems)
            {
                text += ", " + row.Row[column].ToString();
            }
            if (text.Length != 0)
                text = text.Substring(2, text.Length - 2);
            txt.Text = text;
        }

        private void lblMauSacSBtn_Click(object sender, EventArgs e)
        {
            cklMauSacS.Visible = !cklMauSacS.Visible;
            setChecked(checkedMauSac, txtMauSacS, cklMauSacS);
        }

        private void cklMauSacS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ckl_SelectedChanged("sMauSac", txtMauSacS, cklMauSacS);
        }

        private void lblRamSBtn_Click(object sender, EventArgs e)
        {
            cklRamS.Visible = !cklRamS.Visible;
            setChecked(checkedRam, txtRamS, cklRamS);
        }

        private void cklRamS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ckl_SelectedChanged("iRAM", txtRamS, cklRamS);
        }

        private void lblBoNhoTrongSBtn_Click(object sender, EventArgs e)
        {
            cklBoNhoTrongS.Visible = !cklBoNhoTrongS.Visible;
            setChecked(checkedBoNhoTrong, txtBoNhoTrongS, cklBoNhoTrongS);
        }

        private void cklBoNhoTrongcS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ckl_SelectedChanged("iBoNhoTrong", txtBoNhoTrongS, cklBoNhoTrongS);
        }

        private void lblBaoHanhSBtn_Click(object sender, EventArgs e)
        {
            cklBaoHanhS.Visible = !cklBaoHanhS.Visible;
            setChecked(checkedBaoHanh, txtBaoHanhS, cklBaoHanhS);
        }

        private void cklBaoHanhcS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ckl_SelectedChanged("iTGBaoHanh", txtBaoHanhS, cklBaoHanhS);
        }

        private void frmSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show($"Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}
