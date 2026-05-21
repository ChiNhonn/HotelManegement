using System;
using System.Windows.Forms;
using HotelManagement.Helpers;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

public partial class ServicePriceRuleEditForm : Form
{
    public ServicePriceRuleEditModel Model { get; private set; }

    public ServicePriceRuleEditForm(ServicePriceRuleEditModel model, IReadOnlyList<ServiceCatalogRow> services)
    {
        Model = model;
        InitializeComponent();
        Text = model.Id == 0 ? "Thêm quy tắc giá" : "Sửa quy tắc giá";

        foreach (var s in services)
            cboSvc.Items.Add(new SvcPick(s.Id, s.Name));
        cboSvc.DisplayMember = nameof(SvcPick.Name);

        cboType.Items.AddRange(new object[]
        {
            new TypePick(ServicePriceRuleType.HappyHour, ServicePriceRuleType.ToDisplay(ServicePriceRuleType.HappyHour)),
            new TypePick(ServicePriceRuleType.Peak, ServicePriceRuleType.ToDisplay(ServicePriceRuleType.Peak)),
            new TypePick(ServicePriceRuleType.OffPeak, ServicePriceRuleType.ToDisplay(ServicePriceRuleType.OffPeak)),
        });
        cboType.DisplayMember = nameof(TypePick.Label);

        txtName.Text = model.RuleName;
        numPrice.Value = model.Price;
        numPri.Value = model.Priority;
        txtTimeStart.Text = model.TimeStart?.ToString(@"hh\:mm") ?? "";
        txtTimeEnd.Text = model.TimeEnd?.ToString(@"hh\:mm") ?? "";

        if (model.ServiceId > 0)
        {
            for (var i = 0; i < cboSvc.Items.Count; i++)
                if (cboSvc.Items[i] is SvcPick p && p.Id == model.ServiceId) { cboSvc.SelectedIndex = i; break; }
        }
        else if (cboSvc.Items.Count > 0)
            cboSvc.SelectedIndex = 0;

        for (var i = 0; i < cboType.Items.Count; i++)
            if (cboType.Items[i] is TypePick t && t.Value == model.RuleType) { cboType.SelectedIndex = i; break; }

        if (model.DateStart.HasValue) { dtpFrom.Checked = true; dtpFrom.Value = model.DateStart.Value; }
        if (model.DateEnd.HasValue) { dtpTo.Checked = true; dtpTo.Value = model.DateEnd.Value; }
    }

    private void btnOk_Click(object? sender, EventArgs e)
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
    }

    private sealed record SvcPick(int Id, string Name);
    private sealed record TypePick(string Value, string Label);
}
