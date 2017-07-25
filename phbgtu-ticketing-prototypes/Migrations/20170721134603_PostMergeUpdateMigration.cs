using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace phbgtu_ticketing_prototypes.Migrations
{
    public partial class PostMergeUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomFormFieldDataOptions",
                columns: table => new
                {
                    CustomFormFieldDataOptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomFormFieldQuestionID = table.Column<int>(nullable: false),
                    DataOptionValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFormFieldDataOptions", x => x.CustomFormFieldDataOptionID);
                });

            migrationBuilder.CreateTable(
                name: "CustomFormFieldDatatypes",
                columns: table => new
                {
                    CustomFormFieldDatatypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatatypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFormFieldDatatypes", x => x.CustomFormFieldDatatypeID);
                });

            migrationBuilder.CreateTable(
                name: "CustomFormFieldResponses",
                columns: table => new
                {
                    CustomFormFieldResponseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomFormFieldID = table.Column<int>(nullable: false),
                    FormFieldResponse = table.Column<string>(nullable: true),
                    TicketID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFormFieldResponses", x => x.CustomFormFieldResponseID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeginSales = table.Column<DateTime>(nullable: false),
                    CustomMessage = table.Column<string>(nullable: true),
                    EndSales = table.Column<DateTime>(nullable: false),
                    EventName = table.Column<string>(nullable: true),
                    TicketSalesEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "TicketDesignElements",
                columns: table => new
                {
                    TicketDesignElementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElementContent = table.Column<string>(nullable: true),
                    ElementName = table.Column<string>(nullable: true),
                    ElementType = table.Column<string>(nullable: true),
                    TicketDesignID = table.Column<int>(nullable: false),
                    XCoordinate = table.Column<int>(nullable: false),
                    XDimension = table.Column<int>(nullable: false),
                    YCoordinate = table.Column<int>(nullable: false),
                    YDimension = table.Column<int>(nullable: false),
                    ZIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDesignElements", x => x.TicketDesignElementID);
                });

            migrationBuilder.CreateTable(
                name: "TicketStatuses",
                columns: table => new
                {
                    TicketStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TicketStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatuses", x => x.TicketStatusID);
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
                name: "UserAccounts",
                columns: table => new
                {
                    UserAccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailAddress = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordHint = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    UserTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.UserAccountID);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "CustomFormFieldQuestions",
                columns: table => new
                {
                    CustomFormFieldQuestionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormFieldDatatypeID = table.Column<int>(nullable: false),
                    FormFieldLabel = table.Column<string>(nullable: true),
                    FormFieldRequired = table.Column<bool>(nullable: false),
                    TicketDesignID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFormFieldQuestions", x => x.CustomFormFieldQuestionID);
                    table.ForeignKey(
                        name: "FK_CustomFormFieldQuestions_CustomFormFieldDatatypes_FormFieldDatatypeID",
                        column: x => x.FormFieldDatatypeID,
                        principalTable: "CustomFormFieldDatatypes",
                        principalColumn: "CustomFormFieldDatatypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketDesigns",
                columns: table => new
                {
                    TicketDesignID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignDescription = table.Column<string>(nullable: true),
                    DesignName = table.Column<string>(nullable: true),
                    EventID = table.Column<int>(nullable: false),
                    EventTicketCode = table.Column<string>(nullable: true)
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
                name: "EventTickets",
                columns: table => new
                {
                    EventTicketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuantityAvailable = table.Column<int>(nullable: false),
                    TicketDesignID = table.Column<int>(nullable: false),
                    TicketPrice = table.Column<decimal>(nullable: false),
                    TicketTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTickets", x => x.EventTicketID);
                    table.ForeignKey(
                        name: "FK_EventTickets_TicketDesigns_TicketDesignID",
                        column: x => x.TicketDesignID,
                        principalTable: "TicketDesigns",
                        principalColumn: "TicketDesignID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTickets_TicketTypes_TicketTypeID",
                        column: x => x.TicketTypeID,
                        principalTable: "TicketTypes",
                        principalColumn: "TicketTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountPaid = table.Column<decimal>(nullable: false),
                    AttendeeName = table.Column<string>(nullable: true),
                    DateSold = table.Column<DateTime>(nullable: false),
                    EventTicketID = table.Column<int>(nullable: false),
                    TicketNumber = table.Column<string>(nullable: true),
                    TicketStatusID = table.Column<int>(nullable: false),
                    UserAccountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_EventTickets_EventTicketID",
                        column: x => x.EventTicketID,
                        principalTable: "EventTickets",
                        principalColumn: "EventTicketID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketStatuses_TicketStatusID",
                        column: x => x.TicketStatusID,
                        principalTable: "TicketStatuses",
                        principalColumn: "TicketStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_UserAccounts_UserAccountID",
                        column: x => x.UserAccountID,
                        principalTable: "UserAccounts",
                        principalColumn: "UserAccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormFieldQuestions_FormFieldDatatypeID",
                table: "CustomFormFieldQuestions",
                column: "FormFieldDatatypeID");

            migrationBuilder.CreateIndex(
                name: "IX_EventTickets_TicketDesignID",
                table: "EventTickets",
                column: "TicketDesignID");

            migrationBuilder.CreateIndex(
                name: "IX_EventTickets_TicketTypeID",
                table: "EventTickets",
                column: "TicketTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventTicketID",
                table: "Tickets",
                column: "EventTicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketStatusID",
                table: "Tickets",
                column: "TicketStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserAccountID",
                table: "Tickets",
                column: "UserAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDesigns_EventID",
                table: "TicketDesigns",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomFormFieldDataOptions");

            migrationBuilder.DropTable(
                name: "CustomFormFieldQuestions");

            migrationBuilder.DropTable(
                name: "CustomFormFieldResponses");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketDesignElements");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "CustomFormFieldDatatypes");

            migrationBuilder.DropTable(
                name: "EventTickets");

            migrationBuilder.DropTable(
                name: "TicketStatuses");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "TicketDesigns");

            migrationBuilder.DropTable(
                name: "TicketTypes");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
