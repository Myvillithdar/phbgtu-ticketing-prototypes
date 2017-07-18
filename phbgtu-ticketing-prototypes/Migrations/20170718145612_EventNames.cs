using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace phbgtu_ticketing_prototypes.Migrations
{
    public partial class EventNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "eventName",
                table: "TicketEvents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eventName",
                table: "TicketEvents");
        }
    }
}
