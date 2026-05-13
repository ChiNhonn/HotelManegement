using System.Windows.Forms;

namespace HotelManagement.CustomControls;

/// <summary>Placeholder — toàn bộ UI trong Designer (lblMessage).</summary>
public partial class UsModuleStub : UserControl
{
    public UsModuleStub()
    {
        InitializeComponent();
    }

    public UsModuleStub(string title, string? hint = null) : this()
    {
        ApplyText(title, hint);
    }

    public void ApplyText(string title, string? hint = null)
    {
        lblMessage.Text = hint is null
            ? title + "\r\n\r\nMàn hình đang được hoàn thiện."
            : title + "\r\n\r\n" + hint;
    }
}
