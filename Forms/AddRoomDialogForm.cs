using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Forms
{
    public partial class AddRoomDialogForm : Form
    {
        public int MaLoaiPhong { get; set; }
        public bool IsFromLoaiPhong { get; set; }
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomService _roomService;

        public AddRoomDialogForm(IRoomTypeService loaiPhongService, IRoomService phongService)
        {
            InitializeComponent();
            _roomTypeService = loaiPhongService;
            _roomService = phongService;
        }

        private void loadComboRoomType()
        {
            var ds = _roomTypeService.GetAll();
            cboLoaiPhong.DataSource = ds;
            cboLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboLoaiPhong.ValueMember = "MaLoaiPhong";
            if (IsFromLoaiPhong && MaLoaiPhong > 0)
            {
                cboLoaiPhong.SelectedValue = MaLoaiPhong;
                cboLoaiPhong.Enabled = false;
            }
        }

        private void loadFloors()
        {
            cboFloor.Items.Clear();
            cboFloor.Items.Add(new FloorListItem(null, "-- Không gán tầng --"));
            foreach (var f in _roomService.GetAllFloors())
                cboFloor.Items.Add(new FloorListItem(f.Id, f.Name));
            cboFloor.SelectedIndex = 0;
        }

        private void loadStatus()
        {
            cboTrangThai.Items.Add("Sẵn sàng");
            cboTrangThai.Items.Add("Đang ở");
            cboTrangThai.Items.Add("Bảo trì");
            cboTrangThai.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Chưa nhập số phòng");
                txtSoPhong.Focus();
                return;
            }

            if (cboLoaiPhong.SelectedValue is not int loaiId || loaiId <= 0)
            {
                MessageBox.Show("Chọn loại phòng hợp lệ");
                return;
            }

            int? idFloor = (cboFloor.SelectedItem as FloorListItem)?.Id;

            var phong = new Room
            {
                SoPhong = txtSoPhong.Text.Trim(),
                MaLoaiPhong = loaiId,
                IdFloor = idFloor,
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Sẵn sàng",
            };

            try
            {
                _roomService.Add(phong);
                MessageBox.Show("Thêm phòng thành công");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ThemPhongDialogForm_Load(object sender, EventArgs e)
        {
            loadComboRoomType();
            loadFloors();
            loadStatus();
        }
    }
}
