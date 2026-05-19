using HotelManagement.CustomControls;
using HotelManagement.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace HotelManagement.Forms
{
    public partial class MainForm : Form
    {
        private static readonly Color SidebarGradTop = Color.FromArgb(55, 125, 230);
        private static readonly Color SidebarGradBottom = Color.FromArgb(10, 14, 28);

        private static readonly Color NavIdle = Color.FromArgb(12, 255, 255, 255);
        private static readonly Color NavHover = Color.FromArgb(55, 255, 255, 255);
        private static readonly Color NavActive = Color.FromArgb(95, 130, 220, 255);

        private static readonly Color LogoutIdle = Color.FromArgb(35, 255, 255, 255);
        private static readonly Color LogoutHover = Color.FromArgb(65, 255, 255, 255);

        private const int SidebarHeaderBottom = 96;
        private const int NavButtonHeight = 46;
        private const int NavButtonGap = 4;

        private Button? _activeNavButton;

        public MainForm()
        {
            InitializeComponent();
            SetSidebarDoubleBuffered(pnlChoice);
            pnlChoice.Paint += PnlChoice_Paint;
            pnlChoice.Resize += (_, _) => LayoutSidebarButtons();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (Control c in pnlChoice.Controls)
            {
                if (c is Button { Image: not null } b)
                {
                    var img = b.Image;
                    b.Image = null;
                    img.Dispose();
                }
            }

            base.OnFormClosing(e);
        }

        private static void SetSidebarDoubleBuffered(Control c)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(c, true);
        }

        private static Font CreateMdl2Font(float sizePx)
        {
            try
            {
                var f = new Font("Segoe MDL2 Assets", sizePx, FontStyle.Regular, GraphicsUnit.Pixel);
                if (f.Name.IndexOf("MDL2", StringComparison.OrdinalIgnoreCase) >= 0)
                    return f;
                f.Dispose();
            }
            catch { /* ignore */ }

            return new Font("Segoe UI Symbol", sizePx * 0.9f, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        private static Image CreateNavGlyph(char mdl2Char, int box = 28)
        {
            var bmp = new Bitmap(box, box, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bmp))
            using (var font = CreateMdl2Font(box * 0.62f))
            {
                g.Clear(Color.Transparent);
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                using var brush = new SolidBrush(Color.White);
                var sz = TextRenderer.MeasureText(mdl2Char.ToString(), font);
                g.DrawString(
                    mdl2Char.ToString(),
                    font,
                    brush,
                    (box - sz.Width) / 2f,
                    (box - sz.Height) / 2f + 1);
            }

            return bmp;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AssignNavIcons();
            ApplySidebarButtonChrome();
            LayoutSidebarButtons();
            pnlSidebarHeader.BringToFront();

            var dash = Program.ServiceProvider.GetRequiredService<usMainForm>();
            chuyentrang(dash);
            SetActiveNav(btnDashboard);
        }

        private void AssignNavIcons()
        {
            btnDashboard.Image = CreateNavGlyph('\uE80F');
            btnRooms.Image = CreateNavGlyph('\uE8F2');
            btnBookings.Image = CreateNavGlyph('\uE787');
            btnServices.Image = CreateNavGlyph('\uE8A7');
            btnBill.Image = CreateNavGlyph('\uE9F3');
            btnCustomers.Image = CreateNavGlyph('\uE716');
            btnSignOut.Image = CreateNavGlyph('\uF3B1');

            foreach (Control c in pnlChoice.Controls)
            {
                if (c is Button b && b.Image != null)
                {
                    b.TextImageRelation = TextImageRelation.ImageBeforeText;
                    b.ImageAlign = ContentAlignment.MiddleLeft;
                    b.TextAlign = ContentAlignment.MiddleLeft;
                }
            }
        }

        private void PnlChoice_Paint(object? sender, PaintEventArgs e)
        {
            var rect = pnlChoice.ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0) return;

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            using (var brush = new LinearGradientBrush(
                       new Point(0, 0),
                       new Point(0, rect.Height),
                       SidebarGradTop,
                       SidebarGradBottom))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void ApplySidebarButtonChrome()
        {
            foreach (Control c in pnlChoice.Controls)
            {
                if (c is not Button b) continue;

                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.ForeColor = Color.White;
                b.Cursor = Cursors.Hand;
                b.Padding = new Padding(12, 0, 8, 0);
                b.UseVisualStyleBackColor = false;
                b.FlatAppearance.MouseOverBackColor = b.FlatAppearance.MouseDownBackColor = Color.Empty;
                b.Font = new Font("Segoe UI", 10.5f, FontStyle.Regular, GraphicsUnit.Point);
                b.Height = NavButtonHeight;

                if (b == btnSignOut)
                {
                    b.Font = new Font("Segoe UI", 10.5f, FontStyle.Regular, GraphicsUnit.Point);
                    b.BackColor = LogoutIdle;
                    b.MouseEnter -= Logout_MouseEnter;
                    b.MouseLeave -= Logout_MouseLeave;
                    b.MouseEnter += Logout_MouseEnter;
                    b.MouseLeave += Logout_MouseLeave;
                    continue;
                }

                b.BackColor = NavIdle;
                b.MouseEnter -= Nav_MouseEnter;
                b.MouseLeave -= Nav_MouseLeave;
                b.MouseEnter += Nav_MouseEnter;
                b.MouseLeave += Nav_MouseLeave;
            }
        }

        private void Nav_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is not Button b || b == _activeNavButton) return;
            b.BackColor = NavHover;
        }

        private void Nav_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is not Button b) return;
            b.BackColor = b == _activeNavButton ? NavActive : NavIdle;
        }

        private void Logout_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button b) b.BackColor = LogoutHover;
        }

        private void Logout_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button b) b.BackColor = LogoutIdle;
        }

        private void LayoutSidebarButtons()
        {
            pnlSidebarHeader.Width = pnlChoice.ClientSize.Width;

            const int pad = 10;
            int w = Math.Max(100, pnlChoice.ClientSize.Width - 2 * pad);

            int y = SidebarHeaderBottom + 6;
            var navOrder = new[]
            {
                btnDashboard, btnRooms, btnBookings, btnServices, btnBill, btnCustomers
            };

            foreach (var b in navOrder)
            {
                b.Width = w;
                b.Left = pad;
                b.Top = y;
                b.Height = NavButtonHeight;
                y += NavButtonHeight + NavButtonGap;
            }

            btnSignOut.Width = w;
            btnSignOut.Left = pad;
            btnSignOut.Height = NavButtonHeight + 4;
            int logoutY = pnlChoice.ClientSize.Height - btnSignOut.Height - pad;
            int minLogoutY = y + 24;
            if (logoutY < minLogoutY) logoutY = minLogoutY;
            btnSignOut.Top = logoutY;

            pnlChoice.Invalidate();
        }

        private void SetActiveNav(Button active)
        {
            _activeNavButton = active;
            foreach (Control c in pnlChoice.Controls)
            {
                if (c is Button b && b != btnSignOut)
                    b.BackColor = b == _activeNavButton ? NavActive : NavIdle;
            }
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

        /// <summary>Gỡ và dispose một UserControl phụ (trang xem chi tiết / xem tất cả).</summary>
        public void RemovePage(UserControl uc)
        {
            if (uc == null) return;
            if (panelContainer.Controls.Contains(uc))
                panelContainer.Controls.Remove(uc);
            uc.Dispose();
        }

        public void NavigateToServiceOperations()
        {
            SetActiveNav(btnServices);
            var page = Program.ServiceProvider.GetRequiredService<usService>();
            page.SelectOperationsTab();
            chuyentrang(page);
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnRooms);
            chuyentrang(Program.ServiceProvider.GetRequiredService<usRoom>());
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnCustomers);
            var customerForm = Program.ServiceProvider.GetRequiredService<CustomerForm>();
            chuyentrangForm(customerForm);
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnBookings);
            chuyentrang(Program.ServiceProvider.GetRequiredService<usBookRoom>());
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnServices);
            chuyentrang(Program.ServiceProvider.GetRequiredService<usService>());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnDashboard);
            chuyentrang(Program.ServiceProvider.GetRequiredService<usMainForm>());
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            AuthSession.Clear();
            var login = Program.ServiceProvider.GetRequiredService<LoginForm>();
            Hide();
            login.Show();
            Close();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnBill);
            chuyentrang(Program.ServiceProvider.GetRequiredService<usBill>());
        }

        public void chuyentrangForm(Form childForm)
        {
            panelContainer.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContainer.Controls.Add(childForm);
            panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
