using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

public sealed class ServicePriceRuleEditForm : Form
{
    public ServicePriceRuleEditModel Model { get; private set; }

    public ServicePriceRuleEditForm(ServicePriceRuleEditModel model, IReadOnlyList<ServiceCatalogRow> services)
    {
        Model = model;
        Text = model.Id == 0 ? "Thêm quy tắc giá" : "Sửa quy tắc giá";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(420, 340);
        Font = new Font("Segoe UI", 9.5f);

        var cboSvc = new ComboBox { Width = 280, DropDownStyle = ComboBoxStyle.DropDownList, Location = new Point(120, 12) };
        foreach (var s in services) cboSvc.Items.Add(new SvcPick(s.Id, s.Name));
        cboSvc.DisplayMember = nameof(SvcPick.Name);
        if (model.ServiceId > 0)
            for (var i = 0; i < cboSvc.Items.Count; i++)
                if (cboSvc.Items[i] is SvcPick p && p.Id == model.ServiceId) { cboSvc.SelectedIndex = i; break; }
        else if (cboSvc.Items.Count > 0) cboSvc.SelectedIndex = 0;

        var txtName = new TextBox { Text = model.RuleName, Width = 280, Location = new Point(120, 44) };
        var cboType = new ComboBox { Width = 280, DropDownStyle = ComboBoxStyle.DropDownList, Location = new Point(120, 76) };
        cboType.Items.AddRange(new object[]
        {
            new TypePick(ServicePriceRuleType.HappyHour, ServicePriceRuleType.ToDisplay(ServicePriceRuleType.HappyHour)),
            new TypePick(ServicePriceRuleType.Peak, ServicePriceRuleType.ToDisplay(ServicePriceRuleType.Peak)),
            new TypePick(ServicePriceRuleType.OffPeak, ServicePriceRuleType.ToDisplay(ServicePriceRuleType.OffPeak)),
        });
        cboType.DisplayMember = nameof(TypePick.Label);
        for (var i = 0; i < cboType.Items.Count; i++)
            if (cboType.Items[i] is TypePick t && t.Value == model.RuleType) { cboType.SelectedIndex = i; break; }

        var numPrice = new NumericUpDown { Minimum = 0, Maximum = 999_999_999, Value = model.Price, Width = 140, Location = new Point(120, 108), ThousandsSeparator = true };
        var dtpFrom = new DateTimePicker { Format = DateTimePickerFormat.Short, ShowCheckBox = true, Location = new Point(120, 140), Width = 130 };
        var dtpTo = new DateTimePicker { Format = DateTimePickerFormat.Short, ShowCheckBox = true, Location = new Point(270, 140), Width = 130 };
        if (model.DateStart.HasValue) { dtpFrom.Checked = true; dtpFrom.Value = model.DateStart.Value; }
        if (model.DateEnd.HasValue) { dtpTo.Checked = true; dtpTo.Value = model.DateEnd.Value; }

        var txtTimeStart = new TextBox { Text = model.TimeStart?.ToString(@"hh\:mm") ?? "", Width = 80, Location = new Point(120, 172) };
        var txtTimeEnd = new TextBox { Text = model.TimeEnd?.ToString(@"hh\:mm") ?? "", Width = 80, Location = new Point(220, 172) };
        var numPri = new NumericUpDown { Minimum = 0, Maximum = 100, Value = model.Priority, Width = 80, Location = new Point(120, 204) };

        Controls.Add(new Label { Text = "Dịch vụ", Location = new Point(12, 16), AutoSize = true });
        Controls.Add(cboSvc);
        Controls.Add(new Label { Text = "Tên quy tắc", Location = new Point(12, 48), AutoSize = true });
        Controls.Add(txtName);
        Controls.Add(new Label { Text = "Loại", Location = new Point(12, 80), AutoSize = true });
        Controls.Add(cboType);
        Controls.Add(new Label { Text = "Giá áp dụng", Location = new Point(12, 112), AutoSize = true });
        Controls.Add(numPrice);
        Controls.Add(new Label { Text = "Từ ngày → đến", Location = new Point(12, 144), AutoSize = true });
        Controls.Add(dtpFrom);
        Controls.Add(dtpTo);
        Controls.Add(new Label { Text = "Giờ (HH:mm)", Location = new Point(12, 176), AutoSize = true });
        Controls.Add(txtTimeStart);
        Controls.Add(txtTimeEnd);
        Controls.Add(new Label { Text = "Ưu tiên", Location = new Point(12, 208), AutoSize = true });
        Controls.Add(numPri);

        var btnOk = new Button { Text = "Lưu", Location = new Point(220, 250), DialogResult = DialogResult.OK, Width = 80 };
        var btnCancel = new Button { Text = "Hủy", Location = new Point(310, 250), DialogResult = DialogResult.Cancel, Width = 80 };
        btnOk.Click += (_, _) =>
        {
            if (cboSvc.SelectedItem is not SvcPick sp) return;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nhập tên quy tắc.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            Model.ServiceId = sp.Id;
            Model.RuleName = txtName.Text.Trim();
            Model.RuleType = cboType.SelectedItem is TypePick tp ? tp.Value : ServicePriceRuleType.OffPeak;
            Model.Price = numPrice.Value;
            Model.DateStart = dtpFrom.Checked ? dtpFrom.Value.Date : null;
            Model.DateEnd = dtpTo.Checked ? dtpTo.Value.Date : null;
            Model.TimeStart = TimeSpan.TryParse(txtTimeStart.Text, out var ts) ? ts : null;
            Model.TimeEnd = TimeSpan.TryParse(txtTimeEnd.Text, out var te) ? te : null;
            Model.Priority = (int)numPri.Value;
        };
        Controls.Add(btnOk);
        Controls.Add(btnCancel);
    }

    private sealed record SvcPick(int Id, string Name);
    private sealed record TypePick(string Value, string Label);
}
