using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using HotelManagement.Data;

#nullable disable

namespace HotelManagement.Migrations;

[DbContext(typeof(HotelDbContext))]
[Migration("20260519150000_AddPaymentAmount")]
public partial class AddPaymentAmount : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<decimal>(
            name: "Amount",
            table: "Payments",
            type: "decimal(18,2)",
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Amount",
            table: "Payments");
    }
}
