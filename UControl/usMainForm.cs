using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.Forms;
using HotelManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
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
        /// <summary>Nền xanh nhạt cho nhắc nhở chưa được người dùng “đọc” (click).</summary>
        private static readonly Color ReminderHighlightBg = Color.FromArgb(219, 234, 254);

        private readonly HashSet<string> _seenReminderKeys = new(StringComparer.Ordinal);

        private static readonly string ReminderSeenKeysPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "HotelManagement",
            "dashboard_reminders_seen.keys.txt");

        private int _hoverRowPending = -1;
        private int _hoverRowReminders = -1;
        private int _hoverRowRecentTx = -1;
        private int _hoverRowStaffPayouts = -1;

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
            LoadReminderSeenKeys();
            WireGridHover(dgvPending, () => _hoverRowPending, v => _hoverRowPending = v);
            WireReminderGridHover();
            WireGridHover(dgvRecentTx, () => _hoverRowRecentTx, v => _hoverRowRecentTx = v);
            WireGridHover(dgvStaffPayouts, () => _hoverRowStaffPayouts, v => _hoverRowStaffPayouts = v);

            dgvPending.CellToolTipTextNeeded += DgvPending_CellToolTipTextNeeded;
            dgvRecentTx.CellFormatting += DgvRecentTx_CellFormatting;
            dgvStaffPayouts.CellFormatting += DgvRecentTx_CellFormatting;
            dgvRecentTx.CellPainting += DgvTx_CellPainting;
            dgvStaffPayouts.CellPainting += DgvTx_CellPainting;
            btnRecentTxViewAll.Click += BtnRecentTxViewAll_Click;
            btnAddRecentPayment.Click += BtnAddRecentPayment_Click;
            btnMyTasksViewAll.Click += BtnMyTasksViewAll_Click;
            btnPendingViewAll.Click += BtnPendingViewAll_Click;
            btnRemindersViewAll.Click += BtnRemindersViewAll_Click;
            btnAddPayout.Click += BtnAddPayout_Click;
            dgvReminders.CellClick += DgvReminders_CellClick;
            dgvReminders.CellDoubleClick += DgvReminders_CellDoubleClick;
            ConfigureQuickActionsButton();

            try
            {
                ReloadDashboard();
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

        private void ReloadDashboard()
        {
            var m = _dashboard.GetTodayMetrics();
            cardVacant.KpiValue = m.VacantRooms.ToString("N0", Vi);
            cardArrivals.KpiValue = m.ArrivalsToday.ToString("N0", Vi);
            cardDepartures.KpiValue = m.DeparturesToday.ToString("N0", Vi);
            cardRevenue.KpiValue = m.RevenueToday.ToString("N0", Vi) + " đ";

            LoadPendingGrid();
            LoadRemindersGrid();
            LoadRecentTransactionsGrid();
            LoadStaffPayoutsGrid();
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

            foreach (var b in _dashboard.GetPendingBookingsAwaitingConfirmation(5))
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
            AddPayoutInteractively();
            LoadStaffPayoutsGrid();
        }

        private void LoadStaffPayoutsGrid()
        {
            dgvStaffPayouts.Rows.Clear();
            foreach (var t in _dashboard.GetRecentStaffPayouts(15))
            {
                dgvStaffPayouts.Rows.Add(
                    t.UserName,
                    $"- {t.Amount:N0} VNĐ",
                    t.StatusLabel,
                    t.OccurredAt.ToString("dd/MM/yyyy HH:mm", Vi));
            }
        }

        private void ConfigureQuickActionsButton()
        {
            var forest = Color.FromArgb(21, 100, 55);
            var forestHover = Color.FromArgb(28, 125, 68);
            var forestDown = Color.FromArgb(17, 82, 46);

            var blue = Color.FromArgb(37, 99, 235);
            var blueHover = Color.FromArgb(29, 78, 216);
            var blueDown = Color.FromArgb(30, 64, 175);

            const int btnHeight = 52;

            void SizeQuickButtons(object? sender, EventArgs e)
            {
                var inner = Math.Max(120,
                    pnlQuickActionsBody.ClientSize.Width - pnlQuickActionsBody.Padding.Horizontal);
                flowQuickActions.Width = inner;
                btnAddRecentPayment.Width = inner;
                btnAddPayout.Width = inner;
                ApplyRoundedRegionToButton(btnAddRecentPayment, 8);
                ApplyRoundedRegionToButton(btnAddPayout, 8);
            }

            btnAddRecentPayment.Dock = DockStyle.None;
            btnAddRecentPayment.FlatStyle = FlatStyle.Flat;
            btnAddRecentPayment.FlatAppearance.BorderSize = 0;
            btnAddRecentPayment.BackColor = blue;
            btnAddRecentPayment.ForeColor = Color.White;
            btnAddRecentPayment.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnAddRecentPayment.Padding = Padding.Empty;
            btnAddRecentPayment.Margin = new Padding(0, 0, 0, 10);
            btnAddRecentPayment.Height = btnHeight;
            btnAddRecentPayment.FlatAppearance.MouseOverBackColor = blueHover;
            btnAddRecentPayment.FlatAppearance.MouseDownBackColor = blueDown;
            btnAddRecentPayment.UseVisualStyleBackColor = false;
            btnAddRecentPayment.Image?.Dispose();
            btnAddRecentPayment.Image = Mdl2Icons.Create('\uE8D7', Color.White, 20, 0.5f);

            btnAddPayout.Dock = DockStyle.None;
            btnAddPayout.BackColor = forest;
            btnAddPayout.ForeColor = Color.White;
            btnAddPayout.FlatAppearance.BorderSize = 0;
            btnAddPayout.FlatStyle = FlatStyle.Flat;
            btnAddPayout.FlatAppearance.MouseOverBackColor = forestHover;
            btnAddPayout.FlatAppearance.MouseDownBackColor = forestDown;
            btnAddPayout.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnAddPayout.Padding = Padding.Empty;
            btnAddPayout.Margin = new Padding(0);
            btnAddPayout.Height = btnHeight;
            btnAddPayout.UseVisualStyleBackColor = false;
            btnAddPayout.Image?.Dispose();
            btnAddPayout.Image = Mdl2Icons.Create('\uEC59', Color.White, 20, 0.5f);

            pnlQuickActionsBody.SizeChanged += SizeQuickButtons;
            SizeQuickButtons(null, EventArgs.Empty);
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
            var page = new usPaginatedListPage
            {
                PageTitle = "Chi trả đã ghi nhận",
                Columns = new[]
                {
                    new usPaginatedListPage.ColumnSpec { Name = "colTxUser",   HeaderText = "Tiêu đề",   MinWidth = 160, FillWeight = 30 },
                    new usPaginatedListPage.ColumnSpec { Name = "colTxAmount", HeaderText = "Số tiền",   MinWidth = 130, FillWeight = 20 },
                    new usPaginatedListPage.ColumnSpec { Name = "colTxStatus", HeaderText = "Trạng thái", MinWidth = 130, FillWeight = 18 },
                    new usPaginatedListPage.ColumnSpec { Name = "colTxTime",   HeaderText = "Thời gian",  MinWidth = 150, FillWeight = 22 },
                },
                Loader = () => _dashboard.GetRecentStaffPayouts(1000)
                    .Select(t => new object?[]
                    {
                        t.UserName,
                        $"- {t.Amount:N0} VNĐ",
                        t.StatusLabel,
                        t.OccurredAt.ToString("dd/MM/yyyy HH:mm", Vi)
                    }!).Cast<object[]>().ToList(),
                FilterOptions = new[] { "Tất cả", "Hôm nay", "7 ngày qua", "30 ngày qua" },
                FilterPredicate = (row, idx) => MatchesRecentDateFilter(row[3] as string, idx),
                AddButtonText = "Thêm chi trả",
                OnAddClicked = AddPayoutInteractively,
                OnCellFormatting = (g, ev) => DgvRecentTx_CellFormattingStatic(g, ev, isOutflow: true),
                OnCellPainting = (g, ev) => DgvTx_CellPaintingStatic(g, ev),
            };
            ShowPage(page, refreshOnReturn: LoadStaffPayoutsGrid);
        }

        private void BtnRecentTxViewAll_Click(object? sender, EventArgs e)
        {
            var page = new usPaginatedListPage
            {
                PageTitle = "Giao dịch gần đây",
                Columns = new[]
                {
                    new usPaginatedListPage.ColumnSpec { Name = "colTxUser",   HeaderText = "Tiêu đề",     MinWidth = 160, FillWeight = 30 },
                    new usPaginatedListPage.ColumnSpec { Name = "colTxAmount", HeaderText = "Số tiền",     MinWidth = 130, FillWeight = 20 },
                    new usPaginatedListPage.ColumnSpec { Name = "colTxStatus", HeaderText = "Phương thức", MinWidth = 130, FillWeight = 18 },
                    new usPaginatedListPage.ColumnSpec { Name = "colTxTime",   HeaderText = "Thời gian",   MinWidth = 150, FillWeight = 22 },
                },
                Loader = () => _dashboard.GetRecentTransactions(1000)
                    .Select(t => new object?[]
                    {
                        t.UserName,
                        $"+ {t.Amount:N0} VNĐ",
                        string.IsNullOrWhiteSpace(t.Method) ? t.StatusLabel : t.Method,
                        t.OccurredAt.ToString("dd/MM/yyyy HH:mm", Vi)
                    }!).Cast<object[]>().ToList(),
                FilterOptions = new[] { "Tất cả", "Hôm nay", "7 ngày qua", "30 ngày qua" },
                FilterPredicate = (row, idx) => MatchesRecentDateFilter(row[3] as string, idx),
                OnCellFormatting = (g, ev) => DgvRecentTx_CellFormattingStatic(g, ev, isOutflow: false),
                OnCellPainting = (g, ev) => DgvTx_CellPaintingStatic(g, ev),
                AddButtonText = "Thêm giao dịch",
                OnAddClicked = AddManualPaymentInteractively,
            };
            ShowPage(page, refreshOnReturn: ReloadDashboard);
        }

        private void BtnAddRecentPayment_Click(object? sender, EventArgs e) => AddManualPaymentInteractively();

        private void AddManualPaymentInteractively()
        {
            using var dlg = new ManualPaymentDialog(_dashboard);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
            try
            {
                ReloadDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã ghi thanh toán nhưng không làm mới dashboard đầy đủ.\n{ex.Message}",
                    "The Sea",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void BtnPendingViewAll_Click(object? sender, EventArgs e)
        {
            var page = new usPaginatedListPage
            {
                PageTitle = "Booking mới chờ xác nhận",
                Columns = new[]
                {
                    new usPaginatedListPage.ColumnSpec { Name = "colIcon",     HeaderText = "",                  MinWidth = 40,  FillWeight = 4,  IsImage = true },
                    new usPaginatedListPage.ColumnSpec { Name = "colGuest",    HeaderText = "Tên khách hàng — SĐT", MinWidth = 200, FillWeight = 35 },
                    new usPaginatedListPage.ColumnSpec { Name = "colRoom",     HeaderText = "Phòng đặt",        MinWidth = 110, FillWeight = 16 },
                    new usPaginatedListPage.ColumnSpec { Name = "colGuests",   HeaderText = "Số lượng người",   MinWidth = 130, FillWeight = 14 },
                    new usPaginatedListPage.ColumnSpec { Name = "colStatus",   HeaderText = "Thanh toán",       MinWidth = 200, FillWeight = 22 },
                    new usPaginatedListPage.ColumnSpec { Name = "colBookedAt", HeaderText = "Thời gian đặt",   MinWidth = 150, FillWeight = 18 },
                },
                Loader = () => _dashboard.GetPendingBookingsAwaitingConfirmation(0)
                    .Select(b =>
                    {
                        var namePhone = string.IsNullOrWhiteSpace(b.Phone)
                            ? b.CustomerName
                            : $"{b.CustomerName}  ·  {b.Phone}";
                        Image icon = b.PaidOnline
                            ? Mdl2Icons.Create('\uE8D4', Color.FromArgb(5, 150, 105), 24, 0.6f)
                            : Mdl2Icons.Create('\uE787', Color.FromArgb(30, 95, 200), 24, 0.6f);
                        return new object?[]
                        {
                            icon,
                            namePhone,
                            b.BookedRoomsSummary,
                            b.GuestCountText,
                            b.PaymentHint,
                            b.CreatedAt.ToString("dd/MM/yyyy HH:mm", Vi),
                        };
                    }).Cast<object[]>().ToList(),
                FilterOptions = new[] { "Tất cả", "Đã thanh toán online", "Chưa thanh toán" },
                FilterPredicate = (row, idx) =>
                {
                    var hint = row[4] as string ?? string.Empty;
                    return idx switch
                    {
                        1 => hint.Contains("online", StringComparison.OrdinalIgnoreCase),
                        2 => hint.Contains("Chưa thanh toán", StringComparison.OrdinalIgnoreCase),
                        _ => true,
                    };
                },
            };
            ShowPage(page);
        }

        /// <summary>Double-click vào ô nhắc nhở (trừ tiêu đề cột) → mở Dịch vụ & tiện ích, tab Vận hành.</summary>
        private void DgvReminders_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            MarkReminderRowSeen(e.RowIndex);
        }

        private void DgvReminders_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            MarkReminderRowSeen(e.RowIndex);
            if (FindForm() is not MainForm main) return;
            main.NavigateToServiceOperations();
        }

        private void BtnRemindersViewAll_Click(object? sender, EventArgs e)
        {
            var page = new usPaginatedListPage
            {
                PageTitle = "Nhắc nhở",
                Columns = new[]
                {
                    new usPaginatedListPage.ColumnSpec { Name = "colRIcon", HeaderText = "",         MinWidth = 40,  FillWeight = 4, IsImage = true },
                    new usPaginatedListPage.ColumnSpec { Name = "colRCat",  HeaderText = "Loại",     MinWidth = 120, FillWeight = 14 },
                    new usPaginatedListPage.ColumnSpec { Name = "colRMsg",  HeaderText = "Nội dung", MinWidth = 220, FillWeight = 60 },
                    new usPaginatedListPage.ColumnSpec { Name = "colRAt",   HeaderText = "Thời điểm", MinWidth = 150, FillWeight = 22 },
                },
                Loader = () => _dashboard.GetFrontDeskReminders(0)
                    .Select(r =>
                    {
                        Image icon = ReminderImageIndex(r.Category) switch
                        {
                            0 => Mdl2Icons.Create('\uE74C', Color.FromArgb(220, 38, 38), 24, 0.6f),
                            1 => Mdl2Icons.Create('\uE8A5', Color.FromArgb(234, 88, 12), 24, 0.6f),
                            _ => Mdl2Icons.Create('\uE8A7', Color.FromArgb(124, 58, 237), 24, 0.6f),
                        };
                        return new object?[]
                        {
                            icon,
                            r.Category,
                            r.Message,
                            r.At.HasValue ? r.At.Value.ToString("dd/MM/yyyy HH:mm", Vi) : "—",
                        };
                    }).Cast<object[]>().ToList(),
                FilterOptions = new[] { "Tất cả", "Check-out", "Dọn phòng", "Dịch vụ" },
                FilterPredicate = (row, idx) =>
                {
                    var cat = row[1] as string ?? string.Empty;
                    return idx switch
                    {
                        1 => cat.Contains("Check-out", StringComparison.OrdinalIgnoreCase),
                        2 => cat.Contains("Dọn", StringComparison.OrdinalIgnoreCase),
                        3 => cat.Contains("Dịch vụ", StringComparison.OrdinalIgnoreCase),
                        _ => true,
                    };
                },
            };
            ShowPage(page);
        }

        private void ShowPage(usPaginatedListPage page, Action? refreshOnReturn = null)
        {
            if (FindForm() is not HotelManagement.Forms.MainForm main) return;
            page.OnBackClicked = () =>
            {
                main.chuyentrang(this);
                main.RemovePage(page);
                refreshOnReturn?.Invoke();
            };
            main.chuyentrang(page);
        }

        private static bool MatchesRecentDateFilter(string? formattedTime, int idx)
        {
            if (idx <= 0) return true;
            if (string.IsNullOrEmpty(formattedTime)) return false;
            if (!DateTime.TryParseExact(formattedTime, "dd/MM/yyyy HH:mm", Vi,
                    DateTimeStyles.None, out var dt))
                return true;
            var now = DateTime.Now;
            return idx switch
            {
                1 => dt.Date == now.Date,
                2 => dt >= now.AddDays(-7),
                3 => dt >= now.AddDays(-30),
                _ => true,
            };
        }

        private void AddPayoutInteractively()
        {
            using var dlg = new HotelManagement.Forms.AddStaffPayoutDialog();
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
            try
            {
                _dashboard.RecordStaffPayout(dlg.PayoutUserName, dlg.Amount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể ghi nhận chi trả.\n{ex.Message}",
                    "The Sea",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private static void DgvRecentTx_CellFormattingStatic(DataGridView dgv, DataGridViewCellFormattingEventArgs e, bool isOutflow)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var style = e.CellStyle;
            if (style == null) return;
            var name = dgv.Columns[e.ColumnIndex].Name;
            if (name == "colTxAmount")
            {
                var color = isOutflow
                    ? Color.FromArgb(220, 38, 38)
                    : Color.FromArgb(22, 163, 74);
                style.ForeColor = color;
                style.SelectionForeColor = color;
                style.Font = new Font(dgv.Font, FontStyle.Bold);
            }
        }

        private static void DgvTx_CellPaintingStatic(DataGridView dgv, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgv.Columns[e.ColumnIndex].Name != "colTxStatus") return;

            var text = e.FormattedValue?.ToString();
            if (string.IsNullOrEmpty(text))
            {
                e.Handled = false;
                return;
            }

            e.PaintBackground(e.ClipBounds, (e.State & DataGridViewElementStates.Selected) != 0);

            var g = e.Graphics;
            if (g == null) { e.Handled = true; return; }
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using var font = new Font(dgv.Font, FontStyle.Bold);
            var sz = TextRenderer.MeasureText(g, text, font, Size.Empty, TextFormatFlags.NoPadding);
            const int padX = 10, padY = 4;
            var pillW = sz.Width + padX * 2;
            var pillH = sz.Height + padY * 2;

            var cell = e.CellBounds;
            var pillRect = new Rectangle(
                cell.Left + 12,
                cell.Top + (cell.Height - pillH) / 2,
                Math.Min(pillW, cell.Width - 24),
                pillH);

            var (fill, border, ink) = ResolvePillPalette(text);
            using var path = RoundedRect(pillRect, pillRect.Height / 2);
            using (var br = new SolidBrush(fill)) g.FillPath(br, path);
            using (var pen = new Pen(border)) g.DrawPath(pen, path);

            TextRenderer.DrawText(
                g,
                text,
                font,
                pillRect,
                ink,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);

            e.Handled = true;
        }

        /// <summary>Bộ màu pill cho cột « Phương thức / Trạng thái » theo nội dung.</summary>
        private static (Color fill, Color border, Color ink) ResolvePillPalette(string label)
        {
            var s = (label ?? string.Empty).Trim().ToLowerInvariant();
            // Chuyển khoản → xanh dương
            if (s.Contains("chuyển khoản") || s.Contains("transfer") || s.Contains("bank"))
                return (Color.FromArgb(219, 234, 254), Color.FromArgb(191, 219, 254), Color.FromArgb(29, 78, 216));
            // Online / QR / VNPay / Momo… → tím
            if (s.Contains("online") || s.Contains("qr") || s.Contains("vnpay") || s.Contains("momo") || s.Contains("zalopay"))
                return (Color.FromArgb(237, 233, 254), Color.FromArgb(221, 214, 254), Color.FromArgb(91, 33, 182));
            // Thẻ → hổ phách
            if (s.Contains("thẻ") || s.Contains("card"))
                return (Color.FromArgb(254, 243, 199), Color.FromArgb(253, 230, 138), Color.FromArgb(146, 64, 14));
            // Tiền mặt / Thành công / mặc định → xanh lá
            return (Color.FromArgb(220, 252, 231), Color.FromArgb(187, 247, 208), Color.FromArgb(21, 128, 61));
        }

        private void DgvRecentTx_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender is not DataGridView dgv) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var style = e.CellStyle;
            if (style == null) return;
            var name = dgv.Columns[e.ColumnIndex].Name;
            if (name == "colTxAmount")
            {
                var isOutflow = ReferenceEquals(dgv, dgvStaffPayouts);
                var color = isOutflow
                    ? Color.FromArgb(220, 38, 38)
                    : Color.FromArgb(22, 163, 74);
                style.ForeColor = color;
                style.SelectionForeColor = color;
                style.Font = new Font(dgv.Font, FontStyle.Bold);
            }
        }

        private void DgvTx_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (sender is not DataGridView dgv) return;
            DgvTx_CellPaintingStatic(dgv, e);
        }

        private static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            var d = Math.Min(radius * 2, Math.Min(r.Width, r.Height));
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void LoadRecentTransactionsGrid()
        {
            dgvRecentTx.Rows.Clear();
            foreach (var t in _dashboard.GetRecentTransactions(10))
            {
                dgvRecentTx.Rows.Add(
                    t.UserName,
                    $"+ {t.Amount:N0} VNĐ",
                    string.IsNullOrWhiteSpace(t.Method) ? t.StatusLabel : t.Method,
                    t.OccurredAt.ToString("dd/MM/yyyy HH:mm", Vi));
            }
        }

        private void LoadRemindersGrid()
        {
            dgvReminders.Rows.Clear();

            foreach (var r in _dashboard.GetFrontDeskReminders(5))
            {
                var idx = ReminderImageIndex(r.Category);
                var src = _imgReminders?.Images[idx] ?? SystemIcons.Warning.ToBitmap();
                var img = (Image)src.Clone();

                var rowIdx = dgvReminders.Rows.Add(img, r.Category, r.Message,
                    r.At.HasValue ? r.At.Value.ToString("dd/MM/yyyy HH:mm", Vi) : "—");
                var row = dgvReminders.Rows[rowIdx];
                row.Tag = ReminderStableKey(r);
                PaintReminderRow(row);
            }

            ApplyReminderGridHover();
        }

        private static string ReminderStableKey(DashboardReminderItem r)
        {
            if (!string.IsNullOrWhiteSpace(r.DedupeKey))
                return r.DedupeKey.Trim();
            var ticks = r.At?.Ticks ?? 0;
            var h = StableStringHash(r.Category + "\u001f" + r.Message);
            return $"legacy:{ticks}:{h:X8}";
        }

        private static int StableStringHash(string s)
        {
            unchecked
            {
                var h = (int)2166136261;
                foreach (var c in s)
                    h = (h * 16777619) ^ c;
                return h;
            }
        }

        private void LoadReminderSeenKeys()
        {
            _seenReminderKeys.Clear();
            try
            {
                if (!File.Exists(ReminderSeenKeysPath)) return;
                foreach (var line in File.ReadAllLines(ReminderSeenKeysPath))
                {
                    var t = line.Trim();
                    if (t.Length > 0)
                        _seenReminderKeys.Add(t);
                }
            }
            catch
            {
                /* bỏ qua — không chặn dashboard */
            }
        }

        private void SaveReminderSeenKeys()
        {
            try
            {
                var dir = Path.GetDirectoryName(ReminderSeenKeysPath);
                if (!string.IsNullOrEmpty(dir))
                    Directory.CreateDirectory(dir);
                File.WriteAllLines(ReminderSeenKeysPath,
                    _seenReminderKeys.OrderBy(k => k, StringComparer.Ordinal));
            }
            catch
            {
                /* ignore */
            }
        }

        private Color ReminderRowBaseBackColor(DataGridViewRow row)
        {
            if (row.Tag is string key
                && key.Length > 0
                && !_seenReminderKeys.Contains(key))
                return ReminderHighlightBg;
            return GridRowBg;
        }

        private void PaintReminderRow(DataGridViewRow row)
        {
            var bg = ReminderRowBaseBackColor(row);
            row.DefaultCellStyle.BackColor = bg;
            row.DefaultCellStyle.SelectionBackColor = GridSelectBg;
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style.BackColor = bg;
                cell.Style.SelectionBackColor = GridSelectBg;
            }
        }

        private void ApplyReminderGridHover()
        {
            var dgv = dgvReminders;
            if (dgv.IsDisposed || !dgv.IsHandleCreated) return;
            for (var i = 0; i < dgv.Rows.Count; i++)
            {
                var row = dgv.Rows[i];
                var baseBg = ReminderRowBaseBackColor(row);
                var bg = i == _hoverRowReminders ? GridRowHover : baseBg;
                row.DefaultCellStyle.BackColor = bg;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = bg;
                    cell.Style.SelectionBackColor = GridSelectBg;
                }
            }
        }

        private void WireReminderGridHover()
        {
            var dgv = dgvReminders;
            dgv.MouseMove += (_, ev) =>
            {
                var hit = dgv.HitTest(ev.X, ev.Y);
                var r = hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0 ? hit.RowIndex : -1;
                if (r == _hoverRowReminders) return;
                _hoverRowReminders = r;
                ApplyReminderGridHover();
            };
            dgv.CellMouseEnter += (_, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex == _hoverRowReminders) return;
                _hoverRowReminders = e.RowIndex;
                ApplyReminderGridHover();
            };
            dgv.MouseLeave += (_, _) =>
            {
                _hoverRowReminders = -1;
                ApplyReminderGridHover();
            };
        }

        private void MarkReminderRowSeen(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvReminders.Rows.Count) return;
            var row = dgvReminders.Rows[rowIndex];
            if (row.Tag is not string key || key.Length == 0) return;
            if (!_seenReminderKeys.Add(key)) return;
            SaveReminderSeenKeys();
            ApplyReminderGridHover();
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
            picPendingHdr.Image = Mdl2Icons.Create(menuGlyph, ink, box: 28, glyphScale: 0.56f);
            picRemindersHdr.Image = Mdl2Icons.Create(menuGlyph, ink, box: 28, glyphScale: 0.56f);
            picRecentTxHdr.Image = Mdl2Icons.Create(listGlyph, ink, box: 28, glyphScale: 0.52f);
            picQuickHdr.Image = Mdl2Icons.Create(lightningGlyph, ink, box: 28, glyphScale: 0.52f);
            picMyTasksHdr.Image = Mdl2Icons.Create(cashGlyph, ink, box: 28, glyphScale: 0.52f);
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
            _imgPending.Images.Add(Mdl2Icons.Create('\uE787', Color.FromArgb(30, 95, 200)));
            _imgPending.Images.Add(Mdl2Icons.Create('\uE8D4', Color.FromArgb(5, 150, 105)));

            _imgReminders?.Dispose();
            _imgReminders = new ImageList
            {
                ImageSize = new Size(22, 22),
                ColorDepth = ColorDepth.Depth32Bit
            };
            _imgReminders.Images.Add(Mdl2Icons.Create('\uE74C', Color.FromArgb(220, 38, 38)));
            _imgReminders.Images.Add(Mdl2Icons.Create('\uE8A5', Color.FromArgb(234, 88, 12)));
            _imgReminders.Images.Add(Mdl2Icons.Create('\uE8A7', Color.FromArgb(124, 58, 237)));

            StyleTransactionGrid(dgvPending);
            StyleTransactionGrid(dgvReminders);
            StyleTransactionGrid(dgvRecentTx);
            StyleTransactionGrid(dgvStaffPayouts);
            dgvStaffPayouts.RowTemplate.Height = 36;
            dgvStaffPayouts.ColumnHeadersHeight = 38;

            BuildPendingColumns();
            BuildReminderColumns();
            BuildRecentTxColumns();
            BuildStaffPayoutColumns();

            dgvPending.ShowCellToolTips = true;
            dgvReminders.ShowCellToolTips = true;
        }

        private void BuildStaffPayoutColumns()
        {
            dgvStaffPayouts.Columns.Clear();
            dgvStaffPayouts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTxUser", HeaderText = "Tiêu đề" });
            dgvStaffPayouts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTxAmount", HeaderText = "Số tiền" });
            dgvStaffPayouts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTxStatus", HeaderText = "Trạng thái" });
            dgvStaffPayouts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTxTime", HeaderText = "Thời gian" });
            dgvStaffPayouts.Columns[0].MinimumWidth = 90;
            dgvStaffPayouts.Columns[0].FillWeight = 25;
            dgvStaffPayouts.Columns[1].MinimumWidth = 90;
            dgvStaffPayouts.Columns[1].FillWeight = 25;
            dgvStaffPayouts.Columns[2].MinimumWidth = 80;
            dgvStaffPayouts.Columns[2].FillWeight = 20;
            dgvStaffPayouts.Columns[3].MinimumWidth = 110;
            dgvStaffPayouts.Columns[3].FillWeight = 30;
            dgvStaffPayouts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BuildRecentTxColumns()
        {
            dgvRecentTx.Columns.Clear();
            dgvRecentTx.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTxUser", HeaderText = "Tiêu đề" });
            dgvRecentTx.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTxAmount", HeaderText = "Số tiền" });
            dgvRecentTx.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTxStatus", HeaderText = "Phương thức" });
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
            dgvPending.Columns[1].FillWeight = 38;
            dgvPending.Columns[2].MinimumWidth = 100;
            dgvPending.Columns[2].FillWeight = 18;
            dgvPending.Columns[3].MinimumWidth = 130;
            dgvPending.Columns[3].FillWeight = 18;
            dgvPending.Columns[4].MinimumWidth = 140;
            dgvPending.Columns[4].FillWeight = 22;
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
            dgv.ScrollBars = ScrollBars.Vertical;
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

    }
}
