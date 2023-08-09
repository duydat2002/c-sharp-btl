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
using System.Globalization;

namespace BTL
{
    public partial class frmNhanVien : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = getDSNV();

            dgvNhanVien.Columns[0].HeaderText = "MÃ NV";
            dgvNhanVien.Columns[1].HeaderText = "TÊN NV";
            dgvNhanVien.Columns[2].HeaderText = "GIỚI TÍNH";
            dgvNhanVien.Columns[3].HeaderText = "ĐỊA CHỈ";
            dgvNhanVien.Columns[4].HeaderText = "SDT";
            dgvNhanVien.Columns[5].HeaderText = "EMAIL";
            dgvNhanVien.Columns[6].HeaderText = "CMND";
            dgvNhanVien.Columns[7].HeaderText = "NGÀY SINH";
            dgvNhanVien.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns[8].HeaderText = "NGÀY VÀO LÀM";
            dgvNhanVien.Columns[8].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns[9].HeaderText = "HSL";
            dgvNhanVien.Columns[10].HeaderText = "PHỤ CẤP";
            dgvNhanVien.Columns[11].HeaderText = "ROLE";

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaNV.Enabled = false;

            dtpNgaySinhS.Enabled = false;
            dtpNgayVaoLamS.Enabled = false;

            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DataTable getDSNV()
        {
            try
            {
                using(SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using(SqlCommand cm = new SqlCommand(
                        "SELECT sMaNV, sTenNV," +
                        "bGioiTinh = (CASE WHEN bGioiTinh = 0 THEN N'Nữ' ELSE 'Nam' END), " +
                        "sDiaChi, sSDT , sEmail, sCMND ,dNgaySinh, dNgayVaoLam, fHeSoLuong, fPhuCap, sRole FROM tblNhanVien " +
                        "WHERE isDeleted = 0"
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

        private void resetValue()
        {
            txtEmail.Clear();
            txtMaNV.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtTenNV.Clear();
            txtCMND.Clear();
            txtPhuCap.Clear();
            dtpNgayVaoLam.Value = DateTime.Now;
            txtHSL.Clear();
            cboRole.Text = "";
        }

        private void resetValueS()
        {
            txtEmailS.Clear();
            txtMaNVS.Clear();
            chkNgaySinhS.Checked = false;
            txtDiaChiS.Clear();
            txtSDTS.Clear();
            txtTenNVS.Clear();
            txtCMNDS.Clear();
            txtPhuCapS.Clear();
            chkNgayVaoLamS.Checked = false;
            txtHSLS.Clear();
            cboRoleS.Text = "";
        }

        private bool checkValue(bool checkMa)
        {
            bool check = true;
            Regex isInt = new Regex(@"^\d+$"),
                  isFloat = new Regex(@"(\d+(.\d){0,1}\d*)+");
            if (checkMa)
            {
                if (txtMaNV.Text.Trim() == "")
                {
                    errorCheck.SetError(txtMaNV, "Không được để trống!");
                    check = false;
                }
                else if (!Regex.IsMatch(txtMaNV.Text.Trim(), @"^[A-z,0-9]+$"))
                {
                    errorCheck.SetError(txtMaNV, "Mã không hợp lệ!");
                    check = false;
                }
                else
                {
                    errorCheck.SetError(txtMaNV, "");
                }
            }

            if (txtTenNV.Text.Trim() == "")
            {
                errorCheck.SetError(txtTenNV, "Không được để trống!");
                check = false;
            }
            else
            {
                errorCheck.SetError(txtTenNV, "");
            }

            if (txtDiaChi.Text.Trim() == "")
            {
                errorCheck.SetError(txtDiaChi, "Không được để trống!");
                check = false;
            }
            else
            {
                errorCheck.SetError(txtDiaChi, "");
            }

            if (txtSDT.Text.Trim() == "")
            {
                errorCheck.SetError(txtSDT, "Không được để trống!");
                check = false;
            }
            else
            {
                Regex checkSDT = new Regex(@"^0[\d]");

                if (!checkSDT.IsMatch(txtSDT.Text.Trim()))
                {
                    errorCheck.SetError(txtSDT, "Số điện thoại không hợp lệ!");
                    check = false;
                }
                else
                {
                    errorCheck.SetError(txtSDT, "");
                }    
            }

            if (txtCMND.Text.Trim() == "")
            {
                errorCheck.SetError(txtCMND, "Không được để trống!");
                check = false;
            }
            else if (txtCMND.Text.Trim().Length != 11)
            {
                errorCheck.SetError(txtCMND, "Số CMND gồm 11 chữ số!");
                check = false;
            }
            else
            {
                errorCheck.SetError(txtCMND, "");
            }

            if (txtEmail.Text.Trim() == "")
            {
                errorCheck.SetError(txtEmail, "Không được để trống!");
                check = false;
            }
            else
            {
                Regex checkMail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$");

                if (!checkMail.IsMatch(txtEmail.Text.Trim()))
                {
                    errorCheck.SetError(txtEmail, "Mail không hợp lệ!");
                    check = false;
                }
                else
                {
                    errorCheck.SetError(txtEmail, "");
                }
            }

            if (txtHSL.Text.Trim() == "")
            {
                errorCheck.SetError(txtHSL, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isFloat.IsMatch(txtHSL.Text.Trim()))
                {
                    errorCheck.SetError(txtHSL, "Hệ số lương không hợp lệ!");
                    check = false;
                }
                else
                {
                    errorCheck.SetError(txtHSL, "");
                }
            }

            if (txtPhuCap.Text.Trim() == "")
            {
                errorCheck.SetError(txtPhuCap, "Không được để trống!");
                check = false;
            }
            else
            {
                if (!isFloat.IsMatch(txtPhuCap.Text.Trim()))
                {
                    errorCheck.SetError(txtPhuCap, "Phụ cấp không hợp lệ!");
                    check = false;
                }
                else
                {
                    errorCheck.SetError(txtPhuCap, "");
                }    
            }

            if (dtpNgayVaoLam.Value.Year - dtpNgaySinh.Value.Year < 18 )
            {
                errorCheck.SetError(dtpNgaySinh, "Khi vào làm nhân viên phải đủ 18 tuổi!");
                check = false;
            }
            else
            {
                errorCheck.SetError(dtpNgaySinh, "");
            }

            if (cboRole.Text.Trim() != "admin" && cboRole.Text.Trim() != "user")
            {
                errorCheck.SetError(cboRole, "Phải là admin hoặc user!");
                check = false;
            }

            return check;
        }

        private void dgr_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false && tabContainer.SelectedTab == tpChinhSua)
            {
                MessageBox.Show("Đang ở chế độ thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (e.RowIndex == -1)
                return;

            txtEmail.Text = dgvNhanVien.CurrentRow.Cells["sEmail"].Value.ToString();
            txtTenNV.Text = dgvNhanVien.CurrentRow.Cells["sTenNV"].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["sDiaChi"].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.CurrentRow.Cells["dNgaySinh"].Value.ToString();
            txtSDT.Text = dgvNhanVien.CurrentRow.Cells["sSDT"].Value.ToString();
            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells["sMaNV"].Value.ToString();
            txtCMND.Text = dgvNhanVien.CurrentRow.Cells["sCMND"].Value.ToString();

            txtHSL.Text = dgvNhanVien.CurrentRow.Cells["fHeSoLuong"].Value.ToString();
            txtPhuCap.Text = dgvNhanVien.CurrentRow.Cells["fPhuCap"].Value.ToString();
            cboGioiTinh.Text = dgvNhanVien.CurrentRow.Cells["bGioiTinh"].Value.ToString();
            dtpNgayVaoLam.Text = dgvNhanVien.CurrentRow.Cells["dNgayVaoLam"].Value.ToString();
            cboRole.Text = dgvNhanVien.CurrentRow.Cells["sRole"].Value.ToString();

            if (btnThem.Enabled == true)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaNV.Enabled = false;
            }
        }

        private string createMa()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand(
                    $@"SELECT COUNT(sMaNV) FROM tblNhanVien"
                    , con))
                {
                    cm.CommandType = CommandType.Text;
                    con.Open();
                    int count = (int)cm.ExecuteScalar() + 1;
                    return $"NV{count.ToString("000")}";
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (btnSua.Enabled == true)
                resetValue();

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;

            txtMaNV.Text = createMa();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (checkValue(true))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"INSERT INTO dbo.tblNhanVien(sMaNV, sTenNV, bGioiTinh, sDiaChi, sSDT, sEmail, sCMND, dNgaySinh, dNgayVaoLam, fHeSoLuong, fPhuCap, sRole)
                            VALUES(@MaNV, @TenNV, @GioiTinh, @DiaChi, @SDT, @Email, @CMND, @NgaySinh, @NgayVaoLam, @HeSoLuong, @PhuCap, @Role)"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        con.Open();
                        cm.Parameters.AddWithValue("@MaNV", txtMaNV.Text.Trim());
                        cm.Parameters.AddWithValue("@TenNV", txtTenNV.Text.Trim());
                        cm.Parameters.AddWithValue("@ioiTinh", (cboGioiTinh.Text == "Nam" ? 1 : 0));
                        cm.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cm.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cm.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cm.Parameters.AddWithValue("@CMND", txtCMND.Text.Trim());
                        cm.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.Date.ToString("yyyy-MM-dd"));
                        cm.Parameters.AddWithValue("@NgayVaoLam", dtpNgayVaoLam.Value.Date.ToString("yyyy-MM-dd"));
                        cm.Parameters.AddWithValue("@HeSoLuong", txtHSL.Text.Trim());
                        cm.Parameters.AddWithValue("@PhuCap", txtPhuCap.Text.Trim());
                        cm.Parameters.AddWithValue("@Role", cboRole.Text.Trim());
                        cm.ExecuteNonQuery();
                    }
                }

                btnThem.Enabled = true;
                btnLuu.Enabled = false;

                resetValue();

                dgvNhanVien.DataSource = getDSNV();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (checkValue(false))
            {
                bool checkAdmin = true;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT COUNT(sRole) FROM tblNhanVien WHERE isDeleted = 0 AND sRole = 'admin'"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        con.Open();
                        if ((int)cm.ExecuteScalar() == 1 && cboRole.Text.Trim() == "user" && dgvNhanVien.CurrentRow.Cells["sRole"].Value.ToString() == "admin")
                        {
                            errorCheck.SetError(cboRole, "Phải có ít nhất 1 admin!");
                            checkAdmin = false;
                        }
                    }
                }

                if (checkAdmin)
                {
                    if (MessageBox.Show($"Bạn có muốn sửa nhân viên {txtMaNV.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            using (SqlCommand cm = new SqlCommand(
                                $@"UPDATE dbo.tblNhanVien
                                    SET sTenNV = @TenNV,
	                                    bGioiTinh = @GioiTinh,
	                                    sDiaChi = @DiaChi,
	                                    sSDT = @SDT,
	                                    sEmail = @Email,
	                                    sCMND = @CMND,
	                                    dNgaySinh = @NgaySinh,
	                                    dNgayVaoLam = @NgayVaoLam,
	                                    fHeSoLuong = @HeSoLuong,
	                                    fPhuCap = @PhuCap,
                                        sRole = @Role
                                    WHERE sMaNV = @MaNV"
                                , con))
                            {
                                cm.CommandType = CommandType.Text;
                                cm.Parameters.AddWithValue("@MaNV", txtMaNV.Text.Trim());
                                cm.Parameters.AddWithValue("@TenNV", txtTenNV.Text.Trim());
                                cm.Parameters.AddWithValue("@GioiTinh", (cboGioiTinh.Text == "Nam" ? 1 : 0));
                                cm.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                                cm.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                                cm.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                                cm.Parameters.AddWithValue("@CMND", txtCMND.Text.Trim());
                                cm.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.Date.ToString("yyyy-MM-dd"));
                                cm.Parameters.AddWithValue("@NgayVaoLam", dtpNgayVaoLam.Value.Date.ToString("yyyy-MM-dd"));
                                cm.Parameters.AddWithValue("@HeSoLuong", txtHSL.Text.Trim());
                                cm.Parameters.AddWithValue("@PhuCap", txtPhuCap.Text.Trim());
                                cm.Parameters.AddWithValue("@Role", cboRole.Text.Trim());
                                con.Open();
                                cm.ExecuteNonQuery();
                            }
                        }
                    }

                    resetValue();

                    dgvNhanVien.DataSource = getDSNV();
                }
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            bool checkAdmin = true;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand(
                    $@"SELECT COUNT(sRole) FROM tblNhanVien WHERE isDeleted = 0 AND sRole = 'admin'"
                    , con))
                {
                    cm.CommandType = CommandType.Text;
                    con.Open();
                    if ((int)cm.ExecuteScalar() == 1 && dgvNhanVien.CurrentRow.Cells["sRole"].Value.ToString() == "admin")
                    {
                        errorCheck.SetError(cboRole, "Phải có ít nhất 1 admin!");
                        checkAdmin = false;
                    }
                }
            }

            if (checkAdmin)
            {
                if (MessageBox.Show($"Bạn có muốn xóa nhân viên {txtMaNV.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cm = new SqlCommand(
                            $@"UPDATE dbo.tblNhanVien
                                SET isDeleted = 1
                                WHERE sMaNV = @MaNV"
                            , con))
                        {
                            cm.CommandType = CommandType.Text;
                            cm.Parameters.AddWithValue("@MaNV", txtMaNV.Text.Trim());
                            con.Open();
                            cm.ExecuteNonQuery();
                        }
                    }

                    resetValue();

                    dgvNhanVien.DataSource = getDSNV();
                }
            }

        }

        private void btn_huyBo_Click(object sender, EventArgs e)
        {
            errorCheck.Clear();

            txtMaNV.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            if (btnThem.Enabled == false && tabContainer.SelectedTab == tpChinhSua)
            {
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
            }

            if (tabContainer.SelectedTab == tpTimKiem)
            {
                resetValueS();
            }

            resetValue();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string condition = "isDeleted = 0 ";

            if (txtMaNVS.Text.Trim() != "")
                condition += $"AND sMaNV = '{txtMaNVS.Text}' ";
            if (txtTenNVS.Text.Trim() != "")
                condition += $"AND sTenNV LIKE N'%{txtTenNVS.Text}%' ";
            if (txtDiaChiS.Text.Trim() != "")
                condition += $"AND sDiaChi LIKE N'%{txtDiaChiS.Text}%' ";
            if (txtSDTS.Text.Trim() != "")
                condition += $"AND sSDT LIKE '%{txtSDTS.Text}%' ";
            if (txtEmailS.Text.Trim() != "")
                condition += $"AND sEmail LIKE '%{txtEmailS.Text}%' ";
            if (txtCMNDS.Text.Trim() != "")
                condition += $"AND sCMND LIKE '%{txtCMNDS.Text}%' ";
            if (txtPhuCapS.Text.Trim() != "")
                condition += $"AND fPhuCap = {txtPhuCapS.Text} ";
            if (txtHSLS.Text.Trim() != "")
                condition += $"AND fHeSoLuong = {txtHSLS.Text} ";
            if (cboGioiTinhS.Text.Trim() == "Nam")
                condition += $"AND bGioiTinh = 1 ";
            if (cboGioiTinhS.Text.Trim() == "Nữ")
                condition += $"AND bGioiTinh = 0 ";
            if (cboRoleS.Text.Trim() == "admin")
                condition += $"AND sRole = 'admin' ";
            if (cboRoleS.Text.Trim() == "user")
                condition += $"AND sRole = 'user' ";
            if (dtpNgaySinhS.Enabled)
                condition += $"AND dNgaySinh = '{dtpNgaySinhS.Value.Date.ToString("yyyy/MM/dd")}'";
            if (dtpNgayVaoLamS.Enabled)
                condition += $"AND dNgayVaoLam = '{dtpNgayVaoLamS.Value.Date.ToString("yyyy/MM/dd")}'";

            //MessageBox.Show(condition);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand(
                    "SELECT sMaNV, sTenNV," +
                     "bGioiTinh = (CASE WHEN bGioiTinh = 0 THEN N'Nữ' ELSE 'Nam' END), " +
                     $"sDiaChi, sSDT , sEmail, sCMND ,dNgaySinh, dNgayVaoLam, fHeSoLuong, fPhuCap FROM tblNhanVien WHERE {condition}"
                        , con))
                {
                    cm.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                    {
                        using (DataTable dt = new DataTable("tblNhanVien"))
                        {
                            sda.Fill(dt);
                            dgvNhanVien.DataSource = dt;
                        }
                    }
                }
            }

            lblSoLuong.Text = dgvNhanVien.RowCount.ToString();
        }

        private void btn_displayAll_Click(object sender, EventArgs e)
        {
            resetValueS();

            dgvNhanVien.DataSource = getDSNV();

            lblSoLuong.Text = dgvNhanVien.RowCount.ToString();
        }

        private void chkNgaySinhS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgaySinhS.Checked)
            {
                dtpNgaySinhS.Enabled = true;
            }
            else
            {
                dtpNgaySinhS.Enabled = false;
            }
        }

        private void chkNgayVaoLamS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayVaoLamS.Checked)
            {
                dtpNgayVaoLamS.Enabled = true;
            }
            else
            {
                dtpNgayVaoLamS.Enabled = false;
            }
        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show($"Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}
