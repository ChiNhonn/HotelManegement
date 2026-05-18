using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement.CustomControls;

/// <summary>Nút phẳng tự vẽ icon + chữ căn giữa (WinForms Button mặc định hay lệch dọc khi có Image).</summary>
internal sealed class QuickActionButton : Button
{
    private bool _hot;
    private bool _pressed;

    public QuickActionButton()
    {
        SetStyle(
            ControlStyles.UserPaint
            | ControlStyles.AllPaintingInWmPaint
            | ControlStyles.OptimizedDoubleBuffer
            | ControlStyles.ResizeRedraw,
            true);
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Cursor = Cursors.Hand;
        TabStop = true;
    }

    private Color ResolveBackground()
    {
        if (!Enabled)
            return BackColor;
        if (_pressed)
            return FlatAppearance.MouseDownBackColor;
        if (_hot)
            return FlatAppearance.MouseOverBackColor;
        return BackColor;
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        _hot = true;
        Invalidate();
        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        _hot = false;
        _pressed = false;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        if (mevent.Button == MouseButtons.Left)
        {
            _pressed = true;
            Invalidate();
        }
        base.OnMouseDown(mevent);
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        _pressed = false;
        Invalidate();
        base.OnMouseUp(mevent);
    }

    protected override void OnLostFocus(EventArgs e)
    {
        _pressed = false;
        Invalidate();
        base.OnLostFocus(e);
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
        base.OnEnabledChanged(e);
        Invalidate();
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        // Toàn bộ nền vẽ trong OnPaint.
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;

        using (var brush = new SolidBrush(ResolveBackground()))
            g.FillRectangle(brush, ClientRectangle);

        var img = Image;
        var txt = Text ?? string.Empty;
        var font = Font;
        var fore = Enabled ? ForeColor : SystemColors.GrayText;

        var pad = Padding;
        var inner = Rectangle.FromLTRB(
            pad.Left,
            pad.Top,
            ClientSize.Width - pad.Right,
            ClientSize.Height - pad.Bottom);

        if (inner.Width <= 0 || inner.Height <= 0)
            return;

        const int gap = 10;
        var imgSz = img?.Size ?? Size.Empty;

        var tfMeasure = TextFormatFlags.SingleLine | TextFormatFlags.NoPadding;
        var textSz = TextRenderer.MeasureText(g, txt, font, Size.Empty, tfMeasure);

        var totalW = imgSz.Width + (img != null && txt.Length > 0 ? gap : 0) + textSz.Width;
        var totalH = Math.Max(imgSz.Height, textSz.Height);

        var startX = inner.Left + Math.Max(0, (inner.Width - totalW) / 2);
        var startY = inner.Top + Math.Max(0, (inner.Height - totalH) / 2);

        if (img != null)
        {
            var iy = startY + (totalH - imgSz.Height) / 2;
            g.DrawImage(img, startX, iy);
            startX += imgSz.Width + gap;
        }

        if (txt.Length > 0)
        {
            var textRect = new Rectangle(startX, startY, inner.Right - startX, totalH);
            var tfDraw = TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.Left
                                                                        | TextFormatFlags.NoPadding;
            TextRenderer.DrawText(g, txt, font, textRect, fore, tfDraw);
        }

        if (Focused && TabStop && Enabled)
        {
            var focusRect = Rectangle.Inflate(inner, -3, -3);
            if (focusRect.Width > 0 && focusRect.Height > 0)
                ControlPaint.DrawFocusRectangle(g, focusRect);
        }
    }
}
