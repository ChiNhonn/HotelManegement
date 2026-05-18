using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.Windows.Forms;

namespace HotelManagement.CustomControls
{
    public partial class usMainForm : UserControl
    {
        private readonly IDashboardService _dashboard;
        private static readonly CultureInfo Vi = new("vi-VN");
        private ImageList? _imgPending;
        private ImageList? _imgReminders;

        private static readonly Color GridRowBg = Color.White;
        private static readonly Color GridRowHover = Color.FromArgb(245, 247, 250);
        private static readonly Color GridSelectBg = Color.FromArgb(239, 246, 255);

        private int _hoverRowPending = -1;
        private int _hoverRowReminders = -1;
        private int _hoverRowRecentTx = -1;

        private readonly List<string> _pendingTooltips = new();

        public usMainForm(IDashboardService dashboard)
        {
            _dashboard = dashboard;
            InitializeComponent();
        }

        private void usMainForm_Load(object? sender, EventArgs e)
        {
            AssignSectionHeaderIcons();
            ConfigureDashboardGrids();
            WireGridHover(dgvPending, () => _hoverRowPending, v => _hoverRowPending = v);
            WireGridHover(dgvReminders, () => _hoverRowReminders, v => _hoverRowReminders = v);
            WireGridHover(dgvRecentTx, () => _hoverRowRecentTx, v => _hoverRowRecentTx = v);

            dgvPending.CellToolTipTextNeeded += DgvPending_CellToolTipTextNeeded;
            dgvRecentTx.CellFormatting += DgvRecentTx_CellFormatting;
            btnRecentTxViewAll.Click += BtnRecentTxViewAll_Click;
            btnMyTasksViewAll.Click += BtnMyTasksViewAll_Click;
            btnAddPayout.Click += BtnAddPayout_Click;
            ConfigureQuickActionsButton();
            WinFormsScrollPan.EnableForPanel(scrollDashKpi, tblKpiOuter, tblKpiOuter);
            WinFormsScrollPan.EnableForPanel(scrollDashLists, pnlDashListsInner, pnlDashListsInner);

            try
            {
                var m = _dashboard.GetTodayMetrics();
                cardVacant.KpiValue = m.VacantRooms.ToString("N0", Vi);
                cardArrivals.KpiValue = m.ArrivalsToday.ToString("N0", Vi);
                cardDepartures.KpiValue = m.DeparturesToday.ToString("N0", Vi);
                cardRevenue.KpiValue = m.RevenueToday.ToString("N0", Vi) + " đ";

                LoadPendingGrid();
                LoadRemindersGrid();
                LoadRecentTransactionsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không tải được dữ liệu dashboard.\n{ex.Message}",
                    "The Sea",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void DgvPending_CellToolTipTextNeeded(object? sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _pendingTooltips.Count) return;
            e.ToolTipText = _pendingTooltips[e.RowIndex];
        }

        private void LoadPendingGrid()
        {
            dgvPending.Rows.Clear();
            _pendingTooltips.Clear();

            foreach (var b in _dashboard.GetPendingBookingsAwaitingConfirmation())
            {
                var namePhone = string.IsNullOrWhiteSpace(b.Phone)
                    ? b.CustomerName
                    : $"{b.CustomerName}  ·  {b.Phone}";

                var icon = (b.PaidOnline ? _imgPending?.Images[1] : _imgPending?.Images[0]) ?? SystemIcons.Information.ToBitmap();
                var img = (Image)icon.Clone();

                var row = dgvPending.Rows[dgvPending.Rows.Add(img, namePhone, b.BookedRoomsSummary, b.GuestCountText,
                    b.CreatedAt.ToString("dd/MM/yyyy HH:mm", Vi))];
                row.Tag = b.OrderId;

                _pendingTooltips.Add(
                    $"Check-in dự kiến: {b.DateCheckIn:dd/MM/yyyy HH:mm}\nTrạng thái: {b.OrderStatus}\n{b.PaymentHint}");
            }

        }

        private void BtnAddPayout_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Chức năng ghi nhận chi trả sẽ được bổ sung ở bước kế tiếp.",
                "The Sea",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ConfigureQuickActionsButton()
        {
            var forest = Color.FromArgb(21, 100, 55);
            var hover = Color.FromArgb(28, 125, 68);
            var down = Color.FromArgb(17, 82, 46);
            btnAddPayout.BackColor = forest;
            btnAddPayout.ForeColor = Color.White;
            btnAddPayout.FlatAppearance.BorderSize = 0;
            btnAddPayout.FlatAppearance.MouseOverBackColor = hover;
            btnAddPayout.FlatAppearance.MouseDownBackColor = down;
            btnAddPayout.Image?.Dispose();
            btnAddPayout.Image = CreateMdl2Glyph('\uEC59', Color.White, 22, 0.5f);
            btnAddPayout.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddPayout.TextAlign = ContentAlignment.MiddleCenter;
            btnAddPayout.Padding = new Padding(12, 9, 18, 9);

            void UpdateRegion(object? s, EventArgs e) => ApplyRoundedRegionToButton(btnAddPayout, 8);
            btnAddPayout.SizeChanged += UpdateRegion;
            UpdateRegion(btnAddPayout, EventArgs.Empty);
        }

        private static void ApplyRoundedRegionToButton(Button b, int radius)
        {
            if (b.Width <= 2 || b.Height <= 2) return;
            var rect = b.ClientRectangle;
            var d = Math.Min(radius * 2, Math.Min(rect.Width, rect.Height));
            using var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            b.Region?.Dispose();
            b.Region = new Region(path);
        }

        private void BtnMyTasksViewAll_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Danh sách nhiệm vụ đầy đủ sẽ được bổ sung ở phiên bản sau.",
                "The Sea",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnRecentTxViewAll_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Danh sách đầy đủ giao dịch sẽ được bổ sung ở phiên bản sau.",
                "The Sea",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void DgvRecentTx_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var name = dgvRecentTx.Columns[e.ColumnIndex].Name;
            if (name == "colTxAmount")
            {
                var green = Color.FromArgb(22, 163, 74);
                e.CellStyle.ForeColor = green;
                e.CellStyle.SelectionForeColor = green;
            }
            else if (name == "colTxStatus")
            {
                var pill = Color.FromArgb(21, 128, 61);
                e.CellStyle.BackColor = pill;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = pill;
                e.CellStyle.SelectionForeColor = Color.White;
                e.CellStyle.Font = new Font(dgvRecentTx.Font, FontStyle.Bold);
            }
        }

        private void LoadRecentTransactionsGrid()
        {
            dgvRecentTx.Rows.Clear();
            foreach (var t in _dashboard.GetRecentTransactions(10))
            {
                dgvRecentTx.Rows.Add(
                    t.UserName,
                    $"+ {t.Amount:N0} VNĐ",
                    t.StatusLabel,
                    t.OccurredAt.ToString("dd/MM/yyyy HH:mm", Vi));
            }
        }

        private void LoadRemindersGrid()
        {
            dgvReminders.Rows.Clear();

            foreach (var r in _dashboard.GetFrontDeskReminders())
            {
                var idx = ReminderImageIndex(r.Category);
                var src = _imgReminders?.Images[idx] ?? SystemIcons.Warning.ToBitmap();
                var img = (Image)src.Clone();

                dgvReminders.Rows.Add(img, r.Category, r.Message,
                    r.At.HasValue ? r.At.Value.ToString("dd/MM/yyyy HH:mm", Vi) : "—");
            }
        }

        private static void ApplyGridRowHover(DataGridView dgv, int hoverRow)
        {
            if (dgv.IsDisposed || !dgv.IsHandleCreated) return;
            for (var i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].DefaultCellStyle.BackColor = i == hoverRow ? GridRowHover : GridRowBg;
                dgv.Rows[i].DefaultCellStyle.SelectionBackColor = GridSelectBg;
            }
        }

        private void WireGridHover(DataGridView dgv, Func<int> getHover, Action<int> setHover)
        {
            dgv.MouseMove += (_, ev) =>
            {
                var hit = dgv.HitTest(ev.X, ev.Y);
                var r = hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0 ? hit.RowIndex : -1;
                if (r == getHover()) return;
                setHover(r);
                ApplyGridRowHover(dgv, r);
            };
            dgv.CellMouseEnter += (_, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex == getHover()) return;
                setHover(e.RowIndex);
                ApplyGridRowHover(dgv, e.RowIndex);
            };
            dgv.MouseLeave += (_, _) =>
            {
                setHover(-1);
                ApplyGridRowHover(dgv, -1);
            };
        }

        /// <summary>Icon menu MDL2 màu đen, nền trong suốt (không nền xanh giống KPI).</summary>
        private void AssignSectionHeaderIcons()
        {
            const char menuGlyph = '\uE700';
            const char listGlyph = '\uE8C4';
            const char lightningGlyph = '\uE945';
            const char cashGlyph = '\uEC59';
            var ink = Color.Black;
            picPendingHdr.Image?.Dispose();
            picRemindersHdr.Image?.Dispose();
            picRecentTxHdr.Image?.Dispose();
            picQuickHdr.Image?.Dispose();
            picMyTasksHdr.Image?.Dispose();
            picPendingHdr.Image = CreateMdl2Glyph(menuGlyph, ink, box: 28, glyphScale: 0.56f);
            picRemindersHdr.Image = CreateMdl2Glyph(menuGlyph, ink, box: 28, glyphScale: 0.56f);
            picRecentTxHdr.Image = CreateMdl2Glyph(listGlyph, ink, box: 28, glyphScale: 0.52f);
            picQuickHdr.Image = CreateMdl2Glyph(lightningGlyph, ink, box: 28, glyphScale: 0.52f);
            picMyTasksHdr.Image = CreateMdl2Glyph(cashGlyph, ink, box: 28, glyphScale: 0.52f);
        }

        private static int ReminderImageIndex(string category)
        {
            if (category.Contains("Check-out", StringComparison.OrdinalIgnoreCase))
                return 0;
            if (category.Contains("Dọn", StringComparison.OrdinalIgnoreCase))
                return 1;
            if (category.Contains("Dịch vụ", StringComparison.OrdinalIgnoreCase))
                return 2;
            return 0;
        }

        private void ConfigureDashboardGrids()
        {
            _imgPending?.Dispose();
            _imgPending = new ImageList
            {
                ImageSize = new Size(22, 22),
                ColorDepth = ColorDepth.Depth32Bit
            };
            _imgPending.Images.Add(CreateMdl2Glyph('\uE787', Color.FromArgb(30, 95, 200)));
            _imgPending.Images.Add(CreateMdl2Glyph('\uE8D4', Color.FromArgb(5, 150, 105)));

            _imgReminders?.Dispose();
            _imgReminders = new ImageList
            {
                ImageSize = new Size(22, 22),
                ColorDepth = ColorDepth.Depth32Bit
            };
            _imgReminders.Images.Add(CreateMdl2Glyph('\uE74C', Color.FromArgb(220, 38, 38)));
            _imgReminders.Images.Add(CreateMdl2Glyph('\uE8A5', Color.FromArgb(234, 88, 12)));
            _imgReminders.Images.Add(CreateMdl2Glyph('\uE8A7', Color.FromArgb(124, 58, 237)));

            StyleTransactionGrid(dgvPending);
            StyleTransactionGrid(dgvReminders);
            StyleTransactionGrid(dgvRecentTx);

            BuildPendingColumns();
            BuildReminderColumns();
            BuildRecentTxColumns();

            dgvPending.ShowCellToolTips = true;
            dgvReminders.ShowCellToolTips = true;
        }

        private void BuildRecentTxColumns()
        {
            dgvRecentTx.Columns.Clear();
            dgvRecentTx.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTxUser", HeaderText = "Username" });
            dgvRecentTx.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTxAmount", HeaderText = "Số tiền" });
            dgvRecentTx.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTxStatus", HeaderText = "Trạng thái" });
            dgvRecentTx.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTxTime", HeaderText = "Thời gian" });
            dgvRecentTx.Columns[0].MinimumWidth = 120;
            dgvRecentTx.Columns[0].FillWeight = 22;
            dgvRecentTx.Columns[1].MinimumWidth = 110;
            dgvRecentTx.Columns[1].FillWeight = 22;
            dgvRecentTx.Columns[2].MinimumWidth = 110;
            dgvRecentTx.Columns[2].FillWeight = 18;
            dgvRecentTx.Columns[3].MinimumWidth = 130;
            dgvRecentTx.Columns[3].FillWeight = 22;
            dgvRecentTx.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BuildPendingColumns()
        {
            dgvPending.Columns.Clear();
            dgvPending.Columns.Add(new DataGridViewImageColumn
            {
                Name = "colIcon",
                HeaderText = "",
                Width = 40,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                MinimumWidth = 40
            });
            dgvPending.Columns.Add("colGuest", "Tên khách hàng — SĐT");
            dgvPending.Columns.Add("colRoom", "Phòng đặt");
            dgvPending.Columns.Add("colGuests", "Số lượng người");
            dgvPending.Columns.Add("colBookedAt", "Thời gian đặt");
            dgvPending.Columns[1].MinimumWidth = 160;
            dgvPending.Columns[1].FillWeight = 40;
            dgvPending.Columns[2].MinimumWidth = 100;
            dgvPending.Columns[2].FillWeight = 20;
            dgvPending.Columns[3].MinimumWidth = 90;
            dgvPending.Columns[3].FillWeight = 15;
            dgvPending.Columns[4].MinimumWidth = 130;
            dgvPending.Columns[4].FillWeight = 18;
            dgvPending.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BuildReminderColumns()
        {
            dgvReminders.Columns.Clear();
            dgvReminders.Columns.Add(new DataGridViewImageColumn
            {
                Name = "colRIcon",
                HeaderText = "",
                Width = 40,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                MinimumWidth = 40
            });
            dgvReminders.Columns.Add("colRCat", "Loại");
            dgvReminders.Columns.Add("colRMsg", "Nội dung");
            dgvReminders.Columns.Add("colRAt", "Thời điểm");
            dgvReminders.Columns[1].MinimumWidth = 100;
            dgvReminders.Columns[1].FillWeight = 18;
            dgvReminders.Columns[2].MinimumWidth = 160;
            dgvReminders.Columns[2].FillWeight = 55;
            dgvReminders.Columns[3].MinimumWidth = 120;
            dgvReminders.Columns[3].FillWeight = 20;
            dgvReminders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private static void StyleTransactionGrid(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(241, 245, 249);
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 44;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 8, 12, 8);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;

            dgv.DefaultCellStyle.BackColor = GridRowBg;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular, GraphicsUnit.Point);
            dgv.DefaultCellStyle.Padding = new Padding(10, 6, 10, 6);
            dgv.DefaultCellStyle.SelectionBackColor = GridSelectBg;
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);

            dgv.RowTemplate.Height = 48;
            dgv.Cursor = Cursors.Hand;
            dgv.TabStop = false;
            dgv.StandardTab = false;

            dgv.MouseEnter += (_, _) => { dgv.Cursor = Cursors.Hand; };
        }

        private static Bitmap CreateMdl2Glyph(char ch, Color color, int box = 22, float glyphScale = 0.52f)
        {
            var bmp = new Bitmap(box, box, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                using var font = CreateMdl2Font(box * glyphScale);
                var txt = ch.ToString();
                var sz = TextRenderer.MeasureText(txt, font);
                TextRenderer.DrawText(
                    g,
                    txt,
                    font,
                    new Rectangle((box - sz.Width) / 2, (box - sz.Height) / 2, sz.Width, sz.Height),
                    color,
                    TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix);
            }

            return bmp;
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
            catch
            {
                // fallback
            }

            return new Font("Segoe UI Symbol", sizePx * 0.9f, FontStyle.Regular, GraphicsUnit.Pixel);
        }

    }
}
