using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class UpdateTableColumn_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // First, rename 'RealExitYear' to a temporary name
            migrationBuilder.RenameColumn(
                name: "RealExitYear",
                schema: "SchoolUser",
                table: "StudentTable",
                newName: "TempExitYear");

            // Then, rename 'EstimatedExitYear' to 'RealExitYear'
            migrationBuilder.RenameColumn(
                name: "EstimatedExitYear",
                schema: "SchoolUser",
                table: "StudentTable",
                newName: "RealExitYear");

            // Finally, rename 'TempExitYear' to 'EstimatedExitYear'
            migrationBuilder.RenameColumn(
                name: "TempExitYear",
                schema: "SchoolUser",
                table: "StudentTable",
                newName: "EstimatedExitYear");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert 'EstimatedExitYear' back to 'TempExitYear'
            migrationBuilder.RenameColumn(
                name: "EstimatedExitYear",
                schema: "SchoolUser",
                table: "StudentTable",
                newName: "TempExitYear");

            // Revert 'RealExitYear' back to 'EstimatedExitYear'
            migrationBuilder.RenameColumn(
                name: "RealExitYear",
                schema: "SchoolUser",
                table: "StudentTable",
                newName: "EstimatedExitYear");

            // Revert 'TempExitYear' back to 'RealExitYear'
            migrationBuilder.RenameColumn(
                name: "TempExitYear",
                schema: "SchoolUser",
                table: "StudentTable",
                newName: "RealExitYear");
        }
    }
}
