using System;
using System.Drawing;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.ViewModels;

namespace HotelManagement.CustomControls;

/// <summary>Ô tầng trên lưới tab quản lý trạng thái tầng.</summary>
public partial class FloorManagementCard : UserControl
{
    private bool _selected;

    public FloorView Floor { get; private set; } = null!;

    public event EventHandler<FloorView>? FloorSelected;
    public event EventHandler<int>? ToggleRequested;

    public FloorManagementCard()
    {
        InitializeComponent();
        lblName.Click += OnSelect;
        lblStatus.Click += OnSelect;
        lblMeta.Click += OnSelect;
    }

    private void FloorManagementCard_Click(object? sender, EventArgs e) => OnSelect(sender, e);

    private void btnToggle_Click(object? sender, EventArgs e) =>
        ToggleRequested?.Invoke(this, Floor.FloorId);

    private void OnSelect(object? sender, EventArgs e)
    {
        if (sender == btnToggle) return;
        FloorSelected?.Invoke(this, Floor);
    }

    public void Bind(FloorView floor, bool selected)
    {
        Floor = floor;
        Selected = selected;

        lblName.Text = floor.FloorName;
        var locked = floor.IsLockedForBooking;
        lblStatus.Text = floor.StatusDisplay;
        lblStatus.ForeColor = locked
            ? Color.FromArgb(185, 28, 28)
            : Color.FromArgb(22, 163, 74);

        lblMeta.Text =
            $"Chi nhánh: {floor.BranchDisplayName}\r\nSố phòng: {floor.RoomCount}  ·  ID: {floor.FloorId}";

        var mode = FloorStatusMap.DeriveMode(floor.StatusDb);
        btnToggle.Text = mode == FloorOperationalMode.Open ? "Khóa bảo trì tầng" : "Mở tầng";
        btnToggle.BackColor = mode == FloorOperationalMode.Open
            ? Color.FromArgb(185, 28, 28)
            : Color.FromArgb(22, 163, 74);

        BackColor = locked ? Color.FromArgb(248, 250, 252) : Color.White;
    }

    public bool Selected
    {
        get => _selected;
        set
        {
            _selected = value;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var border = _selected ? Color.FromArgb(37, 99, 235) : Color.FromArgb(226, 232, 240);
        var w = _selected ? 2.5f : 1.5f;
        using var pen = new Pen(border, w);
        var r = ClientRectangle;
        r.Inflate(-1, -1);
        e.Graphics.DrawRectangle(pen, r);
    }
}
