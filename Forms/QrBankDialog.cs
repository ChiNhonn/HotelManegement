using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HotelManagement.Forms;

/// <summary>Modal đơn giản — hiển thị QR chuyển khoản (placeholder có thể thay bằng ảnh QR thật / API).</summary>
public sealed class QrBankDialog : Form
{
    private readonly Bitmap _qrBmp;

    /// <param name="transferMemoHint">Hướng dẫn nội dung CK (#DV…) để khớp tự động.</param>
    public QrBankDialog(decimal amount, string subtitle, string? transferMemoHint = null)
    {
        Text = "QR chuyển khoản";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(420, 588);
        BackColor = Color.White;

        var lblAmt = new Label
        {
            AutoSize = false,
            Dock = DockStyle.Top,
            Height = 52,
            Font = new Font("Segoe UI", 13f, FontStyle.Bold),
            ForeColor = Color.FromArgb(15, 23, 42),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = amount.ToString("N0") + " đ",
            Padding = new Padding(12, 14, 12, 6)
        };

        var lblSub = new Label
        {
            AutoSize = false,
            Dock = DockStyle.Top,
            Height = 36,
            Font = new Font("Segoe UI", 9f),
            ForeColor = Color.FromArgb(100, 116, 139),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = subtitle,
            Padding = new Padding(12, 0, 12, 8)
        };

        var memo = transferMemoHint ?? "Khách chuyển khoản nên ghi nội dung có #DV{mã đơn} và đúng số tiền để khớp tự động.";
        var lblMemo = new Label
        {
            AutoSize = false,
            Dock = DockStyle.Top,
            Height = 44,
            Font = new Font("Segoe UI", 8.25f),
            ForeColor = Color.FromArgb(71, 85, 105),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = memo,
            Padding = new Padding(16, 0, 16, 8)
        };

        _qrBmp = BuildPlaceholderQr(280);
        var pic = new PictureBox
        {
            Dock = DockStyle.Fill,
            SizeMode = PictureBoxSizeMode.Zoom,
            Image = _qrBmp,
            Padding = new Padding(24, 8, 24, 8),
            BackColor = Color.White
        };

        var btn = new Button
        {
            Dock = DockStyle.Bottom,
            Height = 44,
            Text = "Đóng",
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            Font = new Font("Segoe UI", 10f),
            DialogResult = DialogResult.OK,
            TabIndex = 0
        };

        Controls.Add(pic);
        Controls.Add(lblMemo);
        Controls.Add(lblSub);
        Controls.Add(lblAmt);
        Controls.Add(btn);

        AcceptButton = btn;
        CancelButton = btn;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            _qrBmp.Dispose();
        base.Dispose(disposing);
    }

    private static Bitmap BuildPlaceholderQr(int size)
    {
        var bmp = new Bitmap(size, size);
        using var g = Graphics.FromImage(bmp);
        g.Clear(Color.White);
        using var penGrid = new Pen(Color.FromArgb(230, 230, 230));
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
