using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class UpdateTableColumn_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExitYear",
                schema: "SchoolUser",
                table: "StudentTable",
                newName: "RealExitYear");

            migrationBuilder.AddColumn<string>(
                name: "EstimatedExitYear",
                schema: "SchoolUser",
                table: "StudentTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedExitYear",
                schema: "SchoolUser",
                table: "StudentTable");

            migrationBuilder.RenameColumn(
                name: "RealExitYear",
                schema: "SchoolUser",
                table: "StudentTable",
                newName: "ExitYear");
        }
    }
}
