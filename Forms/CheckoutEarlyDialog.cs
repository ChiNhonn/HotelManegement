using System;
using System.Windows.Forms;

namespace HotelManagement.Forms;

public sealed partial class CheckoutEarlyDialog : Form
{
    public DateTime SelectedDate => _dtp.Value.Date;

    public CheckoutEarlyDialog(DateTime checkIn, DateTime scheduledCheckout, string roomLabel)
    {
        InitializeComponent();

        lblHead.Text = $"Check out {roomLabel} (may be before scheduled exit).";
        lblRange.Text = $"From {checkIn:dd/MM/yyyy} to {scheduledCheckout:dd/MM/yyyy}";

        _dtp.MinDate = checkIn.Date;
        _dtp.MaxDate = scheduledCheckout.Date;
        var today = DateTime.Today;
        if (today < checkIn.Date)
            _dtp.Value = checkIn;
        else if (today > scheduledCheckout.Date)
            _dtp.Value = scheduledCheckout;
        else
            _dtp.Value = today;
    }
}
