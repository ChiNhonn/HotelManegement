using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Forms;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

namespace HotelManagement.CustomControls;

/// <summary>
/// Khối « Vận hành » — đơn/yêu cầu dịch vụ (tabs + badge + lưới + thao tác + QR).
/// </summary>
public sealed class OperationFulfillmentPanel : UserControl
{
    private static readonly CultureInfo Vi = new("vi-VN");

    private readonly IServiceModuleService _svc;

    private readonly Label _lblSubtitle = new();
    private readonly FlowLayoutPanel _pnlTabs = new();
    private readonly TextBox _txtSearch = new();
    private readonly DateTimePicker _dtpFrom = new();
    private readonly DateTimePicker _dtpTo = new();
    private readonly Button _btnApplyFilter = new();
    private readonly CheckBox _chkUiDemo = new();
    private readonly DataGridView _dgv = new();

    private readonly List<TabChip> _tabChips = new();
    private int _tabIndex;

    private readonly Dictionary<int, List<ActionHitZone>> _hitZones = new();

    private enum OpsBucket { PendingAck, Processing, AwaitingPayment, Done, Cancelled }

    private sealed class OpsVm
    {
        public int Id { get; init; }
        public OpsBucket Bucket { get; init; }
        public string TimeCode { get; init; } = "";
        public string Room { get; init; } = "";
        public string Items { get; init; } = "";
        public decimal Total { get; init; }
        public string PayDisplay { get; init; } = "";
        public bool ImmediatePay { get; init; }
        public bool AwaitingImmediatePayment { get; init; }
        public string StatusRaw { get; init; } = "";
        public string StatusLabel { get; init; } = "";
        public StatusPillKind PillKind { get; init; }
    }

    private enum StatusPillKind { PendingYellow, ProcessingBlue, PaymentOrange, DoneGreen, CancelledRose }

    private sealed class TabChip
    {
        public OpsBucket Bucket { get; init; }
        public Button ChipButton { get; init; } = null!;
        public Label Badge { get; init; } = null!;
    }

    private sealed class ActionHitZone
    {
        public Rectangle Rect { get; init; }
        public Action Action { get; init; } = null!;
    }

    public OperationFulfillmentPanel(IServiceModuleService svc)
    {
        _svc = svc ?? throw new ArgumentNullException(nameof(svc));
        Dock = DockStyle.Fill;
        BackColor = Color.FromArgb(241, 245, 249);

        BuildUi();
        WireEvents();
        SelectTab(0);
        Reload();
    }

    private void BuildUi()
    {
        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2,
            Padding = new Padding(0),
            Margin = new Padding(0),
            BackColor = Color.FromArgb(241, 245, 249)
        };
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 124f));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

        _lblSubtitle.Dock = DockStyle.Fill;
        _lblSubtitle.Margin = new Padding(0, 0, 0, 4);
        _lblSubtitle.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
        _lblSubtitle.ForeColor = Color.FromArgb(51, 65, 85);
        _lblSubtitle.Text = "Vận hành & Xử lý yêu cầu";
        _lblSubtitle.TextAlign = ContentAlignment.MiddleLeft;
        _lblSubtitle.AutoSize = false;

        _pnlTabs.Dock = DockStyle.Fill;
        _pnlTabs.Margin = new Padding(0);
        _pnlTabs.WrapContents = false;
        _pnlTabs.FlowDirection = FlowDirection.LeftToRight;
        _pnlTabs.Padding = new Padding(0, 2, 0, 4);
        _pnlTabs.BackColor = Color.FromArgb(241, 245, 249);

        AddTabChip("Chờ xác nhận", OpsBucket.PendingAck);
        AddTabChip("Đang xử lý", OpsBucket.Processing);
        AddTabChip("Chờ thanh toán", OpsBucket.AwaitingPayment);
        AddTabChip("Hoàn thành", OpsBucket.Done);
        AddTabChip("Đã hủy", OpsBucket.Cancelled);

        var tbl = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 7,
            RowCount = 1,
            Padding = new Padding(0, 4, 0, 6),
            Margin = new Padding(0),
            BackColor = Color.FromArgb(241, 245, 249)
        };
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52f));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 132f));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38f));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 132f));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112f));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118f));

        var lblFrom = new Label { Text = "Từ", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9f), ForeColor = Color.FromArgb(71, 85, 105) };
        var lblTo = new Label { Text = "Đến", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9f), ForeColor = Color.FromArgb(71, 85, 105) };

        _dtpFrom.Format = DateTimePickerFormat.Short;
        _dtpTo.Format = DateTimePickerFormat.Short;
        _dtpFrom.Value = DateTime.Today.AddDays(-7);
        _dtpTo.Value = DateTime.Today;

        _txtSearch.Dock = DockStyle.Fill;
        _txtSearch.Margin = new Padding(12, 6, 12, 6);
        _txtSearch.Font = new Font("Segoe UI", 9.5f);
        _txtSearch.PlaceholderText = "Tìm #DV hoặc số phòng…";

        _btnApplyFilter.Text = "Lọc";
        _btnApplyFilter.Dock = DockStyle.Fill;
        _btnApplyFilter.Margin = new Padding(6, 6, 0, 6);
        _btnApplyFilter.FlatStyle = FlatStyle.Flat;
        _btnApplyFilter.Cursor = Cursors.Hand;
        _btnApplyFilter.BackColor = Color.White;
        _btnApplyFilter.ForeColor = Color.FromArgb(59, 130, 246);
        _btnApplyFilter.FlatAppearance.BorderColor = Color.FromArgb(191, 219, 254);

        _chkUiDemo.Text = "Demo UI";
        _chkUiDemo.Dock = DockStyle.Fill;
        _chkUiDemo.Margin = new Padding(8, 10, 0, 6);
        _chkUiDemo.AutoSize = true;
        _chkUiDemo.Font = new Font("Segoe UI", 9f);

        tbl.Controls.Add(lblFrom, 0, 0);
        tbl.Controls.Add(_dtpFrom, 1, 0);
        tbl.Controls.Add(lblTo, 2, 0);
        tbl.Controls.Add(_dtpTo, 3, 0);
        tbl.Controls.Add(_txtSearch, 4, 0);
        tbl.Controls.Add(_btnApplyFilter, 5, 0);
        tbl.Controls.Add(_chkUiDemo, 6, 0);

        var chromeTbl = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Margin = new Padding(0),
            Padding = new Padding(0),
            BackColor = Color.FromArgb(241, 245, 249)
        };
        chromeTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
        chromeTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 42f));
        chromeTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 52f));
        chromeTbl.Controls.Add(_lblSubtitle, 0, 0);
        chromeTbl.Controls.Add(_pnlTabs, 0, 1);
        chromeTbl.Controls.Add(tbl, 0, 2);

        StyleOpsGrid(_dgv);
        _dgv.Dock = DockStyle.Fill;
        _dgv.Margin = new Padding(0);
        BuildColumns(_dgv);

        root.Controls.Add(chromeTbl, 0, 0);
        root.Controls.Add(_dgv, 0, 1);

        Controls.Add(root);
    }

    private void AddTabChip(string label, OpsBucket bucket)
    {
        var wrap = new FlowLayoutPanel
        {
            AutoSize = true,
            WrapContents = false,
            FlowDirection = FlowDirection.LeftToRight,
            Margin = new Padding(0, 0, 16, 0),
            Padding = new Padding(0),
            BackColor = Color.FromArgb(241, 245, 249)
        };

        var btn = new Button
        {
            Text = label,
            AutoSize = true,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            Font = new Font("Segoe UI", 10f),
            Margin = new Padding(0, 4, 6, 4),
            Padding = new Padding(10, 4, 10, 4),
            BackColor = Color.White,
            ForeColor = Color.FromArgb(71, 85, 105),
            FlatAppearance = { BorderColor = Color.FromArgb(229, 231, 235), BorderSize = 1 }
        };

        var badge = new Label
        {
            AutoSize = false,
            MinimumSize = new Size(22, 22),
            Height = 22,
            Width = 22,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
            ForeColor = Color.White,
            BackColor = Color.FromArgb(239, 68, 68),
            Margin = new Padding(0, 8, 0, 0),
            Visible = false,
            Padding = new Padding(2)
        };

        wrap.Controls.Add(btn);
        wrap.Controls.Add(badge);
        _pnlTabs.Controls.Add(wrap);

        var chip = new TabChip { Bucket = bucket, ChipButton = btn, Badge = badge };
        _tabChips.Add(chip);
        btn.Click += (_, _) =>
        {
            SelectTab(_tabChips.IndexOf(chip));
            Reload();
        };
    }

    private void WireEvents()
    {
        _btnApplyFilter.Click += (_, _) => Reload();
        _chkUiDemo.CheckedChanged += (_, _) => Reload();

        _dgv.CellPainting += Dgv_CellPainting;
        _dgv.CellFormatting += Dgv_CellFormatting;
        _dgv.CellMouseDown += Dgv_CellMouseDown;
        _dgv.CellMouseMove += Dgv_CellMouseMove;
        _dgv.Scroll += (_, _) => _hitZones.Clear();
        _dgv.ColumnWidthChanged += (_, _) => _hitZones.Clear();
        _dgv.SizeChanged += (_, _) => _hitZones.Clear();
    }

    private static void StyleOpsGrid(DataGridView dgv)
    {
        dgv.BackgroundColor = Color.White;
        dgv.BorderStyle = BorderStyle.None;
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
        dgv.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
        dgv.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
        dgv.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
        dgv.AdvancedColumnHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;
        dgv.GridColor = Color.FromArgb(229, 231, 235);
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.AllowUserToResizeRows = false;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.EnableHeadersVisualStyles = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.ColumnHeadersHeight = 36;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
        dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
        dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 249, 250);
        dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
        dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
        dgv.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
        dgv.DefaultCellStyle.Padding = new Padding(8, 6, 8, 6);
        dgv.RowTemplate.Height = 44;
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
    }

    private static void BuildColumns(DataGridView dgv)
    {
        dgv.Columns.Clear();
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "Id", Visible = false });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTime", HeaderText = "Thời gian & Mã đơn", FillWeight = 22 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRoom", HeaderText = "Phòng / Bàn", FillWeight = 12 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colItems", HeaderText = "Nội dung order", FillWeight = 28 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTotal", HeaderText = "Tổng tiền", FillWeight = 12 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPay", HeaderText = "Thanh toán", FillWeight = 14 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Trạng thái", FillWeight = 14 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colActions", HeaderText = "Thao tác", FillWeight = 22 });
        dgv.Columns["colActions"].MinimumWidth = 240;
    }

    private void SelectTab(int idx)
    {
        idx = Math.Clamp(idx, 0, _tabChips.Count - 1);
        _tabIndex = idx;

        for (var i = 0; i < _tabChips.Count; i++)
        {
            var c = _tabChips[i];
            var sel = i == idx;
            c.ChipButton.Font = new Font("Segoe UI", 10f, sel ? FontStyle.Bold : FontStyle.Regular);
            c.ChipButton.ForeColor = sel ? Color.FromArgb(15, 23, 42) : Color.FromArgb(71, 85, 105);
            c.ChipButton.BackColor = sel ? Color.FromArgb(239, 246, 255) : Color.White;
            c.ChipButton.FlatAppearance.BorderColor = sel ? Color.FromArgb(59, 130, 246) : Color.FromArgb(229, 231, 235);
        }
    }

    public void Reload()
    {
        _hitZones.Clear();
        _dgv.Rows.Clear();

        List<OpsVm> rows = _chkUiDemo.Checked ? BuildMockRows() : LoadFromDb();

        UpdateBadges(rows);

        var bucket = _tabChips[_tabIndex].Bucket;
        foreach (var vm in rows.Where(r => r.Bucket == bucket))
        {
            var i = _dgv.Rows.Add(
                vm.Id,
                vm.TimeCode,
                vm.Room,
                vm.Items,
                vm.Total.ToString("N0", Vi) + " đ",
                vm.PayDisplay,
                vm.StatusLabel,
                "");
            _dgv.Rows[i].Tag = vm;
        }

        Invalidate(true);
    }

    private void UpdateBadges(List<OpsVm> rows)
    {
        foreach (var chip in _tabChips)
        {
            var n = rows.Count(r => r.Bucket == chip.Bucket);
            chip.Badge.Visible = n > 0;
            chip.Badge.Text = n > 99 ? "99+" : n.ToString(Vi);

            chip.Badge.BackColor = chip.Bucket switch
            {
                OpsBucket.PendingAck => Color.FromArgb(239, 68, 68),
                OpsBucket.AwaitingPayment => Color.FromArgb(249, 115, 22),
                OpsBucket.Processing => Color.FromArgb(59, 130, 246),
                OpsBucket.Done => Color.FromArgb(148, 163, 184),
                OpsBucket.Cancelled => Color.FromArgb(248, 113, 113),
                _ => Color.FromArgb(148, 163, 184)
            };

            chip.Badge.ForeColor = Color.White;

            chip.Badge.Padding = n > 9 ? new Padding(5, 2, 5, 2) : new Padding(4, 2, 4, 2);
            chip.Badge.AutoSize = false;
            chip.Badge.Height = 22;
            var tw = TextRenderer.MeasureText(chip.Badge.Text, chip.Badge.Font).Width + chip.Badge.Padding.Horizontal;
            chip.Badge.Width = Math.Max(22, tw);
        }
    }

    /// <summary>Dòng đang chọn — phục vụ nút « Hủy » legacy / menu.</summary>
    public int? TryGetSelectedServiceOrderId() =>
        _dgv.CurrentRow?.Tag is OpsVm vm ? vm.Id : null;

    public string? TryGetSelectedLineSummary() =>
        _dgv.CurrentRow?.Tag is OpsVm vm ? vm.Items.Replace(Environment.NewLine, " ").Trim() : null;

    private List<OpsVm> LoadFromDb()
    {
        var awaitingPayIds = _svc.GetOrdersAwaitingPayment().Select(o => o.Id).ToHashSet();

        var from = _dtpFrom.Value.Date;
        var toEnd = _dtpTo.Value.Date.AddDays(1).AddTicks(-1);

        var searchRaw = _txtSearch.Text.Trim();
        var raw = _svc.GetServiceOrders(null, null, null)
            .Where(o => o.CreateAt >= from && o.CreateAt <= toEnd)
            .Where(o => MatchesSearch(o, searchRaw))
            .OrderByDescending(o => o.CreateAt)
            .ToList();

        return raw.Select(o => MapVm(o, awaitingPayIds.Contains(o.Id))).ToList();
    }

    private static bool MatchesSearch(ServiceOrderRow o, string k)
    {
        if (string.IsNullOrWhiteSpace(k)) return true;
        if (o.RoomName.Contains(k, StringComparison.OrdinalIgnoreCase)) return true;
        if (o.ItemName.Contains(k, StringComparison.OrdinalIgnoreCase)) return true;

        if (k.StartsWith("#DV", StringComparison.OrdinalIgnoreCase))
        {
            var tail = k[3..].Trim();
            return int.TryParse(tail, out var pid) && pid == o.Id;
        }

        if (int.TryParse(k.TrimStart('#'), out var bare) && bare == o.Id)
            return true;

        return false;
    }

    private static OpsVm MapVm(ServiceOrderRow o, bool awaitingImmediatePay)
    {
        var bucket = ClassifyBucket(o, awaitingImmediatePay);
        var pill = bucket switch
        {
            OpsBucket.PendingAck => StatusPillKind.PendingYellow,
            OpsBucket.Processing => StatusPillKind.ProcessingBlue,
            OpsBucket.AwaitingPayment => StatusPillKind.PaymentOrange,
            OpsBucket.Done => StatusPillKind.DoneGreen,
            OpsBucket.Cancelled => StatusPillKind.CancelledRose,
            _ => StatusPillKind.DoneGreen
        };

        var statusLabel = bucket switch
        {
            OpsBucket.PendingAck => "Chờ xác nhận",
            OpsBucket.Processing => "Đang xử lý",
            OpsBucket.AwaitingPayment => "Chờ thanh toán",
            OpsBucket.Done => "Hoàn thành",
            OpsBucket.Cancelled => "Đã hủy",
            _ => ServiceOrderStatus.ToDisplay(o.Status)
        };

        var payDisp = o.ChargeMode == ServiceChargeMode.Immediate
            ? "⚡ Ngay — QR / Tiền mặt"
            : "📋 Gộp hóa đơn phòng";

        var items = $"• {o.ItemName} × {o.Quantity}";
        if (bucket == OpsBucket.Cancelled && !string.IsNullOrWhiteSpace(o.CancelReason))
            items += $"{Environment.NewLine}• Lý do: {o.CancelReason.Trim()}";

        var code = $"{o.CreateAt:HH:mm dd/MM/yyyy} — #DV{o.Id}";

        return new OpsVm
        {
            Id = o.Id,
            Bucket = bucket,
            TimeCode = code,
            Room = o.RoomName,
            Items = items,
            Total = o.LineTotal,
            PayDisplay = payDisp,
            ImmediatePay = o.ChargeMode == ServiceChargeMode.Immediate,
            AwaitingImmediatePayment = awaitingImmediatePay,
            StatusRaw = o.Status,
            StatusLabel = statusLabel,
            PillKind = pill
        };
    }

    private static OpsBucket ClassifyBucket(ServiceOrderRow o, bool awaitingImmediatePay)
    {
        if (o.Status == ServiceOrderStatus.Cancelled)
            return OpsBucket.Cancelled;

        if (o.Status == ServiceOrderStatus.Pending)
            return OpsBucket.PendingAck;
        if (o.Status == ServiceOrderStatus.InProgress)
            return OpsBucket.Processing;
        if (o.Status == ServiceOrderStatus.Completed)
        {
            if (o.ChargeMode == ServiceChargeMode.Immediate && awaitingImmediatePay)
                return OpsBucket.AwaitingPayment;
            return OpsBucket.Done;
        }

        return OpsBucket.Done;
    }

    /// <summary>Mock UI — giả lập danh sách để test giao diện (không gọi DB).</summary>
    private List<OpsVm> BuildMockRows()
    {
        var now = DateTime.Now;
        return new List<OpsVm>
        {
            new()
            {
                Id = 9001,
                Bucket = OpsBucket.PendingAck,
                TimeCode = $"{now.AddMinutes(-12):HH:mm dd/MM/yyyy} — #DV9001",
                Room = "103",
                Items = "• Bún Bò Huế ×2\n• Trà đá ×2",
                Total = 156000,
                PayDisplay = "💳 Chuyển khoản QR",
                ImmediatePay = true,
                AwaitingImmediatePayment = false,
                StatusRaw = ServiceOrderStatus.Pending,
                StatusLabel = "Chờ xác nhận",
                PillKind = StatusPillKind.PendingYellow
            },
            new()
            {
                Id = 9002,
                Bucket = OpsBucket.Processing,
                TimeCode = $"{now.AddMinutes(-30):HH:mm dd/MM/yyyy} — #DV9002",
                Room = "308",
                Items = "• Gà 45kg ×1",
                Total = 690000,
                PayDisplay = "💵 Tiền mặt (gộp HĐ)",
                ImmediatePay = false,
                AwaitingImmediatePayment = false,
                StatusRaw = ServiceOrderStatus.InProgress,
                StatusLabel = "Đang xử lý",
                PillKind = StatusPillKind.ProcessingBlue
            },
            new()
            {
                Id = 9003,
                Bucket = OpsBucket.AwaitingPayment,
                TimeCode = $"{now.AddHours(-1):HH:mm dd/MM/yyyy} — #DV9003",
                Room = "201",
                Items = "• Massage ×1",
                Total = 450000,
                PayDisplay = "💳 Chuyển khoản QR",
                ImmediatePay = true,
                AwaitingImmediatePayment = true,
                StatusRaw = ServiceOrderStatus.Completed,
                StatusLabel = "Chờ thanh toán",
                PillKind = StatusPillKind.PaymentOrange
            },
            new()
            {
                Id = 9004,
                Bucket = OpsBucket.Done,
                TimeCode = $"{now.AddHours(-3):HH:mm dd/MM/yyyy} — #DV9004",
                Room = "105",
                Items = "• Buffet sáng ×2",
                Total = 300000,
                PayDisplay = "💵 Tiền mặt",
                ImmediatePay = true,
                AwaitingImmediatePayment = false,
                StatusRaw = ServiceOrderStatus.Completed,
                StatusLabel = "Hoàn thành",
                PillKind = StatusPillKind.DoneGreen
            },
            new()
            {
                Id = 9005,
                Bucket = OpsBucket.Cancelled,
                TimeCode = $"{now.AddHours(-5):HH:mm dd/MM/yyyy} — #DV9005",
                Room = "412",
                Items = "• Nước suối ×3\n• Lý do: Khách đổi ý",
                Total = 45000,
                PayDisplay = "📋 Gộp hóa đơn phòng",
                ImmediatePay = false,
                AwaitingImmediatePayment = false,
                StatusRaw = ServiceOrderStatus.Cancelled,
                StatusLabel = "Đã hủy",
                PillKind = StatusPillKind.CancelledRose
            },
        };
    }

    private void Dgv_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (_dgv.Columns[e.ColumnIndex].Name == "colRoom")
            e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

        if (_dgv.Columns[e.ColumnIndex].Name == "colItems")
            e.CellStyle.WrapMode = DataGridViewTriState.True;
    }

    private void Dgv_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var vm = _dgv.Rows[e.RowIndex].Tag as OpsVm;
        if (vm == null) return;

        if (_dgv.Columns[e.ColumnIndex].Name == "colStatus")
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            var (bg, fg) = vm.PillKind switch
            {
                StatusPillKind.PendingYellow => (Color.FromArgb(254, 249, 195), Color.FromArgb(133, 77, 14)),
                StatusPillKind.ProcessingBlue => (Color.FromArgb(219, 234, 254), Color.FromArgb(29, 78, 216)),
                StatusPillKind.PaymentOrange => (Color.FromArgb(255, 237, 213), Color.FromArgb(194, 65, 12)),
                StatusPillKind.DoneGreen => (Color.FromArgb(220, 252, 231), Color.FromArgb(22, 101, 52)),
                StatusPillKind.CancelledRose => (Color.FromArgb(254, 226, 226), Color.FromArgb(153, 27, 27)),
                _ => (Color.FromArgb(243, 244, 246), Color.FromArgb(55, 65, 81))
            };

            var sz = TextRenderer.MeasureText(vm.StatusLabel, e.CellStyle.Font);
            var inner = new Rectangle(
                e.CellBounds.X + 10,
                e.CellBounds.Y + (e.CellBounds.Height - 24) / 2,
                Math.Min(e.CellBounds.Width - 20, sz.Width + 20),
                24);

            using var path = CreateRoundRect(inner, 12);
            using var b = new SolidBrush(bg);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(b, path);
            TextRenderer.DrawText(e.Graphics, vm.StatusLabel, e.CellStyle.Font, inner, fg,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            e.Handled = true;
            return;
        }

        if (_dgv.Columns[e.ColumnIndex].Name != "colActions")
            return;

        e.PaintBackground(e.CellBounds, true);

        var zones = new List<ActionHitZone>();
        // Hit-test (CellMouse*) dùng tọa độ tương đối ô — rect / Push luôn theo hệ gốc trên-trái của ô.
        var rect = new Rectangle(8, 8, Math.Max(4, e.CellBounds.Width - 16), Math.Max(4, e.CellBounds.Height - 16));

        Rectangle ToAbs(Rectangle rel) =>
            new(e.CellBounds.X + rel.X, e.CellBounds.Y + rel.Y, rel.Width, rel.Height);

        void Outline(Rectangle rel, string text, Color border, Color tx)
        {
            var abs = ToAbs(rel);
            using var path = CreateRoundRect(abs, 4);
            using var pen = new Pen(border);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillRectangle(Brushes.White, abs);
            e.Graphics.DrawPath(pen, path);
            TextRenderer.DrawText(e.Graphics, text, new Font("Segoe UI", 8.5f), abs, tx,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        void Fill(Rectangle rel, string text, Color bg, Color fg)
        {
            var abs = ToAbs(rel);
            using var path = CreateRoundRect(abs, 4);
            using var br = new SolidBrush(bg);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(br, path);
            TextRenderer.DrawText(e.Graphics, text, new Font("Segoe UI", 8.5f, FontStyle.Bold), abs, fg,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        void Push(Rectangle rel, Action cb) => zones.Add(new ActionHitZone { Rect = rel, Action = cb });

        var x = rect.Left;
        const int gap = 6;
        var h = rect.Height;

        if (_chkUiDemo.Checked)
        {
            var rA = new Rectangle(x, rect.Top, 112, h);
            Fill(rA, "Demo ▶", Color.FromArgb(59, 130, 246), Color.White);
            Push(rA, () => MessageBox.Show(FindForm(),
                "Đây là chế độ Demo UI — tick « Demo UI » để không đụng DB.",
                "Demo", MessageBoxButtons.OK, MessageBoxIcon.Information));
            _hitZones[e.RowIndex] = zones;
            e.Handled = true;
            return;
        }

        if (vm.Bucket == OpsBucket.PendingAck)
        {
            var r1 = new Rectangle(x, rect.Top, 138, h);
            Fill(r1, "Xác nhận làm món", Color.FromArgb(59, 130, 246), Color.White);
            Push(r1, () =>
            {
                if (!ConfirmAcceptOrder(vm)) return;
                ExecSafe(() => _svc.UpdateServiceOrderStatus(vm.Id, ServiceOrderStatus.InProgress, null));
            });
            x = r1.Right + gap;

            var r2 = new Rectangle(x, rect.Top, 82, h);
            Outline(r2, "Từ chối", Color.FromArgb(252, 165, 165), Color.FromArgb(185, 28, 28));
            Push(r2, () =>
            {
                var summary = $"{vm.Room} · {vm.Items.Replace(Environment.NewLine, " · ")}";
                using var dlg = new ServiceCancelForm(summary);
                if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
                ExecSafe(() => _svc.CancelServiceOrder(vm.Id,
                    string.IsNullOrWhiteSpace(dlg.Reason) ? "Từ chối tiếp nhận" : dlg.Reason,
                    dlg.CancellationFee,
                    null));
            });
        }
        else if (vm.Bucket == OpsBucket.Processing)
        {
            var r1 = new Rectangle(x, rect.Top, 126, h);
            Fill(r1, "Báo hoàn thành", Color.FromArgb(34, 197, 94), Color.White);
            Push(r1, () =>
            {
                if (!ConfirmCompleteOrder(vm)) return;
                ExecSafe(() => _svc.UpdateServiceOrderStatus(vm.Id, ServiceOrderStatus.Completed, null));
            });
        }
        else if (vm.Bucket == OpsBucket.AwaitingPayment && vm.ImmediatePay)
        {
            var rQr = new Rectangle(x, rect.Top, 102, h);
            Outline(rQr, "Xem QR Bank", Color.FromArgb(129, 140, 248), Color.FromArgb(67, 56, 202));
            Push(rQr, () =>
            {
                using var dlg = new QrBankDialog(vm.Total, $"Đơn #DV{vm.Id} · Phòng {vm.Room}");
                dlg.ShowDialog(FindForm());
            });
            x = rQr.Right + gap;

            var rCk = new Rectangle(x, rect.Top, 152, h);
            Fill(rCk, "Xác nhận đã nhận CK", Color.FromArgb(59, 130, 246), Color.White);
            Push(rCk, () =>
            {
                if (!ConfirmImmediatePaid(vm, "Chuyển khoản")) return;
                ExecSafe(() => _svc.PostImmediatePayment(vm.Id, "Chuyển khoản", null));
            });
            x = rCk.Right + gap;

            var rCash = new Rectangle(x, rect.Top, 118, h);
            Outline(rCash, "Đã thu tiền mặt", Color.FromArgb(191, 219, 254), Color.FromArgb(29, 78, 216));
            Push(rCash, () =>
            {
                if (!ConfirmImmediatePaid(vm, "Tiền mặt")) return;
                ExecSafe(() => _svc.PostImmediatePayment(vm.Id, "Tiền mặt", null));
            });
        }
        else if (vm.Bucket == OpsBucket.Done || vm.Bucket == OpsBucket.Cancelled)
        {
            var dashAbs = ToAbs(rect);
            TextRenderer.DrawText(e.Graphics, "—", new Font("Segoe UI", 9f), dashAbs, Color.FromArgb(148, 163, 184),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        _hitZones[e.RowIndex] = zones;
        e.Handled = true;
    }

    /// <summary>Xác nhận tiếp nhận đơn — sau đó khi hoàn thành mới ghi / chờ thanh toán theo luồng.</summary>
    private bool ConfirmAcceptOrder(OpsVm vm)
    {
        var folioNote = !vm.ImmediatePay
            ? "Khi báo hoàn thành, phí sẽ được ghi vào hóa đơn phòng (gộp bill)."
            : "Khi báo hoàn thành, hệ thống sẽ tạo hóa đơn và chuyển sang bước chờ thanh toán ngay.";

        var msg =
            $"Xác nhận tiếp nhận đơn #DV{vm.Id} · Phòng {vm.Room}?\n\n" +
            "Đơn sẽ chuyển sang « Đang xử lý ».\n\n" +
            folioNote;

        return MessageBox.Show(FindForm(), msg, "Xác nhận đơn / hóa đơn",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    private bool ConfirmCompleteOrder(OpsVm vm)
    {
        var detail = !vm.ImmediatePay
            ? "Phí dịch vụ sẽ được ghi vào hóa đơn phòng của khách."
            : "Hệ thống sẽ ghi chi tiết lên hóa đơn và chờ thu tiền ngay (QR / tiền mặt).";

        var msg = $"Hoàn thành đơn #DV{vm.Id} · Phòng {vm.Room}?\n\n{detail}";
        return MessageBox.Show(FindForm(), msg, "Báo hoàn thành",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    private bool ConfirmImmediatePaid(OpsVm vm, string methodVi)
    {
        var msg =
            $"Xác nhận đã thu [{methodVi}] cho đơn #DV{vm.Id}?\n\n" +
            $"Số tiền: {vm.Total:N0} đ · Phòng {vm.Room}";
        return MessageBox.Show(FindForm(), msg, "Xác nhận thanh toán",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    private void ExecSafe(Action a)
    {
        try
        {
            a();
            Reload();
        }
        catch (Exception ex)
        {
            MessageBox.Show(FindForm(), ex.Message, "Vận hành", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void Dgv_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;
        TryInvokeActionCell(e.RowIndex, e.ColumnIndex, e.Location);
    }

    private void TryInvokeActionCell(int rowIndex, int columnIndex, Point cellRelativePt)
    {
        if (rowIndex < 0 || columnIndex < 0) return;
        if (_dgv.Columns[columnIndex].Name != "colActions") return;

        if (!_hitZones.TryGetValue(rowIndex, out var zones)) return;

        foreach (var z in zones)
        {
            if (!z.Rect.Contains(cellRelativePt)) continue;
            z.Action();
            break;
        }
    }

    private void Dgv_CellMouseMove(object? sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0 || _dgv.Columns[e.ColumnIndex].Name != "colActions")
        {
            Cursor = Cursors.Default;
            return;
        }

        if (!_hitZones.TryGetValue(e.RowIndex, out var zones))
        {
            Cursor = Cursors.Default;
            return;
        }

        Cursor = zones.Exists(z => z.Rect.Contains(e.Location)) ? Cursors.Hand : Cursors.Default;
    }

    private static GraphicsPath CreateRoundRect(Rectangle rect, int radius)
    {
        var path = new GraphicsPath();
        var d = radius * 2;
        path.AddArc(rect.X, rect.Y, d, d, 180, 90);
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }
}
