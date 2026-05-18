using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using HotelManagement.Data;

#nullable disable

namespace HotelManagement.Migrations;

[DbContext(typeof(HotelDbContext))]
[Migration("20260519093000_AddServiceOrderImmediatePaidAt")]
public partial class AddServiceOrderImmediatePaidAt : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<DateTime>(
            name: "ImmediatePaidAt",
            table: "ServiceOrders",
            type: "datetime2",
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(name: "ImmediatePaidAt", table: "ServiceOrders");
    }
}
