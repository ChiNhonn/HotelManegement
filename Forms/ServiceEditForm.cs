using System;
using System.Windows.Forms;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

public partial class ServiceEditForm : Form
{
    public ServiceEditModel Model { get; private set; }

    public ServiceEditForm(ServiceEditModel model, IReadOnlyList<ServiceCategoryRow> categories)
    {
        Model = model;
        InitializeComponent();
        Text = model.Id == 0 ? "Thêm dịch vụ" : "Sửa dịch vụ";

        foreach (var c in categories)
            cboCat.Items.Add(new CatPick(c.Id, c.Name));
        cboCat.DisplayMember = nameof(CatPick.Name);

        txtName.Text = model.Name;
        txtDesc.Text = model.Description ?? "";
        txtUnit.Text = model.Unit;
        numPrice.Value = Math.Min(numPrice.Maximum, model.UnitPrice);
        chkHidden.Checked = model.IsHidden;
        chkStock.Checked = model.TrackInventory;
        numStock.Value = model.StockQuantity;
        txtImage.Text = model.ImagePath ?? "";

        if (model.CategoryId.HasValue)
        {
            for (var i = 0; i < cboCat.Items.Count; i++)
                if (cboCat.Items[i] is CatPick p && p.Id == model.CategoryId) { cboCat.SelectedIndex = i; break; }
        }
        else if (cboCat.Items.Count > 0)
            cboCat.SelectedIndex = 0;
    }

    private void btnOk_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Nhập tên dịch vụ.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        Model.Name = txtName.Text.Trim();
        Model.Description = txtDesc.Text.Trim();
        Model.Unit = string.IsNullOrWhiteSpace(txtUnit.Text) ? "lần" : txtUnit.Text.Trim();
        Model.UnitPrice = numPrice.Value;
        Model.CategoryId = cboCat.SelectedItem is CatPick cp ? cp.Id : null;
        Model.IsHidden = chkHidden.Checked;
        Model.TrackInventory = chkStock.Checked;
        Model.StockQuantity = (int)numStock.Value;
        Model.ImagePath = txtImage.Text.Trim();
    }

    private sealed record CatPick(int Id, string Name);
}
