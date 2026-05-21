using System;
using System.Drawing;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

/// <summary>Hóa đơn sau trả phòng — xem chi tiết và ghi nhận thanh toán (hiện trên dashboard).</summary>
public partial class CheckoutBillPaymentDialog : Form
{
    private readonly IBillService _bills;
    private readonly IDashboardService _dashboard;

    private int _billId;
    private string? _defaultNote;
    private BillDetailView? _data;
    private bool _openedPrintPreview;

    public CheckoutBillPaymentDialog(IBillService bills, IDashboardService dashboard)
    {
        _bills = bills ?? throw new ArgumentNullException(nameof(bills));
        _dashboard = dashboard ?? throw new ArgumentNullException(nameof(dashboard));
        InitializeComponent();
        StyleGrid(grid);
    }

    public void Setup(int billId, string? defaultPaymentNote = null)
    {
        _billId = billId;
        _defaultNote = defaultPaymentNote;
    }

    private void CheckoutBillPaymentDialog_Load(object? sender, EventArgs e) => LoadBill();

    private void CheckoutBillPaymentDialog_Shown(object? sender, EventArgs e) => OpenPrintPreviewOnCheckout();

    private void CheckoutBillPaymentDialog_Resize(object? sender, EventArgs e) => LayoutControls();

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

        lblTitle.Text = $"HÓA ĐƠN #{_data.BillId:D5}";
        lblGuest.Text = $"Khách: {_data.CustomerName}";
        var co = _data.CheckOut.HasValue
            ? _data.CheckOut.Value.ToString("dd/MM/yyyy")
            : "—";
        lblStay.Text = $"Nhận {_data.CheckIn:dd/MM/yyyy} · Trả {co}";

        grid.DataSource = _data.Items;
        LocalizeGrid();

        lblDiscount.Text = $"Giảm giá: - {_data.Discount:N0} đ";
        lblTax.Text = $"Thuế: + {_data.Tax:N0} đ";
        lblDeposit.Text = $"Đã cọc: - {_data.DepositAmount:N0} đ";
        lblTotal.Text = _data.IsPaid
            ? "ĐÃ THANH TOÁN"
            : $"TỔNG THANH TOÁN: {_data.TotalAmount:N0} đ";
        lblTotal.ForeColor = _data.IsPaid
            ? Color.FromArgb(22, 163, 74)
            : Color.FromArgb(15, 23, 42);

        txtNote.Text = string.IsNullOrWhiteSpace(_defaultNote) ? "" : _defaultNote.Trim();
        btnPay.Visible = !_data.IsPaid;
        radCash.Enabled = !_data.IsPaid;
        radTransfer.Enabled = !_data.IsPaid;
        txtNote.Enabled = !_data.IsPaid;

        if (_data.IsPaid)
            Text = "Hóa đơn (đã thanh toán)";

        LayoutControls();
    }

    private void LocalizeGrid()
    {
        if (grid.Columns["Product"] != null)
            grid.Columns["Product"]!.HeaderText = "Nội dung";
        if (grid.Columns["Quantity"] != null)
            grid.Columns["Quantity"]!.HeaderText = "SL";
        if (grid.Columns["UnitPrice"] != null)
        {
            grid.Columns["UnitPrice"]!.HeaderText = "Đơn giá";
            grid.Columns["UnitPrice"]!.DefaultCellStyle.Format = "N0";
        }
        if (grid.Columns["SubTotal"] != null)
        {
            grid.Columns["SubTotal"]!.HeaderText = "Thành tiền";
            grid.Columns["SubTotal"]!.DefaultCellStyle.Format = "N0";
        }
    }

    private void LayoutControls()
    {
        const int pad = 16;
        var y = pad;

        lblTitle.Location = new Point(pad, y);
        y += lblTitle.Height + 4;
        lblGuest.Location = new Point(pad, y);
        y += lblGuest.Height + 2;
        lblStay.Location = new Point(pad, y);
        y += lblStay.Height + 10;

        var gridH = 180;
        grid.SetBounds(pad, y, ClientSize.Width - pad * 2, gridH);
        y += gridH + 8;

        lblDiscount.Location = new Point(pad, y);
        y += 20;
        lblTax.Location = new Point(pad, y);
        y += 20;
        lblDeposit.Location = new Point(pad, y);
        y += 24;
        lblTotal.Location = new Point(pad, y);
        lblTotal.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
        y += 32;

        lblNote.Location = new Point(pad, y);
        y += 22;
        txtNote.SetBounds(pad, y, ClientSize.Width - pad * 2, 26);
        y += 34;

        lblMethod.Location = new Point(pad, y);
        radCash.Location = new Point(pad + 90, y - 2);
        radTransfer.Location = new Point(pad + 200, y - 2);
        y += 40;

        btnClose.Location = new Point(ClientSize.Width - pad - btnClose.Width, y);
        btnPay.Location = new Point(btnClose.Left - 12 - btnPay.Width, y);
        btnPrint.Location = new Point(btnPay.Left - 12 - btnPrint.Width, y);
    }

    private void OpenPrintPreviewOnCheckout()
    {
        if (_openedPrintPreview || _data == null)
            return;
        _openedPrintPreview = true;
        PrintCurrentBill();
    }

    private void btnPrint_Click(object? sender, EventArgs e) => PrintCurrentBill();

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

    private void btnPay_Click(object? sender, EventArgs e)
    {
        if (_data == null || _data.IsPaid) return;

        var method = radCash.Checked ? "Tiền mặt" : "Chuyển khoản";
        var note = string.IsNullOrWhiteSpace(txtNote.Text) ? _defaultNote : txtNote.Text.Trim();

        try
        {
            _dashboard.RecordManualBillPayment(_billId, method, note, finalizeStayIfNeeded: false);
            _data = _bills.GetBillDetail(_billId);
            if (_data != null)
            {
                lblTotal.Text = "ĐÃ THANH TOÁN";
                lblTotal.ForeColor = Color.FromArgb(22, 163, 74);
                btnPay.Visible = false;
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
