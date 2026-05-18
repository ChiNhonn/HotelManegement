using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

public sealed class ServicePackageEditForm : Form
{
    private readonly TextBox _txtName = new() { Width = 300 };
    private readonly TextBox _txtDesc = new() { Width = 300, Multiline = true, Height = 50 };
    private readonly NumericUpDown _numPrice = new() { Minimum = 0, Maximum = 999_999_999, DecimalPlaces = 0, ThousandsSeparator = true, Width = 140 };
    private readonly CheckBox _chkHidden = new() { Text = "Ẩn gói" };
    private readonly ListBox _lstItems = new() { Width = 300, Height = 100 };
    private readonly ComboBox _cboService = new() { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly NumericUpDown _numQty = new() { Minimum = 1, Maximum = 99, Width = 60, Value = 1 };

    public ServicePackageEditModel Model { get; private set; }

    public ServicePackageEditForm(ServicePackageEditModel model, IReadOnlyList<ServiceCatalogRow> services)
    {
        Model = model;
        Text = model.Id == 0 ? "Thêm gói combo" : "Sửa gói combo";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(440, 420);
        Font = new Font("Segoe UI", 9.5f);

        foreach (var s in services)
            _cboService.Items.Add(new SvcPick(s.Id, s.Name));
        _cboService.DisplayMember = nameof(SvcPick.Name);
        if (_cboService.Items.Count > 0) _cboService.SelectedIndex = 0;

        _txtName.Text = model.Name;
        _txtDesc.Text = model.Description ?? "";
        _numPrice.Value = Math.Min(_numPrice.Maximum, model.PackagePrice);
        _chkHidden.Checked = model.IsHidden;
        RefreshList();

        var y = 12;
        void Row(string label, Control c)
        {
            Controls.Add(new Label { Text = label, Location = new Point(12, y + 2), AutoSize = true });
            c.Location = new Point(120, y);
            Controls.Add(c);
            y += c.Height + 10;
        }

        Row("Tên gói *", _txtName);
        Row("Giá gói", _numPrice);
        Row("Mô tả", _txtDesc);
        _chkHidden.Location = new Point(120, y);
        Controls.Add(_chkHidden);
        y += 30;
        Controls.Add(new Label { Text = "Thành phần", Location = new Point(12, y), AutoSize = true });
        y += 22;
        _lstItems.Location = new Point(120, y);
        Controls.Add(_lstItems);
        y += 108;
        _cboService.Location = new Point(120, y);
        _numQty.Location = new Point(330, y);
        Controls.Add(_cboService);
        Controls.Add(_numQty);
        var btnAdd = new Button { Text = "+ Thêm DV", Location = new Point(400, y - 2), Width = 28, Height = 28 };
        btnAdd.Click += (_, _) =>
        {
            if (_cboService.SelectedItem is not SvcPick s) return;
            Model.Items.Add(new ServicePackageItemEdit { ServiceId = s.Id, ServiceName = s.Name, Quantity = (int)_numQty.Value });
            RefreshList();
        };
        Controls.Add(btnAdd);
        y += 36;
        var btnRm = new Button { Text = "Xóa dòng chọn", Location = new Point(120, y), Width = 120 };
        btnRm.Click += (_, _) =>
        {
            if (_lstItems.SelectedIndex < 0) return;
            Model.Items.RemoveAt(_lstItems.SelectedIndex);
            RefreshList();
        };
        Controls.Add(btnRm);
        y += 36;

        var btnOk = new Button { Text = "Lưu", Location = new Point(240, y), DialogResult = DialogResult.OK, Width = 80 };
        var btnCancel = new Button { Text = "Hủy", Location = new Point(330, y), DialogResult = DialogResult.Cancel, Width = 80 };
        btnOk.Click += (_, _) =>
        {
            if (string.IsNullOrWhiteSpace(_txtName.Text))
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
            Model.Name = _txtName.Text.Trim();
            Model.Description = _txtDesc.Text.Trim();
            Model.PackagePrice = _numPrice.Value;
            Model.IsHidden = _chkHidden.Checked;
        };
        Controls.Add(btnOk);
        Controls.Add(btnCancel);
    }

    private void RefreshList()
    {
        _lstItems.Items.Clear();
        foreach (var i in Model.Items)
            _lstItems.Items.Add($"{i.Quantity}× {i.ServiceName}");
    }

    private sealed record SvcPick(int Id, string Name);
}
