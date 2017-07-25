using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace phbgtu_ticketing_prototypes.Migrations
{
    public partial class FixDataTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventTicketCode",
                table: "TicketDesigns");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSold",
                table: "Tickets",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPaid",
                table: "Tickets",
                type: "Money",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventTicketCode",
                table: "TicketDesigns",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSold",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPaid",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");
        }
    }
}
