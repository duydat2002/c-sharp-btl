using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BTL
{
    public partial class frmNCC : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public frmNCC()
        {
            InitializeComponent();
        }

        private DataTable getDSNCC()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT sMaNCC, sTenNCC, sDiaChi, sSDT, sEmail 
                            FROM tblNhaCungCap WHERE isDeleted = 0"
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
            txtMa.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
        }

        private bool checkValue(bool checkMa)
        {
            bool check = true;

            if (checkMa)
            {
                if (txtMa.Text.Trim() == "")
                {
                    errCheck.SetError(txtMa, "Không được để trống!");
                    check = false;
                }
                else if (!Regex.IsMatch(txtMa.Text.Trim(), @"^[A-z,0-9]+$")){
                    errCheck.SetError(txtMa, "Mã không hợp lệ!");
                    check = false;
                }
                else
                {
                    errCheck.SetError(txtMa, "");
                }
            }

            if (txtTen.Text.Trim() == "")
            {
                errCheck.SetError(txtTen, "Không được để trống!");
                check = false;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        "SELECT COUNT(sTenNCC) FROM tblNhaCungCap " +
                        "WHERE sTenNCC = @TenNCC"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@TenNCC", txtTen.Text);
                        con.Open();
                        if ((int)cm.ExecuteScalar() != 0)
                        {
                            errCheck.SetError(txtTen, "Nhà cung cấp đã có trong dữ liệu!");
                            check = false;
                        }
                        else
                            errCheck.SetError(txtTen, "");
                    }
                }
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
                Regex checkSDT = new Regex(@"^0[\d]{9}$");

                if (!checkSDT.IsMatch(txtSDT.Text.Trim()))
                {
                    errCheck.SetError(txtSDT, "Số điện thoại không hợp lệ!");
                    check = false;
                }
                else
                    errCheck.SetError(txtSDT, "");
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

            return check;
        }

        private bool checkValueS()
        {
            bool check = true;

            if (!Regex.IsMatch(txtSDTS.Text.Trim(), @"^\d*$"))
            {
                errCheck.SetError(txtSDTS, "Bạn phải nhập số!");
                check = false;
            }
            else
                errCheck.SetError(txtSDTS, "");

            return check;
        }

        private void frmNCC_Load(object sender, EventArgs e)
        {
            dgvNCC.DataSource = getDSNCC();
            dgvNCC.Columns[0].HeaderText = "Mã NCC";
            dgvNCC.Columns[1].HeaderText = "Tên NCC";
            dgvNCC.Columns[2].HeaderText = "Địa chỉ";
            dgvNCC.Columns[3].HeaderText = "SDT";
            dgvNCC.Columns[4].HeaderText = "Email";
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMa.Enabled = false;

            tabContainer.SelectedTab = tpChinhSua;
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false && tabContainer.SelectedTab == tpChinhSua)
            {
                MessageBox.Show("Đang ở chế độ thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (e.RowIndex == -1)
                return;

            DataGridViewRow row = dgvNCC.Rows[e.RowIndex];
            txtMa.Text = row.Cells["sMaNCC"].Value.ToString();
            txtTen.Text = row.Cells["sTenNCC"].Value.ToString();
            txtDiaChi.Text = row.Cells["sDiaChi"].Value.ToString();
            txtSDT.Text = row.Cells["sSDT"].Value.ToString();
            txtEmail.Text = row.Cells["sEmail"].Value.ToString();

            if (btnThem.Enabled == true)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                txtMa.Enabled = false;
            }
        }

        private string createMa()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand(
                    $@"SELECT COUNT(sMaNCC) FROM tblNhaCungCap"
                    , con))
                {
                    cm.CommandType = CommandType.Text;
                    con.Open();
                    int count = (int)cm.ExecuteScalar() + 1;
                    return $"NCC{count.ToString("000")}";
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnSua.Enabled == true)
                resetValue();

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMa.Text = createMa();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkValue(true))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        "INSERT INTO tblNhaCungCap(sMaNCC, sTenNCC, sDiaChi, sSDT, sEmail) " +
                        "VALUES (@MaNCC, @TenNCC, @DiaChi, @SDT, @Email)"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaNCC", txtMa.Text.Trim());
                        cm.Parameters.AddWithValue("@TenNCC", txtTen.Text.Trim());
                        cm.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cm.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cm.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                btnThem.Enabled = true;
                btnLuu.Enabled = false;

                resetValue();

                dgvNCC.DataSource = getDSNCC();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkValue(false))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        "UPDATE tblNhaCungCap " +
                        "SET sTenNCC = @TenNCC, " +
                        "sDiaChi = @DiaChi, " +
                        "sSDT = @SDT, " +
                        "sEmail = @Email " +
                        "WHERE sMaNCC = @MaNCC"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaNCC", txtMa.Text.Trim());
                        cm.Parameters.AddWithValue("@TenNCC", txtTen.Text.Trim());
                        cm.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cm.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cm.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                resetValue();

                dgvNCC.DataSource = getDSNCC();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nhà cung cấp có mã {txtMa.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        "UPDATE tblNhaCungCap SET isDeleted = 1 WHERE sMaNCC = @MaNCC"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        cm.Parameters.AddWithValue("@MaNCC", txtMa.Text.Trim());
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }

                resetValue();

                dgvNCC.DataSource = getDSNCC();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (checkValueS())
            {
                string condition = "isDeleted = 1 ";

                if (cboMaS.Text.Trim() != "")
                    condition += $"AND sMaNCC = '{cboMaS.Text.Replace("'", "''")}' ";
                if (txtTenS.Text.Trim() != "")
                    condition += $"AND sTenNCC LIKE N'%{txtTenS.Text.Replace("'", "''")}%' ";
                if (txtDiaChiS.Text.Trim() != "")
                    condition += $"AND sDiaChi LIKE N'%{txtDiaChiS.Text.Replace("'", "''")}%' ";
                if (txtSDTS.Text.Trim() != "")
                    condition += $"AND sSDT LIKE '%{txtSDTS.Text.Replace("'", "''")}%' ";
                if (txtEmailS.Text.Trim() != "")
                    condition += $"AND sEmail LIKE '%{txtEmailS.Text.Replace("'", "''")}%' ";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $"SELECT * FROM tblNhaCungCap WHERE {condition}"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cm))
                        {
                            using (DataTable dt = new DataTable("tblNhaCungCap"))
                            {
                                sda.Fill(dt);
                                dgvNCC.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            cboMaS.Text = "";
            txtTenS.Text = "";
            txtDiaChiS.Text = "";
            txtSDTS.Text = "";
            txtEmailS.Text = "";

            dgvNCC.DataSource = getDSNCC();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            errCheck.Clear();

            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            if (btnThem.Enabled == false && tabContainer.SelectedTab == tpChinhSua)
            {
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
            }

            if (tabContainer.SelectedTab == tpTimKiem)
            {
                cboMaS.Text = "";
                txtTenS.Text = "";
                txtDiaChiS.Text = "";
                txtSDTS.Text = "";
                txtEmailS.Text = "";
            }

            resetValue();
        }

        private void tabContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabContainer.SelectedTab == tpChinhSua)
            {
                btnThem.Enabled = true;
            }
            if (tabContainer.SelectedTab == tpTimKiem)
            {
                string oldMaS = cboMaS.Text;

                cboMaS.DataSource = new DataView(getDSNCC(), "", "sMaNCC ASC", DataViewRowState.CurrentRows);
                cboMaS.DisplayMember = "sMaNCC";
                cboMaS.ValueMember = "sMaNCC";
                cboMaS.Text = oldMaS;

                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void frmNCC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show($"Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}
