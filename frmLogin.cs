using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class frmLogin : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public frmLogin()
        {
            InitializeComponent();
        }

        private DataTable getDSTK()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cm = new SqlCommand(
                        $@"SELECT sEmail, sSDT FROM tblNhanVien"
                        , con))
                    {
                        cm.CommandType = CommandType.Text;
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cm))
                        {
                            DataTable dt = new DataTable("tblTaiKhoan");
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

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string roleUser;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cm = new SqlCommand(
                    $@"SELECT sRole FROM tblNhanVien WHERE sEmail = @Email AND sSDT = @Password"
                    , con))
                {
                    cm.CommandType = CommandType.Text;
                    cm.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cm.Parameters.AddWithValue("@Password", mtxtPassword.Text.Trim());
                    con.Open();
                    roleUser = (string)cm.ExecuteScalar();
                    if (roleUser == "" || roleUser == null)
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        Program.role = roleUser;
                        this.Hide();
                        frmMain frm = new frmMain();
                        frm.ShowDialog();
                        Close();
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
