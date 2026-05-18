using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace HotelManagement.Helpers;

/// <summary>Vẽ glyph từ font "Segoe MDL2 Assets" ra bitmap trong suốt (fallback "Segoe UI Symbol").</summary>
public static class Mdl2Icons
{
    public static Bitmap Create(char ch, Color color, int box = 22, float glyphScale = 0.52f)
    {
        var bmp = new Bitmap(box, box, PixelFormat.Format32bppArgb);
        using var g = Graphics.FromImage(bmp);
        g.Clear(Color.Transparent);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = TextRenderingHint.AntiAlias;
        using var font = CreateFont(box * glyphScale);
        var txt = ch.ToString();
        var sz = TextRenderer.MeasureText(txt, font);
        TextRenderer.DrawText(
            g,
            txt,
            font,
            new Rectangle((box - sz.Width) / 2, (box - sz.Height) / 2, sz.Width, sz.Height),
            color,
            TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix);
        return bmp;
    }

    public static Font CreateFont(float sizePx)
    {
        try
        {
            var f = new Font("Segoe MDL2 Assets", sizePx, FontStyle.Regular, GraphicsUnit.Pixel);
            if (f.Name.IndexOf("MDL2", StringComparison.OrdinalIgnoreCase) >= 0)
                return f;
            f.Dispose();
        }
        catch
        {
            // fallback
        }

        return new Font("Segoe UI Symbol", sizePx * 0.9f, FontStyle.Regular, GraphicsUnit.Pixel);
    }
}
