using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using HotelManagement.Models;

namespace HotelManagement.Helpers;

/// <summary>
/// Room number convention NNN: floor is integer division by 100 (101 → 1; 1205 → 12).
/// </summary>
public static class RoomNumberFloorHelper
{
    /// <returns>Inferred floor number from the room string, or null if not enough digits.</returns>
    public static int? TryInferFloorNumber(string? roomName)
    {
        if (string.IsNullOrWhiteSpace(roomName))
            return null;

        var digits = new string(roomName.Trim().Where(char.IsDigit).ToArray());
        if (digits.Length < 2)
            return null;

        if (!int.TryParse(digits, NumberStyles.Integer, CultureInfo.InvariantCulture, out var num))
            return null;

        if (num >= 100)
            return num / 100;
        if (num >= 10)
            return num / 10;

        return null;
    }

    /// <summary>Find a floor row matching the numeric floor (name as number, contains number, or "Tầng n").</summary>
    public static Floor? MatchFloor(IReadOnlyList<Floor> floors, int floorNumber)
    {
        foreach (var f in floors)
        {
            if (int.TryParse(f.Name?.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var n)
                && n == floorNumber)
                return f;
        }

        foreach (var f in floors)
        {
            var name = f.Name?.Trim();
            if (name != null
                && name.Contains(floorNumber.ToString(CultureInfo.InvariantCulture), StringComparison.Ordinal))
                return f;
        }

        var label = $"Tầng {floorNumber}";
        return floors.FirstOrDefault(f =>
            string.Equals(f.Name?.Trim(), label, StringComparison.OrdinalIgnoreCase));
    }
}
