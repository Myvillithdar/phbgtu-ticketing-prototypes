using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace phbgtu_ticketing_prototypes.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketDesigns",
                columns: table => new
                {
                    TicketDesignID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    designDescription = table.Column<string>(nullable: true),
                    designName = table.Column<string>(nullable: true),
                    eventTicketCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDesigns", x => x.TicketDesignID);
                });

            migrationBuilder.CreateTable(
                name: "CustomFormFields",
                columns: table => new
                {
                    CustomFormFieldID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TicketDesignID = table.Column<int>(nullable: true),
                    formFieldLabel = table.Column<string>(nullable: true),
                    formFieldRequired = table.Column<bool>(nullable: false),
                    formFiledDataType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFormFields", x => x.CustomFormFieldID);
                    table.ForeignKey(
                        name: "FK_CustomFormFields_TicketDesigns_TicketDesignID",
                        column: x => x.TicketDesignID,
                        principalTable: "TicketDesigns",
                        principalColumn: "TicketDesignID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketDesignElements",
                columns: table => new
                {
                    TicketDesignElementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TicketDesignID = table.Column<int>(nullable: true),
                    dimensions = table.Column<int>(nullable: false),
                    elementContent = table.Column<string>(nullable: true),
                    elementName = table.Column<string>(nullable: true),
                    elementType = table.Column<string>(nullable: true),
                    xyCoordinates = table.Column<int>(nullable: false),
                    zIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDesignElements", x => x.TicketDesignElementID);
                    table.ForeignKey(
                        name: "FK_TicketDesignElements_TicketDesigns_TicketDesignID",
                        column: x => x.TicketDesignID,
                        principalTable: "TicketDesigns",
                        principalColumn: "TicketDesignID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketEvents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TicketDesignID = table.Column<int>(nullable: true),
                    beginSales = table.Column<DateTime>(nullable: false),
                    customMessage = table.Column<string>(nullable: true),
                    endSales = table.Column<DateTime>(nullable: false),
                    ticketSalesEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketEvents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TicketEvents_TicketDesigns_TicketDesignID",
                        column: x => x.TicketDesignID,
                        principalTable: "TicketDesigns",
                        principalColumn: "TicketDesignID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormFields_TicketDesignID",
                table: "CustomFormFields",
                column: "TicketDesignID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDesignElements_TicketDesignID",
                table: "TicketDesignElements",
                column: "TicketDesignID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketEvents_TicketDesignID",
                table: "TicketEvents",
                column: "TicketDesignID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomFormFields");

            migrationBuilder.DropTable(
                name: "TicketDesignElements");

            migrationBuilder.DropTable(
                name: "TicketEvents");

            migrationBuilder.DropTable(
                name: "TicketDesigns");
        }
    }
}
