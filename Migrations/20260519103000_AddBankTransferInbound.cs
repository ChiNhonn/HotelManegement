using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using HotelManagement.Data;

#nullable disable

namespace HotelManagement.Migrations;

[DbContext(typeof(HotelDbContext))]
[Migration("20260519103000_AddBankTransferInbound")]
public partial class AddBankTransferInbound : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "BankTransferInbounds",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                RawContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                ReceivedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                MatchedServiceOrderId = table.Column<int>(type: "int", nullable: true),
                ProcessedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                SoftDelete = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table => table.PrimaryKey("PK_BankTransferInbounds", x => x.Id));

        migrationBuilder.CreateIndex(
            name: "IX_BankTransferInbounds_MatchedServiceOrderId",
            table: "BankTransferInbounds",
            column: "MatchedServiceOrderId");

        migrationBuilder.CreateIndex(
            name: "IX_BankTransferInbounds_ReceivedAt",
            table: "BankTransferInbounds",
            column: "ReceivedAt");

        migrationBuilder.CreateIndex(
            name: "IX_BankTransferInbounds_SoftDelete",
            table: "BankTransferInbounds",
            column: "SoftDelete");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "BankTransferInbounds");
    }
}
