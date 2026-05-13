using System.Collections.Generic;
using System.Linq;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Forms
{
    public partial class UpdateRoomDialogForm : Form
    {
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly int _roomId;
        private List<Floor> _floorsCache = new();

        public UpdateRoomDialogForm(IRoomService roomService, IRoomTypeService roomTypeService, int roomId)
        {
            InitializeComponent();
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _roomId = roomId;
        }

        private void LoadRoomTypeCombo()
        {
            var ds = _roomTypeService.GetAll();
            cboRoomType.DataSource = ds;
            cboRoomType.DisplayMember = nameof(RoomType.Name);
            cboRoomType.ValueMember = nameof(RoomType.Id);
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
            var room = _roomService.GetById(_roomId);
            if (room == null)
            {
                MessageBox.Show("Không tìm thấy phòng.");
                return;
            }

            txtRoomNumber.Text = room.Name;
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cboRoomType.SelectedValue is not int typeId || typeId <= 0)
            {
                MessageBox.Show("Chọn loại phòng hợp lệ.");
                return;
            }

            var floorNum = RoomNumberFloorHelper.TryInferFloorNumber(txtRoomNumber.Text);
            if (floorNum is { } fn && RoomNumberFloorHelper.MatchFloor(_floorsCache, fn) == null)
            {
                MessageBox.Show(
                    $"Số phòng gợi ý tầng {fn}, nhưng chưa có tầng tương ứng. Hãy thêm tầng hoặc đổi số phòng.");
                return;
            }

            int? idFloor = (cboFloor.SelectedItem as FloorListItem)?.Id;

            var dbStatus = RoomStatusMap.ToDatabase(cboStatus.SelectedItem?.ToString());

            var room = new Room
            {
                Id = _roomId,
                Name = txtRoomNumber.Text.Trim(),
                IdRoomType = typeId,
                IdFloor = idFloor,
                Status = dbStatus,
            };

            try
            {
                _roomService.Update(room);
                MessageBox.Show("Đã cập nhật phòng thành công.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void UpdateRoomDialogForm_Load(object sender, EventArgs e)
        {
            _floorsCache = _roomService.GetAllFloors().ToList();
            LoadRoomTypeCombo();
            LoadFloorCombo();
            LoadStatusCombo();
            txtRoomNumber.TextChanged += TxtRoomNumber_TextChanged;
            LoadExistingRoom();
            TxtRoomNumber_TextChanged(null, EventArgs.Empty);
        }
    }
}
