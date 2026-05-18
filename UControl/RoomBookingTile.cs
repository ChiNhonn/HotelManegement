using System;
using System.Drawing;
using System.Windows.Forms;
using HotelManagement.Forms;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.Services;
using HotelManagement.ViewModels;

namespace HotelManagement.CustomControls;

/// <summary>Ô phòng: layout trong <c>RoomBookingTile.Designer.cs</c> (kéo thả Designer).</summary>
public partial class RoomBookingTile : UserControl
{
    private IRoomService? _rooms;
    private IBookingService? _booking;
    private Func<DateTime>? _viewDate;
    private Action? _onChanged;
    private Action<string>? _applySearchHint;

    private DashboardMiniRoomCell _cell = null!;

    private static readonly Color VacantGreen = Color.FromArgb(22, 163, 74);
    private static readonly Color BookedRed = Color.FromArgb(220, 38, 38);
    private static readonly Color CleaningYellow = Color.FromArgb(234, 179, 8);
    private static readonly Color MaintenanceGray = Color.FromArgb(100, 116, 139);

    /// <summary>Constructor cho Visual Studio Designer (kéo thả).</summary>
    public RoomBookingTile()
    {
        InitializeComponent();
    }

    public RoomBookingTile(
        IRoomService rooms,
        IBookingService booking,
        Func<DateTime> viewDate,
        Action onChanged,
        Action<string>? applySearchHint = null)
        : this()
    {
        _rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
        _booking = booking ?? throw new ArgumentNullException(nameof(booking));
        _viewDate = viewDate ?? throw new ArgumentNullException(nameof(viewDate));
        _onChanged = onChanged ?? throw new ArgumentNullException(nameof(onChanged));
        _applySearchHint = applySearchHint;

        WireRuntimeEvents();
    }

    private void WireRuntimeEvents()
    {
        btnPrimary.Click += Btn_Click;
        btnCheckout.Click += (_, _) => RunGuestCheckout();
        btnView.Click += (_, _) => RunGuestView();
        btnEdit.Click += (_, _) => RunGuestEdit();
        btnCleaningDone.Click += (_, _) => RunCleaningDone();
    }

    private bool IsRuntimeReady =>
        _rooms != null && _booking != null && _viewDate != null && _onChanged != null;

    public void Bind(DashboardMiniRoomCell cell)
    {
        _cell = cell;
        lblNum.Text = cell.Name;
        ApplyVisuals();
    }

    private bool IsQuickBookedHold() =>
        string.Equals(_cell.RawStatus?.Trim(), "booked", StringComparison.OrdinalIgnoreCase);

    private bool HasStayingGuest() => !string.IsNullOrWhiteSpace(_cell.GuestName);

    private bool ShowGuestActions() => HasStayingGuest() && _cell.ActiveOrderId is > 0;

    private void ApplyActionMode(bool guestActions)
    {
        tblGuest.Visible = guestActions;
        btnPrimary.Visible = !guestActions;
        if (guestActions)
            tblGuest.BringToFront();
        else
            btnPrimary.BringToFront();
    }

    private void RunCleaningDone()
    {
        if (!IsRuntimeReady) return;
        try
        {
            _rooms!.ReleaseRoomAfterHousekeeping(_cell.RoomId);
            _onChanged!();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Chưa đánh dấu dọn xong được.\n{ex.Message}", "The Sea",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ApplyVisuals()
    {
        btnPrimary.FlatAppearance.BorderSize = 1;

        if (_cell.Kind == RoomPhysicalStatusKind.Maintenance)
        {
            pnlCleaning.Visible = false;
            ApplyActionMode(ShowGuestActions());
            BackColor = MaintenanceGray;
            lblNum.ForeColor = Color.White;
            btnPrimary.Text = "Bảo trì";
            btnPrimary.Enabled = false;
            btnPrimary.BackColor = Color.FromArgb(148, 163, 184);
            btnPrimary.ForeColor = Color.White;
            btnPrimary.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            return;
        }

        if (_cell.Kind == RoomPhysicalStatusKind.Cleaning)
        {
            ApplyActionMode(false);
            tblGuest.Visible = false;
            btnPrimary.Visible = false;
            pnlCleaning.Visible = true;
            pnlCleaning.BringToFront();

            BackColor = CleaningYellow;
            lblNum.ForeColor = Color.FromArgb(30, 41, 59);
            return;
        }

        pnlCleaning.Visible = false;

        ApplyActionMode(ShowGuestActions());

        if (_cell.Kind == RoomPhysicalStatusKind.Vacant && !IsQuickBookedHold())
        {
            BackColor = VacantGreen;
            lblNum.ForeColor = Color.White;
            btnPrimary.Text = "Đặt phòng";
            btnPrimary.Enabled = true;
            btnPrimary.Visible = true;
            btnPrimary.BackColor = Color.White;
            btnPrimary.ForeColor = Color.FromArgb(15, 23, 42);
            btnPrimary.FlatAppearance.BorderColor = Color.FromArgb(220, 230, 220);
            btnPrimary.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 253, 244);
            btnPrimary.BringToFront();
            return;
        }

        if (HasStayingGuest())
        {
            BackColor = BookedRed;
            lblNum.ForeColor = Color.White;
            if (ShowGuestActions())
            {
                foreach (Control c in tblGuest.Controls)
                {
                    if (c is Button gb)
                    {
                        gb.Enabled = true;
                        gb.BackColor = Color.FromArgb(254, 242, 242);
                        gb.ForeColor = Color.FromArgb(127, 29, 29);
                    }
                }

                tblGuest.BringToFront();
                return;
            }

            btnPrimary.Text = "Có khách (đơn)";
            btnPrimary.Enabled = false;
            btnPrimary.BackColor = Color.FromArgb(185, 28, 28);
            btnPrimary.ForeColor = Color.White;
            btnPrimary.FlatAppearance.BorderColor = Color.FromArgb(240, 180, 180);
            return;
        }

        BackColor = BookedRed;
        lblNum.ForeColor = Color.White;
        btnPrimary.Text = "Hủy phòng";
        btnPrimary.Enabled = IsQuickBookedHold();
        btnPrimary.BackColor = Color.White;
        btnPrimary.ForeColor = Color.FromArgb(127, 29, 29);
        btnPrimary.FlatAppearance.BorderColor = Color.FromArgb(252, 200, 200);
        btnPrimary.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 226, 226);

        if (!btnPrimary.Enabled)
        {
            btnPrimary.Text = "Đang sử dụng";
            btnPrimary.BackColor = Color.FromArgb(185, 28, 28);
            btnPrimary.ForeColor = Color.White;
        }
    }

    private Form? OwnerForm() => FindForm() ?? Form.ActiveForm;

    private void RunGuestCheckout()
    {
        if (!IsRuntimeReady) return;
        var id = _cell.ActiveOrderId;
        if (id is null or <= 0) return;
        try
        {
            var d = _booking!.GetBookingDetails(id.Value, _cell.RoomId);
            if (!d.CheckOut.HasValue)
            {
                MessageBox.Show("Đơn chưa có ngày trả dự kiến.", "The Sea", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using var dlg = new CheckoutEarlyDialog(d.CheckIn.Date, d.CheckOut.Value.Date, _cell.Name);
            var owner = OwnerForm();
            if ((owner != null ? dlg.ShowDialog(owner) : dlg.ShowDialog()) != DialogResult.OK)
                return;
            _booking.CheckoutEarly(id.Value, dlg.SelectedDate);
            _onChanged!();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Trả phòng thất bại.\n{ex.Message}", "The Sea", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private void RunGuestView()
    {
        if (!IsRuntimeReady) return;
        var id = _cell.ActiveOrderId;
        if (id is null or <= 0) return;
        try
        {
            var d = _booking!.GetBookingDetails(id.Value, _cell.RoomId);
            var owner = OwnerForm();
            Action<string> hint = _applySearchHint ?? (_ => { });
            using var dlg = new BookingViewDialog(d, hint);
            if (owner != null)
                dlg.ShowDialog(owner);
            else
                dlg.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Không mở được chi tiết.\n{ex.Message}", "The Sea", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private void RunGuestEdit()
    {
        if (!IsRuntimeReady) return;
        var id = _cell.ActiveOrderId;
        if (id is null or <= 0) return;
        try
        {
            var d = _booking!.GetBookingDetails(id.Value, _cell.RoomId);
            using var dlg = new BookingEditDialog(_booking, d);
            var owner = OwnerForm();
            if ((owner != null ? dlg.ShowDialog(owner) : dlg.ShowDialog()) == DialogResult.OK)
                _onChanged!();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Không sửa được đặt phòng.\n{ex.Message}", "The Sea", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private void Btn_Click(object? sender, EventArgs e)
    {
        if (!IsRuntimeReady) return;
        try
        {
            if (string.Equals(btnPrimary.Text, "Đặt phòng", StringComparison.Ordinal))
            {
                if (_cell.Kind != RoomPhysicalStatusKind.Vacant)
                    return;
                using var dlg = new BookRoomDialog(
                    _booking!,
                    _cell.RoomId,
                    _cell.Name,
                    _cell.RoomTypeName,
                    _cell.NightlyPrice,
                    _viewDate!());
                var owner = OwnerForm();
                if ((owner != null ? dlg.ShowDialog(owner) : dlg.ShowDialog()) == DialogResult.OK)
                    _onChanged!();
                return;
            }

            var room = _rooms!.GetById(_cell.RoomId);
            if (room == null)
            {
                MessageBox.Show("Không tìm thấy phòng trong hệ thống.", "The Sea", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.Equals(btnPrimary.Text, "Hủy phòng", StringComparison.Ordinal))
            {
                if (!IsQuickBookedHold())
                    return;
                room.Status = "available";
                _rooms.Update(room);
            }

            _onChanged!();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Thao tác thất bại.\n{ex.Message}", "The Sea", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
