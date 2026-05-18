using HotelManagement.Interfaces;
using HotelManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagement.Forms;

public partial class LoginForm : Form
{
    private readonly IUserService _userService;

    public LoginForm(IUserService userService)
    {
        InitializeComponent();
        _userService = userService;
    }

    private void btnSignIn_Click(object sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;
        if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(username))
        {
            MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
            return;
        }

        var user = _userService.Login(username, password);
        if (user != null)
        {
            AuthSession.SetUser(user);
            var mainForm = Program.ServiceProvider.GetRequiredService<MainForm>();
            Hide();
            mainForm.ShowDialog();
            AuthSession.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            Show();
        }
        else
        {
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtPassword.Clear();
            txtPassword.Focus();
        }
    }

    private void btnOpenRegister_Click(object sender, EventArgs e)
    {
        var registerForm = Program.ServiceProvider.GetRequiredService<RegisterForm>();
        registerForm.Show();
        Hide();
    }

    private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var forgetForm = Program.ServiceProvider.GetRequiredService<ForgetPasswordForm>();
        forgetForm.Show();
        this.Hide();
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
        txtUsername.Select();
    }
}
