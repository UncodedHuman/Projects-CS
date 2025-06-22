using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentNoteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditFieldsToSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Subjects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Subjects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Subjects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Subjects",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Subjects");
        }
    }
}
