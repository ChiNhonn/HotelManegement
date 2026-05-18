using System;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Forms;

public sealed partial class BulkCreateRoomsDialog : Form
{
    private readonly IRoomService _roomService;
    private readonly IRoomTypeService _roomTypeService;

    public BulkCreateRoomsDialog(IRoomService roomService, IRoomTypeService roomTypeService)
    {
        _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
        _roomTypeService = roomTypeService ?? throw new ArgumentNullException(nameof(roomTypeService));
        InitializeComponent();
    }

    private void BulkCreateRoomsDialog_Load(object? sender, EventArgs e) => LoadData();

    private void LoadData()
    {
        var types = _roomTypeService.GetAll();
        cboRoomType.DataSource = types.ToList();
        cboRoomType.DisplayMember = nameof(Models.RoomType.Name);
        cboRoomType.ValueMember = nameof(Models.RoomType.Id);
        if (cboRoomType.Items.Count > 0)
            cboRoomType.SelectedIndex = 0;

        cboFloor.Items.Clear();
        cboFloor.Items.Add(new FloorListItem(null, "— Chưa gán —"));
        foreach (var f in _roomService.GetAllFloors().OrderBy(f => f.Name))
            cboFloor.Items.Add(new FloorListItem(f.Id, f.Name));
        cboFloor.SelectedIndex = 0;
    }

    private void BtnCreate_Click(object? sender, EventArgs e)
    {
        if (cboRoomType.SelectedValue is not int typeId || typeId <= 0)
        {
            MessageBox.Show("Chọn loại phòng.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var from = (int)numFrom.Value;
        var to = (int)numTo.Value;
        int? floorId = (cboFloor.SelectedItem as FloorListItem)?.Id;
        var prefix = txtPrefix.Text.Trim();

        try
        {
            var added = _roomService.BulkCreateRooms(floorId, typeId, from, to,
                string.IsNullOrEmpty(prefix) ? null : prefix);
            MessageBox.Show(
                $"Đã tạo {added} phòng mới. Các số trùng với phòng đã có sẽ được bỏ qua.",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
