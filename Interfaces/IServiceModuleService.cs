using HotelManagement.ViewModels;

namespace HotelManagement.Interfaces;

public interface IServiceModuleService
{
    // Catalog — categories
    List<ServiceCategoryRow> GetCategories(string? search = null);
    ServiceCategoryEditModel? GetCategoryForEdit(int id);
    void SaveCategory(ServiceCategoryEditModel model);
    void DeleteCategory(int id);

    // Catalog — services
    List<ServiceCatalogRow> GetServices(int? categoryId, string? search, bool includeHidden);
    ServiceEditModel? GetServiceForEdit(int id);
    void SaveService(ServiceEditModel model);
    void SetServiceHidden(int id, bool hidden);
    void DeleteService(int id);

    // Catalog — packages
    List<ServicePackageRow> GetPackages(string? search, bool includeHidden);
    ServicePackageEditModel? GetPackageForEdit(int id);
    void SavePackage(ServicePackageEditModel model);
    void DeletePackage(int id);

    // Catalog — price rules
    List<ServicePriceRuleRow> GetPriceRules(int? serviceId);
    ServicePriceRuleEditModel? GetPriceRuleForEdit(int id);
    void SavePriceRule(ServicePriceRuleEditModel model);
    void DeletePriceRule(int id);
    decimal ResolveUnitPrice(int serviceId, DateTime? at = null);

    // Operations
    List<ActiveStayRow> GetActiveStays(string? search);
    List<ServiceCatalogItemPick> GetCatalogItemsForOrder(int? categoryId, string? search);
    List<ServiceCategoryRow> GetCategoriesForPicker();
    void PlaceServiceOrder(int orderId, int roomId, int? serviceId, int? packageId, int quantity, string chargeMode, string? notes, int? userId);
    List<ServiceOrderRow> GetServiceOrders(string? statusFilter, int? orderId, string? search);
    void UpdateServiceOrderStatus(int serviceOrderId, string newStatus, int? userId);
    void CancelServiceOrder(int serviceOrderId, string reason, decimal cancellationFee, int? userId);

    // Payment
    List<ServiceOrderRow> GetOrdersAwaitingPayment();
    void PostImmediatePayment(int serviceOrderId, string method, int? userId);

    // Reports
    List<ServiceRevenueReportRow> GetRevenueReport(DateTime from, DateTime to, int? categoryId);
    List<ServiceUsageReportRow> GetUsageReport(DateTime from, DateTime to);
}
