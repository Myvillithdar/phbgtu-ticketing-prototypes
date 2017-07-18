using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace phbgtu_ticketing_prototypes.Migrations
{
    public partial class TicketTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeID",
                table: "Tickets");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "TicketTypes",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TicketEventID",
                table: "TicketTypes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TicketTypeID",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypes_TicketEventID",
                table: "TicketTypes",
                column: "TicketEventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeID",
                table: "Tickets",
                column: "TicketTypeID",
                principalTable: "TicketTypes",
                principalColumn: "TicketTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTypes_TicketEvents_TicketEventID",
                table: "TicketTypes",
                column: "TicketEventID",
                principalTable: "TicketEvents",
                principalColumn: "TicketEventID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTypes_TicketEvents_TicketEventID",
                table: "TicketTypes");

            migrationBuilder.DropIndex(
                name: "IX_TicketTypes_TicketEventID",
                table: "TicketTypes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TicketTypes");

            migrationBuilder.DropColumn(
                name: "TicketEventID",
                table: "TicketTypes");

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
    }
}
