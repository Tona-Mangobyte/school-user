using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class UpdateTableColumn_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GraduatedYear",
                schema: "SchoolUser",
                table: "StudentTable",
                newName: "ExitYear");

            migrationBuilder.AddColumn<string>(
                name: "ExitReason",
                schema: "SchoolUser",
                table: "StudentTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExitReason",
                schema: "SchoolUser",
                table: "StudentTable");

            migrationBuilder.RenameColumn(
                name: "ExitYear",
                schema: "SchoolUser",
                table: "StudentTable",
                newName: "GraduatedYear");
        }
    }
}
