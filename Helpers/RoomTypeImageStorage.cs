using System.Drawing;
using System.IO;

namespace HotelManagement.Helpers;

/// <summary>Lưu ảnh đại diện loại phòng dưới LocalAppData; DB chỉ giữ tên file.</summary>
public static class RoomTypeImageStorage
{
    public static string StorageDirectory => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "HotelManagement", "room-type-images");

    public static void EnsureStorageExists() => Directory.CreateDirectory(StorageDirectory);

    /// <summary>Sao chép file người dùng chọn vào thư mục lưu; trả về chỉ tên file.</summary>
    public static string ImportFile(string sourcePath)
    {
        if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
            throw new ArgumentException("Không tìm thấy file ảnh.");

        EnsureStorageExists();
        var ext = Path.GetExtension(sourcePath);
        if (string.IsNullOrEmpty(ext) || ext.Length > 6)
            ext = ".jpg";

        var extLower = ext.ToLowerInvariant();
        if (extLower is not ".jpg" and not ".jpeg" and not ".png" and not ".gif" and not ".webp" and not ".bmp")
            ext = ".jpg";

        var name = $"{Guid.NewGuid():N}{ext}";
        var dest = Path.Combine(StorageDirectory, name);
        File.Copy(sourcePath, dest, overwrite: true);
        return name;
    }

    public static string? GetFullPath(string? storedFileName)
    {
        if (string.IsNullOrWhiteSpace(storedFileName))
            return null;

        var name = Path.GetFileName(storedFileName.Trim());
        var p = Path.Combine(StorageDirectory, name);
        return File.Exists(p) ? p : null;
    }

    public static void TryDeleteStoredFile(string? storedFileName)
    {
        var p = GetFullPath(storedFileName);
        if (p == null)
            return;
        try
        {
            File.Delete(p);
        }
        catch
        {
            // bỏ qua — không chặn xóa loại phòng
        }
    }

    public static void TryLoadPicture(string? storedFileName, out Image? image)
    {
        image = null;
        var p = GetFullPath(storedFileName);
        if (p == null)
            return;
        try
        {
            using var fs = new FileStream(p, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            image = Image.FromStream(fs);
        }
        catch
        {
            image = null;
        }
    }
}
