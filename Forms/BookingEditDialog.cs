using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

/// <summary>Sửa đặt phòng — layout trong <c>BookingEditDialog.Designer.cs</c>.</summary>
public partial class BookingEditDialog : Form
{
    private readonly IBookingService? _booking;
    private readonly int _orderId;
    private readonly decimal _unitNight;

    private static readonly CultureInfo En = CultureInfo.GetCultureInfo("en-US");

    public BookingEditDialog()
    {
        InitializeComponent();
    }

    public BookingEditDialog(IBookingService booking, BookingDetailsDto d)
        : this()
    {
        _booking = booking ?? throw new ArgumentNullException(nameof(booking));
        if (d == null) throw new ArgumentNullException(nameof(d));
        _orderId = d.OrderId;
        _unitNight = d.NightlyPrice;

        lblRoom.Text = d.RoomName;
        lblType.Text = string.IsNullOrWhiteSpace(d.RoomTypeName) ? "—" : d.RoomTypeName!;
        lblRate.Text = $"{d.NightlyPrice.ToString("N0", En)} VND / đêm (cố định)";

        var checkIn = d.CheckIn.Date;
        var nights = Math.Max(1, d.Nights);
        var checkOut = d.CheckOut?.Date ?? checkIn.AddDays(nights);
        if (checkOut <= checkIn)
            checkOut = checkIn.AddDays(nights);

        dtpIn.Value = checkIn;
        dtpOut.MinDate = checkIn;
        dtpOut.Value = checkOut;

        txtName.Text = d.GuestName;
        txtCccd.Text = d.CitizenId;
        txtPhone.Text = d.Phone;
        numAdults.Value = Math.Clamp(Math.Max(1, d.Adults), (int)numAdults.Minimum, (int)numAdults.Maximum);
        numChildren.Value = Math.Clamp(Math.Max(0, d.Children), (int)numChildren.Minimum, (int)numChildren.Maximum);
        txtNote.Text = d.UserNote ?? "";

        WireRuntimeEvents();
        RecalcTotals();
    }

    private void WireRuntimeEvents()
    {
        dtpIn.ValueChanged += (_, _) =>
        {
            dtpOut.MinDate = dtpIn.Value.Date;
            if (dtpOut.Value.Date < dtpOut.MinDate)
                dtpOut.Value = dtpOut.MinDate;
            RecalcTotals();
        };
        dtpOut.ValueChanged += (_, _) => RecalcTotals();
        btnOk.Click += BtnOk_Click;
        Shown += (_, _) => txtName.Focus();
    }

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        if (_booking == null) return;
        try
        {
            var nights = (dtpOut.Value.Date - dtpIn.Value.Date).Days;
            if (nights < 1)
            {
                MessageBox.Show("Ngày trả phòng phải sau ngày nhận phòng ít nhất 1 ngày.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _booking.UpdateBooking(new ReservationUpdateRequest
            {
                OrderId = _orderId,
                FullName = txtName.Text,
                CitizenId = txtCccd.Text,
                Phone = txtPhone.Text,
                CheckIn = dtpIn.Value.Date,
                CheckOut = dtpOut.Value.Date,
                Adults = (int)numAdults.Value,
                Children = (int)numChildren.Value,
                Note = txtNote.Text
            });
            MessageBox.Show("Đã cập nhật đặt phòng.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void RecalcTotals()
    {
        var nights = (dtpOut.Value.Date - dtpIn.Value.Date).Days;
        if (nights < 1)
        {
            lblNights.Text = "—";
            lblTotal.Text = "—";
            lblNights.ForeColor = Color.FromArgb(220, 38, 38);
            lblTotal.ForeColor = Color.FromArgb(220, 38, 38);
            return;
        }

        lblNights.ForeColor = Color.FromArgb(30, 41, 59);
        lblTotal.ForeColor = Color.FromArgb(22, 101, 52);
        lblNights.Text = nights.ToString(En);
        lblTotal.Text = $"{(_unitNight * nights).ToString("N0", En)} VND";
    }
}
