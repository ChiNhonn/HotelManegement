using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Forms
{
    public partial class UpdateRoomDialogForm : Form
    {
        private readonly IRoomService _phongService;
        private readonly IRoomTypeService _loaiPhongService;
        private readonly int _maPhong;

        public UpdateRoomDialogForm(IRoomService phongService, IRoomTypeService loaiPhongService, int maPhong)
        {
            InitializeComponent();
            _phongService = phongService;
            _loaiPhongService = loaiPhongService;
            _maPhong = maPhong;
        }

        private void loadComboRoomType()
        {
            var ds = _loaiPhongService.GetAll();
            cboLoaiPhong.DataSource = ds;
            cboLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboLoaiPhong.ValueMember = "MaLoaiPhong";
        }

        private void loadFloors()
        {
            cboFloor.Items.Clear();
            cboFloor.Items.Add(new FloorListItem(null, "-- Không gán tầng --"));
            foreach (var f in _phongService.GetAllFloors())
                cboFloor.Items.Add(new FloorListItem(f.Id, f.Name));
        }

        private void loadStatus()
        {
            cboTrangThai.Items.Add("Sẵn sàng");
            cboTrangThai.Items.Add("Đang ở");
            cboTrangThai.Items.Add("Bảo trì");
            cboTrangThai.SelectedIndex = 0;
        }

        private void loadData()
        {
            var phong = _phongService.GetById(_maPhong);
            if (phong == null)
            {
                MessageBox.Show("Không tìm thấy phòng.");
                return;
            }

            txtSoPhong.Text = phong.SoPhong;
            if (phong.MaLoaiPhong is { } lp)
                cboLoaiPhong.SelectedValue = lp;

            var displayStatus = RoomStatusMap.ToDisplay(phong.Status);
            if (!cboTrangThai.Items.Contains(displayStatus))
                cboTrangThai.Items.Add(displayStatus);
            cboTrangThai.SelectedItem = displayStatus;

            for (var i = 0; i < cboFloor.Items.Count; i++)
            {
                if (cboFloor.Items[i] is FloorListItem fl && fl.Id == phong.IdFloor)
                {
                    cboFloor.SelectedIndex = i;
                    return;
                }
            }

            cboFloor.SelectedIndex = 0;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboLoaiPhong.SelectedValue is not int loaiId || loaiId <= 0)
            {
                MessageBox.Show("Chọn loại phòng hợp lệ");
                return;
            }

            int? idFloor = (cboFloor.SelectedItem as FloorListItem)?.Id;

            var phong = new Room
            {
                MaPhong = _maPhong,
                SoPhong = txtSoPhong.Text.Trim(),
                MaLoaiPhong = loaiId,
                IdFloor = idFloor,
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Sẵn sàng",
            };

            try
            {
                _phongService.Update(phong);
                MessageBox.Show("Cập nhập phòng thành công");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void SuaPhongDialogForm_Load(object sender, EventArgs e)
        {
            loadComboRoomType();
            loadFloors();
            loadStatus();
            loadData();
        }
    }
}
