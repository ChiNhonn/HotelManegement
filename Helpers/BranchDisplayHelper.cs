using HotelManagement.Models;

namespace HotelManagement.Helpers;

public static class BranchDisplayHelper
{
    public static string Format(Branch? branch)
    {
        if (branch == null)
            return "—";

        var parts = new[]
        {
            branch.City?.Trim(),
            branch.Commune?.Trim(),
            branch.StreetName?.Trim(),
            string.IsNullOrWhiteSpace(branch.HouseNumber) ? null : $"Số {branch.HouseNumber.Trim()}",
        }.Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();

        return parts.Length > 0 ? string.Join(" · ", parts) : $"Chi nhánh #{branch.Id}";
    }
}
