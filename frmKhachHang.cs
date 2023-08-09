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

namespace BTL
{
    public partial class frmKhachHang : Form
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachhang.DataSource = getDSKH();

            dgvKhachhang.Columns[0].HeaderText = "MÃ KH";
            dgvKhachhang.Columns[1].HeaderText = "TÊN KH";
            dgvKhachhang.Columns[2].HeaderText = "ĐỊA CHỈ";
            dgvKhachhang.Columns[3].HeaderText = "NGÀY SINH";
            dgvKhachhang.Columns[4].HeaderText = "SDT";
            dgvKhachhang.Columns[4].DefaultCellStyle.Format = "0##";
            dgvKhachhang.Columns[5].HeaderText = "EMAIL";
            dgvKhachhang.Columns[6].HeaderText = "CMND";

            dgvKhachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaKH.Enabled = false;

            dtpNgaySinhS.Enabled = false;
        }

        private void resetValue()
        {
            txtEmail.Clear();
            txtMaKH.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtTenKH.Clear();
            txtCMND.Clear();
        }

        private void resetValueS()
        {
            txtEmailS.Clear();
            txtMaKHS.Clear();
            chkNgaySinhS.Checked = false;
            txtDiaChiS.Clear();
            txtSDTS.Clear();
            txtTenKHS.Clear();
            txtCMNDS.Clear();
        }

        private DataTable getDSKH()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        "SELECT sMaKH, sTenKH, sDiaChi, dNgaySinh, sSDT, sEmail, sCMND FROM dbo.tblKhachHang WHERE isDeleted = 0"
                        , conn))
                    {
                        cm.CommandType = CommandType.Text;
                        conn.Open();
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

        private bool checkValue(bool checkMa)
        {
            bool check = true;
            if (checkMa)
            {
                if (txtMaKH.Text.Trim() == "")
                {
                    errCheck.SetError(txtMaKH, "Không được để trống!");
                    check = false;
                }
                else if (!Regex.IsMatch(txtMaKH.Text.Trim(), @"^[A-z,0-9]+$"))
                {
                    errCheck.SetError(txtMaKH, "Mã không hợp lệ!");
                    check = false;
                }
                else
                {
                    errCheck.SetError(txtMaKH, "");
                }
            }

            if (txtTenKH.Text.Trim() == "")
            {
                errCheck.SetError(txtTenKH, "Không được để trống!");
                check = false;
            }
            else
            {
                errCheck.SetError(txtTenKH, "");
            }

            if (txtDiaChi.Text.Trim() == "")
            {
                errCheck.SetError(txtDiaChi, "Không được để trống!");
                check = false;
            }
            else
            {
                errCheck.SetError(txtDiaChi, "");
            }

            if (txtSDT.Text.Trim() == "")
            {
                errCheck.SetError(txtSDT, "Không được để trống!");
                check = false;
            }
            else
            {
                Regex checkSDT = new Regex(@"^0[\d]{9}");

                if (!checkSDT.IsMatch(txtSDT.Text.Trim()))
                {
                    errCheck.SetError(txtSDT, "Số điện thoại không hợp lệ!");
                    check = false;
                }
                else
                    errCheck.SetError(txtSDT, "");
            }

            if(txtCMND.Text.Trim() == "")
            {
                errCheck.SetError(txtCMND, "Không được để trống!");
                check = false;
            }
            else if (txtCMND.Text.Trim().Length != 11)
            {
                errCheck.SetError(txtCMND, "Số CMND gồm 11 chữ số!");
                check = false;
            }
            else
            {
                 errCheck.SetError(txtCMND, "");
            }

            if (txtEmail.Text.Trim() == "")
            {
                errCheck.SetError(txtEmail, "Không được để trống!");
                check = false;
            }
            else
            {
                Regex checkMail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$");

                if (!checkMail.IsMatch(txtEmail.Text.Trim()))
                {
                    errCheck.SetError(txtEmail, "Mail không hợp lệ!");
                    check = false;
                }
                else
                    errCheck.SetError(txtEmail, "");
            }

            if (dtpNgaySinh.Value.Year - dtpNgaySinh.Value.Year < 18)
            {
                errCheck.SetError(dtpNgaySinh, "Khách hàng phải đủ 18 tuổi!");
                check = false;
            }
            else
            {
                errCheck.SetError(dtpNgaySinh, "");
            }

            return check;
        }
      
        private void dgr_Khachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false && tabContainer.SelectedTab == tpChinhSua)
            {
                MessageBox.Show("Đang ở chế độ thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (e.RowIndex == -1)
                return;

            txtEmail.Text = dgvKhachhang.CurrentRow.Cells["sEmail"].Value.ToString();
            txtTenKH.Text = dgvKhachhang.CurrentRow.Cells["sTenKH"].Value.ToString();
            txtDiaChi.Text = dgvKhachhang.CurrentRow.Cells["sDiaChi"].Value.ToString();
            dtpNgaySinh.Text = dgvKhachhang.CurrentRow.Cells["dNgaySinh"].Value.ToString();
            txtSDT.Text = dgvKhachhang.CurrentRow.Cells["sSDT"].Value.ToString();
            txtMaKH.Text = dgvKhachhang.CurrentRow.Cells["sMaKH"].Value.ToString();
            txtCMND.Text = dgvKhachhang.CurrentRow.Cells["sCMND"].Value.ToString();
            
            if (btnThem.Enabled == true)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaKH.Enabled = false;
            }
        }

        private string createMa()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand(
                    $@"SELECT COUNT(sMaKH) FROM tblKhachHang"
                    , con))
                {
                    cm.CommandType = CommandType.Text;
                    con.Open();
                    int count = (int)cm.ExecuteScalar() + 1;
                    return $"KH{count.ToString("000")}";
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

            txtMaKH.Text = createMa();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (checkValue(true))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"INSERT INTO dbo.tblKhachHang(sMaKH, sTenKH, sDiaChi, dNgaySinh, sSDT, sEmail, sCMND)
                            VALUES(@MaKH, @TenKH, @DiaChi, @NgaySinh, @SDT, @Email, @CMND)"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@sMaKH", txtMaKH.Text);
                        cm.Parameters.AddWithValue("@sTenKH", txtTenKH.Text);
                        cm.Parameters.AddWithValue("@sDiaChi", txtDiaChi.Text);
                        cm.Parameters.AddWithValue("@dNgaySinh", dtpNgaySinh.Value.Date.ToString("yyyy/MM/dd"));
                        cm.Parameters.AddWithValue("@sSDT", txtSDT.Text);
                        cm.Parameters.AddWithValue("@sEmail", txtEmail.Text);
                        cm.Parameters.AddWithValue("@sCMND", txtCMND.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                btnThem.Enabled = true;
                btnLuu.Enabled = false;

                resetValue();

                dgvKhachhang.DataSource = getDSKH();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Bạn có muốn xóa khách hàng {txtMaKH.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"UPDATE tblKhachHang SET isDeleted = 1 WHERE sMaKH = @MaKH"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        con.Open();
                        cm.Parameters.AddWithValue("@MaKH", txtMaKH.Text.Trim());
                        cm.ExecuteNonQuery();
                    }
                }

                resetValue();

                dgvKhachhang.DataSource = getDSKH();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (checkValue(false))
            {        
                if (MessageBox.Show($"Bạn có muốn sửa khách hàng {txtMaKH.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cm = new SqlCommand(
                            $@"UPDATE dbo.tblKhachHang
                                SET sTenKH = @TenKH,
	                                sDiaChi = @DiaChi,
	                                dNgaySinh = @NgaySinh,
	                                sSDT = @SDT,
	                                sEmail = @Email,
	                                sCMND = @CMND
                                WHERE sMaKH = @MaKH"
                            , con))
                        {
                            cm.CommandType = CommandType.Text;
                            cm.Parameters.AddWithValue("@sMaKH", txtMaKH.Text);
                            cm.Parameters.AddWithValue("@sTenKH", txtTenKH.Text);
                            cm.Parameters.AddWithValue("@sDiaChi", txtDiaChi.Text);
                            cm.Parameters.AddWithValue("@dNgaySinh", dtpNgaySinh.Value.Date.ToString("yyyy/MM/dd"));
                            cm.Parameters.AddWithValue("@sSDT", txtSDT.Text);
                            cm.Parameters.AddWithValue("@sEmail", txtEmail.Text);
                            cm.Parameters.AddWithValue("@sCMND", txtCMND.Text);
                            con.Open();
                            cm.ExecuteNonQuery();
                        }
                    }
                }

                resetValue();

                dgvKhachhang.DataSource = getDSKH();
            }
        }

        private void btn_huyBo_Click(object sender, EventArgs e)
        {
            errCheck.Clear();

            txtMaKH.Enabled = false;
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

        private void btn_displayAll_Click(object sender, EventArgs e)
        {
            resetValueS();

            dgvKhachhang.DataSource = getDSKH();

            lblSoLuong.Text = dgvKhachhang.RowCount.ToString();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string condition = "isDeleted = 0 ";

            if (txtMaKHS.Text.TrimEnd() != "")
                condition += $"AND sMaKH = '{txtMaKHS.Text}' ";
            if (txtTenKHS.Text.TrimEnd() != "")
                condition += $"AND sTenKH LIKE N'%{txtTenKHS.Text}%' ";
            if (txtDiaChiS.Text.TrimEnd() != "")
                condition += $"AND sDiaChi LIKE N'%{txtDiaChiS.Text}%' ";
            if (txtSDTS.Text.TrimEnd() != "")
                condition += $"AND sSDT LIKE '%{txtSDTS.Text}%' ";
            if (txtEmailS.Text.TrimEnd() != "")
                condition += $"AND sEmail LIKE '%{txtEmailS.Text}%' ";
            if (txtCMNDS.Text.TrimEnd() != "")
                condition += $"AND sCMND LIKE '%{txtCMNDS.Text}%' ";
            /*if (ngaysinh.TrimEnd() != "")
                condition += $"AND d LIKE '%{ngaysinh}%' ";
*/

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand(
                    $"SELECT sMaKH, sTenKH, sDiaChi, dNgaySinh, sSDT, sEmail, sCMND FROM tblKhachHang WHERE {condition}"
                    , con))
                {
                    cm.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                    {
                        using (DataTable dt = new DataTable("tblKhachHang"))
                        {
                            sda.Fill(dt);
                            dgvKhachhang.DataSource = dt;
                        }
                    }
                }
            }

            lblSoLuong.Text = dgvKhachhang.RowCount.ToString();
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

        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show($"Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}
