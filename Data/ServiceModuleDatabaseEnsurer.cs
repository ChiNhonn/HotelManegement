using HotelManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data;

/// <summary>
/// Áp dụng schema module dịch vụ khi migration EF chưa chạy (idempotent).
/// </summary>
public static class ServiceModuleDatabaseEnsurer
{
    public static void EnsureSchema(HotelDbContext db)
    {
        db.Database.ExecuteSqlRaw("""
            IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'ServiceCategories') AND name = N'Description')
                ALTER TABLE ServiceCategories ADD Description nvarchar(300) NULL;

            IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'ServiceCategories') AND name = N'SortOrder')
                ALTER TABLE ServiceCategories ADD SortOrder int NOT NULL CONSTRAINT DF_ServiceCategories_SortOrder DEFAULT 0;

            IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'Services') AND name = N'Description')
                ALTER TABLE Services ADD Description nvarchar(500) NULL;

            IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'Services') AND name = N'ImagePath')
                ALTER TABLE Services ADD ImagePath nvarchar(500) NULL;

            IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'Services') AND name = N'Unit')
                ALTER TABLE Services ADD Unit nvarchar(50) NOT NULL CONSTRAINT DF_Services_Unit DEFAULT N'lần';

            IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'Services') AND name = N'IsHidden')
                ALTER TABLE Services ADD IsHidden bit NOT NULL CONSTRAINT DF_Services_IsHidden DEFAULT 0;

            IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'Services') AND name = N'TrackInventory')
                ALTER TABLE Services ADD TrackInventory bit NOT NULL CONSTRAINT DF_Services_TrackInventory DEFAULT 0;

            IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'Services') AND name = N'StockQuantity')
                ALTER TABLE Services ADD StockQuantity int NOT NULL CONSTRAINT DF_Services_StockQuantity DEFAULT 0;

            IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Services_IsHidden' AND object_id = OBJECT_ID(N'Services'))
                CREATE INDEX IX_Services_IsHidden ON Services(IsHidden);

            IF OBJECT_ID(N'ServicePackages', N'U') IS NULL
            BEGIN
                CREATE TABLE ServicePackages (
                    Id int NOT NULL IDENTITY,
                    Name nvarchar(120) NOT NULL,
                    Description nvarchar(500) NULL,
                    ImagePath nvarchar(500) NULL,
                    PackagePrice decimal(18,2) NOT NULL,
                    IsHidden bit NOT NULL,
                    CreateAt datetime2 NOT NULL,
                    UpdateAt datetime2 NULL,
                    SoftDelete datetime2 NULL,
                    CONSTRAINT PK_ServicePackages PRIMARY KEY (Id));
                CREATE INDEX IX_ServicePackages_SoftDelete ON ServicePackages(SoftDelete);
            END

            IF OBJECT_ID(N'ServicePackageItems', N'U') IS NULL
            BEGIN
                CREATE TABLE ServicePackageItems (
                    Id int NOT NULL IDENTITY,
                    IdServicePackage int NOT NULL,
                    IdService int NOT NULL,
                    Quantity int NOT NULL,
                    CONSTRAINT PK_ServicePackageItems PRIMARY KEY (Id),
                    CONSTRAINT FK_ServicePackageItems_ServicePackages_IdServicePackage
                        FOREIGN KEY (IdServicePackage) REFERENCES ServicePackages(Id) ON DELETE CASCADE,
                    CONSTRAINT FK_ServicePackageItems_Services_IdService
                        FOREIGN KEY (IdService) REFERENCES Services(Id) ON DELETE NO ACTION);
                CREATE INDEX IX_ServicePackageItems_IdServicePackage ON ServicePackageItems(IdServicePackage);
                CREATE INDEX IX_ServicePackageItems_IdService ON ServicePackageItems(IdService);
            END

            IF OBJECT_ID(N'ServicePriceRules', N'U') IS NULL
            BEGIN
                CREATE TABLE ServicePriceRules (
                    Id int NOT NULL IDENTITY,
                    IdService int NOT NULL,
                    RuleName nvarchar(80) NOT NULL,
                    RuleType nvarchar(30) NOT NULL,
                    Price decimal(18,2) NOT NULL,
                    TimeStart time NULL,
                    TimeEnd time NULL,
                    DateStart datetime2 NULL,
                    DateEnd datetime2 NULL,
                    Priority int NOT NULL,
                    CreateAt datetime2 NOT NULL,
                    SoftDelete datetime2 NULL,
                    CONSTRAINT PK_ServicePriceRules PRIMARY KEY (Id),
                    CONSTRAINT FK_ServicePriceRules_Services_IdService
                        FOREIGN KEY (IdService) REFERENCES Services(Id) ON DELETE CASCADE);
                CREATE INDEX IX_ServicePriceRules_IdService ON ServicePriceRules(IdService);
                CREATE INDEX IX_ServicePriceRules_SoftDelete ON ServicePriceRules(SoftDelete);
            END

            IF OBJECT_ID(N'ServiceOrders', N'U') IS NULL
            BEGIN
                CREATE TABLE ServiceOrders (
                    Id int NOT NULL IDENTITY,
                    IdOrder int NOT NULL,
                    IdRoom int NOT NULL,
                    IdService int NULL,
                    IdServicePackage int NULL,
                    ItemName nvarchar(150) NOT NULL,
                    Quantity int NOT NULL,
                    UnitPrice decimal(18,2) NOT NULL,
                    LineTotal decimal(18,2) NOT NULL,
                    Status nvarchar(30) NOT NULL,
                    ChargeMode nvarchar(20) NOT NULL,
                    IsPostedToBill bit NOT NULL,
                    IdBillDetail int NULL,
                    Notes nvarchar(500) NULL,
                    CancelReason nvarchar(500) NULL,
                    CancellationFee decimal(18,2) NOT NULL,
                    IdUser int NULL,
                    CreateAt datetime2 NOT NULL,
                    UpdateAt datetime2 NULL,
                    CompletedAt datetime2 NULL,
                    CancelledAt datetime2 NULL,
                    SoftDelete datetime2 NULL,
                    CONSTRAINT PK_ServiceOrders PRIMARY KEY (Id),
                    CONSTRAINT FK_ServiceOrders_Orders_IdOrder FOREIGN KEY (IdOrder) REFERENCES Orders(Id),
                    CONSTRAINT FK_ServiceOrders_Rooms_IdRoom FOREIGN KEY (IdRoom) REFERENCES Rooms(Id),
                    CONSTRAINT FK_ServiceOrders_Services_IdService FOREIGN KEY (IdService) REFERENCES Services(Id),
                    CONSTRAINT FK_ServiceOrders_ServicePackages_IdServicePackage FOREIGN KEY (IdServicePackage) REFERENCES ServicePackages(Id),
                    CONSTRAINT FK_ServiceOrders_Users_IdUser FOREIGN KEY (IdUser) REFERENCES Users(Id));
                CREATE INDEX IX_ServiceOrders_CreateAt ON ServiceOrders(CreateAt);
                CREATE INDEX IX_ServiceOrders_IdOrder ON ServiceOrders(IdOrder);
                CREATE INDEX IX_ServiceOrders_IdRoom ON ServiceOrders(IdRoom);
                CREATE INDEX IX_ServiceOrders_Status ON ServiceOrders(Status);
                CREATE INDEX IX_ServiceOrders_SoftDelete ON ServiceOrders(SoftDelete);
            END
            """);

        EnsureMigrationHistoryRow(db);
    }

    /// <summary>Ghi nhận migration đã áp dụng (tránh Migrate chạy lại và lỗi cột trùng).</summary>
    private static void EnsureMigrationHistoryRow(HotelDbContext db)
    {
        db.Database.ExecuteSqlRaw("""
            IF NOT EXISTS (SELECT 1 FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20260518130000_AddServiceModule')
            AND EXISTS (
                SELECT 1 FROM sys.columns
                WHERE object_id = OBJECT_ID(N'ServiceCategories') AND name = N'SortOrder')
                INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
                VALUES (N'20260518130000_AddServiceModule', N'8.0.0');
            """);
    }
}
