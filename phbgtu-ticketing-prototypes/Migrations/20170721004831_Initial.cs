using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace phbgtu_ticketing_prototypes.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    beginSales = table.Column<DateTime>(nullable: false),
                    customMessage = table.Column<string>(nullable: true),
                    endSales = table.Column<DateTime>(nullable: false),
                    eventName = table.Column<string>(nullable: true),
                    ticketSalesEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                columns: table => new
                {
                    TicketTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TicketTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.TicketTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TicketDesigns",
                columns: table => new
                {
                    TicketDesignID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventID = table.Column<int>(nullable: false),
                    ticketDesignDescription = table.Column<string>(nullable: true),
                    ticketDesignName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDesigns", x => x.TicketDesignID);
                    table.ForeignKey(
                        name: "FK_TicketDesigns_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "EventTickets",
                columns: table => new
                {
                    eventTicketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    TicketDesignID = table.Column<int>(nullable: true),
                    TicketTypeID = table.Column<int>(nullable: true),
                    quantityAvailable = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTickets", x => x.eventTicketID);
                    table.ForeignKey(
                        name: "FK_EventTickets_TicketDesigns_TicketDesignID",
                        column: x => x.TicketDesignID,
                        principalTable: "TicketDesigns",
                        principalColumn: "TicketDesignID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventTickets_TicketTypes_TicketTypeID",
                        column: x => x.TicketTypeID,
                        principalTable: "TicketTypes",
                        principalColumn: "TicketTypeID",
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
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventTicketCode = table.Column<string>(nullable: true),
                    TicketTypeID = table.Column<int>(nullable: true),
                    attendeeName = table.Column<string>(nullable: true),
                    dateSold = table.Column<DateTime>(nullable: false),
                    eventTicketID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketTypes_TicketTypeID",
                        column: x => x.TicketTypeID,
                        principalTable: "TicketTypes",
                        principalColumn: "TicketTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_EventTickets_eventTicketID",
                        column: x => x.eventTicketID,
                        principalTable: "EventTickets",
                        principalColumn: "eventTicketID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormFields_TicketDesignID",
                table: "CustomFormFields",
                column: "TicketDesignID");

            migrationBuilder.CreateIndex(
                name: "IX_EventTickets_TicketDesignID",
                table: "EventTickets",
                column: "TicketDesignID");

            migrationBuilder.CreateIndex(
                name: "IX_EventTickets_TicketTypeID",
                table: "EventTickets",
                column: "TicketTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeID",
                table: "Tickets",
                column: "TicketTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_eventTicketID",
                table: "Tickets",
                column: "eventTicketID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDesigns_EventID",
                table: "TicketDesigns",
                column: "EventID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketDesignElements_TicketDesignID",
                table: "TicketDesignElements",
                column: "TicketDesignID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomFormFields");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketDesignElements");

            migrationBuilder.DropTable(
                name: "EventTickets");

            migrationBuilder.DropTable(
                name: "TicketDesigns");

            migrationBuilder.DropTable(
                name: "TicketTypes");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
