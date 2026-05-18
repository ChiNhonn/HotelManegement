using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data;

/// <summary>Đảm bảo cột <c>Floors.Status</c> tồn tại (migration thủ công có thể chưa được EF đăng ký).</summary>
public static class FloorSchemaPatcher
{
    public static void EnsureFloorStatusColumn(HotelDbContext db)
    {
        db.Database.ExecuteSqlRaw("""
            IF COL_LENGTH('dbo.Floors', 'Status') IS NULL
            BEGIN
                ALTER TABLE dbo.Floors
                    ADD Status nvarchar(20) NOT NULL
                        CONSTRAINT DF_Floors_Status DEFAULT N'open';
            END
            """);
    }
}
