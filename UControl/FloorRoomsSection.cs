using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.ViewModels;

namespace HotelManagement.CustomControls;

/// <summary>Một khối tầng: tiêu đề + lưới ô phòng.</summary>
public sealed class FloorRoomsSection : Panel
{
    private readonly Label _lblTitle = new();
    private readonly Label _lblStatus = new();
    private readonly Button _btnFloorToggle = new();
    private readonly FlowLayoutPanel _roomFlow = new();

    private int _floorId;
    private FloorOperationalMode _mode = FloorOperationalMode.Open;

    public event EventHandler<int>? FloorToggleRequested;
    public event EventHandler<RoomView>? RoomSelected;

    public FloorRoomsSection()
    {
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Margin = new Padding(0, 0, 0, 16);
        Padding = new Padding(14, 12, 14, 14);
        BackColor = Color.White;
        MinimumSize = new Size(400, 80);
        Width = 900;

        var header = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            ColumnCount = 3,
            RowCount = 1,
            Margin = new Padding(0, 0, 0, 10)
        };
        header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
        header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));

        _lblTitle.AutoSize = true;
        _lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        _lblTitle.Text = "Tầng";

        _lblStatus.AutoSize = true;
        _lblStatus.Font = new Font("Segoe UI", 9.5F);
        _lblStatus.ForeColor = Color.FromArgb(71, 85, 105);
        _lblStatus.Anchor = AnchorStyles.Left;

        _btnFloorToggle.Anchor = AnchorStyles.Right;
        _btnFloorToggle.Size = new Size(150, 34);
        _btnFloorToggle.FlatStyle = FlatStyle.Flat;
        _btnFloorToggle.Cursor = Cursors.Hand;
        _btnFloorToggle.Click += (_, _) => FloorToggleRequested?.Invoke(this, _floorId);

        header.Controls.Add(_lblTitle, 0, 0);
        header.Controls.Add(_lblStatus, 1, 0);
        header.Controls.Add(_btnFloorToggle, 2, 0);

        _roomFlow.AutoSize = true;
        _roomFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        _roomFlow.Dock = DockStyle.Top;
        _roomFlow.WrapContents = true;
        _roomFlow.FlowDirection = FlowDirection.LeftToRight;
        _roomFlow.Padding = new Padding(4, 0, 4, 4);

        Controls.Add(_roomFlow);
        Controls.Add(header);
    }

    public void Bind(Floor floor, IReadOnlyList<RoomView> rooms, RoomView? selectedRoom)
    {
        _floorId = floor.Id;
        _mode = FloorStatusMap.DeriveMode(floor.Status);
        var locked = FloorStatusMap.IsLockedForBooking(floor.Status);

        _lblTitle.Text = floor.Name ?? $"Tầng #{floor.Id}";
        _lblStatus.Text = FloorStatusMap.ToDisplay(floor.Status)
                          + (rooms.Count > 0 ? $"  ·  {rooms.Count} phòng" : "  ·  Chưa có phòng");

        BackColor = locked ? Color.FromArgb(248, 250, 252) : Color.White;

        _btnFloorToggle.Text = _mode switch
        {
            FloorOperationalMode.Open => "Khóa bảo trì tầng",
            FloorOperationalMode.Maintenance => "Mở tầng",
            _ => "Mở tầng"
        };
        _btnFloorToggle.BackColor = locked
            ? Color.FromArgb(22, 163, 74)
            : Color.FromArgb(185, 28, 28);
        _btnFloorToggle.ForeColor = Color.White;

        _roomFlow.SuspendLayout();
        _roomFlow.Controls.Clear();
        foreach (var room in rooms.OrderBy(r => r.RoomNumber, StringComparer.OrdinalIgnoreCase))
        {
            var tile = new RoomManagementTile(room) { Selected = selectedRoom?.RoomId == room.RoomId };
            tile.TileClicked += (_, _) => RoomSelected?.Invoke(this, room);
            _roomFlow.Controls.Add(tile);
        }

        if (rooms.Count == 0)
        {
            _roomFlow.Controls.Add(new Label
            {
                AutoSize = true,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 9.5F),
                Margin = new Padding(8),
                Text = "Chưa có phòng trên tầng này."
            });
        }

        _roomFlow.ResumeLayout(true);
        PerformLayout();
    }

    public void UpdateSelection(RoomView? selectedRoom)
    {
        foreach (Control c in _roomFlow.Controls)
        {
            if (c is RoomManagementTile t)
                t.Selected = selectedRoom?.RoomId == t.Room.RoomId;
        }
    }
}
