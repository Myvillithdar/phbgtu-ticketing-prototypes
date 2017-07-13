using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace phbgtu_ticketing_prototypes.Migrations
{
    public partial class NoTicketType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeID",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "TicketTypeID",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeID",
                table: "Tickets",
                column: "TicketTypeID",
                principalTable: "TicketTypes",
                principalColumn: "TicketTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeID",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "TicketTypeID",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeID",
                table: "Tickets",
                column: "TicketTypeID",
                principalTable: "TicketTypes",
                principalColumn: "TicketTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
