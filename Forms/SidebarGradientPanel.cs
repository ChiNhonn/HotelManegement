using System.Windows.Forms;

namespace HotelManagement.Forms;

/// <summary>
/// Panel không vẽ OnPaintBackground để gradient trong Paint hiển thị đúng (kể cả chỗ trong suốt).
/// </summary>
public sealed class SidebarGradientPanel : Panel
{
    public SidebarGradientPanel()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint
            | ControlStyles.UserPaint
            | ControlStyles.OptimizedDoubleBuffer
            | ControlStyles.ResizeRedraw,
            true);
        DoubleBuffered = true;
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        // Không fill BackColor — toàn bộ nền do MainForm_Paint xử lý.
    }
}
