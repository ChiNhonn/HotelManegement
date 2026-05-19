using System;
using System.Drawing;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

/// <summary>Hóa đơn sau trả phòng — xem chi tiết và ghi nhận thanh toán (hiện trên dashboard).</summary>
public sealed class CheckoutBillPaymentDialog : Form
{
    private readonly IBillService _bills;
    private readonly IDashboardService _dashboard;

    private int _billId;
    private string? _defaultNote;
    private BillDetailView? _data;

    private readonly Label _lblTitle = new();
    private readonly Label _lblGuest = new();
    private readonly Label _lblStay = new();
    private readonly DataGridView _grid = new();
    private readonly Label _lblDiscount = new();
    private readonly Label _lblTax = new();
    private readonly Label _lblDeposit = new();
    private readonly Label _lblTotal = new();
    private readonly Label _lblNote = new();
    private readonly TextBox _txtNote = new();
    private readonly Label _lblMethod = new();
    private readonly RadioButton _radCash = new();
    private readonly RadioButton _radTransfer = new();
    private readonly Button _btnPay = new();
    private readonly Button _btnPrint = new();
    private readonly Button _btnClose = new();
    private bool _openedPrintPreview;

    public CheckoutBillPaymentDialog(IBillService bills, IDashboardService dashboard)
    {
        _bills = bills ?? throw new ArgumentNullException(nameof(bills));
        _dashboard = dashboard ?? throw new ArgumentNullException(nameof(dashboard));

        Text = "Hóa đơn — thanh toán";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 9.5f);
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(640, 520);

        _lblTitle.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
        _lblTitle.AutoSize = false;
        _lblTitle.Width = 600;
        _lblTitle.Height = 28;

        _lblGuest.AutoSize = true;
        _lblStay.AutoSize = true;

        StyleGrid(_grid);

        _lblNote.Text = "Nội dung thanh toán";
        _lblNote.AutoSize = true;

        _txtNote.Width = 600;

        _lblMethod.Text = "Phương thức";
        _lblMethod.AutoSize = true;
        _radCash.Text = "Tiền mặt";
        _radCash.AutoSize = true;
        _radCash.Checked = true;
        _radTransfer.Text = "Chuyển khoản";
        _radTransfer.AutoSize = true;

        _btnPay.Text = "Thanh toán";
        _btnPay.Width = 120;
        _btnPay.Height = 34;
        _btnPay.BackColor = Color.FromArgb(59, 130, 246);
        _btnPay.ForeColor = Color.White;
        _btnPay.FlatStyle = FlatStyle.Flat;
        _btnPay.FlatAppearance.BorderSize = 0;
        _btnPay.Click += BtnPay_Click;

        _btnPrint.Text = "In hóa đơn";
        _btnPrint.Width = 110;
        _btnPrint.Height = 34;
        _btnPrint.BackColor = Color.FromArgb(100, 116, 139);
        _btnPrint.ForeColor = Color.White;
        _btnPrint.FlatStyle = FlatStyle.Flat;
        _btnPrint.FlatAppearance.BorderSize = 0;
        _btnPrint.Click += (_, _) => PrintCurrentBill();

        _btnClose.Text = "Đóng";
        _btnClose.DialogResult = DialogResult.Cancel;
        _btnClose.Width = 88;
        _btnClose.Height = 34;

        Controls.AddRange(new Control[]
        {
            _lblTitle, _lblGuest, _lblStay, _grid,
            _lblDiscount, _lblTax, _lblDeposit, _lblTotal,
            _lblNote, _txtNote, _lblMethod, _radCash, _radTransfer,
            _btnPrint, _btnPay, _btnClose
        });

        CancelButton = _btnClose;
        Load += (_, _) => LoadBill();
        Shown += (_, _) => OpenPrintPreviewOnCheckout();
        Resize += (_, _) => LayoutControls();
    }

    public void Setup(int billId, string? defaultPaymentNote = null)
    {
        _billId = billId;
        _defaultNote = defaultPaymentNote;
    }

    private void LoadBill()
    {
        _data = _bills.GetBillDetail(_billId);
        if (_data == null)
        {
            MessageBox.Show("Không tìm thấy hóa đơn.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        _lblTitle.Text = $"HÓA ĐƠN #{_data.BillId:D5}";
        _lblGuest.Text = $"Khách: {_data.CustomerName}";
        var co = _data.CheckOut.HasValue
            ? _data.CheckOut.Value.ToString("dd/MM/yyyy")
            : "—";
        _lblStay.Text = $"Nhận {_data.CheckIn:dd/MM/yyyy} · Trả {co}";

        _grid.DataSource = _data.Items;
        LocalizeGrid();

        _lblDiscount.Text = $"Giảm giá: - {_data.Discount:N0} đ";
        _lblTax.Text = $"Thuế: + {_data.Tax:N0} đ";
        _lblDeposit.Text = $"Đã cọc: - {_data.DepositAmount:N0} đ";
        _lblTotal.Text = _data.IsPaid
            ? "ĐÃ THANH TOÁN"
            : $"TỔNG THANH TOÁN: {_data.TotalAmount:N0} đ";
        _lblTotal.ForeColor = _data.IsPaid
            ? Color.FromArgb(22, 163, 74)
            : Color.FromArgb(15, 23, 42);

        _txtNote.Text = string.IsNullOrWhiteSpace(_defaultNote) ? "" : _defaultNote.Trim();
        _btnPay.Visible = !_data.IsPaid;
        _radCash.Enabled = !_data.IsPaid;
        _radTransfer.Enabled = !_data.IsPaid;
        _txtNote.Enabled = !_data.IsPaid;

        if (_data.IsPaid)
            Text = "Hóa đơn (đã thanh toán)";

        LayoutControls();
    }

    private void LocalizeGrid()
    {
        if (_grid.Columns["Product"] != null)
            _grid.Columns["Product"]!.HeaderText = "Nội dung";
        if (_grid.Columns["Quantity"] != null)
            _grid.Columns["Quantity"]!.HeaderText = "SL";
        if (_grid.Columns["UnitPrice"] != null)
        {
            _grid.Columns["UnitPrice"]!.HeaderText = "Đơn giá";
            _grid.Columns["UnitPrice"]!.DefaultCellStyle.Format = "N0";
        }
        if (_grid.Columns["SubTotal"] != null)
        {
            _grid.Columns["SubTotal"]!.HeaderText = "Thành tiền";
            _grid.Columns["SubTotal"]!.DefaultCellStyle.Format = "N0";
        }
    }

    private void LayoutControls()
    {
        const int pad = 16;
        var y = pad;

        _lblTitle.Location = new Point(pad, y);
        y += _lblTitle.Height + 4;
        _lblGuest.Location = new Point(pad, y);
        y += _lblGuest.Height + 2;
        _lblStay.Location = new Point(pad, y);
        y += _lblStay.Height + 10;

        var gridH = 180;
        _grid.SetBounds(pad, y, ClientSize.Width - pad * 2, gridH);
        y += gridH + 8;

        _lblDiscount.Location = new Point(pad, y);
        y += 20;
        _lblTax.Location = new Point(pad, y);
        y += 20;
        _lblDeposit.Location = new Point(pad, y);
        y += 24;
        _lblTotal.Location = new Point(pad, y);
        _lblTotal.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
        y += 32;

        _lblNote.Location = new Point(pad, y);
        y += 22;
        _txtNote.SetBounds(pad, y, ClientSize.Width - pad * 2, 26);
        y += 34;

        _lblMethod.Location = new Point(pad, y);
        _radCash.Location = new Point(pad + 90, y - 2);
        _radTransfer.Location = new Point(pad + 200, y - 2);
        y += 40;

        _btnClose.Location = new Point(ClientSize.Width - pad - _btnClose.Width, y);
        _btnPay.Location = new Point(_btnClose.Left - 12 - _btnPay.Width, y);
        _btnPrint.Location = new Point(_btnPay.Left - 12 - _btnPrint.Width, y);
    }

    /// <summary>Mở xem trước in ngay sau trả phòng (in máy từ hộp thoại preview).</summary>
    private void OpenPrintPreviewOnCheckout()
    {
        if (_openedPrintPreview || _data == null)
            return;
        _openedPrintPreview = true;
        PrintCurrentBill();
    }

    private void PrintCurrentBill()
    {
        var detail = _bills.GetBillDetail(_billId);
        if (detail == null)
        {
            MessageBox.Show("Không tải được hóa đơn để in.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            BillPrintHelper.ShowPrintPreview(detail, this);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi in: {ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnPay_Click(object? sender, EventArgs e)
    {
        if (_data == null || _data.IsPaid) return;

        var method = _radCash.Checked ? "Tiền mặt" : "Chuyển khoản";
        var note = string.IsNullOrWhiteSpace(_txtNote.Text) ? _defaultNote : _txtNote.Text.Trim();

        try
        {
            _dashboard.RecordManualBillPayment(_billId, method, note, finalizeStayIfNeeded: false);
            _data = _bills.GetBillDetail(_billId);
            if (_data != null)
            {
                _lblTotal.Text = "ĐÃ THANH TOÁN";
                _lblTotal.ForeColor = Color.FromArgb(22, 163, 74);
                _btnPay.Visible = false;
            }

            var askPrint = MessageBox.Show(
                "Đã ghi nhận thanh toán.\nKhoản thu hiển thị tại Dashboard → Giao dịch gần đây.\n\nIn lại hóa đơn đã thanh toán?",
                Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (askPrint == DialogResult.Yes)
                PrintCurrentBill();

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private static void StyleGrid(DataGridView dgv)
    {
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.RowHeadersVisible = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.BackgroundColor = Color.White;
        dgv.BorderStyle = BorderStyle.FixedSingle;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.EnableHeadersVisualStyles = false;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
        dgv.ColumnHeadersHeight = 32;
        dgv.RowTemplate.Height = 28;
    }
}
