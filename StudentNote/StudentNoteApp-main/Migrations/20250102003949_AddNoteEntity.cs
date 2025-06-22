using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentNoteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNoteEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailsOfEvent",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "CreditId",
                table: "Notes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    DescriptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TeacherId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credits_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Credits_Descriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "Descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Credits_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Credits_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CreditId",
                table: "Notes",
                column: "CreditId");

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
                name: "FK_Notes_Credits_CreditId",
                table: "Notes",
                column: "CreditId",
                principalTable: "Credits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Credits_CreditId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CreditId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CreditId",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "DetailsOfEvent",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
