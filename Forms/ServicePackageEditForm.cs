using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

public partial class ServicePackageEditForm : Form
{
    public ServicePackageEditModel Model { get; private set; }

    public ServicePackageEditForm(ServicePackageEditModel model, IReadOnlyList<ServiceCatalogRow> services)
    {
        Model = model;
        InitializeComponent();
        Text = model.Id == 0 ? "Thêm gói combo" : "Sửa gói combo";

        foreach (var s in services)
            cboService.Items.Add(new SvcPick(s.Id, s.Name));
        cboService.DisplayMember = nameof(SvcPick.Name);
        if (cboService.Items.Count > 0)
            cboService.SelectedIndex = 0;

        txtName.Text = model.Name;
        txtDesc.Text = model.Description ?? "";
        numPrice.Value = Math.Min(numPrice.Maximum, model.PackagePrice);
        chkHidden.Checked = model.IsHidden;
        RefreshList();
    }

    private void btnAddItem_Click(object? sender, EventArgs e)
    {
        if (cboService.SelectedItem is not SvcPick s) return;
        Model.Items.Add(new ServicePackageItemEdit { ServiceId = s.Id, ServiceName = s.Name, Quantity = (int)numQty.Value });
        RefreshList();
    }

    private void btnRemoveItem_Click(object? sender, EventArgs e)
    {
        if (lstItems.SelectedIndex < 0) return;
        Model.Items.RemoveAt(lstItems.SelectedIndex);
        RefreshList();
    }

    private void btnOk_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Nhập tên gói.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        if (Model.Items.Count == 0)
        {
            MessageBox.Show("Thêm ít nhất một dịch vụ vào gói.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        Model.Name = txtName.Text.Trim();
        Model.Description = txtDesc.Text.Trim();
        Model.PackagePrice = numPrice.Value;
        Model.IsHidden = chkHidden.Checked;
    }

    private void RefreshList()
    {
        lstItems.Items.Clear();
        foreach (var i in Model.Items)
            lstItems.Items.Add($"{i.Quantity}× {i.ServiceName}");
    }

    private sealed record SvcPick(int Id, string Name);
}
