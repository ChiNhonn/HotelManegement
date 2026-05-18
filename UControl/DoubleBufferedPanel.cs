using System.Windows.Forms;

namespace HotelManagement.CustomControls;

/// <summary>Panel dùng trong Designer: bật double-buffer để vùng cuộn sơ đồ phòng mượt hơn.</summary>
public class DoubleBufferedPanel : Panel
{
    public DoubleBufferedPanel()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
    }
}
