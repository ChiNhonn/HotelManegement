using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

/// <summary>Chi tiết đặt phòng — layout trong <c>BookingViewDialog.Designer.cs</c>.</summary>
public partial class BookingViewDialog : Form
{
    private static readonly CultureInfo En = CultureInfo.GetCultureInfo("en-US");

    public BookingViewDialog()
    {
        InitializeComponent();
    }

    public BookingViewDialog(BookingDetailsDto d, Action<string> applySearchFilter)
        : this()
    {
        if (applySearchFilter == null) throw new ArgumentNullException(nameof(applySearchFilter));

        txtDetails.Text = BuildDetailsText(d);

        btnGuest.Click += (_, _) =>
        {
            applySearchFilter(d.GuestName.Trim());
            DialogResult = DialogResult.OK;
            Close();
        };
        btnRoom.Click += (_, _) =>
        {
            applySearchFilter(d.RoomName.Trim());
            DialogResult = DialogResult.OK;
            Close();
        };
    }

    private static string BuildDetailsText(BookingDetailsDto d)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Đơn: {d.OrderId}");
        sb.AppendLine($"Phòng: {d.RoomName}");
        sb.AppendLine($"Hạng phòng: {d.RoomTypeName ?? "—"}");
        sb.AppendLine($"Giá / đêm: {d.NightlyPrice.ToString("N0", En)} VND");
        sb.AppendLine();
        sb.AppendLine($"Khách: {d.GuestName}");
        sb.AppendLine($"CCCD: {d.CitizenId}");
        sb.AppendLine($"SĐT: {d.Phone}");
        sb.AppendLine();
        sb.AppendLine($"Nhận phòng: {d.CheckIn:dd/MM/yyyy}");
        sb.AppendLine($"Trả phòng (dự kiến): {(d.CheckOut.HasValue ? d.CheckOut.Value.ToString("dd/MM/yyyy") : "—")}");
        sb.AppendLine($"Số đêm: {d.Nights}");
        sb.AppendLine($"Người lớn / trẻ em: {d.Adults} / {d.Children}");
        sb.AppendLine($"Tổng dự kiến: {d.ExpectedTotal.ToString("N0", En)} VND");
        if (!string.IsNullOrWhiteSpace(d.UserNote))
        {
            sb.AppendLine();
            sb.AppendLine("Ghi chú:");
            sb.Append(d.UserNote);
        }

        return sb.ToString();
    }
}
