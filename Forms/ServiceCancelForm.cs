using System.Windows.Forms;

namespace HotelManagement.Forms;

public partial class ServiceCancelForm : Form
{
    public string Reason => txtReason.Text.Trim();
    public decimal CancellationFee => numFee.Value;

    public ServiceCancelForm(string itemName)
    {
        InitializeComponent();
        lblTitle.Text = $"Hủy: {itemName}";
    }
}
