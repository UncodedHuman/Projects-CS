using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentNoteApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Students",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "Email");
        }
    }
}
