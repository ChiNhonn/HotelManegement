using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using HotelManagement.Data;

#nullable disable

namespace HotelManagement.Migrations;

[DbContext(typeof(HotelDbContext))]
[Migration("20260518170000_AddPaymentNote")]
public partial class AddPaymentNote : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Note",
            table: "Payments",
            type: "nvarchar(500)",
            maxLength: 500,
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Note",
            table: "Payments");
    }
}
