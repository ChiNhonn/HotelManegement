using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using HotelManagement.ViewModels;

namespace HotelManagement.Forms;

public sealed class BookingViewDialog : Form
{
    private static readonly CultureInfo En = CultureInfo.GetCultureInfo("en-US");

    public BookingViewDialog(BookingDetailsDto d, Action<string> applySearchFilter)
    {
        if (applySearchFilter == null) throw new ArgumentNullException(nameof(applySearchFilter));

        Text = "Booking details";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Segoe UI", 10F);
        ClientSize = new Size(480, 520);

        var sb = new StringBuilder();
        sb.AppendLine($"Order: {d.OrderId}");
        sb.AppendLine($"Room: {d.RoomName}");
        sb.AppendLine($"Room type: {d.RoomTypeName ?? "—"}");
        sb.AppendLine($"Rate / night: {d.NightlyPrice.ToString("N0", En)} VND");
        sb.AppendLine();
        sb.AppendLine($"Guest: {d.GuestName}");
        sb.AppendLine($"National ID: {d.CitizenId}");
        sb.AppendLine($"Phone: {d.Phone}");
        sb.AppendLine();
        sb.AppendLine($"Check-in: {d.CheckIn:dd/MM/yyyy}");
        sb.AppendLine($"Check-out (planned): {(d.CheckOut.HasValue ? d.CheckOut.Value.ToString("dd/MM/yyyy") : "—")}");
        sb.AppendLine($"Nights: {d.Nights}");
        sb.AppendLine($"Adults / children: {d.Adults} / {d.Children}");
        sb.AppendLine($"Estimated total: {d.ExpectedTotal.ToString("N0", En)} VND");
        if (!string.IsNullOrWhiteSpace(d.UserNote))
        {
            sb.AppendLine();
            sb.AppendLine("Notes:");
            sb.Append(d.UserNote);
        }

        var txt = new TextBox
        {
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            Dock = DockStyle.Fill,
            Font = new Font("Consolas", 9.75F),
            BackColor = Color.White
        };
        txt.Text = sb.ToString();

        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(14, 12, 14, 10),
            RowCount = 2,
            ColumnCount = 1
        };
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));

        root.Controls.Add(txt, 0, 0);

        var flow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.RightToLeft,
            WrapContents = true,
            Padding = new Padding(0, 4, 0, 0)
        };
        var btnClose = new Button
        {
            Text = "Close",
            DialogResult = DialogResult.OK,
            AutoSize = true,
            Padding = new Padding(12, 6, 12, 6)
        };
        var btnRoom = new Button
        {
            Text = "Filter by room",
            AutoSize = true,
            Padding = new Padding(12, 6, 12, 6)
        };
        var btnName = new Button
        {
            Text = "Filter by guest",
            AutoSize = true,
            Padding = new Padding(12, 6, 12, 6)
        };
        btnName.Click += (_, _) =>
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
        flow.Controls.Add(btnClose);
        flow.Controls.Add(btnRoom);
        flow.Controls.Add(btnName);
        root.Controls.Add(flow, 0, 1);

        Controls.Add(root);
        AcceptButton = btnClose;
        CancelButton = btnClose;
    }
}
