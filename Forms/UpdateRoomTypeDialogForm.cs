using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Forms
{
    public partial class UpdateRoomTypeDialogForm : Form
    {
        private readonly IRoomTypeService _roomTypeService;
        private readonly int _roomTypeId;
        private string? _existingStoredImage;

        public UpdateRoomTypeDialogForm(IRoomTypeService roomTypeService, int roomTypeId)
        {
            _roomTypeService = roomTypeService;
            _roomTypeId = roomTypeId;
            InitializeComponent();
        }

        private void UpdateRoomTypeDialogForm_Load(object? sender, EventArgs e)
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

            LoadData();
        }

        private static string? BedTypeFromCombo(ComboBox cmb) =>
            cmb.SelectedItem is not null ? cmb.SelectedItem.ToString()?.Trim() : null;

        private void LoadData()
        {
            var t = _roomTypeService.GetById(_roomTypeId);
            if (t == null)
            {
                MessageBox.Show("Không tìm thấy loại phòng.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            txtTypeCode.Text = t.Code ?? "";
            txtDisplayName.Text = t.Name;
            numBasePrice.Value = Math.Clamp(t.UnitPrice, numBasePrice.Minimum, numBasePrice.Maximum);
            numMaxAdults.Value = Math.Clamp(t.MaxAdults, numMaxAdults.Minimum, numMaxAdults.Maximum);
            numMaxChildren.Value = Math.Clamp(t.MaxChildren, numMaxChildren.Minimum, numMaxChildren.Maximum);

            var bed = t.BedTypeDescription ?? "";
            if (string.IsNullOrWhiteSpace(bed))
            {
                cmbBedType.SelectedIndex = cmbBedType.Items.Count > 0 ? 0 : -1;
            }
            else
            {
                var idx = -1;
                for (var i = 0; i < cmbBedType.Items.Count; i++)
                {
                    if (string.Equals(cmbBedType.Items[i]?.ToString(), bed, StringComparison.Ordinal))
                    {
                        idx = i;
                        break;
                    }
                }

                if (idx >= 0)
                    cmbBedType.SelectedIndex = idx;
                else
                {
                    cmbBedType.Items.Add(bed);
                    cmbBedType.SelectedIndex = cmbBedType.Items.Count - 1;
                }
            }

            txtNotes.Text = t.DescriptionRoom?.Content ?? "";
            _existingStoredImage = t.DescriptionRoom?.ImageUrl;
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object? sender, EventArgs e)
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
                Id = _roomTypeId,
                Code = txtTypeCode.Text.Trim(),
                Name = txtDisplayName.Text.Trim(),
                UnitPrice = numBasePrice.Value,
                MaxAdults = (int)numMaxAdults.Value,
                MaxChildren = (int)numMaxChildren.Value,
                BedTypeDescription = string.IsNullOrWhiteSpace(bedType) ? null : bedType,
            };

            var note = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();
            if (!string.IsNullOrWhiteSpace(note) || !string.IsNullOrWhiteSpace(_existingStoredImage))
            {
                rt.DescriptionRoom = new DescriptionRoom
                {
                    Content = note,
                    ImageUrl = _existingStoredImage,
                };
            }

            try
            {
                _roomTypeService.Update(rt);
                MessageBox.Show("Đã cập nhật loại phòng.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
