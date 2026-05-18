using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Data;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services;

public sealed class ServiceModuleService : IServiceModuleService
{
    private readonly HotelDbContext _db;

    public ServiceModuleService(HotelDbContext db)
    {
        _db = db;
    }

    #region Categories

    public List<ServiceCategoryRow> GetCategories(string? search = null)
    {
        var q = _db.ServiceCategories.AsNoTracking().Where(c => c.SoftDelete == null);
        if (!string.IsNullOrWhiteSpace(search))
        {
            var k = search.Trim();
            q = q.Where(c => c.Name.Contains(k));
        }

        return q.OrderBy(c => c.SortOrder).ThenBy(c => c.Name)
            .Select(c => new ServiceCategoryRow
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                SortOrder = c.SortOrder,
                ServiceCount = c.Services.Count(s => s.SoftDelete == null)
            })
            .ToList();
    }

    public List<ServiceCategoryRow> GetCategoriesForPicker() => GetCategories();

    public ServiceCategoryEditModel? GetCategoryForEdit(int id)
    {
        var c = _db.ServiceCategories.AsNoTracking().FirstOrDefault(x => x.Id == id && x.SoftDelete == null);
        if (c == null) return null;
        return new ServiceCategoryEditModel { Id = c.Id, Name = c.Name, Description = c.Description, SortOrder = c.SortOrder };
    }

    public void SaveCategory(ServiceCategoryEditModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Name))
            throw new InvalidOperationException("Tên phân loại không được để trống.");

        if (model.Id == 0)
        {
            _db.ServiceCategories.Add(new ServiceCategory
            {
                Name = model.Name.Trim(),
                Description = model.Description?.Trim(),
                SortOrder = model.SortOrder,
                CreateAt = DateTime.Now
            });
        }
        else
        {
            var c = _db.ServiceCategories.FirstOrDefault(x => x.Id == model.Id && x.SoftDelete == null)
                ?? throw new InvalidOperationException("Không tìm thấy phân loại.");
            c.Name = model.Name.Trim();
            c.Description = model.Description?.Trim();
            c.SortOrder = model.SortOrder;
            c.UpdateAt = DateTime.Now;
        }

        _db.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        var c = _db.ServiceCategories.FirstOrDefault(x => x.Id == id && x.SoftDelete == null)
            ?? throw new InvalidOperationException("Không tìm thấy phân loại.");
        var hasServices = _db.Services.Any(s => s.IdServiceCategory == id && s.SoftDelete == null);
        if (hasServices)
            throw new InvalidOperationException("Không thể xóa phân loại đang có dịch vụ.");
        c.SoftDelete = DateTime.Now;
        c.UpdateAt = DateTime.Now;
        _db.SaveChanges();
    }

    #endregion

    #region Services

    public List<ServiceCatalogRow> GetServices(int? categoryId, string? search, bool includeHidden)
    {
        var q = _db.Services.AsNoTracking()
            .Include(s => s.ServiceCategory)
            .Where(s => s.SoftDelete == null);

        if (!includeHidden) q = q.Where(s => !s.IsHidden);
        if (categoryId.HasValue) q = q.Where(s => s.IdServiceCategory == categoryId);
        if (!string.IsNullOrWhiteSpace(search))
        {
            var k = search.Trim();
            q = q.Where(s => s.Name.Contains(k));
        }

        return q.OrderBy(s => s.ServiceCategory!.Name).ThenBy(s => s.Name)
            .Select(s => new ServiceCatalogRow
            {
                Id = s.Id,
                Name = s.Name,
                CategoryName = s.ServiceCategory != null ? s.ServiceCategory.Name : "",
                CategoryId = s.IdServiceCategory,
                Unit = s.Unit,
                UnitPrice = s.UnitPrice,
                IsHidden = s.IsHidden,
                TrackInventory = s.TrackInventory,
                StockQuantity = s.StockQuantity,
                Description = s.Description
            })
            .ToList();
    }

    public ServiceEditModel? GetServiceForEdit(int id)
    {
        var s = _db.Services.AsNoTracking().FirstOrDefault(x => x.Id == id && x.SoftDelete == null);
        if (s == null) return null;
        return new ServiceEditModel
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            ImagePath = s.ImagePath,
            Unit = s.Unit,
            UnitPrice = s.UnitPrice,
            CategoryId = s.IdServiceCategory,
            IsHidden = s.IsHidden,
            TrackInventory = s.TrackInventory,
            StockQuantity = s.StockQuantity
        };
    }

    public void SaveService(ServiceEditModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Name))
            throw new InvalidOperationException("Tên dịch vụ không được để trống.");
        if (model.UnitPrice < 0)
            throw new InvalidOperationException("Giá bán không hợp lệ.");

        if (model.Id == 0)
        {
            _db.Services.Add(new Service
            {
                Name = model.Name.Trim(),
                Description = model.Description?.Trim(),
                ImagePath = model.ImagePath?.Trim(),
                Unit = string.IsNullOrWhiteSpace(model.Unit) ? "lần" : model.Unit.Trim(),
                UnitPrice = model.UnitPrice,
                IdServiceCategory = model.CategoryId,
                IsHidden = model.IsHidden,
                TrackInventory = model.TrackInventory,
                StockQuantity = Math.Max(0, model.StockQuantity),
                CreateAt = DateTime.Now
            });
        }
        else
        {
            var s = _db.Services.FirstOrDefault(x => x.Id == model.Id && x.SoftDelete == null)
                ?? throw new InvalidOperationException("Không tìm thấy dịch vụ.");
            s.Name = model.Name.Trim();
            s.Description = model.Description?.Trim();
            s.ImagePath = model.ImagePath?.Trim();
            s.Unit = string.IsNullOrWhiteSpace(model.Unit) ? "lần" : model.Unit.Trim();
            s.UnitPrice = model.UnitPrice;
            s.IdServiceCategory = model.CategoryId;
            s.IsHidden = model.IsHidden;
            s.TrackInventory = model.TrackInventory;
            s.StockQuantity = Math.Max(0, model.StockQuantity);
            s.UpdateAt = DateTime.Now;
        }

        _db.SaveChanges();
    }

    public void SetServiceHidden(int id, bool hidden)
    {
        var s = _db.Services.FirstOrDefault(x => x.Id == id && x.SoftDelete == null)
            ?? throw new InvalidOperationException("Không tìm thấy dịch vụ.");
        s.IsHidden = hidden;
        s.UpdateAt = DateTime.Now;
        _db.SaveChanges();
    }

    public void DeleteService(int id)
    {
        var s = _db.Services.FirstOrDefault(x => x.Id == id && x.SoftDelete == null)
            ?? throw new InvalidOperationException("Không tìm thấy dịch vụ.");
        s.SoftDelete = DateTime.Now;
        s.UpdateAt = DateTime.Now;
        _db.SaveChanges();
    }

    #endregion

    #region Packages

    public List<ServicePackageRow> GetPackages(string? search, bool includeHidden)
    {
        var q = _db.ServicePackages.AsNoTracking()
            .Include(p => p.Items)
            .ThenInclude(i => i.Service)
            .Where(p => p.SoftDelete == null);

        if (!includeHidden) q = q.Where(p => !p.IsHidden);
        if (!string.IsNullOrWhiteSpace(search))
        {
            var k = search.Trim();
            q = q.Where(p => p.Name.Contains(k));
        }

        return q.OrderBy(p => p.Name).Select(p => new ServicePackageRow
        {
            Id = p.Id,
            Name = p.Name,
            PackagePrice = p.PackagePrice,
            IsHidden = p.IsHidden,
            ItemsSummary = string.Join(", ", p.Items.Select(i =>
                $"{i.Quantity}×{i.Service.Name}"))
        }).ToList();
    }

    public ServicePackageEditModel? GetPackageForEdit(int id)
    {
        var p = _db.ServicePackages
            .Include(x => x.Items)
            .ThenInclude(i => i.Service)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id && x.SoftDelete == null);
        if (p == null) return null;

        return new ServicePackageEditModel
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            ImagePath = p.ImagePath,
            PackagePrice = p.PackagePrice,
            IsHidden = p.IsHidden,
            Items = p.Items.Select(i => new ServicePackageItemEdit
            {
                ServiceId = i.IdService,
                ServiceName = i.Service.Name,
                Quantity = i.Quantity
            }).ToList()
        };
    }

    public void SavePackage(ServicePackageEditModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Name))
            throw new InvalidOperationException("Tên gói không được để trống.");
        if (model.Items.Count == 0)
            throw new InvalidOperationException("Gói cần ít nhất một dịch vụ.");

        ServicePackage entity;
        if (model.Id == 0)
        {
            entity = new ServicePackage { CreateAt = DateTime.Now };
            _db.ServicePackages.Add(entity);
        }
        else
        {
            entity = _db.ServicePackages
                .Include(p => p.Items)
                .FirstOrDefault(x => x.Id == model.Id && x.SoftDelete == null)
                ?? throw new InvalidOperationException("Không tìm thấy gói.");
            _db.ServicePackageItems.RemoveRange(entity.Items);
            entity.UpdateAt = DateTime.Now;
        }

        entity.Name = model.Name.Trim();
        entity.Description = model.Description?.Trim();
        entity.ImagePath = model.ImagePath?.Trim();
        entity.PackagePrice = model.PackagePrice;
        entity.IsHidden = model.IsHidden;
        entity.Items = model.Items.Select(i => new ServicePackageItem
        {
            IdService = i.ServiceId,
            Quantity = Math.Max(1, i.Quantity)
        }).ToList();

        _db.SaveChanges();
    }

    public void DeletePackage(int id)
    {
        var p = _db.ServicePackages.FirstOrDefault(x => x.Id == id && x.SoftDelete == null)
            ?? throw new InvalidOperationException("Không tìm thấy gói.");
        p.SoftDelete = DateTime.Now;
        p.UpdateAt = DateTime.Now;
        _db.SaveChanges();
    }

    #endregion

    #region Price rules

    public List<ServicePriceRuleRow> GetPriceRules(int? serviceId)
    {
        var q = _db.ServicePriceRules.AsNoTracking()
            .Include(r => r.Service)
            .Where(r => r.SoftDelete == null);

        if (serviceId.HasValue) q = q.Where(r => r.IdService == serviceId);

        return q.OrderByDescending(r => r.Priority).ThenBy(r => r.RuleName)
            .Select(r => new ServicePriceRuleRow
            {
                Id = r.Id,
                ServiceId = r.IdService,
                ServiceName = r.Service.Name,
                RuleName = r.RuleName,
                RuleType = r.RuleType,
                RuleTypeDisplay = ServicePriceRuleType.ToDisplay(r.RuleType),
                Price = r.Price,
                Priority = r.Priority,
                ScheduleSummary = BuildScheduleSummary(r.TimeStart, r.TimeEnd, r.DateStart, r.DateEnd)
            })
            .ToList();
    }

    public ServicePriceRuleEditModel? GetPriceRuleForEdit(int id)
    {
        var r = _db.ServicePriceRules.AsNoTracking().FirstOrDefault(x => x.Id == id && x.SoftDelete == null);
        if (r == null) return null;
        return new ServicePriceRuleEditModel
        {
            Id = r.Id,
            ServiceId = r.IdService,
            RuleName = r.RuleName,
            RuleType = r.RuleType,
            Price = r.Price,
            TimeStart = r.TimeStart,
            TimeEnd = r.TimeEnd,
            DateStart = r.DateStart,
            DateEnd = r.DateEnd,
            Priority = r.Priority
        };
    }

    public void SavePriceRule(ServicePriceRuleEditModel model)
    {
        if (string.IsNullOrWhiteSpace(model.RuleName))
            throw new InvalidOperationException("Tên quy tắc không được để trống.");
        if (!_db.Services.Any(s => s.Id == model.ServiceId && s.SoftDelete == null))
            throw new InvalidOperationException("Dịch vụ không hợp lệ.");

        if (model.Id == 0)
        {
            _db.ServicePriceRules.Add(MapRule(model, new ServicePriceRule { CreateAt = DateTime.Now }));
        }
        else
        {
            var r = _db.ServicePriceRules.FirstOrDefault(x => x.Id == model.Id && x.SoftDelete == null)
                ?? throw new InvalidOperationException("Không tìm thấy quy tắc giá.");
            MapRule(model, r);
        }

        _db.SaveChanges();
    }

    public void DeletePriceRule(int id)
    {
        var r = _db.ServicePriceRules.FirstOrDefault(x => x.Id == id && x.SoftDelete == null)
            ?? throw new InvalidOperationException("Không tìm thấy quy tắc giá.");
        r.SoftDelete = DateTime.Now;
        _db.SaveChanges();
    }

    public decimal ResolveUnitPrice(int serviceId, DateTime? at = null)
    {
        var when = at ?? DateTime.Now;
        var service = _db.Services.AsNoTracking().FirstOrDefault(s => s.Id == serviceId && s.SoftDelete == null);
        if (service == null) return 0;

        var rules = _db.ServicePriceRules.AsNoTracking()
            .Where(r => r.IdService == serviceId && r.SoftDelete == null)
            .OrderByDescending(r => r.Priority)
            .ToList();

        foreach (var r in rules)
        {
            if (RuleMatches(r, when)) return r.Price;
        }

        return service.UnitPrice;
    }

    private static bool RuleMatches(ServicePriceRule r, DateTime when)
    {
        if (r.DateStart.HasValue && when.Date < r.DateStart.Value.Date) return false;
        if (r.DateEnd.HasValue && when.Date > r.DateEnd.Value.Date) return false;

        if (r.TimeStart.HasValue && r.TimeEnd.HasValue)
        {
            var t = when.TimeOfDay;
            var start = r.TimeStart.Value;
            var end = r.TimeEnd.Value;
            if (start <= end)
            {
                if (t < start || t > end) return false;
            }
            else
            {
                if (t < start && t > end) return false;
            }
        }

        return true;
    }

    private static ServicePriceRule MapRule(ServicePriceRuleEditModel m, ServicePriceRule r)
    {
        r.IdService = m.ServiceId;
        r.RuleName = m.RuleName.Trim();
        r.RuleType = m.RuleType;
        r.Price = m.Price;
        r.TimeStart = m.TimeStart;
        r.TimeEnd = m.TimeEnd;
        r.DateStart = m.DateStart?.Date;
        r.DateEnd = m.DateEnd?.Date;
        r.Priority = m.Priority;
        return r;
    }

    private static string BuildScheduleSummary(TimeSpan? ts, TimeSpan? te, DateTime? ds, DateTime? de)
    {
        var parts = new List<string>();
        if (ts.HasValue && te.HasValue)
            parts.Add($"{ts.Value:hh\\:mm}–{te.Value:hh\\:mm}");
        if (ds.HasValue || de.HasValue)
            parts.Add($"{ds:dd/MM/yyyy} → {de:dd/MM/yyyy}");
        return parts.Count > 0 ? string.Join(" · ", parts) : "Cả ngày";
    }

    #endregion

    #region Operations

    private static readonly string[] ActiveOrderStatuses = { "Confirmed", "CheckedIn", "checked_in", "occupied" };

    public List<ActiveStayRow> GetActiveStays(string? search)
    {
        var today = DateTime.Today;
        var q = _db.Orders.AsNoTracking()
            .Include(o => o.Customer)
            .Include(o => o.OrderDetails!)
            .ThenInclude(d => d.Room)
            .Where(o => o.SoftDelete == null
                && o.DateCheckIn.Date <= today
                && (o.DateCheckOut == null || o.DateCheckOut.Value.Date >= today)
                && ActiveOrderStatuses.Contains(o.Status));

        var rows = new List<ActiveStayRow>();
        foreach (var o in q.ToList())
        {
            var roomLine = o.OrderDetails?.FirstOrDefault(d => d.IdRoom != null);
            if (roomLine?.Room == null) continue;

            var guest = o.Customer?.FullName?.Trim() ?? "Khách";
            var room = roomLine.Room.Name?.Trim() ?? $"#{roomLine.Room.Id}";
            if (!string.IsNullOrWhiteSpace(search))
            {
                var k = search.Trim();
                if (!room.Contains(k, StringComparison.OrdinalIgnoreCase)
                    && !guest.Contains(k, StringComparison.OrdinalIgnoreCase))
                    continue;
            }

            rows.Add(new ActiveStayRow
            {
                OrderId = o.Id,
                RoomId = roomLine.Room.Id,
                RoomName = room,
                GuestName = guest,
                Status = o.Status,
                CheckIn = o.DateCheckIn,
                CheckOut = o.DateCheckOut
            });
        }

        return rows.OrderBy(r => r.RoomName).ToList();
    }

    public List<ServiceCatalogItemPick> GetCatalogItemsForOrder(int? categoryId, string? search)
    {
        var items = new List<ServiceCatalogItemPick>();

        var svcQ = _db.Services.AsNoTracking()
            .Include(s => s.ServiceCategory)
            .Where(s => s.SoftDelete == null && !s.IsHidden);

        if (categoryId.HasValue) svcQ = svcQ.Where(s => s.IdServiceCategory == categoryId);
        if (!string.IsNullOrWhiteSpace(search))
        {
            var k = search.Trim();
            svcQ = svcQ.Where(s => s.Name.Contains(k));
        }

        foreach (var s in svcQ.OrderBy(s => s.Name).ToList())
        {
            items.Add(new ServiceCatalogItemPick
            {
                ServiceId = s.Id,
                Name = s.Name,
                Unit = s.Unit,
                UnitPrice = ResolveUnitPrice(s.Id),
                CategoryId = s.IdServiceCategory ?? 0,
                CategoryName = s.ServiceCategory?.Name ?? "",
                IsPackage = false
            });
        }

        var pkgQ = _db.ServicePackages.AsNoTracking().Where(p => p.SoftDelete == null && !p.IsHidden);
        if (!string.IsNullOrWhiteSpace(search))
        {
            var k = search.Trim();
            pkgQ = pkgQ.Where(p => p.Name.Contains(k));
        }

        foreach (var p in pkgQ.OrderBy(p => p.Name).ToList())
        {
            items.Add(new ServiceCatalogItemPick
            {
                PackageId = p.Id,
                Name = $"[Gói] {p.Name}",
                Unit = "gói",
                UnitPrice = p.PackagePrice,
                CategoryId = -1,
                CategoryName = "Combo",
                IsPackage = true
            });
        }

        return items;
    }

    public void PlaceServiceOrder(int orderId, int roomId, int? serviceId, int? packageId, int quantity, string chargeMode, string? notes, int? userId)
    {
        if (quantity < 1) throw new InvalidOperationException("Số lượng phải ≥ 1.");
        if (serviceId == null && packageId == null)
            throw new InvalidOperationException("Chọn dịch vụ hoặc gói.");

        var order = _db.Orders.FirstOrDefault(o => o.Id == orderId && o.SoftDelete == null)
            ?? throw new InvalidOperationException("Không tìm thấy đơn lưu trú.");

        string itemName;
        decimal unitPrice;

        if (packageId.HasValue)
        {
            var pkg = _db.ServicePackages.AsNoTracking().FirstOrDefault(p => p.Id == packageId && p.SoftDelete == null)
                ?? throw new InvalidOperationException("Không tìm thấy gói.");
            itemName = pkg.Name;
            unitPrice = pkg.PackagePrice;
        }
        else
        {
            var svc = _db.Services.AsNoTracking().FirstOrDefault(s => s.Id == serviceId && s.SoftDelete == null)
                ?? throw new InvalidOperationException("Không tìm thấy dịch vụ.");
            if (svc.TrackInventory && svc.StockQuantity < quantity)
                throw new InvalidOperationException($"Tồn kho không đủ ({svc.StockQuantity} {svc.Unit}).");
            itemName = svc.Name;
            unitPrice = ResolveUnitPrice(svc.Id);
        }

        var line = new ServiceOrder
        {
            IdOrder = orderId,
            IdRoom = roomId,
            IdService = serviceId,
            IdServicePackage = packageId,
            ItemName = itemName.Length > 150 ? itemName[..150] : itemName,
            Quantity = quantity,
            UnitPrice = unitPrice,
            LineTotal = unitPrice * quantity,
            Status = ServiceOrderStatus.Pending,
            ChargeMode = chargeMode == ServiceChargeMode.Immediate ? ServiceChargeMode.Immediate : ServiceChargeMode.Folio,
            Notes = notes?.Trim(),
            IdUser = userId,
            CreateAt = DateTime.Now
        };

        _db.ServiceOrders.Add(line);
        _db.SaveChanges();
    }

    public List<ServiceOrderRow> GetServiceOrders(string? statusFilter, int? orderId, string? search)
    {
        var q = _db.ServiceOrders.AsNoTracking()
            .Include(o => o.Order).ThenInclude(ord => ord!.Customer)
            .Include(o => o.Room)
            .Where(o => o.SoftDelete == null);

        if (!string.IsNullOrWhiteSpace(statusFilter) && statusFilter != "all")
            q = q.Where(o => o.Status == statusFilter);
        if (orderId.HasValue) q = q.Where(o => o.IdOrder == orderId);

        var list = q.OrderByDescending(o => o.CreateAt).Take(500).ToList();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var k = search.Trim();
            list = list.Where(o =>
                o.ItemName.Contains(k, StringComparison.OrdinalIgnoreCase)
                || (o.Room?.Name?.Contains(k, StringComparison.OrdinalIgnoreCase) ?? false)).ToList();
        }

        return list.Select(MapOrderRow).ToList();
    }

    public void UpdateServiceOrderStatus(int serviceOrderId, string newStatus, int? userId)
    {
        if (!ServiceOrderStatus.All.Contains(newStatus))
            throw new InvalidOperationException("Trạng thái không hợp lệ.");

        var line = _db.ServiceOrders
            .Include(o => o.Service)
            .FirstOrDefault(o => o.Id == serviceOrderId && o.SoftDelete == null)
            ?? throw new InvalidOperationException("Không tìm thấy yêu cầu dịch vụ.");

        if (line.Status == ServiceOrderStatus.Cancelled)
            throw new InvalidOperationException("Yêu cầu đã hủy, không thể cập nhật.");

        line.Status = newStatus;
        line.UpdateAt = DateTime.Now;

        if (newStatus == ServiceOrderStatus.Completed)
        {
            line.CompletedAt = DateTime.Now;
            DeductInventoryIfNeeded(line);
            if (!line.IsPostedToBill)
                PostToRoomFolio(line, userId);
        }

        _db.SaveChanges();
    }

    public void CancelServiceOrder(int serviceOrderId, string reason, decimal cancellationFee, int? userId)
    {
        var line = _db.ServiceOrders.FirstOrDefault(o => o.Id == serviceOrderId && o.SoftDelete == null)
            ?? throw new InvalidOperationException("Không tìm thấy yêu cầu dịch vụ.");

        if (line.Status == ServiceOrderStatus.Completed)
            throw new InvalidOperationException("Đã hoàn thành, không thể hủy trực tiếp.");

        line.Status = ServiceOrderStatus.Cancelled;
        line.CancelReason = string.IsNullOrWhiteSpace(reason) ? "Khách đổi ý" : reason.Trim();
        line.CancellationFee = Math.Max(0, cancellationFee);
        line.CancelledAt = DateTime.Now;
        line.UpdateAt = DateTime.Now;

        if (line.CancellationFee > 0 && !line.IsPostedToBill)
        {
            line.ItemName = $"{line.ItemName} (phí hủy)";
            line.LineTotal = line.CancellationFee;
            line.Quantity = 1;
            line.UnitPrice = line.CancellationFee;
            PostToRoomFolio(line, userId);
        }

        _db.SaveChanges();
    }

    #endregion

    #region Payment

    public List<ServiceOrderRow> GetOrdersAwaitingPayment()
    {
        var paidBillIds = _db.Payments.AsNoTracking()
            .Where(p => p.SoftDelete == null && p.Status == "Paid" && p.IdBill != null)
            .Select(p => p.IdBill!.Value)
            .ToHashSet();

        // Không được gọi _db trong .AsEnumerable()/.Where LINQ-client: một DataReader của truy vấn cha
        // đang mở sẽ gây lỗi "already an open DataReader..." (SQLite / MARS không bật).
        var candidates = _db.ServiceOrders.AsNoTracking()
            .Include(o => o.Order).ThenInclude(ord => ord!.Customer)
            .Include(o => o.Room)
            .Where(o => o.SoftDelete == null
                && o.Status == ServiceOrderStatus.Completed
                && o.ChargeMode == ServiceChargeMode.Immediate
                && o.IsPostedToBill)
            .ToList();

        if (candidates.Count == 0)
            return new List<ServiceOrderRow>();

        var orderIds = candidates.Select(o => o.IdOrder).Distinct().ToList();
        var billsByOrder = _db.Bills.AsNoTracking()
            .Where(b => b.SoftDelete == null && b.IdOrder != null && orderIds.Contains(b.IdOrder.Value))
            .Select(b => new { b.Id, IdOrder = b.IdOrder!.Value })
            .ToList()
            .GroupBy(x => x.IdOrder)
            .ToDictionary(g => g.Key, g => g.Min(x => x.Id));

        return candidates
            .Where(o => billsByOrder.TryGetValue(o.IdOrder, out var billId)
                && billId > 0
                && !paidBillIds.Contains(billId))
            .Select(MapOrderRow)
            .ToList();
    }

    public void PostImmediatePayment(int serviceOrderId, string method, int? userId)
    {
        var line = _db.ServiceOrders.FirstOrDefault(o => o.Id == serviceOrderId && o.SoftDelete == null)
            ?? throw new InvalidOperationException("Không tìm thấy yêu cầu.");

        if (line.ChargeMode != ServiceChargeMode.Immediate)
            throw new InvalidOperationException("Yêu cầu không thuộc luồng thanh toán ngay.");

        if (!line.IsPostedToBill)
            PostToRoomFolio(line, userId);

        var bill = _db.Bills.Include(b => b.Payments).FirstOrDefault(b => b.IdOrder == line.IdOrder)
            ?? throw new InvalidOperationException("Không tìm thấy hóa đơn.");

        _db.Payments.Add(new Payment
        {
            IdBill = bill.Id,
            Method = string.IsNullOrWhiteSpace(method) ? "Tiền mặt" : method.Trim(),
            Status = "Paid",
            CreateAt = DateTime.Now
        });

        bill.Status = "Paid";
        _db.SaveChanges();
    }

    #endregion

    #region Reports

    public List<ServiceRevenueReportRow> GetRevenueReport(DateTime from, DateTime to, int? categoryId)
    {
        var end = to.Date.AddDays(1);
        var q = _db.ServiceOrders.AsNoTracking()
            .Include(o => o.Service).ThenInclude(s => s!.ServiceCategory)
            .Where(o => o.SoftDelete == null
                && o.Status == ServiceOrderStatus.Completed
                && o.CreateAt >= from.Date
                && o.CreateAt < end);

        if (categoryId.HasValue)
            q = q.Where(o => o.Service != null && o.Service.IdServiceCategory == categoryId);

        return q.AsEnumerable()
            .GroupBy(o => o.Service?.ServiceCategory?.Name ?? (o.IdServicePackage != null ? "Combo" : "Khác"))
            .Select(g => new ServiceRevenueReportRow
            {
                GroupKey = g.Key,
                CategoryName = g.Key,
                OrderCount = g.Count(),
                Revenue = g.Sum(x => x.LineTotal),
                CancelFees = 0
            })
            .OrderByDescending(r => r.Revenue)
            .ToList();
    }

    public List<ServiceUsageReportRow> GetUsageReport(DateTime from, DateTime to)
    {
        var end = to.Date.AddDays(1);
        var orders = _db.ServiceOrders.AsNoTracking()
            .Where(o => o.SoftDelete == null && o.CreateAt >= from.Date && o.CreateAt < end)
            .ToList();

        return orders
            .GroupBy(o => new { o.CreateAt.Hour, o.ItemName })
            .Select(g => new ServiceUsageReportRow
            {
                Hour = g.Key.Hour,
                ServiceName = g.Key.ItemName,
                CompletedCount = g.Count(x => x.Status == ServiceOrderStatus.Completed),
                CancelledCount = g.Count(x => x.Status == ServiceOrderStatus.Cancelled)
            })
            .OrderBy(r => r.Hour)
            .ThenByDescending(r => r.CompletedCount)
            .ToList();
    }

    #endregion

    #region Folio / inventory helpers

    private void PostToRoomFolio(ServiceOrder line, int? userId)
    {
        var bill = EnsureBillForOrder(line.IdOrder, userId);
        var product = line.ItemName.Length > 255 ? line.ItemName[..255] : line.ItemName;

        var detail = new BillDetail
        {
            IdBill = bill.Id,
            IdService = line.IdService,
            Product = product,
            Quantity = line.Quantity,
            UnitPrice = line.UnitPrice,
            SubTotal = line.LineTotal
        };
        _db.BillDetails.Add(detail);
        _db.SaveChanges();

        line.IdBillDetail = detail.Id;
        line.IsPostedToBill = true;
        RecalculateBillTotal(bill.Id);
    }

    private Bill EnsureBillForOrder(int orderId, int? userId)
    {
        var bill = _db.Bills
            .Include(b => b.BillDetails)
            .FirstOrDefault(b => b.IdOrder == orderId && b.SoftDelete == null);

        if (bill != null) return bill;

        var order = _db.Orders.FirstOrDefault(o => o.Id == orderId)
            ?? throw new InvalidOperationException("Không tìm thấy đơn.");

        bill = new Bill
        {
            IdOrder = orderId,
            IdUser = userId ?? order.IdUser,
            Status = "Pending",
            CreateAt = DateTime.Now,
            TotalAmount = 0,
            Discount = 0,
            Tax = 0
        };
        _db.Bills.Add(bill);
        _db.SaveChanges();
        return bill;
    }

    private void RecalculateBillTotal(int billId)
    {
        var bill = _db.Bills.Include(b => b.BillDetails).FirstOrDefault(b => b.Id == billId);
        if (bill == null) return;

        var sub = bill.BillDetails?.Sum(d => d.SubTotal) ?? 0;
        bill.TotalAmount = Math.Max(0, sub - bill.Discount + bill.Tax);
        _db.SaveChanges();
    }

    private void DeductInventoryIfNeeded(ServiceOrder line)
    {
        if (!line.IdService.HasValue) return;
        var svc = _db.Services.FirstOrDefault(s => s.Id == line.IdService && s.SoftDelete == null);
        if (svc == null || !svc.TrackInventory) return;
        svc.StockQuantity = Math.Max(0, svc.StockQuantity - line.Quantity);
        svc.UpdateAt = DateTime.Now;
    }

    private static ServiceOrderRow MapOrderRow(ServiceOrder o) => new()
    {
        Id = o.Id,
        OrderId = o.IdOrder,
        RoomId = o.IdRoom,
        RoomName = o.Room?.Name ?? "",
        GuestName = o.Order?.Customer?.FullName ?? "",
        ItemName = o.ItemName,
        Quantity = o.Quantity,
        LineTotal = o.LineTotal,
        Status = o.Status,
        StatusDisplay = ServiceOrderStatus.ToDisplay(o.Status),
        ChargeMode = o.ChargeMode,
        ChargeModeDisplay = ServiceChargeMode.ToDisplay(o.ChargeMode),
        IsPostedToBill = o.IsPostedToBill,
        CreateAt = o.CreateAt,
        Notes = o.Notes,
        CancelReason = o.CancelReason
    };

    #endregion
}
