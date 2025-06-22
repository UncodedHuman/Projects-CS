using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentNoteApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Notes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_DescriptionId",
                table: "Notes",
                column: "DescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Descriptions_DescriptionId",
                table: "Notes",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Descriptions_DescriptionId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropIndex(
                name: "IX_Notes_DescriptionId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
