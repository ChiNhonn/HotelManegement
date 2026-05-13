using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

public sealed class BookRoomDialog : Form
{
    private readonly IBookingService _booking;
    private readonly int _roomId;
    private readonly decimal _nightly;

    private readonly Label _lblNights = new();
    private readonly Label _lblTotal = new();
    private readonly DateTimePicker _dtpIn = new();
    private readonly DateTimePicker _dtpOut = new();
    private readonly TextBox _txtName = new();
    private readonly TextBox _txtCccd = new();
    private readonly TextBox _txtPhone = new();
    private readonly NumericUpDown _numAdults = new();
    private readonly NumericUpDown _numChildren = new();
    private readonly TextBox _txtNote = new();

    private static readonly CultureInfo En = CultureInfo.GetCultureInfo("en-US");

    public BookRoomDialog(
        IBookingService booking,
        int roomId,
        string roomName,
        string? roomTypeName,
        decimal nightlyPrice,
        DateTime suggestedCheckIn)
    {
        _booking = booking ?? throw new ArgumentNullException(nameof(booking));
        _roomId = roomId;
        _nightly = nightlyPrice;

        Text = "Book room";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Segoe UI", 10F);
        ClientSize = new Size(460, 560);

        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(18, 14, 18, 12),
            ColumnCount = 2
        };
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 148F));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

        var row = 0;
        void AddRow(string caption, Control c, int height = 28)
        {
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, height + 6));
            var lbl = new Label
            {
                Text = caption,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(71, 85, 105)
            };
            c.Dock = DockStyle.Fill;
            root.Controls.Add(lbl, 0, row);
            root.Controls.Add(c, 1, row);
            row++;
        }

        var lblRoom = new Label
        {
            Text = roomName,
            ForeColor = Color.FromArgb(30, 41, 59),
            Font = new Font("Segoe UI", 10F, FontStyle.Bold)
        };
        AddRow("Room", lblRoom);

        var lblType = new Label
        {
            Text = string.IsNullOrWhiteSpace(roomTypeName) ? "—" : roomTypeName!,
            ForeColor = Color.FromArgb(30, 41, 59)
        };
        AddRow("Room type", lblType);

        var lblUnit = new Label
        {
            Text = $"{nightlyPrice.ToString("N0", En)} VND / night",
            ForeColor = Color.FromArgb(30, 41, 59)
        };
        AddRow("Rate per night", lblUnit);

        _dtpIn.Format = DateTimePickerFormat.Short;
        _dtpOut.Format = DateTimePickerFormat.Short;
        _dtpIn.Value = suggestedCheckIn.Date;
        _dtpOut.Value = suggestedCheckIn.Date.AddDays(1);
        AddRow("Check-in", _dtpIn);
        AddRow("Check-out", _dtpOut);

        AddRow("Full name", _txtName);
        AddRow("National ID", _txtCccd);
        AddRow("Phone", _txtPhone);

        _numAdults.Minimum = 1;
        _numAdults.Maximum = 30;
        _numAdults.Value = 1;
        AddRow("Adults", _numAdults);

        _numChildren.Minimum = 0;
        _numChildren.Maximum = 30;
        _numChildren.Value = 0;
        AddRow("Children", _numChildren);

        _lblNights.AutoSize = false;
        _lblNights.TextAlign = ContentAlignment.MiddleLeft;
        AddRow("Nights", _lblNights);

        _lblTotal.AutoSize = false;
        _lblTotal.TextAlign = ContentAlignment.MiddleLeft;
        _lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        AddRow("Estimated total (nights × rate)", _lblTotal);

        _txtNote.Multiline = true;
        _txtNote.ScrollBars = ScrollBars.Vertical;
        _txtNote.MinimumSize = new Size(0, 72);
        AddRow("Notes", _txtNote, 78);

        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        var flow = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.RightToLeft,
            Dock = DockStyle.Fill,
            AutoSize = true,
            WrapContents = false,
            Padding = new Padding(0, 8, 0, 0)
        };
        var btnOk = new Button
        {
            Text = "Confirm booking",
            DialogResult = DialogResult.None,
            AutoSize = true,
            Padding = new Padding(14, 6, 14, 6),
            Margin = new Padding(8, 0, 0, 0)
        };
        var btnCancel = new Button
        {
            Text = "Cancel",
            DialogResult = DialogResult.Cancel,
            AutoSize = true,
            Padding = new Padding(12, 6, 12, 6)
        };
        flow.Controls.Add(btnOk);
        flow.Controls.Add(btnCancel);
        root.SetColumnSpan(flow, 2);
        root.Controls.Add(flow, 0, row);
        root.RowCount = row + 1;

        Controls.Add(root);

        _dtpIn.ValueChanged += (_, _) => RecalcTotals();
        _dtpOut.ValueChanged += (_, _) => RecalcTotals();

        btnOk.Click += (_, _) =>
        {
            try
            {
                var nights = (_dtpOut.Value.Date - _dtpIn.Value.Date).Days;
                if (nights < 1)
                {
                    MessageBox.Show("Check-out must be at least one day after check-in.", Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _booking.CreateReservation(new ReservationRequest
                {
                    RoomId = _roomId,
                    FullName = _txtName.Text,
                    CitizenId = _txtCccd.Text,
                    Phone = _txtPhone.Text,
                    CheckIn = _dtpIn.Value.Date,
                    CheckOut = _dtpOut.Value.Date,
                    Adults = (int)_numAdults.Value,
                    Children = (int)_numChildren.Value,
                    Note = _txtNote.Text
                });
                MessageBox.Show("Booking created.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        };

        CancelButton = btnCancel;
        AcceptButton = btnOk;

        RecalcTotals();
        Shown += (_, _) => _txtName.Focus();
    }

    private void RecalcTotals()
    {
        var nights = (_dtpOut.Value.Date - _dtpIn.Value.Date).Days;
        if (nights < 1)
        {
            _lblNights.Text = "—";
            _lblTotal.Text = "—";
            _lblNights.ForeColor = Color.FromArgb(220, 38, 38);
            _lblTotal.ForeColor = Color.FromArgb(220, 38, 38);
            return;
        }

        _lblNights.ForeColor = Color.FromArgb(30, 41, 59);
        _lblTotal.ForeColor = Color.FromArgb(22, 101, 52);
        _lblNights.Text = nights.ToString(En);
        var total = _nightly * nights;
        _lblTotal.Text = $"{total.ToString("N0", En)} VND";
    }
}
