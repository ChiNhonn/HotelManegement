using System;
using System.Drawing;
using System.Windows.Forms;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

public sealed class ServiceCategoryEditForm : Form
{
    private readonly TextBox _txtName = new() { Width = 320 };
    private readonly TextBox _txtDesc = new() { Width = 320, Multiline = true, Height = 60 };
    private readonly NumericUpDown _numSort = new() { Minimum = 0, Maximum = 9999, Width = 100 };

    public ServiceCategoryEditModel Model { get; private set; }

    public ServiceCategoryEditForm(ServiceCategoryEditModel? existing = null)
    {
        Model = existing ?? new ServiceCategoryEditModel();
        Text = Model.Id == 0 ? "Thêm phân loại" : "Sửa phân loại";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(400, 220);
        Font = new Font("Segoe UI", 9.5f);

        var tbl = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(16), ColumnCount = 2, RowCount = 4 };
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        _txtName.Text = Model.Name;
        _txtDesc.Text = Model.Description ?? "";
        _numSort.Value = Model.SortOrder;

        tbl.Controls.Add(new Label { Text = "Tên *", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 0);
        tbl.Controls.Add(_txtName, 1, 0);
        tbl.Controls.Add(new Label { Text = "Mô tả", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 1);
        tbl.Controls.Add(_txtDesc, 1, 1);
        tbl.Controls.Add(new Label { Text = "Thứ tự", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 2);
        tbl.Controls.Add(_numSort, 1, 2);

        var pnlBtn = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Bottom, Height = 44, Padding = new Padding(8) };
        var btnOk = new Button { Text = "Lưu", DialogResult = DialogResult.OK, Width = 90 };
        var btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Width = 90 };
        btnOk.Click += (_, _) =>
        {
            if (string.IsNullOrWhiteSpace(_txtName.Text))
            {
                MessageBox.Show("Nhập tên phân loại.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            Model.Name = _txtName.Text.Trim();
            Model.Description = _txtDesc.Text.Trim();
            Model.SortOrder = (int)_numSort.Value;
        };
        pnlBtn.Controls.Add(btnOk);
        pnlBtn.Controls.Add(btnCancel);
        AcceptButton = btnOk;
        CancelButton = btnCancel;

        Controls.Add(tbl);
        Controls.Add(pnlBtn);
    }
}
