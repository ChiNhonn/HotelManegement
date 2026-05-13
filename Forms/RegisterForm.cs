using HotelManagement.Interfaces;
using HotelManagement.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.Forms
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

            var registerDto = new RegisterView
            {
                FullName = username,
                Username = username,
                Password = password,
                Phone = phone,
                Email = email,
                IdBranch = 0
            };

            var userService = Program.ServiceProvider.GetRequiredService<IUserService>();
            var result = userService.RegisterUser(registerDto);

            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoginForm loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();
                loginForm.Show();
                this.Hide();
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
            LoginForm loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();
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