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
    private readonly int? _editingFloorId;
    private int? _lockedSingleBranchId;

    public FloorEditDialogForm(IFloorService floorService, int? editingFloorId = null)
    {
        _floorService = floorService ?? throw new ArgumentNullException(nameof(floorService));
        _editingFloorId = editingFloorId;
        InitializeComponent();
    }

    private void FloorEditDialogForm_Load(object? sender, EventArgs e)
    {
        Text = _editingFloorId is { } id && id > 0 ? "Sửa tầng" : "Thêm tầng";

        var branches = _floorService.GetActiveBranchesOrdered();
        if (branches.Count == 0)
        {
            MessageBox.Show(this, "Chưa có chi nhánh hoạt động. Thêm chi nhánh trước.", "Tầng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        if (branches.Count == 1)
        {
            _lockedSingleBranchId = branches[0].Id;
            lblBranch.Visible = false;
            cmbBranch.Visible = false;
            layout.RowStyles[1].SizeType = SizeType.Absolute;
            layout.RowStyles[1].Height = 0;
            layout.PerformLayout();
            var innerH = layout.PreferredSize.Height + 24;
            ClientSize = new System.Drawing.Size(ClientSize.Width, innerH);
            MinimumSize = new System.Drawing.Size(MinimumSize.Width, innerH);
        }
        else
        {
            var list = branches.Select(b => new BranchListItem(b.Id, BranchDisplayHelper.Format(b))).ToList();
            cmbBranch.DisplayMember = nameof(BranchListItem.Label);
            cmbBranch.ValueMember = nameof(BranchListItem.Id);
            cmbBranch.DataSource = list;
        }

        if (_editingFloorId is { } editId && editId > 0)
        {
            var f = _floorService.GetById(editId);
            if (f == null)
            {
                MessageBox.Show(this, "Không tìm thấy tầng.", "Tầng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            txtName.Text = f.Name ?? "";

            if (_lockedSingleBranchId == null && cmbBranch.DataSource is List<BranchListItem> items)
            {
                var ix = items.FindIndex(x => x.Id == f.IdBranch);
                if (ix >= 0)
                    cmbBranch.SelectedIndex = ix;
            }
        }
        else
        {
            txtName.Clear();
            if (cmbBranch.Items.Count > 0)
                cmbBranch.SelectedIndex = 0;
        }
    }

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        var name = txtName.Text?.Trim() ?? "";
        int? branchId = _lockedSingleBranchId;
        if (branchId == null)
        {
            if (cmbBranch.SelectedValue is not int bid)
            {
                MessageBox.Show(this, "Chọn chi nhánh.", "Tầng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            branchId = bid;
        }

        try
        {
            if (_editingFloorId is { } editId && editId > 0)
            {
                _floorService.Update(new Floor
                {
                    Id = editId,
                    Name = name,
                    IdBranch = branchId,
                });
            }
            else
            {
                _floorService.Add(new Floor
                {
                    Name = name,
                    IdBranch = branchId,
                });
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Tầng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private sealed class BranchListItem(int id, string label)
    {
        public int Id { get; } = id;
        public string Label { get; } = label;
    }
}
