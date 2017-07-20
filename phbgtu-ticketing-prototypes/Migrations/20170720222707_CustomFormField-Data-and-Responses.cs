using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace phbgtu_ticketing_prototypes.Migrations
{
    public partial class CustomFormFieldDataandResponses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormFields_TicketDesigns_TicketDesignID",
                table: "CustomFormFields");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDesignElements_TicketDesigns_TicketDesignID",
                table: "TicketDesignElements");

            migrationBuilder.DropIndex(
                name: "IX_TicketDesignElements_TicketDesignID",
                table: "TicketDesignElements");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormFields_TicketDesignID",
                table: "CustomFormFields");

            migrationBuilder.DropColumn(
                name: "TicketDesignID",
                table: "TicketDesignElements");

            migrationBuilder.DropColumn(
                name: "FormFieldDataType",
                table: "CustomFormFields");

            migrationBuilder.DropColumn(
                name: "TicketDesignID",
                table: "CustomFormFields");

            migrationBuilder.RenameColumn(
                name: "zIndex",
                table: "TicketDesignElements",
                newName: "ZIndex");

            migrationBuilder.RenameColumn(
                name: "elementType",
                table: "TicketDesignElements",
                newName: "ElementType");

            migrationBuilder.RenameColumn(
                name: "elementName",
                table: "TicketDesignElements",
                newName: "ElementName");

            migrationBuilder.RenameColumn(
                name: "elementContent",
                table: "TicketDesignElements",
                newName: "ElementContent");

            migrationBuilder.RenameColumn(
                name: "xyCoordinates",
                table: "TicketDesignElements",
                newName: "YDimension");

            migrationBuilder.RenameColumn(
                name: "dimensions",
                table: "TicketDesignElements",
                newName: "YCoordinate");

            migrationBuilder.RenameColumn(
                name: "eventTicketCode",
                table: "TicketDesigns",
                newName: "EventTicketCode");

            migrationBuilder.RenameColumn(
                name: "designName",
                table: "TicketDesigns",
                newName: "DesignName");

            migrationBuilder.RenameColumn(
                name: "designDescription",
                table: "TicketDesigns",
                newName: "DesignDescription");

            migrationBuilder.AddColumn<int>(
                name: "XCoordinate",
                table: "TicketDesignElements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XDimension",
                table: "TicketDesignElements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormFieldDatatypeID",
                table: "CustomFormFields",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CustomFormFieldDatatype",
                columns: table => new
                {
                    CustomFormFieldDatatypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatatypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFormFieldDatatype", x => x.CustomFormFieldDatatypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormFields_FormFieldDatatypeID",
                table: "CustomFormFields",
                column: "FormFieldDatatypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormFields_CustomFormFieldDatatype_FormFieldDatatypeID",
                table: "CustomFormFields",
                column: "FormFieldDatatypeID",
                principalTable: "CustomFormFieldDatatype",
                principalColumn: "CustomFormFieldDatatypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormFields_CustomFormFieldDatatype_FormFieldDatatypeID",
                table: "CustomFormFields");

            migrationBuilder.DropTable(
                name: "CustomFormFieldDatatype");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormFields_FormFieldDatatypeID",
                table: "CustomFormFields");

            migrationBuilder.DropColumn(
                name: "XCoordinate",
                table: "TicketDesignElements");

            migrationBuilder.DropColumn(
                name: "XDimension",
                table: "TicketDesignElements");

            migrationBuilder.DropColumn(
                name: "FormFieldDatatypeID",
                table: "CustomFormFields");

            migrationBuilder.RenameColumn(
                name: "ZIndex",
                table: "TicketDesignElements",
                newName: "zIndex");

            migrationBuilder.RenameColumn(
                name: "ElementType",
                table: "TicketDesignElements",
                newName: "elementType");

            migrationBuilder.RenameColumn(
                name: "ElementName",
                table: "TicketDesignElements",
                newName: "elementName");

            migrationBuilder.RenameColumn(
                name: "ElementContent",
                table: "TicketDesignElements",
                newName: "elementContent");

            migrationBuilder.RenameColumn(
                name: "YDimension",
                table: "TicketDesignElements",
                newName: "xyCoordinates");

            migrationBuilder.RenameColumn(
                name: "YCoordinate",
                table: "TicketDesignElements",
                newName: "dimensions");

            migrationBuilder.RenameColumn(
                name: "EventTicketCode",
                table: "TicketDesigns",
                newName: "eventTicketCode");

            migrationBuilder.RenameColumn(
                name: "DesignName",
                table: "TicketDesigns",
                newName: "designName");

            migrationBuilder.RenameColumn(
                name: "DesignDescription",
                table: "TicketDesigns",
                newName: "designDescription");

            migrationBuilder.AddColumn<int>(
                name: "TicketDesignID",
                table: "TicketDesignElements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormFieldDataType",
                table: "CustomFormFields",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketDesignID",
                table: "CustomFormFields",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketDesignElements_TicketDesignID",
                table: "TicketDesignElements",
                column: "TicketDesignID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormFields_TicketDesignID",
                table: "CustomFormFields",
                column: "TicketDesignID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormFields_TicketDesigns_TicketDesignID",
                table: "CustomFormFields",
                column: "TicketDesignID",
                principalTable: "TicketDesigns",
                principalColumn: "TicketDesignID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDesignElements_TicketDesigns_TicketDesignID",
                table: "TicketDesignElements",
                column: "TicketDesignID",
                principalTable: "TicketDesigns",
                principalColumn: "TicketDesignID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
