using System;
using System.Windows.Forms;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Forms;

public partial class RoomTypeEditDialogForm : Form
{
    private readonly IRoomTypeService _roomTypeService;
    private int? _roomTypeId;
    private string? _existingStoredImage;

    // Constructor chuẩn DI — Chỉ nhận service
    public RoomTypeEditDialogForm(IRoomTypeService roomTypeService)
    {
        _roomTypeService = roomTypeService ?? throw new ArgumentNullException(nameof(roomTypeService));
        InitializeComponent();
    }

    // Hàm gán dữ liệu từ bên ngoài (Method Injection)
    public void Setup(int? roomTypeId = null)
    {
        _roomTypeId = roomTypeId;

        // 1. Nạp danh sách cứng vào ComboBox trước khi đổ dữ liệu
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

        // 2. CHẠY NGAY TẠI ĐÂY: Kiểm tra chế độ Thêm mới hay Sửa đổi để nạp dữ liệu luôn
        if (_roomTypeId is { } editId && editId > 0)
        {
            LoadData(editId);
        }
        else
        {
            // Reset toàn bộ trường thông tin về trạng thái trống khi Thêm mới
            txtTypeCode.Clear();
            txtDisplayName.Clear();
            numBasePrice.Value = numBasePrice.Minimum;
            numMaxAdults.Value = numMaxAdults.Minimum;
            numMaxChildren.Value = numMaxChildren.Minimum;
            txtNotes.Clear();
            _existingStoredImage = null;
            if (cmbBedType.Items.Count > 0) cmbBedType.SelectedIndex = 0;
        }
    }

    private void RoomTypeEditDialogForm_Load(object? sender, EventArgs e)
    {
        // Hàm này giờ chỉ làm nhiệm vụ đổi tiêu đề Form để tránh lỗi mất liên kết Designer
        Text = _roomTypeId is { } id && id > 0 ? "Sửa loại phòng" : "Thêm loại phòng";
    }

    private static string? BedTypeFromCombo(ComboBox cmb) =>
        cmb.SelectedItem is not null ? cmb.SelectedItem.ToString()?.Trim() : null;

    private void LoadData(int id)
    {
        var t = _roomTypeService.GetById(id);
        if (t == null)
        {
            MessageBox.Show(this, "Không tìm thấy thông tin loại phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        txtTypeCode.Text = t.Code ?? "";
        txtDisplayName.Text = t.Name ?? "";
        numBasePrice.Value = Math.Clamp(t.UnitPrice, numBasePrice.Minimum, numBasePrice.Maximum);
        numMaxAdults.Value = Math.Clamp(t.MaxAdults, numMaxAdults.Minimum, numMaxAdults.Maximum);
        numMaxChildren.Value = Math.Clamp(t.MaxChildren, numMaxChildren.Minimum, numMaxChildren.Maximum);

        var bed = t.BedTypeDescription?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(bed))
        {
            cmbBedType.SelectedIndex = cmbBedType.Items.Count > 0 ? 0 : -1;
        }
        else
        {
            var idx = -1;
            for (var i = 0; i < cmbBedType.Items.Count; i++)
            {
                if (string.Equals(cmbBedType.Items[i]?.ToString()?.Trim(), bed, StringComparison.OrdinalIgnoreCase))
                {
                    idx = i;
                    break;
                }
            }

            if (idx >= 0)
            {
                cmbBedType.SelectedIndex = idx;
            }
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
            MessageBox.Show(this, "Vui lòng nhập tên loại phòng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (_roomTypeId is { } editId && editId > 0)
            {
                rt.Id = editId;
                _roomTypeService.Update(rt);
                MessageBox.Show(this, "Cập nhật loại phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _roomTypeService.Add(rt);
                MessageBox.Show(this, "Thêm mới loại phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}