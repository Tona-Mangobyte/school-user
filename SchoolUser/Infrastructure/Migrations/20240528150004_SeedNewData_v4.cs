using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;
using SchoolUser.Domain.Models;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class SeedNewData_v4 : Migration
    {

        private readonly string _pepper = "PasswordHashSaltPepperIterationForSchoolManagementSystemPortal";
        private readonly int _iteration = 3;
        private string randomPassword = "1234qwerASDF_";

        Guid UserId = new Guid("44bebbc5-3424-4feb-9234-5caeb5abaf1e");
        Guid TeacherId = new Guid("c3d79e3a-2a18-4bb8-a074-df1612dd2210");
        Guid roleIdAsTeacher = new Guid("30909974-D5C8-4F98-B12C-2F5D56C84257");
        Guid UserRoleId = new Guid("3ad57940-784b-4276-b0cb-0612682a827c");

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademicYear",
                schema: "SchoolUser",
                table: "ClassSubjectTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            #region UserCreation

            var user = new User
            {
                FullName = "Nickolas Teacher",
                EmailAddress = "nickolasnpm.work@gmail.com",
                Id = UserId,
                IsConfirmedEmail = true,
                MobileNumber = "0123456789",
                BirthDate = "1996-02-10",
                Age = 28,
                Gender = "male"
            };

            #region generateSalt
            using var rng = RandomNumberGenerator.Create();
            var byteSalt = new byte[16];
            rng.GetBytes(byteSalt);
            user.PasswordSalt = Convert.ToBase64String(byteSalt);
            #endregion

            #region generateHash
            for (int j = 0; j < _iteration; j++)
            {
                using var sha256 = SHA256.Create();
                var passwordSaltPepper = $"{randomPassword}{user.PasswordSalt}{_pepper}";
                var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
                var byteHash = sha256.ComputeHash(byteValue);
                randomPassword = Convert.ToBase64String(byteHash);
            }

            user.PasswordHash = randomPassword;
            #endregion

            user.VerificationNumber = "123456";
            user.VerificationExpiration = DateTime.Now.AddHours(48);
            user.TokenExpiration = DateTime.Now;
            user.CreatedBy = "Initial Data Seeding";
            user.CreatedAt = DateTime.Now.ToString("dd-MM-yyyy");

            #endregion

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "UserTable",
                columns: new[] { "Id", "FullName", "EmailAddress", "IsConfirmedEmail", "MobileNumber", "BirthDate", "Gender", "Age", "PasswordSalt", "PasswordHash", "VerificationNumber", "VerificationExpiration", "AccessToken", "RefreshToken", "TokenExpiration", "CreatedBy", "CreatedAt" },
                values: new object[,]
                {
                    { user.Id, user.FullName, user.EmailAddress, user.IsConfirmedEmail, user.MobileNumber, user.BirthDate, user.Gender, user.Age, user.PasswordSalt, user.PasswordHash, user.VerificationNumber, user.VerificationExpiration, user.AccessToken, user.RefreshToken, user.TokenExpiration, user.CreatedBy, user.CreatedAt },
                });

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "TeacherTable",
                columns: new[] { "Id", "ServiceStatus", "IsAvailable", "UserId", "ClassCategoryId" },
                values: new object[,]
                {
                    { TeacherId, "permanent", true, UserId, null },
                });

            migrationBuilder.InsertData(
                schema: "SchoolUser",
                table: "UserRoleTable",
                columns: new[] { "Id", "UserId", "RoleId" },
                values: new object[,]
                {
                    { UserRoleId, UserId, roleIdAsTeacher },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicYear",
                schema: "SchoolUser",
                table: "ClassSubjectTable");

            migrationBuilder.DeleteData(schema: "SchoolUser", table: "UserRoleTable", keyColumn: "Id", keyValues: new object[]
            {
                UserRoleId
            });

            migrationBuilder.DeleteData(schema: "SchoolUser", table: "TeacherTable", keyColumn: "Id", keyValues: new object[]
            {
                TeacherId
            });

            migrationBuilder.DeleteData(schema: "SchoolUser", table: "UserTable", keyColumn: "Id", keyValues: new object[]
            {
                UserId
            });
        }
    }
}
