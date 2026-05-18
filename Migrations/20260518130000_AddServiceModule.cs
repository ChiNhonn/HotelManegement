using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using HotelManagement.Data;

#nullable disable

namespace HotelManagement.Migrations;

[DbContext(typeof(HotelDbContext))]
[Migration("20260518130000_AddServiceModule")]
public partial class AddServiceModule : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Description",
            table: "ServiceCategories",
            type: "nvarchar(300)",
            maxLength: 300,
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "SortOrder",
            table: "ServiceCategories",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<string>(
            name: "Description",
            table: "Services",
            type: "nvarchar(500)",
            maxLength: 500,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ImagePath",
            table: "Services",
            type: "nvarchar(500)",
            maxLength: 500,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Unit",
            table: "Services",
            type: "nvarchar(50)",
            maxLength: 50,
            nullable: false,
            defaultValue: "lần");

        migrationBuilder.AddColumn<bool>(
            name: "IsHidden",
            table: "Services",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            name: "TrackInventory",
            table: "Services",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<int>(
            name: "StockQuantity",
            table: "Services",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateIndex(
            name: "IX_Services_IsHidden",
            table: "Services",
            column: "IsHidden");

        migrationBuilder.CreateTable(
            name: "ServicePackages",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                ImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                PackagePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                IsHidden = table.Column<bool>(type: "bit", nullable: false),
                CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                SoftDelete = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table => table.PrimaryKey("PK_ServicePackages", x => x.Id));

        migrationBuilder.CreateTable(
            name: "ServicePackageItems",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IdServicePackage = table.Column<int>(type: "int", nullable: false),
                IdService = table.Column<int>(type: "int", nullable: false),
                Quantity = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ServicePackageItems", x => x.Id);
                table.ForeignKey(
                    name: "FK_ServicePackageItems_ServicePackages_IdServicePackage",
                    column: x => x.IdServicePackage,
                    principalTable: "ServicePackages",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ServicePackageItems_Services_IdService",
                    column: x => x.IdService,
                    principalTable: "Services",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "ServicePriceRules",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IdService = table.Column<int>(type: "int", nullable: false),
                RuleName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                RuleType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                TimeStart = table.Column<TimeSpan>(type: "time", nullable: true),
                TimeEnd = table.Column<TimeSpan>(type: "time", nullable: true),
                DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                Priority = table.Column<int>(type: "int", nullable: false),
                CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                SoftDelete = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ServicePriceRules", x => x.Id);
                table.ForeignKey(
                    name: "FK_ServicePriceRules_Services_IdService",
                    column: x => x.IdService,
                    principalTable: "Services",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "ServiceOrders",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IdOrder = table.Column<int>(type: "int", nullable: false),
                IdRoom = table.Column<int>(type: "int", nullable: false),
                IdService = table.Column<int>(type: "int", nullable: true),
                IdServicePackage = table.Column<int>(type: "int", nullable: true),
                ItemName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                Quantity = table.Column<int>(type: "int", nullable: false),
                UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                LineTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                ChargeMode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                IsPostedToBill = table.Column<bool>(type: "bit", nullable: false),
                IdBillDetail = table.Column<int>(type: "int", nullable: true),
                Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                CancelReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                CancellationFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                IdUser = table.Column<int>(type: "int", nullable: true),
                CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                CancelledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                SoftDelete = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ServiceOrders", x => x.Id);
                table.ForeignKey(
                    name: "FK_ServiceOrders_Orders_IdOrder",
                    column: x => x.IdOrder,
                    principalTable: "Orders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_ServiceOrders_Rooms_IdRoom",
                    column: x => x.IdRoom,
                    principalTable: "Rooms",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_ServiceOrders_Services_IdService",
                    column: x => x.IdService,
                    principalTable: "Services",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_ServiceOrders_ServicePackages_IdServicePackage",
                    column: x => x.IdServicePackage,
                    principalTable: "ServicePackages",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_ServiceOrders_Users_IdUser",
                    column: x => x.IdUser,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.SetNull);
            });

        migrationBuilder.CreateIndex(
            name: "IX_ServicePackageItems_IdService",
            table: "ServicePackageItems",
            column: "IdService");

        migrationBuilder.CreateIndex(
            name: "IX_ServicePackageItems_IdServicePackage",
            table: "ServicePackageItems",
            column: "IdServicePackage");

        migrationBuilder.CreateIndex(
            name: "IX_ServicePackages_SoftDelete",
            table: "ServicePackages",
            column: "SoftDelete");

        migrationBuilder.CreateIndex(
            name: "IX_ServicePriceRules_IdService",
            table: "ServicePriceRules",
            column: "IdService");

        migrationBuilder.CreateIndex(
            name: "IX_ServicePriceRules_SoftDelete",
            table: "ServicePriceRules",
            column: "SoftDelete");

        migrationBuilder.CreateIndex(
            name: "IX_ServiceOrders_CreateAt",
            table: "ServiceOrders",
            column: "CreateAt");

        migrationBuilder.CreateIndex(
            name: "IX_ServiceOrders_IdOrder",
            table: "ServiceOrders",
            column: "IdOrder");

        migrationBuilder.CreateIndex(
            name: "IX_ServiceOrders_IdRoom",
            table: "ServiceOrders",
            column: "IdRoom");

        migrationBuilder.CreateIndex(
            name: "IX_ServiceOrders_IdService",
            table: "ServiceOrders",
            column: "IdService");

        migrationBuilder.CreateIndex(
            name: "IX_ServiceOrders_IdServicePackage",
            table: "ServiceOrders",
            column: "IdServicePackage");

        migrationBuilder.CreateIndex(
            name: "IX_ServiceOrders_IdUser",
            table: "ServiceOrders",
            column: "IdUser");

        migrationBuilder.CreateIndex(
            name: "IX_ServiceOrders_SoftDelete",
            table: "ServiceOrders",
            column: "SoftDelete");

        migrationBuilder.CreateIndex(
            name: "IX_ServiceOrders_Status",
            table: "ServiceOrders",
            column: "Status");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "ServiceOrders");
        migrationBuilder.DropTable(name: "ServicePriceRules");
        migrationBuilder.DropTable(name: "ServicePackageItems");
        migrationBuilder.DropTable(name: "ServicePackages");
        migrationBuilder.DropIndex(name: "IX_Services_IsHidden", table: "Services");
        migrationBuilder.DropColumn(name: "Description", table: "ServiceCategories");
        migrationBuilder.DropColumn(name: "SortOrder", table: "ServiceCategories");
        migrationBuilder.DropColumn(name: "Description", table: "Services");
        migrationBuilder.DropColumn(name: "ImagePath", table: "Services");
        migrationBuilder.DropColumn(name: "Unit", table: "Services");
        migrationBuilder.DropColumn(name: "IsHidden", table: "Services");
        migrationBuilder.DropColumn(name: "TrackInventory", table: "Services");
        migrationBuilder.DropColumn(name: "StockQuantity", table: "Services");
    }
}
