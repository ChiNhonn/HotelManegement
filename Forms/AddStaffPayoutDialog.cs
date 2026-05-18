using System;
using System.Windows.Forms;

namespace HotelManagement.Forms;

internal sealed partial class AddStaffPayoutDialog : Form
{
    public string PayoutUserName => _txtUser.Text.Trim();
    public decimal Amount => _numAmount.Value;

    public AddStaffPayoutDialog()
    {
        InitializeComponent();
    }

    private void AddStaffPayoutDialog_Shown(object? sender, EventArgs e)
    {
        _txtUser.Focus();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (DialogResult != DialogResult.OK)
        {
            base.OnFormClosing(e);
            return;
        }

        if (string.IsNullOrWhiteSpace(PayoutUserName))
        {
            MessageBox.Show("Please enter a username.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = true;
            _txtUser.Focus();
            return;
        }

        base.OnFormClosing(e);
    }
}
