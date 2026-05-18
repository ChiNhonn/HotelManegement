using System.ComponentModel;
using System.Windows.Forms;

namespace HotelManagement.CustomControls;

/// <summary>Thẻ KPI dùng hoàn toàn layout WinForms Designer (bảng + nhãn).</summary>
public partial class UsKpiTile : UserControl
{
    public UsKpiTile()
    {
        InitializeComponent();
    }

    [Browsable(true)]
    [Category("Kpi")]
    [DefaultValue("")]
    public string KpiCaption
    {
        get => lblCaption.Text;
        set => lblCaption.Text = value ?? "";
    }

    [Browsable(true)]
    [Category("Kpi")]
    [DefaultValue("0")]
    public string KpiValue
    {
        get => lblValue.Text;
        set => lblValue.Text = value ?? "0";
    }

    [Browsable(true)]
    [Category("Kpi")]
    [DefaultValue("\uE80F")]
    public string KpiIconGlyph
    {
        get => lblIcon.Text;
        set => lblIcon.Text = value ?? "";
    }

    private void lblValue_Click(object sender, EventArgs e)
    {

    }
}
