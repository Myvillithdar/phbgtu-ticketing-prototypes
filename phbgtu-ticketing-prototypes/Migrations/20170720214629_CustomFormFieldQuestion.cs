using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace phbgtu_ticketing_prototypes.Migrations
{
    public partial class CustomFormFieldQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "formFieldRequired",
                table: "CustomFormFields",
                newName: "FormFieldRequired");

            migrationBuilder.RenameColumn(
                name: "formFieldLabel",
                table: "CustomFormFields",
                newName: "FormFieldLabel");

            migrationBuilder.RenameColumn(
                name: "formFiledDataType",
                table: "CustomFormFields",
                newName: "FormFieldDataType");

            migrationBuilder.RenameColumn(
                name: "CustomFormFieldID",
                table: "CustomFormFields",
                newName: "CustomFormFieldQuestionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FormFieldRequired",
                table: "CustomFormFields",
                newName: "formFieldRequired");

            migrationBuilder.RenameColumn(
                name: "FormFieldLabel",
                table: "CustomFormFields",
                newName: "formFieldLabel");

            migrationBuilder.RenameColumn(
                name: "FormFieldDataType",
                table: "CustomFormFields",
                newName: "formFiledDataType");

            migrationBuilder.RenameColumn(
                name: "CustomFormFieldQuestionID",
                table: "CustomFormFields",
                newName: "CustomFormFieldID");
        }
    }
}
