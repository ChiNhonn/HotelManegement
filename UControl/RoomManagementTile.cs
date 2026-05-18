using System;
using System.Drawing;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.ViewModels;

namespace HotelManagement.CustomControls;

/// <summary>Ô phòng trên lưới quản lý (theo tầng).</summary>
public sealed class RoomManagementTile : Panel
{
    private static readonly Color Vacant = Color.FromArgb(22, 163, 74);
    private static readonly Color Occupied = Color.FromArgb(220, 38, 38);
    private static readonly Color Cleaning = Color.FromArgb(234, 179, 8);
    private static readonly Color Locked = Color.FromArgb(100, 116, 139);
    private static readonly Color SelectedBorder = Color.FromArgb(37, 99, 235);

    private readonly Label _lblNum = new();
    private readonly Label _lblSub = new();
    private bool _selected;

    public RoomView Room { get; }

    public event EventHandler? TileClicked;

    public RoomManagementTile(RoomView room)
    {
        Room = room;
        Size = new Size(108, 72);
        Margin = new Padding(6);
        Cursor = Cursors.Hand;
        Padding = new Padding(8, 6, 8, 4);
        BackColor = Color.White;

        _lblNum.Dock = DockStyle.Top;
        _lblNum.Height = 26;
        _lblNum.TextAlign = ContentAlignment.MiddleCenter;
        _lblNum.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        _lblNum.Text = room.RoomNumber;

        _lblSub.Dock = DockStyle.Fill;
        _lblSub.TextAlign = ContentAlignment.TopCenter;
        _lblSub.Font = new Font("Segoe UI", 7.5F);
        _lblSub.ForeColor = Color.FromArgb(71, 85, 105);
        _lblSub.Text = room.RoomTypeName;

        Controls.Add(_lblSub);
        Controls.Add(_lblNum);

        Click += (_, _) => TileClicked?.Invoke(this, EventArgs.Empty);
        _lblNum.Click += (_, _) => TileClicked?.Invoke(this, EventArgs.Empty);
        _lblSub.Click += (_, _) => TileClicked?.Invoke(this, EventArgs.Empty);

        ApplyColors();
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

    private void ApplyColors()
    {
        var accent = AccentFor(Room.StatusDb);
        BackColor = Color.FromArgb(248, 250, 252);
        _lblNum.ForeColor = accent;
    }

    private static Color AccentFor(string? statusDb)
    {
        return RoomStatusMap.ClassifyPhysicalKind(statusDb) switch
        {
            RoomPhysicalStatusKind.Vacant => Vacant,
            RoomPhysicalStatusKind.Occupied => Occupied,
            RoomPhysicalStatusKind.Cleaning => Cleaning,
            RoomPhysicalStatusKind.Maintenance => Locked,
            _ => Color.FromArgb(51, 65, 85)
        };
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var accent = AccentFor(Room.StatusDb);
        var border = _selected ? SelectedBorder : accent;
        var w = _selected ? 3 : 2;
        using var pen = new Pen(border, w);
        var r = ClientRectangle;
        r.Inflate(-1, -1);
        e.Graphics.DrawRectangle(pen, r);
    }
}
