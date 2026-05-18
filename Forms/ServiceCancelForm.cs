using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement.Forms;

public sealed class ServiceCancelForm : Form
{
    private readonly TextBox _txtReason = new() { Width = 320, Multiline = true, Height = 70 };
    private readonly NumericUpDown _numFee = new() { Minimum = 0, Maximum = 99_999_999, ThousandsSeparator = true, Width = 140, DecimalPlaces = 0 };

    public string Reason => _txtReason.Text.Trim();
    public decimal CancellationFee => _numFee.Value;

    public ServiceCancelForm(string itemName)
    {
        Text = "Hủy dịch vụ";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(400, 200);
        Font = new Font("Segoe UI", 9.5f);

        Controls.Add(new Label
        {
            Text = $"Hủy: {itemName}",
            Location = new Point(16, 12),
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold)
        });
        Controls.Add(new Label { Text = "Lý do", Location = new Point(16, 44), AutoSize = true });
        _txtReason.Location = new Point(16, 64);
        Controls.Add(_txtReason);
        Controls.Add(new Label { Text = "Phí hủy (VNĐ)", Location = new Point(16, 140), AutoSize = true });
        _numFee.Location = new Point(140, 136);
        Controls.Add(_numFee);

        var btnOk = new Button { Text = "Xác nhận hủy", Location = new Point(200, 136), DialogResult = DialogResult.OK, Width = 110 };
        var btnCancel = new Button { Text = "Đóng", Location = new Point(318, 136), DialogResult = DialogResult.Cancel, Width = 70 };
        Controls.Add(btnOk);
        Controls.Add(btnCancel);
        AcceptButton = btnOk;
        CancelButton = btnCancel;
    }
}
