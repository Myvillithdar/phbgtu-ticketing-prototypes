using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace phbgtu_ticketing_prototypes.Migrations
{
    public partial class TicketEventRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TicketEvents",
                newName: "TicketEventID");

            migrationBuilder.AddColumn<int>(
                name: "TicketEventID",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketEventID",
                table: "Tickets",
                column: "TicketEventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketEvents_TicketEventID",
                table: "Tickets",
                column: "TicketEventID",
                principalTable: "TicketEvents",
                principalColumn: "TicketEventID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketEvents_TicketEventID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketEventID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketEventID",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketEventID",
                table: "TicketEvents",
                newName: "ID");
        }
    }
}
