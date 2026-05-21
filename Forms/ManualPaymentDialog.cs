using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

/// <summary>Hộp thoại ghi nhận thanh toán — có thể chọn hóa đơn chờ thu hoặc thu trực tiếp (không gắn HĐ).</summary>
public partial class ManualPaymentDialog : Form
{
    private const int StandalonePickBillId = 0;

    private readonly IDashboardService _dashboard;

    public ManualPaymentDialog(IDashboardService dashboard)
    {
        _dashboard = dashboard ?? throw new ArgumentNullException(nameof(dashboard));
        InitializeComponent();
    }

    private void ManualPaymentDialog_Shown(object? sender, EventArgs e) => ReloadBills();

    private void cmbBill_SelectedIndexChanged(object? sender, EventArgs e)
    {
        ApplyDefaultNoteFromBill();
        SyncLayout();
    }

    private DashboardBillPickRow? SelectedPick() =>
        cmbBill.SelectedItem as DashboardBillPickRow;

    private bool IsStandalone() => SelectedPick()?.BillId == StandalonePickBillId;

    private void ApplyDefaultNoteFromBill()
    {
        if (SelectedPick() is not { } pick)
            return;

        if (pick.BillId == StandalonePickBillId)
            txtNote.Clear();
        else
            txtNote.Text = pick.DefaultPaymentNote ?? "";
    }

    private void ReloadBills()
    {
        var bills = _dashboard.GetBillsForManualPaymentPick().ToList();
        var list = new List<DashboardBillPickRow>
        {
            new()
            {
                BillId = StandalonePickBillId,
                Display = "(Thu trực tiếp — không gắn hóa đơn)",
                TotalAmount = 0,
                DefaultPaymentNote = ""
            }
        };
        list.AddRange(bills);

        cmbBill.DataSource = null;
        cmbBill.DataSource = list;
        cmbBill.DisplayMember = nameof(DashboardBillPickRow.Display);

        if (cmbBill.Items.Count > 0)
            cmbBill.SelectedIndex = 0;

        ApplyDefaultNoteFromBill();
        SyncLayout();
    }

    private void SyncLayout()
    {
        bool st = IsStandalone();
        lblAmount.Visible = txtAmount.Visible = st;

        const int pad = 12;
        var y = txtNote.Bottom + pad;

        if (st)
        {
            lblAmount.Location = new Point(16, y);
            txtAmount.Location = new Point(16, y + 22);
            y = txtAmount.Bottom + pad;
        }

        lblMethod.Location = new Point(16, y);
        radCash.Location = new Point(16, y + 24);
        radTransfer.Location = new Point(132, y + 24);

        var btnTop = y + 24 + 36;
        btnOk.Location = new Point(296, btnTop);
        btnCancel.Location = new Point(416, btnTop);

        ClientSize = new Size(520, btnTop + btnOk.Height + 16);
    }

    private void btnOk_Click(object? sender, EventArgs e)
    {
        if (SelectedPick() is not { } pick)
            return;

        var method = radTransfer.Checked ? "Chuyển khoản" : "Tiền mặt";
        var noteRaw = string.IsNullOrWhiteSpace(txtNote.Text) ? null : txtNote.Text.Trim();

        try
        {
            if (pick.BillId == StandalonePickBillId)
            {
                if (!TryParseMoneyVi(txtAmount.Text, out var amt) || amt <= 0)
                {
                    MessageBox.Show(this,
                        "Vui lòng nhập số tiền hợp lệ (VNĐ).",
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                _dashboard.RecordStandalonePayment(amt, method, noteRaw);
            }
            else
            {
                _dashboard.RecordManualBillPayment(pick.BillId, method, noteRaw);
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

        s = s.Replace(".", "").Replace(",", ".");
        return decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out amount)
               && amount > 0;
    }
}
