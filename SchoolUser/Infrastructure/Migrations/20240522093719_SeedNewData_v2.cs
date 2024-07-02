using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class SeedNewData_v2 : Migration
    {

        Guid Batch7 = new Guid("58b02409-af73-4fc0-9c35-b586ed997e63");
        Guid ClassStream3 = new Guid("168c5e88-e771-497a-993f-b4a64ef5896e");
        Guid ClassCategory13 = new Guid("cb119b6f-6f59-4685-a439-9a8443ddbce9");
        Guid ClassCategory14 = new Guid("ab9d56fb-f773-4a98-9ff0-0c82d8cb6fee");
        Guid ClassCategory15 = new Guid("11d74d9b-a4ad-4623-9a32-b06002118487");

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "BatchTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { Batch7, "NONE" },
                }
            );

            migrationBuilder.InsertData(
              schema: "SchoolUser",
              table: "ClassStreamTable",
              columns: new[] { "Id", "Name", "Code" },
              values: new object[,]
              {
                    { ClassStream3, "NONE", "NN" },
              }
          );

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "ClassCategoryTable",
                columns: new[] { "Id", "Code", "BatchId", "ClassStreamId" },
                values: new object[,]
                {
                    { ClassCategory13, "Graduated", Batch7, ClassStream3 },
                    { ClassCategory14, "Removed", Batch7, ClassStream3 },
                    { ClassCategory15, "Moved", Batch7, ClassStream3 }
                }
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            // Remove data from CategoryTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "ClassCategoryTable", keyColumn: "Id", keyValues: new object[]
            {
                ClassCategory13, ClassCategory14, ClassCategory15
            });

            // Remove data from StreamTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "ClassStreamTable", keyColumn: "Id", keyValues: new object[]
            {
                ClassStream3
            });

            // Remove data from BatchTable
            migrationBuilder.DeleteData(schema: "SchoolUser", table: "BatchTable", keyColumn: "Id", keyValues: new object[]
            {
                Batch7
            });

        }
    }
}
