using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace QuanLyKhachSan.Views
{
    public partial class ForgetPasswordForm : Form
    {
        public ForgetPasswordForm()
        {
            InitializeComponent();
        }

        private void QuenMKForm_Load(object sender, EventArgs e)
        {
            txtNhapEmail.Focus();
        }

        private void btnQuayVeLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = Program.ServiceProvider.GetService<LoginForm>();
            loginForm.Show();
        }
    }
}
