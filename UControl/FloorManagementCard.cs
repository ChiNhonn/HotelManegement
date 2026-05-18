using System;
using System.Drawing;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.ViewModels;

namespace HotelManagement.CustomControls;

/// <summary>Ô tầng trên lưới tab quản lý trạng thái tầng.</summary>
public sealed class FloorManagementCard : Panel
{
    private readonly Label _lblName = new();
    private readonly Label _lblStatus = new();
    private readonly Label _lblMeta = new();
    private readonly Button _btnToggle = new();

    private bool _selected;

    public FloorView Floor { get; private set; } = null!;

    public event EventHandler<FloorView>? FloorSelected;
    public event EventHandler<int>? ToggleRequested;

    public FloorManagementCard()
    {
        Size = new Size(320, 148);
        Margin = new Padding(8);
        Padding = new Padding(14, 12, 14, 12);
        BackColor = Color.White;
        Cursor = Cursors.Hand;

        _lblName.AutoSize = false;
        _lblName.Dock = DockStyle.Top;
        _lblName.Height = 28;
        _lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        _lblName.ForeColor = Color.FromArgb(15, 23, 42);

        _lblStatus.AutoSize = false;
        _lblStatus.Dock = DockStyle.Top;
        _lblStatus.Height = 24;
        _lblStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        _lblStatus.ForeColor = Color.FromArgb(71, 85, 105);

        _lblMeta.AutoSize = false;
        _lblMeta.Dock = DockStyle.Top;
        _lblMeta.Height = 40;
        _lblMeta.Font = new Font("Segoe UI", 9F);
        _lblMeta.ForeColor = Color.FromArgb(100, 116, 139);

        _btnToggle.Dock = DockStyle.Bottom;
        _btnToggle.Height = 34;
        _btnToggle.FlatStyle = FlatStyle.Flat;
        _btnToggle.Cursor = Cursors.Hand;
        _btnToggle.ForeColor = Color.White;
        _btnToggle.Click += (_, _) => ToggleRequested?.Invoke(this, Floor.FloorId);

        Controls.Add(_btnToggle);
        Controls.Add(_lblMeta);
        Controls.Add(_lblStatus);
        Controls.Add(_lblName);

        Click += OnSelect;
        _lblName.Click += OnSelect;
        _lblStatus.Click += OnSelect;
        _lblMeta.Click += OnSelect;
    }

    private void OnSelect(object? sender, EventArgs e)
    {
        if (sender == _btnToggle) return;
        FloorSelected?.Invoke(this, Floor);
    }

    public void Bind(FloorView floor, bool selected)
    {
        Floor = floor;
        Selected = selected;

        _lblName.Text = floor.FloorName;
        var locked = floor.IsLockedForBooking;
        _lblStatus.Text = floor.StatusDisplay;
        _lblStatus.ForeColor = locked
            ? Color.FromArgb(185, 28, 28)
            : Color.FromArgb(22, 163, 74);

        _lblMeta.Text =
            $"Chi nhánh: {floor.BranchDisplayName}\r\nSố phòng: {floor.RoomCount}  ·  ID: {floor.FloorId}";

        var mode = FloorStatusMap.DeriveMode(floor.StatusDb);
        _btnToggle.Text = mode == FloorOperationalMode.Open ? "Khóa bảo trì tầng" : "Mở tầng";
        _btnToggle.BackColor = mode == FloorOperationalMode.Open
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
