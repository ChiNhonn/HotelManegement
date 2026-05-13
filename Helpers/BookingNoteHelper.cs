using System;
using System.Text.RegularExpressions;

namespace HotelManagement.Helpers;

public static class BookingNoteHelper
{
    private static readonly Regex GuestHeadRx = new(
        @"^\s*Người lớn:\s*(\d+)\s*,\s*Trẻ em:\s*(\d+)\.\s*",
        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

    public static bool TryParseStandardGuestNote(string? note, out int adults, out int children,
        out string? userNote)
    {
        adults = 1;
        children = 0;
        userNote = null;
        if (string.IsNullOrWhiteSpace(note))
            return false;
        var m = GuestHeadRx.Match(note);
        if (!m.Success)
            return false;
        adults = int.TryParse(m.Groups[1].Value, out var a) ? Math.Max(1, a) : 1;
        children = int.TryParse(m.Groups[2].Value, out var c) ? Math.Max(0, c) : 0;
        var tail = note[m.Length..].Trim();
        userNote = string.IsNullOrEmpty(tail) ? null : tail;
        return true;
    }

    public static (int Adults, int Children, string? UserNote) ParseGuestNote(string? note)
    {
        if (TryParseStandardGuestNote(note, out var a, out var c, out var u))
            return (a, c, u);
        if (string.IsNullOrWhiteSpace(note))
            return (1, 0, null);
        return (1, 0, note.Trim());
    }

    public static string ComposeGuestNote(int adults, int children, string? userNote)
    {
        var head = $"Người lớn: {adults}, Trẻ em: {children}.";
        if (string.IsNullOrWhiteSpace(userNote))
            return head.Length <= 255 ? head : head[..255];
        var trimmed = userNote.Trim();
        var combined = head + " " + trimmed;
        return combined.Length <= 255 ? combined : combined[..255];
    }
}
