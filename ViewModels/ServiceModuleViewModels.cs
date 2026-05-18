using System;
using HotelManagement.Helpers;

namespace HotelManagement.ViewModels;

public sealed class ServiceCategoryRow
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string? Description { get; init; }
    public int SortOrder { get; init; }
    public int ServiceCount { get; init; }
}

public sealed class ServiceCatalogRow
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string CategoryName { get; init; } = "";
    public int? CategoryId { get; init; }
    public string Unit { get; init; } = "";
    public decimal UnitPrice { get; init; }
    public bool IsHidden { get; init; }
    public bool TrackInventory { get; init; }
    public int StockQuantity { get; init; }
    public string? Description { get; init; }
}

public sealed class ServicePackageRow
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public decimal PackagePrice { get; init; }
    public bool IsHidden { get; init; }
    public string ItemsSummary { get; init; } = "";
}

public sealed class ServicePriceRuleRow
{
    public int Id { get; init; }
    public int ServiceId { get; init; }
    public string ServiceName { get; init; } = "";
    public string RuleName { get; init; } = "";
    public string RuleType { get; init; } = "";
    public string RuleTypeDisplay { get; init; } = "";
    public decimal Price { get; init; }
    public string ScheduleSummary { get; init; } = "";
    public int Priority { get; init; }
}

public sealed class ActiveStayRow
{
    public int OrderId { get; init; }
    public int RoomId { get; init; }
    public string RoomName { get; init; } = "";
    public string GuestName { get; init; } = "";
    public string Status { get; init; } = "";
    public DateTime CheckIn { get; init; }
    public DateTime? CheckOut { get; init; }
    public string Display => $"{RoomName} — {GuestName}";
}

public sealed class ServiceOrderRow
{
    public int Id { get; init; }
    public int OrderId { get; init; }
    public int RoomId { get; init; }
    public string RoomName { get; init; } = "";
    public string GuestName { get; init; } = "";
    public string ItemName { get; init; } = "";
    public int Quantity { get; init; }
    public decimal LineTotal { get; init; }
    public string Status { get; init; } = "";
    public string StatusDisplay { get; init; } = "";
    public string ChargeMode { get; init; } = "";
    public string ChargeModeDisplay { get; init; } = "";
    public bool IsPostedToBill { get; init; }
    public DateTime CreateAt { get; init; }
    public string? Notes { get; init; }
    public string? CancelReason { get; init; }
}

public sealed class ServiceCatalogItemPick
{
    public int? ServiceId { get; init; }
    public int? PackageId { get; init; }
    public string Name { get; init; } = "";
    public string Unit { get; init; } = "";
    public decimal UnitPrice { get; init; }
    public int CategoryId { get; init; }
    public string CategoryName { get; init; } = "";
    public bool IsPackage { get; init; }
}

public sealed class ServiceRevenueReportRow
{
    public string GroupKey { get; init; } = "";
    public string CategoryName { get; init; } = "";
    public int OrderCount { get; init; }
    public decimal Revenue { get; init; }
    public decimal CancelFees { get; init; }
}

public sealed class ServiceUsageReportRow
{
    public int Hour { get; init; }
    public string ServiceName { get; init; } = "";
    public int CompletedCount { get; init; }
    public int CancelledCount { get; init; }
}

public sealed class ServiceCategoryEditModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public int SortOrder { get; set; }
}

public sealed class ServiceEditModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
    public string Unit { get; set; } = "lần";
    public decimal UnitPrice { get; set; }
    public int? CategoryId { get; set; }
    public bool IsHidden { get; set; }
    public bool TrackInventory { get; set; }
    public int StockQuantity { get; set; }
}

public sealed class ServicePackageEditModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
    public decimal PackagePrice { get; set; }
    public bool IsHidden { get; set; }
    public List<ServicePackageItemEdit> Items { get; set; } = new();
}

public sealed class ServicePackageItemEdit
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; } = "";
    public int Quantity { get; set; } = 1;
}

public sealed class ServicePriceRuleEditModel
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public string RuleName { get; set; } = "";
    public string RuleType { get; set; } = ServicePriceRuleType.OffPeak;
    public decimal Price { get; set; }
    public TimeSpan? TimeStart { get; set; }
    public TimeSpan? TimeEnd { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public int Priority { get; set; }
}
