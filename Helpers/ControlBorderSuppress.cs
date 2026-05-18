using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HotelManagement.Helpers;

/// <summary>Gỡ WS_BORDER / WS_EX_CLIENTEDGE — TabControl WinForms hay vẽ khung đậm quanh vùng nội dung tab.</summary>
internal static class ControlBorderSuppress
{
    private const int GwlStyle = -16;
    private const int GwlExStyle = -20;
    private const int WsBorder = 0x00800000;
    private const int WsExClientEdge = 0x00000200;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    public static void RemoveNativeBorder(IntPtr handle)
    {
        if (handle == IntPtr.Zero) return;
        var style = GetWindowLong(handle, GwlStyle);
        SetWindowLong(handle, GwlStyle, style & ~WsBorder);
        var ex = GetWindowLong(handle, GwlExStyle);
        SetWindowLong(handle, GwlExStyle, ex & ~WsExClientEdge);
    }

    public static void RemoveNativeBorder(Control c)
    {
        void Strip(object? _, EventArgs __)
        {
            if (c.IsHandleCreated)
                RemoveNativeBorder(c.Handle);
        }

        if (c.IsHandleCreated)
            Strip(null, EventArgs.Empty);
        else
            c.HandleCreated += Strip;
    }
}
