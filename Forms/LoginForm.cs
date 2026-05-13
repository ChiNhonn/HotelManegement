using QuanLyKhachSan.Services;
using QuanLyKhachSan.Views;
using QuanLyKhachSan.Models;
using Microsoft.Extensions.DependencyInjection;
namespace QuanLyKhachSan
{
    public partial class LoginForm : Form
    {
        private ITaiKhoanService _taiKhoanService;
        public LoginForm(ITaiKhoanService taiKhoanService)
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
            TaiKhoan tk = _taiKhoanService.DangNhap(tendangnhap, matkhau);
            if (tk != null)
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

        }

        private void linkQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMKForm quenMKForm = new QuenMKForm();
            quenMKForm.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Select();
        }
    }
}
