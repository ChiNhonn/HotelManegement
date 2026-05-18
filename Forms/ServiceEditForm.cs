using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

public sealed class ServiceEditForm : Form
{
    private readonly TextBox _txtName = new() { Width = 300 };
    private readonly TextBox _txtDesc = new() { Width = 300, Multiline = true, Height = 50 };
    private readonly TextBox _txtUnit = new() { Width = 120 };
    private readonly NumericUpDown _numPrice = new() { Minimum = 0, Maximum = 999_999_999, DecimalPlaces = 0, ThousandsSeparator = true, Width = 140 };
    private readonly ComboBox _cboCat = new() { Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly CheckBox _chkHidden = new() { Text = "Ẩn khỏi menu đặt" };
    private readonly CheckBox _chkStock = new() { Text = "Theo dõi tồn kho" };
    private readonly NumericUpDown _numStock = new() { Minimum = 0, Maximum = 99999, Width = 100 };
    private readonly TextBox _txtImage = new() { Width = 220 };

    public ServiceEditModel Model { get; private set; }

    public ServiceEditForm(ServiceEditModel model, IReadOnlyList<ServiceCategoryRow> categories)
    {
        Model = model;
        Text = model.Id == 0 ? "Thêm dịch vụ" : "Sửa dịch vụ";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(440, 380);
        Font = new Font("Segoe UI", 9.5f);

        foreach (var c in categories)
            _cboCat.Items.Add(new CatPick(c.Id, c.Name));
        _cboCat.DisplayMember = nameof(CatPick.Name);

        _txtName.Text = model.Name;
        _txtDesc.Text = model.Description ?? "";
        _txtUnit.Text = model.Unit;
        _numPrice.Value = Math.Min(_numPrice.Maximum, model.UnitPrice);
        _chkHidden.Checked = model.IsHidden;
        _chkStock.Checked = model.TrackInventory;
        _numStock.Value = model.StockQuantity;
        _txtImage.Text = model.ImagePath ?? "";
        if (model.CategoryId.HasValue)
        {
            for (var i = 0; i < _cboCat.Items.Count; i++)
                if (_cboCat.Items[i] is CatPick p && p.Id == model.CategoryId) { _cboCat.SelectedIndex = i; break; }
        }
        else if (_cboCat.Items.Count > 0) _cboCat.SelectedIndex = 0;

        var y = 16;
        void Row(string label, Control c)
        {
            Controls.Add(new Label { Text = label, Location = new Point(16, y + 3), AutoSize = true });
            c.Location = new Point(130, y);
            Controls.Add(c);
            y += c.Height + 12;
        }

        Row("Tên *", _txtName);
        Row("Phân loại", _cboCat);
        Row("Đơn vị", _txtUnit);
        Row("Giá bán", _numPrice);
        Row("Mô tả", _txtDesc);
        Row("Hình ảnh", _txtImage);
        _chkHidden.Location = new Point(130, y);
        Controls.Add(_chkHidden);
        y += 28;
        _chkStock.Location = new Point(130, y);
        _numStock.Location = new Point(280, y);
        Controls.Add(_chkStock);
        Controls.Add(_numStock);
        y += 36;

        var btnOk = new Button { Text = "Lưu", Location = new Point(240, y), DialogResult = DialogResult.OK, Width = 80 };
        var btnCancel = new Button { Text = "Hủy", Location = new Point(330, y), DialogResult = DialogResult.Cancel, Width = 80 };
        btnOk.Click += (_, _) =>
        {
            if (string.IsNullOrWhiteSpace(_txtName.Text))
            {
                MessageBox.Show("Nhập tên dịch vụ.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            Model.Name = _txtName.Text.Trim();
            Model.Description = _txtDesc.Text.Trim();
            Model.Unit = string.IsNullOrWhiteSpace(_txtUnit.Text) ? "lần" : _txtUnit.Text.Trim();
            Model.UnitPrice = _numPrice.Value;
            Model.CategoryId = _cboCat.SelectedItem is CatPick cp ? cp.Id : null;
            Model.IsHidden = _chkHidden.Checked;
            Model.TrackInventory = _chkStock.Checked;
            Model.StockQuantity = (int)_numStock.Value;
            Model.ImagePath = _txtImage.Text.Trim();
        };
        Controls.Add(btnOk);
        Controls.Add(btnCancel);
        AcceptButton = btnOk;
        CancelButton = btnCancel;
    }

    private sealed record CatPick(int Id, string Name);
}
