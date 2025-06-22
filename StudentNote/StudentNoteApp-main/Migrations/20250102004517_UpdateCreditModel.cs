using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentNoteApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCreditModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credits_AspNetUsers_TeacherId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Descriptions_DescriptionId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Students_StudentId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Subjects_SubjectId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_DescriptionId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_StudentId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_SubjectId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_TeacherId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Credits");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Credits",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Credits",
                newName: "IsNumeric");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Credits",
                newName: "DisplayText");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Credits",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Credits");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Credits",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "IsNumeric",
                table: "Credits",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "DisplayText",
                table: "Credits",
                newName: "Details");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Credits",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Credits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Credits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Credits_DescriptionId",
                table: "Credits",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_StudentId",
                table: "Credits",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_SubjectId",
                table: "Credits",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_TeacherId",
                table: "Credits",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_AspNetUsers_TeacherId",
                table: "Credits",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Descriptions_DescriptionId",
                table: "Credits",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Students_StudentId",
                table: "Credits",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Subjects_SubjectId",
                table: "Credits",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
