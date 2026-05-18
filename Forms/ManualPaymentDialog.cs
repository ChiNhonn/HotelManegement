using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

/// <summary>Hộp thoại ghi nhận thanh toán — có thể chọn hóa đơn chờ thu hoặc thu trực tiếp (không gắn HĐ).</summary>
public sealed class ManualPaymentDialog : Form
{
    private const int StandalonePickBillId = 0;

    private readonly IDashboardService _dashboard;
    private readonly Label _lblBill = new();
    private readonly ComboBox _cmbBill = new();
    private readonly Label _lblAmount = new();
    private readonly TextBox _txtAmount = new();
    private readonly Label _lblMethod = new();
    private readonly RadioButton _radCash = new();
    private readonly RadioButton _radTransfer = new();
    private readonly Button _btnOk = new();
    private readonly Button _btnCancel = new();

    public ManualPaymentDialog(IDashboardService dashboard)
    {
        _dashboard = dashboard ?? throw new ArgumentNullException(nameof(dashboard));

        Text = "Thêm giao dịch — ghi nhận thanh toán";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(520, 228);
        Font = new Font("Segoe UI", 9.5f);
        MaximizeBox = false;
        MinimizeBox = false;

        _lblBill.Text = "Chọn hóa đơn chờ thu";
        _lblBill.Location = new Point(16, 14);
        _lblBill.AutoSize = true;

        _cmbBill.DropDownStyle = ComboBoxStyle.DropDownList;
        _cmbBill.Location = new Point(16, 38);
        _cmbBill.Width = 488;
        _cmbBill.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        _lblAmount.Text = "Số tiền (VNĐ)";
        _lblAmount.Location = new Point(16, 72);
        _lblAmount.AutoSize = true;
        _lblAmount.Visible = false;

        _txtAmount.Location = new Point(16, 94);
        _txtAmount.Width = 240;
        _txtAmount.Visible = false;

        _lblMethod.Text = "Phương thức thanh toán";
        _lblMethod.Location = new Point(16, 84);
        _lblMethod.AutoSize = true;

        _radCash.Text = "Tiền mặt";
        _radCash.AutoSize = true;
        _radCash.Checked = true;
        _radCash.Location = new Point(16, 108);

        _radTransfer.Text = "Chuyển khoản";
        _radTransfer.AutoSize = true;
        _radTransfer.Location = new Point(132, 108);

        _btnOk.Text = "Ghi nhận";
        _btnOk.Location = new Point(296, 176);
        _btnOk.Width = 110;
        _btnOk.Height = 32;
        _btnOk.DialogResult = DialogResult.None;

        _btnCancel.Text = "Đóng";
        _btnCancel.DialogResult = DialogResult.Cancel;
        _btnCancel.Location = new Point(416, 176);
        _btnCancel.Width = 88;
        _btnCancel.Height = 32;

        _btnOk.Click += BtnOk_Click;
        _cmbBill.SelectedIndexChanged += (_, _) => SyncLayout();

        Controls.Add(_lblBill);
        Controls.Add(_cmbBill);
        Controls.Add(_lblAmount);
        Controls.Add(_txtAmount);
        Controls.Add(_lblMethod);
        Controls.Add(_radCash);
        Controls.Add(_radTransfer);
        Controls.Add(_btnOk);
        Controls.Add(_btnCancel);

        AcceptButton = _btnOk;
        CancelButton = _btnCancel;

        Shown += (_, _) => ReloadBills();
    }

    private DashboardBillPickRow? SelectedPick() =>
        _cmbBill.SelectedItem as DashboardBillPickRow;

    private bool IsStandalone() => SelectedPick()?.BillId == StandalonePickBillId;

    private void ReloadBills()
    {
        var bills = _dashboard.GetBillsForManualPaymentPick().ToList();
        var list = new List<DashboardBillPickRow>
        {
            new()
            {
                BillId = StandalonePickBillId,
                Display = "(Thu trực tiếp — không gắn hóa đơn)",
                TotalAmount = 0
            }
        };
        list.AddRange(bills);

        _cmbBill.DataSource = null;
        _cmbBill.DataSource = list;
        _cmbBill.DisplayMember = nameof(DashboardBillPickRow.Display);

        if (_cmbBill.Items.Count > 0)
            _cmbBill.SelectedIndex = 0;

        SyncLayout();
    }

    private void SyncLayout()
    {
        bool st = IsStandalone();
        _lblAmount.Visible = _txtAmount.Visible = st;

        int methodTop = st ? 130 : 84;
        int radTop = st ? 154 : 108;
        int btnTop = st ? 218 : 176;

        _lblMethod.Location = new Point(16, methodTop);
        _radCash.Location = new Point(16, radTop);
        _radTransfer.Location = new Point(132, radTop);
        _btnOk.Location = new Point(296, btnTop);
        _btnCancel.Location = new Point(416, btnTop);

        ClientSize = new Size(520, st ? 268 : 228);
    }

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        if (SelectedPick() is not { } pick)
            return;

        var method = _radTransfer.Checked ? "Chuyển khoản" : "Tiền mặt";

        try
        {
            if (pick.BillId == StandalonePickBillId)
            {
                if (!TryParseMoneyVi(_txtAmount.Text, out var amt) || amt <= 0)
                {
                    MessageBox.Show(this,
                        "Vui lòng nhập số tiền hợp lệ (VNĐ).",
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                _dashboard.RecordStandalonePayment(amt, method);
            }
            else
            {
                _dashboard.RecordManualBillPayment(pick.BillId, method);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private static bool TryParseMoneyVi(string? text, out decimal amount)
    {
        amount = 0m;
        if (string.IsNullOrWhiteSpace(text))
            return false;

        var s = text.Trim().Replace(" ", "");
        if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out amount))
            return amount > 0;

        // Cho phép dấu phẩy/chấm phân tách hàng nghìn hoặc thập phân (VN)
        s = s.Replace(".", "").Replace(",", ".");
        return decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out amount)
               && amount > 0;
    }
}
