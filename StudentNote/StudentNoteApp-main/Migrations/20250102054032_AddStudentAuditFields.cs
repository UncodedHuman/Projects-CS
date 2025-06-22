using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentNoteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Notes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Notes");
        }
    }
}
