using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoomTypeAreaSquareMeters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Idempotent: migration was previously missing Designer metadata, so this may not have run yet.
            migrationBuilder.Sql("""
                IF COL_LENGTH(N'dbo.RoomTypes', N'AreaSquareMeters') IS NOT NULL
                    ALTER TABLE dbo.RoomTypes DROP COLUMN AreaSquareMeters;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AreaSquareMeters",
                table: "RoomTypes",
                type: "decimal(10,2)",
                nullable: true);
        }
    }
}
