using System;
using System.Windows.Forms;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

public partial class ServiceCategoryEditForm : Form
{
    public ServiceCategoryEditModel Model { get; private set; }

    public ServiceCategoryEditForm(ServiceCategoryEditModel? existing = null)
    {
        Model = existing ?? new ServiceCategoryEditModel();
        InitializeComponent();
        Text = Model.Id == 0 ? "Thêm phân loại" : "Sửa phân loại";
        txtName.Text = Model.Name;
        txtDesc.Text = Model.Description ?? "";
        numSort.Value = Model.SortOrder;
    }

    private void btnOk_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Nhập tên phân loại.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        Model.Name = txtName.Text.Trim();
        Model.Description = txtDesc.Text.Trim();
        Model.SortOrder = (int)numSort.Value;
    }
}
