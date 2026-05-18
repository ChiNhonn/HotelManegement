using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

/// <summary>Hộp thoại ghi nhận thanh toán tiền mặt / chuyển khoản cho một hóa đơn chờ thu.</summary>
public sealed class ManualPaymentDialog : Form
{
    private readonly IDashboardService _dashboard;
    private readonly ComboBox _cmbBill = new();
    private readonly RadioButton _radCash = new();
    private readonly RadioButton _radTransfer = new();
    private readonly Button _btnOk = new();

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

        var lblBill = new Label
        {
            Text = "Chọn hóa đơn chờ thu",
            Location = new Point(16, 14),
            AutoSize = true
        };

        _cmbBill.DropDownStyle = ComboBoxStyle.DropDownList;
        _cmbBill.DisplayMember = nameof(DashboardBillPickRow.Display);
        _cmbBill.Location = new Point(16, 38);
        _cmbBill.Width = 488;
        _cmbBill.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        var lblMethod = new Label
        {
            Text = "Phương thức thanh toán",
            Location = new Point(16, 84),
            AutoSize = true
        };

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

        var btnCancel = new Button
        {
            Text = "Đóng",
            DialogResult = DialogResult.Cancel,
            Location = new Point(416, 176),
            Width = 88,
            Height = 32
        };

        _btnOk.Click += (_, _) =>
        {
            if (_cmbBill.SelectedItem is not DashboardBillPickRow pick)
            {
                MessageBox.Show(this, "Vui lòng chọn hóa đơn.", Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var method = _radTransfer.Checked ? "Chuyển khoản" : "Tiền mặt";
            try
            {
                _dashboard.RecordManualBillPayment(pick.BillId, method);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        };

        Controls.Add(lblBill);
        Controls.Add(_cmbBill);
        Controls.Add(lblMethod);
        Controls.Add(_radCash);
        Controls.Add(_radTransfer);
        Controls.Add(_btnOk);
        Controls.Add(btnCancel);

        AcceptButton = _btnOk;
        CancelButton = btnCancel;

        Shown += (_, _) => ReloadBills();
    }

    private void ReloadBills()
    {
        var list = _dashboard.GetBillsForManualPaymentPick().ToList();
        _cmbBill.DataSource = list;
        var has = list.Count > 0;
        _cmbBill.Enabled = has;
        _btnOk.Enabled = has;
        if (!has)
        {
            MessageBox.Show(this,
                "Không có hóa đơn nào đang chờ thu trong danh sách (trạng thái chưa thanh toán).",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
