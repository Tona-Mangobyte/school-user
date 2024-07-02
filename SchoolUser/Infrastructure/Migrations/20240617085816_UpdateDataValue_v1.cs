using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class UpdateDataValue_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE [SchoolUser].[StudentTable] " +
                "SET [ExitReason] = 'N/A', [RealExitYear] = 'N/A' "
            );

            migrationBuilder.Sql(
                "UPDATE [SchoolUser].[ClassSubjectTable] " +
                "SET [AcademicYear] = 2024"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE [SchoolUser].[StudentTable] " +
                "SET [ExitReason] = NULL, [RealExitYear] = NULL "
            );

            migrationBuilder.Sql(
                "UPDATE [SchoolUser].[ClassSubjectTable] " +
                "SET [AcademicYear] = ''"
            );
        }
    }
}
