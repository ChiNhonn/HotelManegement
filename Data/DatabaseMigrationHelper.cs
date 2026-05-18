using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data;

/// <summary>
/// Đồng bộ <c>__EFMigrationsHistory</c> khi database đã có schema (tạo thủ công / migrate cũ)
/// nhưng EF chưa ghi nhận migration — tránh lỗi "already an object named 'Branches'".
/// </summary>
public static class DatabaseMigrationHelper
{
    private const string ProductVersion = "8.0.0";

    private static readonly (string MigrationId, string SchemaProbeSql)[] MigrationProbes =
    [
        ("20260512221349_Init",
            "SELECT CASE WHEN OBJECT_ID(N'dbo.Branches', N'U') IS NOT NULL THEN 1 ELSE 0 END"),
        ("20260513134618_Step1_DomainAndFluentConfiguration",
            "SELECT CASE WHEN EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Branches_SoftDelete' AND object_id = OBJECT_ID(N'dbo.Branches')) THEN 1 ELSE 0 END"),
        ("20260513164548_AddStaffPayouts",
            "SELECT CASE WHEN OBJECT_ID(N'dbo.StaffPayouts', N'U') IS NOT NULL THEN 1 ELSE 0 END"),
        ("20260513214706_RoomTypeExtendedFields",
            "SELECT CASE WHEN COL_LENGTH(N'dbo.RoomTypes', N'Code') IS NOT NULL THEN 1 ELSE 0 END"),
        ("20260513220000_RemoveRoomTypeAreaSquareMeters",
            "SELECT CASE WHEN COL_LENGTH(N'dbo.RoomTypes', N'Code') IS NOT NULL THEN 1 ELSE 0 END"),
        ("20260515183559_Update-Database",
            "SELECT CASE WHEN COL_LENGTH(N'dbo.Floors', N'Status') IS NOT NULL THEN 1 ELSE 0 END"),
    ];

    public static void Migrate(HotelDbContext db)
    {
        BaselineAppliedMigrations(db);
        db.Database.Migrate();
    }

    private static void BaselineAppliedMigrations(HotelDbContext db)
    {
        EnsureMigrationHistoryTable(db);

        foreach (var (migrationId, probeSql) in MigrationProbes)
        {
            if (ScalarInt(db, probeSql) != 1)
                break;

            RegisterMigrationIfMissing(db, migrationId);
        }
    }

    private static void EnsureMigrationHistoryTable(HotelDbContext db)
    {
        db.Database.ExecuteSqlRaw("""
            IF OBJECT_ID(N'dbo.__EFMigrationsHistory', N'U') IS NULL
            BEGIN
                CREATE TABLE dbo.__EFMigrationsHistory (
                    MigrationId nvarchar(150) NOT NULL,
                    ProductVersion nvarchar(32) NOT NULL,
                    CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
                );
            END
            """);
    }

    private static void RegisterMigrationIfMissing(HotelDbContext db, string migrationId)
    {
        db.Database.ExecuteSqlRaw("""
            IF NOT EXISTS (SELECT 1 FROM dbo.__EFMigrationsHistory WHERE MigrationId = {0})
                INSERT INTO dbo.__EFMigrationsHistory (MigrationId, ProductVersion)
                VALUES ({0}, {1});
            """, migrationId, ProductVersion);
    }

    private static int ScalarInt(HotelDbContext db, string sql)
    {
        return db.Database.SqlQueryRaw<int>(sql).AsEnumerable().FirstOrDefault();
    }
}
