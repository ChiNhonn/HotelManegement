using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement.Helpers;

/// <summary>
/// Chuẩn WinForms: <see cref="Panel"/> bật <c>AutoScroll</c> và kéo chuột trái để pan (kéo thả cuộn nội dung).
/// Dùng làm mặc định khi thêm màn hình có bảng / lưới lớn hơn viewport.
/// </summary>
public static class WinFormsScrollPan
{
    /// <summary>
    /// Gắn pan + tùy chọn đồng bộ chiều ngang cho con <c>Dock = Top</c>.
    /// </summary>
    /// <param name="scrollHost"><c>AutoScroll = true</c>, thường <c>Dock = Fill</c>.</param>
    /// <param name="matchChildWidth">Con cần <c>Width</c> khớp vùng cuộn (trừ thanh dọc nếu có).</param>
    /// <param name="alsoStartPanFrom">Thêm nơi bắt đầu kéo (ví dụ nền <c>TableLayoutPanel</c>).</param>
    public static void EnableForPanel(Panel scrollHost, Control? matchChildWidth, params Control[] alsoStartPanFrom)
    {
        ArgumentNullException.ThrowIfNull(scrollHost);

        void SyncContentWidth(object? sender, EventArgs e)
        {
            if (matchChildWidth == null || !scrollHost.IsHandleCreated) return;
            var w = scrollHost.ClientSize.Width;
            if (scrollHost.VerticalScroll.Visible)
                w -= SystemInformation.VerticalScrollBarWidth;
            var minW = matchChildWidth.MinimumSize.Width;
            matchChildWidth.Width = Math.Max(w, minW > 0 ? minW : w);
        }

        scrollHost.Resize += SyncContentWidth;
        SyncContentWidth(null, EventArgs.Empty);

        var state = new PanState();

        void BeginPan()
        {
            state.Panning = true;
            state.DragStartScreen = Control.MousePosition;
            var asp = scrollHost.AutoScrollPosition;
            state.ScrollAtDragStart = new Point(-asp.X, -asp.Y);
            scrollHost.Capture = true;
            scrollHost.Cursor = Cursors.SizeAll;
        }

        void EndPan()
        {
            if (!state.Panning) return;
            state.Panning = false;
            if (scrollHost.Capture)
                scrollHost.Capture = false;
            scrollHost.Cursor = Cursors.Default;
        }

        void OnMouseMove(MouseEventArgs e)
        {
            if (!state.Panning) return;
            var cur = Control.MousePosition;
            var dx = cur.X - state.DragStartScreen.X;
            var dy = cur.Y - state.DragStartScreen.Y;
            var nx = state.ScrollAtDragStart.X - dx;
            var ny = state.ScrollAtDragStart.Y - dy;
            nx = Math.Max(0, nx);
            ny = Math.Max(0, ny);
            if (scrollHost.HorizontalScroll.Visible)
                nx = Math.Min(nx, scrollHost.HorizontalScroll.Maximum);
            if (scrollHost.VerticalScroll.Visible)
                ny = Math.Min(ny, scrollHost.VerticalScroll.Maximum);
            scrollHost.AutoScrollPosition = new Point(nx, ny);
        }

        scrollHost.MouseMove += (_, ev) => OnMouseMove(ev);
        scrollHost.MouseUp += (_, ev) =>
        {
            if (ev.Button == MouseButtons.Left) EndPan();
        };
        scrollHost.MouseLeave += (_, _) =>
        {
            if (!state.Panning) return;
            if ((Control.MouseButtons & MouseButtons.Left) == 0)
                EndPan();
        };

        void HookPanStart(Control c)
        {
            c.MouseDown += (_, ev) =>
            {
                if (ev.Button == MouseButtons.Left) BeginPan();
            };
        }

        HookPanStart(scrollHost);
        if (alsoStartPanFrom != null)
        {
            foreach (var c in alsoStartPanFrom)
            {
                if (c != null) HookPanStart(c);
            }
        }
    }

    private sealed class PanState
    {
        public bool Panning;
        public Point DragStartScreen;
        public Point ScrollAtDragStart;
    }
}
