using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace phbgtu_ticketing_prototypes.Migrations
{
    public partial class RelationshipsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TicketDesigns_EventID",
                table: "TicketDesigns");

            migrationBuilder.RenameColumn(
                name: "CustomFormFieldID",
                table: "CustomFormFieldResponses",
                newName: "CustomFormFieldQuestionID");

            migrationBuilder.AddColumn<bool>(
                name: "AvailableOnline",
                table: "EventTickets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_UserTypeID",
                table: "UserAccounts",
                column: "UserTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDesignElements_TicketDesignID",
                table: "TicketDesignElements",
                column: "TicketDesignID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDesigns_EventID",
                table: "TicketDesigns",
                column: "EventID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormFieldResponses_CustomFormFieldQuestionID",
                table: "CustomFormFieldResponses",
                column: "CustomFormFieldQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormFieldQuestions_TicketDesignID",
                table: "CustomFormFieldQuestions",
                column: "TicketDesignID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFormFieldDataOptions_CustomFormFieldQuestionID",
                table: "CustomFormFieldDataOptions",
                column: "CustomFormFieldQuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormFieldDataOptions_CustomFormFieldQuestions_CustomFormFieldQuestionID",
                table: "CustomFormFieldDataOptions",
                column: "CustomFormFieldQuestionID",
                principalTable: "CustomFormFieldQuestions",
                principalColumn: "CustomFormFieldQuestionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormFieldQuestions_TicketDesigns_TicketDesignID",
                table: "CustomFormFieldQuestions",
                column: "TicketDesignID",
                principalTable: "TicketDesigns",
                principalColumn: "TicketDesignID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFormFieldResponses_CustomFormFieldQuestions_CustomFormFieldQuestionID",
                table: "CustomFormFieldResponses",
                column: "CustomFormFieldQuestionID",
                principalTable: "CustomFormFieldQuestions",
                principalColumn: "CustomFormFieldQuestionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDesignElements_TicketDesigns_TicketDesignID",
                table: "TicketDesignElements",
                column: "TicketDesignID",
                principalTable: "TicketDesigns",
                principalColumn: "TicketDesignID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_UserTypes_UserTypeID",
                table: "UserAccounts",
                column: "UserTypeID",
                principalTable: "UserTypes",
                principalColumn: "UserTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormFieldDataOptions_CustomFormFieldQuestions_CustomFormFieldQuestionID",
                table: "CustomFormFieldDataOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormFieldQuestions_TicketDesigns_TicketDesignID",
                table: "CustomFormFieldQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFormFieldResponses_CustomFormFieldQuestions_CustomFormFieldQuestionID",
                table: "CustomFormFieldResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDesignElements_TicketDesigns_TicketDesignID",
                table: "TicketDesignElements");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_UserTypes_UserTypeID",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_UserTypeID",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_TicketDesignElements_TicketDesignID",
                table: "TicketDesignElements");

            migrationBuilder.DropIndex(
                name: "IX_TicketDesigns_EventID",
                table: "TicketDesigns");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormFieldResponses_CustomFormFieldQuestionID",
                table: "CustomFormFieldResponses");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormFieldQuestions_TicketDesignID",
                table: "CustomFormFieldQuestions");

            migrationBuilder.DropIndex(
                name: "IX_CustomFormFieldDataOptions_CustomFormFieldQuestionID",
                table: "CustomFormFieldDataOptions");

            migrationBuilder.DropColumn(
                name: "AvailableOnline",
                table: "EventTickets");

            migrationBuilder.RenameColumn(
                name: "CustomFormFieldQuestionID",
                table: "CustomFormFieldResponses",
                newName: "CustomFormFieldID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDesigns_EventID",
                table: "TicketDesigns",
                column: "EventID");
        }
    }
}
