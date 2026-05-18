using HotelManagement.Interfaces;
using HotelManagement.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace HotelManagement.Forms;

public partial class RegisterForm : Form
{
    private static readonly Regex PhoneRegex = new(@"^0\d{9,10}$", RegexOptions.Compiled);

    private readonly IUserService _userService;

    public RegisterForm(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        InitializeComponent();
    }

    private void RegisterForm_Load(object? sender, EventArgs e)
    {
        txtFullName.Focus();
    }

    private void btnRegister_Click(object? sender, EventArgs e)
    {
        var fullName = txtFullName.Text.Trim();
        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;
        var confirmPassword = txtConfirmPassword.Text;
        var phone = txtSDT.Text.Trim();
        var email = txtEmail.Text.Trim();

        if (string.IsNullOrWhiteSpace(fullName))
        {
            ShowWarning("Vui lòng nhập họ và tên.", txtFullName);
            return;
        }

        if (string.IsNullOrWhiteSpace(username))
        {
            ShowWarning("Vui lòng nhập tên đăng nhập.", txtUsername);
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            ShowWarning("Vui lòng nhập mật khẩu.", txtPassword);
            return;
        }

        if (password != confirmPassword)
        {
            ShowWarning("Mật khẩu xác nhận không khớp.", txtConfirmPassword);
            return;
        }

        if (string.IsNullOrWhiteSpace(phone))
        {
            ShowWarning("Vui lòng nhập số điện thoại.", txtSDT);
            return;
        }

        if (!PhoneRegex.IsMatch(phone))
        {
            ShowWarning("Số điện thoại không hợp lệ (ví dụ: 0912345678).", txtSDT);
            return;
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            ShowWarning("Vui lòng nhập email.", txtEmail);
            return;
        }

        var registerDto = new RegisterView
        {
            FullName = fullName,
            Username = username,
            Password = password,
            Phone = phone,
            Email = email,
            CitizenId = "",
            IdBranch = 0
        };

        var result = _userService.RegisterUser(registerDto);

        if (result.IsSuccess)
        {
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            OpenLogin();
        }
        else
        {
            MessageBox.Show(result.Message, "Đăng ký thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void linkLogin_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        OpenLogin();
    }

    private void OpenLogin()
    {
        var loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();
        loginForm.Show();
        Hide();
    }

    private void ClearForm()
    {
        txtFullName.Clear();
        txtUsername.Clear();
        txtPassword.Clear();
        txtConfirmPassword.Clear();
        txtSDT.Clear();
        txtEmail.Clear();
    }

    private static void ShowWarning(string message, Control focus)
    {
        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        focus.Focus();
    }
}
