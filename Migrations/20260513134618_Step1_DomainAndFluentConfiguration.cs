using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class Step1_DomainAndFluentConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomDetail_IdRoom",
                table: "RoomDetail");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinTotalPrice",
                table: "Vouchers",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DepositAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "DescriptionRooms",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Branches",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Branches",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "HouseNumber",
                table: "Branches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Branches",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Commune",
                table: "Branches",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Branches",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Bills",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_SoftDelete",
                table: "Vouchers",
                column: "SoftDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SoftDelete",
                table: "Users",
                column: "SoftDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_SoftDelete",
                table: "Services",
                column: "SoftDelete");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_SoftDelete",
                table: "RoomTypes",
                column: "SoftDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SoftDelete",
                table: "Rooms",
                column: "SoftDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Status",
                table: "Rooms",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetail_IdRoom_IdFurniture",
                table: "RoomDetail",
                columns: new[] { "IdRoom", "IdFurniture" },
                unique: true,
                filter: "[IdRoom] IS NOT NULL AND [IdFurniture] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SoftDelete",
                table: "Payments",
                column: "SoftDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SoftDelete",
                table: "Orders",
                column: "SoftDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Status",
                table: "Orders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_SoftDelete",
                table: "Furnitures",
                column: "SoftDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CitizenId",
                table: "Customers",
                column: "CitizenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Phone",
                table: "Customers",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SoftDelete",
                table: "Customers",
                column: "SoftDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_SoftDelete",
                table: "Branches",
                column: "SoftDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_SoftDelete",
                table: "Bills",
                column: "SoftDelete");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vouchers_SoftDelete",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Users_SoftDelete",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Services_SoftDelete",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_RoomTypes_SoftDelete",
                table: "RoomTypes");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_SoftDelete",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_Status",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_RoomDetail_IdRoom_IdFurniture",
                table: "RoomDetail");

            migrationBuilder.DropIndex(
                name: "IX_Payments_SoftDelete",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SoftDelete",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Status",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Furnitures_SoftDelete",
                table: "Furnitures");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CitizenId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Phone",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SoftDelete",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Branches_SoftDelete",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Bills_SoftDelete",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "MinTotalPrice",
                table: "Vouchers",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepositAmount",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "DescriptionRooms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Branches",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Branches",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "HouseNumber",
                table: "Branches",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Branches",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Commune",
                table: "Branches",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Branches",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetail_IdRoom",
                table: "RoomDetail",
                column: "IdRoom");
        }
    }
}
