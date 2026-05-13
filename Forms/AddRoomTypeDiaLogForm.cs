using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Forms
{
    public partial class AddRoomTypeDiaLogForm : Form
    {
        private readonly IRoomTypeService _roomTypeService;

        public AddRoomTypeDiaLogForm(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
            InitializeComponent();
        }

        private void AddRoomTypeDiaLogForm_Load(object? sender, EventArgs e)
        {
            cmbBedType.Items.Clear();
            cmbBedType.Items.AddRange(new object[]
            {
                "1 giường đôi (King / Queen)",
                "2 giường đơn (Twin)",
                "1 giường đôi + sofa bed",
                "2 giường đôi (2 King — Suite lớn)",
                "Giường tầng (Bunk) — phòng gia đình",
                "Phòng studio — giường + bếp nhỏ"
            });
            cmbBedType.SelectedIndex = 0;

            numBasePrice.Value = 800_000;
        }

        private static string? BedTypeFromCombo(ComboBox cmb) =>
            cmb.SelectedItem is not null ? cmb.SelectedItem.ToString()?.Trim() : null;

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDisplayName.Text))
            {
                MessageBox.Show("Nhập tên loại phòng.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDisplayName.Focus();
                return;
            }

            var bedType = BedTypeFromCombo(cmbBedType);
            var rt = new RoomType
            {
                Code = txtTypeCode.Text.Trim(),
                Name = txtDisplayName.Text.Trim(),
                UnitPrice = numBasePrice.Value,
                MaxAdults = (int)numMaxAdults.Value,
                MaxChildren = (int)numMaxChildren.Value,
                BedTypeDescription = string.IsNullOrWhiteSpace(bedType) ? null : bedType,
            };

            if (!string.IsNullOrWhiteSpace(txtNotes.Text))
            {
                rt.DescriptionRoom = new DescriptionRoom
                {
                    Content = txtNotes.Text.Trim(),
                };
            }

            try
            {
                _roomTypeService.Add(rt);
                MessageBox.Show("Đã thêm loại phòng.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                var addRooms = MessageBox.Show(
                    "Bạn có muốn thêm phòng cho loại này ngay không?",
                    Text,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                Tag = addRooms == DialogResult.Yes ? rt : null;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
