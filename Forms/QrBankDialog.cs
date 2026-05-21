using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HotelManagement.Forms;

/// <summary>Modal đơn giản — hiển thị QR chuyển khoản (placeholder có thể thay bằng ảnh QR thật / API).</summary>
public partial class QrBankDialog : Form
{
    private Bitmap? _qrBmp;

    /// <param name="transferMemoHint">Hướng dẫn nội dung CK (#DV…) để khớp tự động.</param>
    public QrBankDialog(decimal amount, string subtitle, string? transferMemoHint = null)
    {
        InitializeComponent();
        lblAmt.Text = amount.ToString("N0") + " đ";
        lblSub.Text = subtitle;
        lblMemo.Text = transferMemoHint
            ?? "Khách chuyển khoản nên ghi nội dung có #DV{mã đơn} và đúng số tiền để khớp tự động.";
        _qrBmp = BuildPlaceholderQr(280);
        picQr.Image = _qrBmp;
    }

    private static Bitmap BuildPlaceholderQr(int size)
    {
        var bmp = new Bitmap(size, size);
        using var g = Graphics.FromImage(bmp);
        g.Clear(Color.White);
        var rnd = new Random(42);
        int step = size / 33;
        for (var y = 0; y < size; y += step)
        for (var x = 0; x < size; x += step)
        {
            if (rnd.NextDouble() > 0.55)
                g.FillRectangle(Brushes.Black, x, y, step - 1, step - 1);
        }

        using var pen = new Pen(Color.FromArgb(59, 130, 246), 3);
        g.DrawRectangle(pen, 6, 6, size - 13, size - 13);

        using var f = new Font("Segoe UI", 8f);
        TextRenderer.DrawText(g, "QR DEMO\n(thay ảnh VietQR)", f,
            new Rectangle(0, size / 2 - 24, size, 48),
            Color.FromArgb(148, 163, 184),
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

        return bmp;
    }
}
