using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Forms;

public partial class RoomEditDialogForm : Form
{
    private readonly IRoomService _roomService;
    private readonly IRoomTypeService _roomTypeService;
    private int? _editingRoomId;
    private List<Floor> _floorsCache = new();

    // Constructor chuẩn DI — Chỉ nhận các dịch vụ hệ thống
    public RoomEditDialogForm(IRoomService roomService, IRoomTypeService roomTypeService)
    {
        _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
        _roomTypeService = roomTypeService ?? throw new ArgumentNullException(nameof(roomTypeService));
        InitializeComponent();
    }

    // Hàm nhận ID từ bên ngoài (Method Injection)
    public void Setup(int? roomId = null)
    {
        _editingRoomId = roomId;

        // 1. Nạp dữ liệu bộ đệm và các ComboBox trước
        _floorsCache = _roomService.GetAllFloors().ToList();
        LoadRoomTypeCombo();
        LoadFloorCombo();
        LoadStatusCombo();

        // 🌟 2. QUAN TRỌNG: Đăng ký sự kiện gõ chữ NGAY TẠI ĐÂY để chắc chắn 100% nó hoạt động
        txtRoomNumber.TextChanged -= TxtRoomNumber_TextChanged; // Hủy đăng ký cũ nếu có để tránh trùng lặp
        txtRoomNumber.TextChanged += TxtRoomNumber_TextChanged; // Đăng ký mới

        // 3. Phân nhánh logic Thêm mới / Sửa đổi
        if (_editingRoomId is { } editId && editId > 0)
        {
            LoadExistingRoom();
        }
        else
        {
            // Thiết lập trạng thái ban đầu cho form Thêm mới
            txtRoomNumber.Clear();
            if (cboRoomType.Items.Count > 0) cboRoomType.SelectedIndex = 0;
            if (cboFloor.Items.Count > 0) cboFloor.SelectedIndex = 0;
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0; // "Sẵn sàng"
        }

        // Kích hoạt nhận diện tầng lần đầu tiên dựa trên dữ liệu hiện tại
        TxtRoomNumber_TextChanged(null, EventArgs.Empty);
    }
    private void LoadRoomTypeCombo()
    {
        var ds = _roomTypeService.GetAll();
        cboRoomType.DataSource = ds;
        cboRoomType.DisplayMember = nameof(Models.RoomType.Name);
        cboRoomType.ValueMember = nameof(Models.RoomType.Id);
    }

    private void LoadFloorCombo()
    {
        cboFloor.Items.Clear();
        cboFloor.Items.Add(new FloorListItem(null, "— (theo số phòng) —"));
        foreach (var f in _floorsCache.OrderBy(x => x.Name))
            cboFloor.Items.Add(new FloorListItem(f.Id, f.Name));
        cboFloor.SelectedIndex = 0;
    }

    private void LoadStatusCombo()
    {
        cboStatus.Items.Clear();
        cboStatus.Items.Add("Sẵn sàng");
        cboStatus.Items.Add("Đang ở");
        cboStatus.Items.Add("Bảo trì");
        cboStatus.Items.Add("Hỏng / Khóa");
        cboStatus.Items.Add("Ngưng dùng");
        cboStatus.SelectedIndex = 0;
    }

    private void LoadExistingRoom()
    {
        var room = _roomService.GetById(_editingRoomId!.Value);

        if (room == null)
        {
            MessageBox.Show(this, $"Không tìm thấy dữ liệu trong hệ thống cho phòng ID = {_editingRoomId!.Value}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        txtRoomNumber.Text = room.Name ?? "";

        if (room.IdRoomType is { } lp)
            cboRoomType.SelectedValue = lp;

        var displayStatus = RoomStatusMap.ToDisplay(room.Status);
        if (string.IsNullOrWhiteSpace(displayStatus))
            displayStatus = room.Status ?? "";

        if (!cboStatus.Items.Cast<object>().Any(o => o.ToString() == displayStatus))
            cboStatus.Items.Add(displayStatus);

        cboStatus.SelectedItem = displayStatus;
    }

    private void TxtRoomNumber_TextChanged(object? sender, EventArgs e)
    {
        var key = txtRoomNumber.Text.Trim();
        var fn = RoomNumberFloorHelper.TryInferFloorNumber(key);
        if (fn is not { } floorNum)
        {
            if (cboFloor.Items.Count > 0)
                cboFloor.SelectedIndex = 0;
            return;
        }

        var match = RoomNumberFloorHelper.MatchFloor(_floorsCache, floorNum);
        for (var i = 0; i < cboFloor.Items.Count; i++)
        {
            if (cboFloor.Items[i] is FloorListItem fl && fl.Id == match?.Id)
            {
                cboFloor.SelectedIndex = i;
                return;
            }
        }

        cboFloor.SelectedIndex = 0;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        var name = txtRoomNumber.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show(this, "Vui lòng nhập số phòng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtRoomNumber.Focus();
            return;
        }

        if (cboRoomType.SelectedValue is not int typeId || typeId <= 0)
        {
            MessageBox.Show(this, "Vui lòng chọn loại phòng hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var floorNum = RoomNumberFloorHelper.TryInferFloorNumber(name);
        if (floorNum is { } fn && RoomNumberFloorHelper.MatchFloor(_floorsCache, fn) == null)
        {
            MessageBox.Show(this,
                $"Hệ thống gợi ý số phòng này thuộc tầng {fn}, nhưng hiện tại chưa có tầng này trong cơ sở dữ liệu.\nHãy tạo tầng trước hoặc thay đổi cấu trúc số phòng.",
                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int? idFloor = (cboFloor.SelectedItem as FloorListItem)?.Id;
        var dbStatus = RoomStatusMap.ToDatabase(cboStatus.Text);

        var room = new Room
        {
            Name = name,
            IdRoomType = typeId,
            IdFloor = idFloor,
            Status = dbStatus,
        };

        try
        {
            if (_editingRoomId is { } editId && editId > 0)
            {
                room.Id = editId;
                _roomService.Update(room);
                MessageBox.Show(this, "Cập nhật thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _roomService.Add(room);
                MessageBox.Show(this, "Thêm mới phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}