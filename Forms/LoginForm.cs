using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.Extensions.DependencyInjection;
namespace HotelManagement.Forms
{
    public partial class LoginForm : Form
    {
        private IUserService _taiKhoanService;
        public LoginForm(IUserService taiKhoanService)
        {
            InitializeComponent();
            this._taiKhoanService = taiKhoanService;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tendangnhap = txtTaiKhoan.Text.Trim();
            string matkhau = txtMatKhau.Text;
            if (string.IsNullOrWhiteSpace(tendangnhap) && string.IsNullOrWhiteSpace(matkhau))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(tendangnhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(matkhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }
            Userr? user = _taiKhoanService.Login(tendangnhap, matkhau);
            if (user != null)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm mainForm = Program.ServiceProvider.GetRequiredService<MainForm>();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            var registerForm = Program.ServiceProvider.GetRequiredService<RegisterForm>();
            registerForm.Show();
            Hide();
        }

        private void linkQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPasswordForm quenMKForm = new ForgetPasswordForm();
            quenMKForm.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Select();
        }
    }
}
