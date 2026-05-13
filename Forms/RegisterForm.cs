using HotelManagement.Services;
using Microsoft.Extensions.DependencyInjection;
using QuanLyKhachSan.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Views
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string phone = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var registerDto = new RegisterView
            {
                Username = username,
                Password = password,
                Phone = phone,
                Email = email
            };

            var registerService = Program.ServiceProvider.GetService<RegisterService>();

            if (registerService == null)
            {
                MessageBox.Show("Lỗi: Chưa cấu hình RegisterService trong hệ thống!", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = registerService.RegisterUser(registerDto);

            if (result.IsSuccess)
            {
                // Thông báo thành công
                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Chuyển sang form đăng nhập
                LoginForm loginForm = Program.ServiceProvider.GetService<LoginForm>();
                if (loginForm != null)
                {
                    loginForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show(result.Message, "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = Program.ServiceProvider.GetService<LoginForm>();
            if (loginForm != null)
            {
                loginForm.Show();
                this.Hide();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}