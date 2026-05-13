using System;
using System.Drawing;
using System.Windows.Forms;
using HotelManagement.Forms;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.Services;
using HotelManagement.ViewModels;

namespace HotelManagement.CustomControls;

/// <summary>Ô phòng: Đặt / Hủy nhanh, hoặc Trả — Xem — Sửa khi có khách theo đơn.</summary>
public sealed class RoomBookingTile : UserControl
{
    private readonly IRoomService _rooms;
    private readonly IBookingService _booking;
    private readonly Func<DateTime> _viewDate;
    private readonly Action _onChanged;
    private readonly Action<string>? _applySearchHint;

    private readonly Label _lblNum = new();
    private readonly Panel _actionArea = new();
    private readonly Button _btn = new();
    private readonly TableLayoutPanel _guestGrid = new();
    private readonly Button _btnCheckout = new();
    private readonly Button _btnView = new();
    private readonly Button _btnEdit = new();

    private readonly Panel _cleaningPanel = new();
    private readonly Label _lblCleaningHead = new();
    private readonly Button _btnCleaningDone = new();

    private DashboardMiniRoomCell _cell = null!;

    private static readonly Color VacantGreen = Color.FromArgb(22, 163, 74);
    private static readonly Color BookedRed = Color.FromArgb(220, 38, 38);
    private static readonly Color CleaningYellow = Color.FromArgb(234, 179, 8);
    private static readonly Color MaintenanceGray = Color.FromArgb(100, 116, 139);

    public RoomBookingTile(
        IRoomService rooms,
        IBookingService booking,
        Func<DateTime> viewDate,
        Action onChanged,
        Action<string>? applySearchHint = null)
    {
        _rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
        _booking = booking ?? throw new ArgumentNullException(nameof(booking));
        _viewDate = viewDate ?? throw new ArgumentNullException(nameof(viewDate));
        _onChanged = onChanged ?? throw new ArgumentNullException(nameof(onChanged));
        _applySearchHint = applySearchHint;

        Dock = DockStyle.Fill;
        Margin = new Padding(5);
        Padding = new Padding(10, 10, 10, 8);

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2,
            ColumnCount = 1,
            Margin = new Padding(0)
        };
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        _lblNum.Dock = DockStyle.Fill;
        _lblNum.TextAlign = ContentAlignment.TopCenter;
        _lblNum.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold, GraphicsUnit.Point);
        _lblNum.Margin = new Padding(0, 0, 0, 4);

        _actionArea.Dock = DockStyle.Fill;
        _actionArea.Margin = new Padding(0, 2, 0, 0);

        _btn.Dock = DockStyle.Fill;
        _btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        _btn.FlatStyle = FlatStyle.Flat;
        _btn.Cursor = Cursors.Hand;
        _btn.Margin = new Padding(0);
        _actionArea.Controls.Add(_btn);

        _guestGrid.Dock = DockStyle.Fill;
        _guestGrid.Margin = new Padding(0);
        _guestGrid.RowCount = 3;
        _guestGrid.ColumnCount = 1;
        _guestGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
        _guestGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
        _guestGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
        _guestGrid.Visible = false;

        void StyleGuestButton(Button b, string text)
        {
            b.Text = text;
            b.Dock = DockStyle.Fill;
            b.Margin = new Padding(0, 0, 0, 4);
            b.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            b.FlatStyle = FlatStyle.Flat;
            b.Cursor = Cursors.Hand;
            b.BackColor = Color.FromArgb(254, 242, 242);
            b.ForeColor = Color.FromArgb(127, 29, 29);
            b.FlatAppearance.BorderColor = Color.FromArgb(252, 200, 200);
        }

        StyleGuestButton(_btnCheckout, "Trả");
        StyleGuestButton(_btnView, "Xem");
        StyleGuestButton(_btnEdit, "Sửa");
        _guestGrid.Controls.Add(_btnCheckout, 0, 0);
        _guestGrid.Controls.Add(_btnView, 0, 1);
        _guestGrid.Controls.Add(_btnEdit, 0, 2);
        _actionArea.Controls.Add(_guestGrid);

        _cleaningPanel.Dock = DockStyle.Fill;
        _cleaningPanel.Margin = new Padding(0);
        _cleaningPanel.Visible = false;
        var cleanLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2,
            ColumnCount = 1,
            Margin = new Padding(0)
        };
        cleanLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        cleanLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        _lblCleaningHead.Dock = DockStyle.Fill;
        _lblCleaningHead.Text = "Đang dọn";
        _lblCleaningHead.TextAlign = ContentAlignment.MiddleCenter;
        _lblCleaningHead.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        _lblCleaningHead.ForeColor = Color.FromArgb(120, 90, 0);

        _btnCleaningDone.Dock = DockStyle.Fill;
        _btnCleaningDone.Text = "Đã dọn xong";
        _btnCleaningDone.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
        _btnCleaningDone.FlatStyle = FlatStyle.Flat;
        _btnCleaningDone.Cursor = Cursors.Hand;
        _btnCleaningDone.Margin = new Padding(0, 4, 0, 0);
        _btnCleaningDone.BackColor = Color.FromArgb(255, 237, 150);
        _btnCleaningDone.ForeColor = Color.FromArgb(30, 41, 59);
        _btnCleaningDone.FlatAppearance.BorderColor = Color.FromArgb(180, 150, 30);
        _btnCleaningDone.Click += (_, _) => RunCleaningDone();

        cleanLayout.Controls.Add(_lblCleaningHead, 0, 0);
        cleanLayout.Controls.Add(_btnCleaningDone, 0, 1);
        _cleaningPanel.Controls.Add(cleanLayout);
        _actionArea.Controls.Add(_cleaningPanel);

        _btn.Click += Btn_Click;
        _btnCheckout.Click += (_, _) => RunGuestCheckout();
        _btnView.Click += (_, _) => RunGuestView();
        _btnEdit.Click += (_, _) => RunGuestEdit();

        layout.Controls.Add(_lblNum, 0, 0);
        layout.Controls.Add(_actionArea, 0, 1);
        Controls.Add(layout);
    }

    public void Bind(DashboardMiniRoomCell cell)
    {
        _cell = cell;
        _lblNum.Text = cell.Name;
        ApplyVisuals();
    }

    private bool IsQuickBookedHold() =>
        string.Equals(_cell.RawStatus?.Trim(), "booked", StringComparison.OrdinalIgnoreCase);

    private bool HasStayingGuest() => !string.IsNullOrWhiteSpace(_cell.GuestName);

    private bool ShowGuestActions() => HasStayingGuest() && _cell.ActiveOrderId is > 0;

    private void ApplyActionMode(bool guestActions)
    {
        _guestGrid.Visible = guestActions;
        _btn.Visible = !guestActions;
        if (guestActions)
            _btn.SendToBack();
        else
            _guestGrid.SendToBack();
    }

    private void RunCleaningDone()
    {
        try
        {
            _rooms.ReleaseRoomAfterHousekeeping(_cell.RoomId);
            _onChanged();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Chưa đánh dấu dọn xong được.\n{ex.Message}", "The Sea",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ApplyVisuals()
    {
        _btn.FlatAppearance.BorderSize = 1;

        if (_cell.Kind == RoomPhysicalStatusKind.Maintenance)
        {
            _cleaningPanel.Visible = false;
            ApplyActionMode(ShowGuestActions());
            BackColor = MaintenanceGray;
            _lblNum.ForeColor = Color.White;
            _btn.Text = "Bảo trì";
            _btn.Enabled = false;
            _btn.BackColor = Color.FromArgb(148, 163, 184);
            _btn.ForeColor = Color.White;
            _btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            return;
        }

        if (_cell.Kind == RoomPhysicalStatusKind.Cleaning)
        {
            ApplyActionMode(false);
            _guestGrid.Visible = false;
            _btn.Visible = false;
            _cleaningPanel.Visible = true;
            _cleaningPanel.BringToFront();

            BackColor = CleaningYellow;
            _lblNum.ForeColor = Color.FromArgb(30, 41, 59);
            return;
        }

        _cleaningPanel.Visible = false;

        ApplyActionMode(ShowGuestActions());

        if (_cell.Kind == RoomPhysicalStatusKind.Vacant && !IsQuickBookedHold())
        {
            BackColor = VacantGreen;
            _lblNum.ForeColor = Color.White;
            _btn.Text = "Đặt phòng";
            _btn.Enabled = true;
            _btn.BackColor = Color.White;
            _btn.ForeColor = Color.FromArgb(15, 23, 42);
            _btn.FlatAppearance.BorderColor = Color.FromArgb(220, 230, 220);
            _btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 253, 244);
            return;
        }

        if (HasStayingGuest())
        {
            BackColor = BookedRed;
            _lblNum.ForeColor = Color.White;
            if (ShowGuestActions())
            {
                foreach (Control c in _guestGrid.Controls)
                {
                    if (c is Button gb)
                    {
                        gb.Enabled = true;
                        gb.BackColor = Color.FromArgb(254, 242, 242);
                        gb.ForeColor = Color.FromArgb(127, 29, 29);
                    }
                }

                return;
            }

            _btn.Text = "Có khách (đơn)";
            _btn.Enabled = false;
            _btn.BackColor = Color.FromArgb(185, 28, 28);
            _btn.ForeColor = Color.White;
            _btn.FlatAppearance.BorderColor = Color.FromArgb(240, 180, 180);
            return;
        }

        BackColor = BookedRed;
        _lblNum.ForeColor = Color.White;
        _btn.Text = "Hủy phòng";
        _btn.Enabled = IsQuickBookedHold();
        _btn.BackColor = Color.White;
        _btn.ForeColor = Color.FromArgb(127, 29, 29);
        _btn.FlatAppearance.BorderColor = Color.FromArgb(252, 200, 200);
        _btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 226, 226);

        if (!_btn.Enabled)
        {
            _btn.Text = "Đang sử dụng";
            _btn.BackColor = Color.FromArgb(185, 28, 28);
            _btn.ForeColor = Color.White;
        }
    }

    private Form? OwnerForm() => FindForm() ?? Form.ActiveForm;

    private void RunGuestCheckout()
    {
        var id = _cell.ActiveOrderId;
        if (id is null or <= 0) return;
        try
        {
            var d = _booking.GetBookingDetails(id.Value, _cell.RoomId);
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
            _onChanged();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Trả phòng thất bại.\n{ex.Message}", "The Sea", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private void RunGuestView()
    {
        var id = _cell.ActiveOrderId;
        if (id is null or <= 0) return;
        try
        {
            var d = _booking.GetBookingDetails(id.Value, _cell.RoomId);
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
        var id = _cell.ActiveOrderId;
        if (id is null or <= 0) return;
        try
        {
            var d = _booking.GetBookingDetails(id.Value, _cell.RoomId);
            using var dlg = new BookingEditDialog(_booking, d);
            var owner = OwnerForm();
            if ((owner != null ? dlg.ShowDialog(owner) : dlg.ShowDialog()) == DialogResult.OK)
                _onChanged();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Không sửa được đặt phòng.\n{ex.Message}", "The Sea", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private void Btn_Click(object? sender, EventArgs e)
    {
        try
        {
            if (string.Equals(_btn.Text, "Đặt phòng", StringComparison.Ordinal))
            {
                if (_cell.Kind != RoomPhysicalStatusKind.Vacant)
                    return;
                using var dlg = new BookRoomDialog(
                    _booking,
                    _cell.RoomId,
                    _cell.Name,
                    _cell.RoomTypeName,
                    _cell.NightlyPrice,
                    _viewDate());
                var owner = OwnerForm();
                if ((owner != null ? dlg.ShowDialog(owner) : dlg.ShowDialog()) == DialogResult.OK)
                    _onChanged();
                return;
            }

            var room = _rooms.GetById(_cell.RoomId);
            if (room == null)
            {
                MessageBox.Show("Không tìm thấy phòng trong hệ thống.", "The Sea", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.Equals(_btn.Text, "Hủy phòng", StringComparison.Ordinal))
            {
                if (!IsQuickBookedHold())
                    return;
                room.Status = "available";
                _rooms.Update(room);
            }

            _onChanged();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Thao tác thất bại.\n{ex.Message}", "The Sea", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
