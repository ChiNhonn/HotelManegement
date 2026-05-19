using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using HotelManagement.ViewModels;

namespace HotelManagement.Helpers;

/// <summary>In hóa đơn (xem trước → máy in) — dùng chung tab Hóa đơn và trả phòng.</summary>
public static class BillPrintHelper
{
    public static void ShowPrintPreview(BillDetailView bill, IWin32Window? owner = null)
    {
        ArgumentNullException.ThrowIfNull(bill);

        using var pd = new PrintDocument();
        pd.PrintPage += (_, e) => DrawBillPage(e, bill);

        using var preview = new PrintPreviewDialog
        {
            Document = pd,
            Width = 800,
            Height = 600,
            ShowIcon = false,
            Text = "Xem trước hóa đơn — In (Ctrl+P)"
        };

        if (owner != null)
            preview.ShowDialog(owner);
        else
            preview.ShowDialog();
    }

    private static void DrawBillPage(PrintPageEventArgs e, BillDetailView bill)
    {
        var g = e.Graphics!;
        const int startX = 50;
        const int startY = 50;
        var offset = 0;

        using var fontTitle = new Font("Arial", 18, FontStyle.Bold);
        using var fontHeader = new Font("Arial", 12, FontStyle.Bold);
        using var fontRegular = new Font("Arial", 10, FontStyle.Regular);
        using var fontBold = new Font("Arial", 10, FontStyle.Bold);

        g.DrawString("KHÁCH SẠN HOTEL MANAGEMENT", fontHeader, Brushes.Black, startX, startY + offset);
        offset += 30;
        g.DrawString("Địa chỉ: 123 Đường ABC, Quận X, TP.HCM", fontRegular, Brushes.Black, startX, startY + offset);
        offset += 40;

        g.DrawString("HÓA ĐƠN THANH TOÁN", fontTitle, Brushes.Black, startX + 220, startY + offset);
        offset += 40;

        g.DrawString($"Mã HĐ: #{bill.BillId:D5}", fontBold, Brushes.Black, startX, startY + offset);
        offset += 25;
        g.DrawString($"Khách hàng: {bill.CustomerName}", fontRegular, Brushes.Black, startX, startY + offset);
        offset += 25;
        g.DrawString($"Ngày vào: {bill.CheckIn:dd/MM/yyyy HH:mm}", fontRegular, Brushes.Black, startX, startY + offset);
        var checkOutText = bill.CheckOut.HasValue
            ? bill.CheckOut.Value.ToString("dd/MM/yyyy HH:mm")
            : "N/A";
        g.DrawString($"Ngày ra: {checkOutText}", fontRegular, Brushes.Black, startX + 350, startY + offset);
        offset += 30;

        g.DrawLine(Pens.Black, startX, startY + offset, startX + 700, startY + offset);
        offset += 15;

        g.DrawString("Nội dung", fontBold, Brushes.Black, startX, startY + offset);
        g.DrawString("SL", fontBold, Brushes.Black, startX + 350, startY + offset);
        g.DrawString("Đơn giá", fontBold, Brushes.Black, startX + 450, startY + offset);
        g.DrawString("Thành tiền", fontBold, Brushes.Black, startX + 580, startY + offset);
        offset += 25;

        g.DrawLine(Pens.Gray, startX, startY + offset, startX + 700, startY + offset);
        offset += 15;

        if (bill.Items != null)
        {
            foreach (var item in bill.Items)
            {
                var productName = item.Product.Length > 40
                    ? item.Product[..40] + "..."
                    : item.Product;
                g.DrawString(productName, fontRegular, Brushes.Black, startX, startY + offset);
                g.DrawString(item.Quantity.ToString(), fontRegular, Brushes.Black, startX + 350, startY + offset);
                g.DrawString(item.UnitPrice.ToString("N0"), fontRegular, Brushes.Black, startX + 450, startY + offset);
                g.DrawString(item.SubTotal.ToString("N0"), fontRegular, Brushes.Black, startX + 580, startY + offset);
                offset += 25;
            }
        }

        g.DrawLine(Pens.Black, startX, startY + offset, startX + 700, startY + offset);
        offset += 20;

        const int rightAlignX = startX + 400;

        g.DrawString("Giảm giá:", fontRegular, Brushes.Black, rightAlignX, startY + offset);
        g.DrawString($"- {bill.Discount:N0} VNĐ", fontRegular, Brushes.Black, rightAlignX + 150, startY + offset);
        offset += 25;

        g.DrawString("Thuế VAT:", fontRegular, Brushes.Black, rightAlignX, startY + offset);
        g.DrawString($"+ {bill.Tax:N0} VNĐ", fontRegular, Brushes.Black, rightAlignX + 150, startY + offset);
        offset += 25;

        g.DrawString("Đã cọc:", fontRegular, Brushes.Black, rightAlignX, startY + offset);
        g.DrawString($"- {bill.DepositAmount:N0} VNĐ", fontRegular, Brushes.Black, rightAlignX + 150, startY + offset);
        offset += 25;

        var totalLabel = bill.IsPaid ? "ĐÃ THANH TOÁN:" : "TỔNG THANH TOÁN:";
        g.DrawString(totalLabel, fontHeader, Brushes.Black, rightAlignX - 30, startY + offset);
        g.DrawString($"{bill.TotalAmount:N0} VNĐ", fontHeader, Brushes.Red, rightAlignX + 150, startY + offset);
        offset += 50;

        g.DrawString(
            "Cảm ơn Quý khách và hẹn gặp lại!",
            new Font("Arial", 10, FontStyle.Italic),
            Brushes.Black,
            startX + 250,
            startY + offset);
    }
}
