using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SchoolUser");

            migrationBuilder.CreateTable(
                name: "BatchTable",
                schema: "SchoolUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassStreamTable",
                schema: "SchoolUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStreamTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleTable",
                schema: "SchoolUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTable",
                schema: "SchoolUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                schema: "SchoolUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirmedEmail = table.Column<bool>(type: "bit", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassCategoryTable",
                schema: "SchoolUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassStreamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassCategoryTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassCategoryTable_BatchTable_BatchId",
                        column: x => x.BatchId,
                        principalSchema: "SchoolUser",
                        principalTable: "BatchTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassCategoryTable_ClassStreamTable_ClassStreamId",
                        column: x => x.ClassStreamId,
                        principalSchema: "SchoolUser",
                        principalTable: "ClassStreamTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleTable",
                schema: "SchoolUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleTable_RoleTable_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "SchoolUser",
                        principalTable: "RoleTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleTable_UserTable_UserId",
                        column: x => x.UserId,
                        principalSchema: "SchoolUser",
                        principalTable: "UserTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubjectTable",
                schema: "SchoolUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjectTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTable_ClassCategoryTable_ClassCategoryId",
                        column: x => x.ClassCategoryId,
                        principalSchema: "SchoolUser",
                        principalTable: "ClassCategoryTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTable_SubjectTable_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "SchoolUser",
                        principalTable: "SubjectTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTable",
                schema: "SchoolUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntranceYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraduatedYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTable_ClassCategoryTable_ClassCategoryId",
                        column: x => x.ClassCategoryId,
                        principalSchema: "SchoolUser",
                        principalTable: "ClassCategoryTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StudentTable_UserTable_UserId",
                        column: x => x.UserId,
                        principalSchema: "SchoolUser",
                        principalTable: "UserTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherTable",
                schema: "SchoolUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherTable_ClassCategoryTable_ClassCategoryId",
                        column: x => x.ClassCategoryId,
                        principalSchema: "SchoolUser",
                        principalTable: "ClassCategoryTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TeacherTable_UserTable_UserId",
                        column: x => x.UserId,
                        principalSchema: "SchoolUser",
                        principalTable: "UserTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubjectStudentTable",
                schema: "SchoolUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjectStudentTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSubjectStudentTable_ClassSubjectTable_ClassSubjectId",
                        column: x => x.ClassSubjectId,
                        principalSchema: "SchoolUser",
                        principalTable: "ClassSubjectTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubjectStudentTable_StudentTable_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "SchoolUser",
                        principalTable: "StudentTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubjectTeacherTable",
                schema: "SchoolUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjectTeacherTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTeacherTable_ClassSubjectTable_ClassSubjectId",
                        column: x => x.ClassSubjectId,
                        principalSchema: "SchoolUser",
                        principalTable: "ClassSubjectTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTeacherTable_TeacherTable_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "SchoolUser",
                        principalTable: "TeacherTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassCategoryTable_BatchId",
                schema: "SchoolUser",
                table: "ClassCategoryTable",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassCategoryTable_ClassStreamId",
                schema: "SchoolUser",
                table: "ClassCategoryTable",
                column: "ClassStreamId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectStudentTable_ClassSubjectId",
                schema: "SchoolUser",
                table: "ClassSubjectStudentTable",
                column: "ClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectStudentTable_StudentId",
                schema: "SchoolUser",
                table: "ClassSubjectStudentTable",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTable_ClassCategoryId",
                schema: "SchoolUser",
                table: "ClassSubjectTable",
                column: "ClassCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTable_SubjectId",
                schema: "SchoolUser",
                table: "ClassSubjectTable",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTeacherTable_ClassSubjectId",
                schema: "SchoolUser",
                table: "ClassSubjectTeacherTable",
                column: "ClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTeacherTable_TeacherId",
                schema: "SchoolUser",
                table: "ClassSubjectTeacherTable",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTable_ClassCategoryId",
                schema: "SchoolUser",
                table: "StudentTable",
                column: "ClassCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTable_UserId",
                schema: "SchoolUser",
                table: "StudentTable",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTable_ClassCategoryId",
                schema: "SchoolUser",
                table: "TeacherTable",
                column: "ClassCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTable_UserId",
                schema: "SchoolUser",
                table: "TeacherTable",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleTable_RoleId",
                schema: "SchoolUser",
                table: "UserRoleTable",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleTable_UserId",
                schema: "SchoolUser",
                table: "UserRoleTable",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassSubjectStudentTable",
                schema: "SchoolUser");

            migrationBuilder.DropTable(
                name: "ClassSubjectTeacherTable",
                schema: "SchoolUser");

            migrationBuilder.DropTable(
                name: "UserRoleTable",
                schema: "SchoolUser");

            migrationBuilder.DropTable(
                name: "StudentTable",
                schema: "SchoolUser");

            migrationBuilder.DropTable(
                name: "ClassSubjectTable",
                schema: "SchoolUser");

            migrationBuilder.DropTable(
                name: "TeacherTable",
                schema: "SchoolUser");

            migrationBuilder.DropTable(
                name: "RoleTable",
                schema: "SchoolUser");

            migrationBuilder.DropTable(
                name: "SubjectTable",
                schema: "SchoolUser");

            migrationBuilder.DropTable(
                name: "ClassCategoryTable",
                schema: "SchoolUser");

            migrationBuilder.DropTable(
                name: "UserTable",
                schema: "SchoolUser");

            migrationBuilder.DropTable(
                name: "BatchTable",
                schema: "SchoolUser");

            migrationBuilder.DropTable(
                name: "ClassStreamTable",
                schema: "SchoolUser");
        }
    }
}
