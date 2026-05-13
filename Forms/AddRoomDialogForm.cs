using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Forms
{
    public partial class AddRoomDialogForm : Form
    {
        /// <summary>When &gt; 0 and <see cref="LockRoomTypeSelection"/> is true, pre-selects this room type and disables the combo.</summary>
        public int PresetRoomTypeId { get; set; }

        public bool LockRoomTypeSelection { get; set; }
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomService _roomService;
        private List<Floor> _floorsCache = new();

        public AddRoomDialogForm(IRoomTypeService roomTypeService, IRoomService roomService)
        {
            InitializeComponent();
            _roomTypeService = roomTypeService;
            _roomService = roomService;
        }

        private void LoadRoomTypeCombo()
        {
            cboRoomType.DataSource = null;
            var three = _roomTypeService.GetAll().OrderBy(x => x.Id).ToList();
            cboRoomType.DataSource = three;
            cboRoomType.DisplayMember = nameof(RoomType.Name);
            cboRoomType.ValueMember = nameof(RoomType.Id);
            if (LockRoomTypeSelection && PresetRoomTypeId > 0)
            {
                cboRoomType.SelectedValue = PresetRoomTypeId;
                cboRoomType.Enabled = false;
            }
            else if (three.Count > 0)
                cboRoomType.SelectedIndex = 0;
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập số phòng.");
                txtRoomNumber.Focus();
                return;
            }

            if (cboRoomType.SelectedValue is not int loaiId || loaiId <= 0)
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

            var phong = new Room
            {
                Name = txtRoomNumber.Text.Trim(),
                IdRoomType = loaiId,
                IdFloor = idFloor,
                Status = dbStatus,
            };

            try
            {
                _roomService.Add(phong);
                MessageBox.Show("Đã thêm phòng thành công.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AddRoomDialogForm_Load(object sender, EventArgs e)
        {
            _floorsCache = _roomService.GetAllFloors().ToList();
            LoadRoomTypeCombo();
            LoadFloorCombo();
            LoadStatusCombo();
            txtRoomNumber.TextChanged += TxtRoomNumber_TextChanged;
            TxtRoomNumber_TextChanged(null, EventArgs.Empty);
        }
    }
}
