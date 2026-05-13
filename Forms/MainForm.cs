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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chuyentrang(new usTrangChu());
        }

        public void chuyentrang(UserControl tc)
        {
            if (!panelContainer.Controls.Contains(tc))
            {
                tc.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(tc);
            }

            tc.BringToFront();
        }
        private void btnPhong_Click(object sender, EventArgs e)
        {
            var phong = Program.ServiceProvider.GetRequiredService<usPhong>();
            chuyentrang(phong);
        }

        private void btnKhach_Click(object sender, EventArgs e)
        {
            chuyentrang(new usKhach());
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            chuyentrang(new usDatPhong());
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            chuyentrang(new usDichVu());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            chuyentrang(new usThongKe());
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            chuyentrang(new usTrangChu());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            LoginForm login = Program.ServiceProvider.GetService<LoginForm>();
            this.Hide();
            login.Show();
            this.Close();
        }
    }
}
