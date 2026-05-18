using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.Forms;

public partial class FloorEditDialogForm : Form
{
    private readonly IFloorService _floorService;
    private int? _editingFloorId;
    private int? _lockedSingleBranchId;

    public FloorEditDialogForm(IFloorService floorService)
    {
        _floorService = floorService ?? throw new ArgumentNullException(nameof(floorService));
        InitializeComponent();
    }

    public void Setup(int? editingFloorId = null)
    {
        _editingFloorId = editingFloorId;

        // 1. Chuẩn bị ComboBox Chi nhánh
        bool isBranchReady = SetupBranchComboBox();
        if (!isBranchReady) return;

        // 2. Phân nhánh nạp dữ liệu
        if (IsEditMode())
        {
            LoadOldFloorData();
        }
        else
        {
            PrepareNewFloorData();
        }
    }

    private void FloorEditDialogForm_Load(object? sender, EventArgs e)
    {
        Text = IsEditMode() ? "Sửa tầng" : "Thêm tầng";
    }

    // ==========================================
    // CÁC HÀM HỖ TRỢ XỬ LÝ LOGIC (Tách nhỏ để dễ đọc)
    // ==========================================

    private bool IsEditMode()
    {
        // Trả về true nếu ID có giá trị và lớn hơn 0
        return _editingFloorId.HasValue && _editingFloorId.Value > 0;
    }

    private bool SetupBranchComboBox()
    {
        var branches = _floorService.GetActiveBranchesOrdered();

        if (branches.Count == 0)
        {
            MessageBox.Show(this, "Chưa có chi nhánh hoạt động nào. Vui lòng thêm chi nhánh trước.", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.Cancel;
            Close();
            return false;
        }

        if (branches.Count == 1)
        {
            // Chỉ có 1 chi nhánh -> Giấu ComboBox đi
            _lockedSingleBranchId = branches[0].Id;
            HideBranchUI();
        }
        else
        {
            // Nhiều chi nhánh -> Nạp vào ComboBox
            var list = branches.Select(b => new BranchListItem(b.Id, BranchDisplayHelper.Format(b))).ToList();
            cmbBranch.DisplayMember = nameof(BranchListItem.Label);
            cmbBranch.ValueMember = nameof(BranchListItem.Id);
            cmbBranch.DataSource = list;
        }

        return true;
    }

    private void HideBranchUI()
    {
        lblBranch.Visible = false;
        cmbBranch.Visible = false;

        // Co kích thước Form lại để lấp đi khoảng trống của ComboBox vừa giấu
        tlpTang.RowStyles[1].SizeType = SizeType.Absolute;
        tlpTang.RowStyles[1].Height = 0;

        var innerH = tlpTang.PreferredSize.Height + 24;
        ClientSize = new System.Drawing.Size(ClientSize.Width, innerH);
        MinimumSize = new System.Drawing.Size(MinimumSize.Width, innerH);
    }

    private void LoadOldFloorData()
    {
        var floor = _floorService.GetById(_editingFloorId!.Value);

        if (floor == null)
        {
            MessageBox.Show(this, "Không tìm thấy thông tin tầng cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        txtName.Text = floor.Name ?? "";

        // Chọn lại chi nhánh cũ trên ComboBox
        if (_lockedSingleBranchId == null && cmbBranch.DataSource is List<BranchListItem> items)
        {
            var index = items.FindIndex(x => x.Id == floor.IdBranch);
            if (index >= 0)
            {
                cmbBranch.SelectedIndex = index;
            }
        }
    }

    private void PrepareNewFloorData()
    {
        txtName.Clear();
        if (cmbBranch.Items.Count > 0)
        {
            cmbBranch.SelectedIndex = 0;
        }
    }

    // ==========================================
    // XỬ LÝ SỰ KIỆN NÚT BẤM
    // ==========================================

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        var name = txtName.Text?.Trim() ?? "";

        int? branchId = _lockedSingleBranchId;
        if (branchId == null)
        {
            if (cmbBranch.SelectedValue is not int bid)
            {
                MessageBox.Show(this, "Vui lòng chọn chi nhánh trực thuộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            branchId = bid;
        }

        try
        {
            if (IsEditMode())
            {
                var floorToUpdate = new Floor { Id = _editingFloorId!.Value, Name = name, IdBranch = branchId };
                _floorService.Update(floorToUpdate);
            }
            else
            {
                var newFloor = new Floor { Name = name, IdBranch = branchId };
                _floorService.Add(newFloor);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    // ==========================================
    // CLASS CHUYÊN CHỞ DỮ LIỆU (DTO)
    // ==========================================

    private class BranchListItem
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public BranchListItem(int id, string label)
        {
            Id = id;
            Label = label;
        }
    }
}