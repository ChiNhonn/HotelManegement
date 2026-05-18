using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

/// <summary>Đặt phòng — layout trong <c>BookRoomDialog.Designer.cs</c>.</summary>
public partial class BookRoomDialog : Form
{
    private readonly IBookingService? _booking;
    private readonly int _roomId;
    private readonly decimal _nightly;

    private static readonly CultureInfo En = CultureInfo.GetCultureInfo("en-US");

    public BookRoomDialog()
    {
        InitializeComponent();
    }

    public BookRoomDialog(
        IBookingService booking,
        int roomId,
        string roomName,
        string? roomTypeName,
        decimal nightlyPrice,
        DateTime suggestedCheckIn)
        : this()
    {
        _booking = booking ?? throw new ArgumentNullException(nameof(booking));
        _roomId = roomId;
        _nightly = nightlyPrice;

        lblRoom.Text = roomName;
        lblType.Text = string.IsNullOrWhiteSpace(roomTypeName) ? "—" : roomTypeName!;
        lblRate.Text = $"{nightlyPrice.ToString("N0", En)} VND / đêm";
        dtpIn.Value = suggestedCheckIn.Date;
        dtpOut.Value = suggestedCheckIn.Date.AddDays(1);

        WireRuntimeEvents();
        RecalcTotals();
    }

    private void WireRuntimeEvents()
    {
        dtpIn.ValueChanged += (_, _) => RecalcTotals();
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

            _booking.CreateReservation(new ReservationRequest
            {
                RoomId = _roomId,
                FullName = txtName.Text,
                CitizenId = txtCccd.Text,
                Phone = txtPhone.Text,
                CheckIn = dtpIn.Value.Date,
                CheckOut = dtpOut.Value.Date,
                Adults = (int)numAdults.Value,
                Children = (int)numChildren.Value,
                Note = txtNote.Text
            });
            MessageBox.Show("Đã tạo đặt phòng.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        lblTotal.Text = $"{(_nightly * nights).ToString("N0", En)} VND";
    }
}
