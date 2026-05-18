using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design;

namespace HotelManagement.CustomControls;

/// <summary>Panel nền trắng bo góc + viền nhạt + bóng đổ nhẹ (dashboard card).</summary>
[Designer(typeof(ParentControlDesigner))]
public sealed class RoundedCardPanel : Panel
{
    private int _radius = 10;

    public int Radius
    {
        get => _radius;
        set
        {
            _radius = Math.Max(2, value);
            UpdateClipRegion();
            Invalidate();
        }
    }

    public Color CardBackColor { get; set; } = Color.White;

    public Color BorderColor { get; set; } = Color.FromArgb(226, 232, 240);

    /// <summary>Khi true (mặc định) sẽ vẽ shadow nhẹ phía dưới — dùng cho dashboard.
    /// Đặt false để có phong cách flat (chỉ viền 1px) — dùng cho các trang phụ.</summary>
    public bool DrawShadow { get; set; } = true;

    /// <summary>Khi false: không đặt Region bo góc — control con không bị WinForms clip theo đường cong (tránh cắt đáy khối dock).</summary>
    public bool ClipChildrenToRoundedBounds { get; set; } = true;

    /// <summary>Khi false: chỉ tô nền bo góc, không vẽ đường viền (tránh khung đậm quanh card).</summary>
    public bool DrawCardBorder { get; set; } = true;

    public RoundedCardPanel()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint
            | ControlStyles.UserPaint
            | ControlStyles.OptimizedDoubleBuffer
            | ControlStyles.ResizeRedraw,
            true);
        BackColor = Color.Transparent;
        Padding = new Padding(16, 14, 16, 16);
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdateClipRegion();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        UpdateClipRegion();
    }

    /// <summary>Bo cắt con theo hình chữ nhật bo góc — tránh góc vuông/viền lạ của control con.</summary>
    private void UpdateClipRegion()
    {
        if (!ClipChildrenToRoundedBounds)
        {
            Region?.Dispose();
            Region = null;
            return;
        }

        if (!IsHandleCreated || Width <= 1 || Height <= 1)
            return;

        var bounds = ClientRectangle;
        bounds.Inflate(-6, -6);
        var r = Math.Min(_radius, Math.Max(1, bounds.Height / 2));
        if (bounds.Width < 4 || bounds.Height < 4)
        {
            Region?.Dispose();
            Region = null;
            return;
        }

        using var path = CreateRoundRectPath(bounds, r);
        Region?.Dispose();
        Region = new Region(path);
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        // Nền vẽ tay trong OnPaint (bo góc + bóng).
    }

    /// <summary>Lề vẽ nội dung bo góc. Khi không clip con + không viền card, tô full bleed để không còn vành tối (WinForms để trống OnPaintBackground).</summary>
    private int PaintInset => ClipChildrenToRoundedBounds || DrawCardBorder ? 6 : 0;

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        // Bắt buộc tô full client — nếu không, vùng ngoài path bo góc (lề ~6px) có thể thành màu đen khi UserPaint.
        using (var full = new SolidBrush(CardBackColor))
            g.FillRectangle(full, ClientRectangle);

        g.SmoothingMode = SmoothingMode.AntiAlias;
        var bounds = ClientRectangle;
        var inset = PaintInset;
        if (inset != 0)
            bounds.Inflate(-inset, -inset);
        if (bounds.Width < 4 || bounds.Height < 4)
            return;

        var r = Math.Min(_radius, bounds.Height / 2);

        if (DrawShadow)
        {
            for (var i = 3; i >= 1; i--)
            {
                var shadowRect = new Rectangle(bounds.X, bounds.Y + i, bounds.Width, bounds.Height);
                using var path = CreateRoundRectPath(shadowRect, r + 1);
                using var sh = new SolidBrush(Color.FromArgb(8 + i * 4, 95, 115, 140));
                g.FillPath(sh, path);
            }
        }

        using (var path = CreateRoundRectPath(bounds, r))
        {
            using var fill = new SolidBrush(CardBackColor);
            g.FillPath(fill, path);
            if (DrawCardBorder)
            {
                using var pen = new Pen(BorderColor, 1f);
                g.DrawPath(pen, path);
            }
        }
    }

    private static GraphicsPath CreateRoundRectPath(Rectangle rect, int rad)
    {
        var path = new GraphicsPath();
        var d = rad * 2;
        if (d > rect.Width) d = rect.Width;
        if (d > rect.Height) d = rect.Height;
        var rr = Math.Max(1, d / 2);
        path.AddArc(rect.X, rect.Y, d, d, 180, 90);
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }
}
