using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.ViewModels;

namespace HotelManagement.CustomControls;

/// <summary>Lưới 3×10 ô vuông trạng thái phòng theo tầng (dashboard).</summary>
public sealed class MiniRoomStatusStrip : UserControl
{
    private DashboardMiniRoomStatus? _data;
    private readonly List<Rectangle> _roomHitRects = new();
    private readonly List<DashboardMiniRoomCell?> _flatGridCells = new();
    private readonly ToolTip _tip = new();
    private int _lastTooltipCellIndex = -2;

    private static readonly Color SubtleText = Color.FromArgb(100, 116, 139);
    private static readonly Color EmptyCellBg = Color.FromArgb(236, 242, 248);

    /// <summary>Cùng glyph phòng như MainForm (Segoe MDL2).</summary>
    private const char FloorRoomIconGlyph = '\uE8F2';

    public MiniRoomStatusStrip()
    {
        SetStyle(
            ControlStyles.OptimizedDoubleBuffer
            | ControlStyles.AllPaintingInWmPaint
            | ControlStyles.UserPaint
            | ControlStyles.ResizeRedraw,
            true);
        BackColor = Color.White;
        ForeColor = Color.FromArgb(51, 65, 85);
        MinimumSize = new Size(200, 148);
        Cursor = Cursors.Default;
    }

    public void Bind(DashboardMiniRoomStatus data)
    {
        _data = data ?? throw new ArgumentNullException(nameof(data));
        _lastTooltipCellIndex = -2;
        _tip.SetToolTip(this, string.Empty);
        Invalidate();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            _tip.Dispose();

        base.Dispose(disposing);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        var i = HitTest(e.Location);

        if (i == _lastTooltipCellIndex) return;
        _lastTooltipCellIndex = i;

        if (i >= 0 && i < _flatGridCells.Count && _flatGridCells[i] is { } c)
        {
            var lbl = LabelForKind(c.Kind);
            var guestLine = string.IsNullOrWhiteSpace(c.GuestName) ? "" : $"\nKhách: {c.GuestName}";
            _tip.SetToolTip(this, $"{c.Name}{guestLine}\n{lbl} · {RoomStatusMap.ToDisplay(c.RawStatus)}");
        }
        else
            _tip.SetToolTip(this, string.Empty);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);

        _lastTooltipCellIndex = -2;
        _tip.SetToolTip(this, string.Empty);
    }

    private int HitTest(Point p)
    {
        for (var i = 0; i < _roomHitRects.Count; i++)
        {
            if (_roomHitRects[i].Contains(p))
                return i;
        }

        return -1;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        _roomHitRects.Clear();
        _flatGridCells.Clear();

        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        const int pad = 8;
        var w = Math.Max(1, ClientSize.Width - pad * 2);
        float y = pad;

        using var fontTitle = new Font("Segoe UI", 10.5f, FontStyle.Bold, GraphicsUnit.Point);
        using var fontSub = new Font("Segoe UI", 8.5f, FontStyle.Regular, GraphicsUnit.Point);
        using var fontFloor = new Font("Segoe UI", 11.5f, FontStyle.Bold, GraphicsUnit.Point);
        using var fontLeg = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point);
        using var fontCell = new Font("Segoe UI", 8f, FontStyle.Bold, GraphicsUnit.Point);

        TextRenderer.DrawText(
            g,
            "Sơ đồ trạng thái phòng",
            fontTitle,
            new Rectangle(pad, (int)y, w, 24),
            ForeColor,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        y += 26f;

        if (_data == null || _data.TotalRooms == 0)
        {
            TextRenderer.DrawText(
                g,
                "Chưa có phòng trong hệ thống.",
                fontSub,
                new Rectangle(pad, (int)y, w, 48),
                SubtleText,
                TextFormatFlags.Left | TextFormatFlags.WordBreak);
            return;
        }

        TextRenderer.DrawText(
            g,
            "Theo tầng — mỗi ô vuông là một phòng",
            fontSub,
            new Rectangle(pad, (int)y, w, 18),
            SubtleText,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        y += 22f;

        var x0 = (float)pad;
        const float legendReserve = 40f;
        var maxBottom = ClientSize.Height - pad - legendReserve;
        const int rows = 3;
        const int cols = 10;
        var map = _data.Rooms
            .GroupBy(r => r.GridRow * cols + r.GridCol)
            .ToDictionary(g => g.Key, g => g.First());
        var gap = 6f;
        const float iconBox = 26f;
        const float labelColW = 128f;
        var gridWAvail = w - labelColW;
        var availH = maxBottom - y - 2f;
        if (availH < 24f) availH = 24f;

        var cellW = (gridWAvail - (cols - 1) * gap) / cols;
        var cellH = (availH - (rows - 1) * gap) / rows;
        var cell = Math.Max(18f, Math.Min(cellW, cellH));
        var totalGridW = cols * cell + (cols - 1) * gap;
        var startX = x0 + labelColW + Math.Max(0f, (gridWAvail - totalGridW) / 2f);

        using var fontMdl2 = CreateMdl2Font(15f);

        for (var row = 0; row < rows; row++)
        {
            var label = $"Tầng {row + 1}";
            var rowTop = y + row * (cell + gap);
            var iconY = (int)(rowTop + (cell - iconBox) / 2f);
            var iconRect = new Rectangle(pad, iconY, (int)iconBox, (int)iconBox);
            TextRenderer.DrawText(
                g,
                FloorRoomIconGlyph.ToString(),
                fontMdl2,
                iconRect,
                Color.FromArgb(59, 130, 246),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            var textLeft = pad + (int)iconBox + 4;
            var labelTextW = (int)Math.Max(40f, labelColW - iconBox - 6f);
            TextRenderer.DrawText(
                g,
                label,
                fontFloor,
                new Rectangle(textLeft, (int)rowTop, labelTextW, (int)cell),
                ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            for (var col = 0; col < cols; col++)
            {
                var ix = row * cols + col;
                map.TryGetValue(ix, out var cellData);
                var rx = (int)(startX + col * (cell + gap));
                var ry = (int)(y + row * (cell + gap));
                var rect = new Rectangle(rx, ry, (int)cell, (int)cell);
                _roomHitRects.Add(rect);
                _flatGridCells.Add(cellData);

                if (cellData == null)
                {
                    using var brE = new SolidBrush(EmptyCellBg);
                    FillRoundRect(g, brE, rect.X, rect.Y, rect.Width, rect.Height, 5f);
                    using var pe = new Pen(Color.FromArgb(220, 228, 236), 1f);
                    DrawRoundRect(g, pe, rect.X, rect.Y, rect.Width, rect.Height, 5f);
                }
                else
                {
                    using var br = new SolidBrush(ColorForKind(cellData.Kind));
                    FillRoundRect(g, br, rect.X, rect.Y, rect.Width, rect.Height, 5f);
                    using var po = new Pen(Color.FromArgb(40, 255, 255, 255), 1f);
                    DrawRoundRect(g, po, rect.X, rect.Y, rect.Width, rect.Height, 5f);

                    if (cell >= 22f)
                    {
                        var tc = cellData.Kind is RoomPhysicalStatusKind.Vacant or RoomPhysicalStatusKind.Cleaning
                            ? Color.FromArgb(30, 41, 59)
                            : Color.White;
                        TextRenderer.DrawText(
                            g,
                            cellData.Name,
                            fontCell,
                            rect,
                            tc,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                                                         | TextFormatFlags.EndEllipsis);
                    }
                }
            }
        }

        y = maxBottom;

        var legendItems = new List<(string text, RoomPhysicalStatusKind kind, int count)>
        {
            ("Trống", RoomPhysicalStatusKind.Vacant, _data.VacantCount),
            ("Có khách", RoomPhysicalStatusKind.Occupied, _data.OccupiedCount),
            ("Đang dọn", RoomPhysicalStatusKind.Cleaning, _data.CleaningCount),
            ("Bảo trì / hỏng", RoomPhysicalStatusKind.Maintenance, _data.MaintenanceCount),
        };
        if (_data.UnknownCount > 0)
            legendItems.Add(("Không rõ", RoomPhysicalStatusKind.Unknown, _data.UnknownCount));

        var lx = (float)pad;
        const float dot = 9f;
        foreach (var (text, kind, count) in legendItems)
        {
            using var dotBr = new SolidBrush(ColorForKind(kind));
            g.FillEllipse(dotBr, lx, y + 5f, dot, dot);
            var txt = $"{text}: {count}";
            var tw = TextRenderer.MeasureText(txt, fontLeg).Width;
            TextRenderer.DrawText(
                g,
                txt,
                fontLeg,
                new Rectangle((int)(lx + dot + 7), (int)y, tw + 6, 22),
                ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            lx += dot + 10 + tw + 20;
            if (lx > pad + w - 48)
            {
                lx = pad;
                y += 24f;
            }
        }
    }

    private static Font CreateMdl2Font(float sizePt)
    {
        try
        {
            var f = new Font("Segoe MDL2 Assets", sizePt, FontStyle.Regular, GraphicsUnit.Point);
            if (f.Name.IndexOf("MDL2", StringComparison.OrdinalIgnoreCase) >= 0)
                return f;
            f.Dispose();
        }
        catch
        {
            // fallback font
        }

        return new Font("Segoe UI Symbol", sizePt * 0.9f, FontStyle.Regular, GraphicsUnit.Point);
    }

    private static void FillRoundRect(Graphics g, Brush brush, float x, float y, float width, float height, float radius)
    {
        if (width <= 0.5f || height <= 0.5f) return;
        using var path = CreateRoundRectPath(x, y, width, height, radius);
        g.FillPath(brush, path);
    }

    private static void DrawRoundRect(Graphics g, Pen pen, float x, float y, float width, float height, float radius)
    {
        if (width <= 0.5f || height <= 0.5f) return;
        using var path = CreateRoundRectPath(x, y, width, height, radius);
        g.DrawPath(pen, path);
    }

    private static GraphicsPath CreateRoundRectPath(float x, float y, float width, float height, float radius)
    {
        var path = new GraphicsPath();
        var d = Math.Min(radius * 2f, Math.Min(width, height));
        var r = Math.Max(1f, d / 2f);
        path.AddArc(x, y, d, d, 180, 90);
        path.AddArc(x + width - d, y, d, d, 270, 90);
        path.AddArc(x + width - d, y + height - d, d, d, 0, 90);
        path.AddArc(x, y + height - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }

    private static string LabelForKind(RoomPhysicalStatusKind k) => k switch
    {
        RoomPhysicalStatusKind.Vacant => "Trống",
        RoomPhysicalStatusKind.Occupied => "Có khách",
        RoomPhysicalStatusKind.Cleaning => "Đang dọn",
        RoomPhysicalStatusKind.Maintenance => "Bảo trì",
        _ => "Không rõ"
    };

    private void InitializeComponent()
    {

    }

    private static Color ColorForKind(RoomPhysicalStatusKind k) => k switch
    {
        RoomPhysicalStatusKind.Vacant => Color.FromArgb(22, 163, 74),
        RoomPhysicalStatusKind.Occupied => Color.FromArgb(37, 99, 235),
        RoomPhysicalStatusKind.Cleaning => Color.FromArgb(234, 179, 8),
        RoomPhysicalStatusKind.Maintenance => Color.FromArgb(100, 116, 139),
        _ => Color.FromArgb(148, 163, 184)
    };
}
