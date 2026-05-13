using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class RoomTypeExtendedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RoomTypes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxAdults",
                table: "RoomTypes",
                type: "int",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "MaxChildren",
                table: "RoomTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "AreaSquareMeters",
                table: "RoomTypes",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BedTypeDescription",
                table: "RoomTypes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.Sql("UPDATE RoomTypes SET MaxAdults = MaxNumber, MaxChildren = 0;");
            migrationBuilder.Sql("""
                UPDATE RoomTypes SET Code = N'STD' WHERE Name = N'Standard' AND Code IS NULL;
                UPDATE RoomTypes SET Code = N'DLX' WHERE Name = N'VIP' AND Code IS NULL;
                UPDATE RoomTypes SET Code = N'SUI' WHERE Name = N'Luxury' AND Code IS NULL;
                """);

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_Code",
                table: "RoomTypes",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomTypes_Code",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "MaxAdults",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "MaxChildren",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "AreaSquareMeters",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "BedTypeDescription",
                table: "RoomTypes");
        }
    }
}
