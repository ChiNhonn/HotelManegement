using HotelManagement.CustomControls;
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

namespace HotelManagement.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chuyentrang(new usMainForm());
        }

        public void chuyentrang(UserControl uc)
        {
            if (!panelContainer.Controls.Contains(uc))
            {
                uc.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(uc);
            }

            uc.BringToFront();
        }
        private void btnPhong_Click(object sender, EventArgs e)
        {
            var phong = Program.ServiceProvider.GetRequiredService<usRoom>();
            chuyentrang(phong);
        }

        private void btnKhach_Click(object sender, EventArgs e)
        {
            chuyentrang(new usCustomer());
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            chuyentrang(new usBookRoom());
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            chuyentrang(new usService());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            chuyentrang(new usStatistics());
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            chuyentrang(new usMainForm());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            LoginForm login = Program.ServiceProvider.GetRequiredService<LoginForm>();
            this.Hide();
            login.Show();
            this.Close();
        }
    }
}
