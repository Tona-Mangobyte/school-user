﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolUser.Infrastructure.Data;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SchoolUser.Domain.Models.Batch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BatchTable", "SchoolUser");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.ClassCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassStreamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.HasIndex("ClassStreamId");

                    b.ToTable("ClassCategoryTable", "SchoolUser");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.ClassStream", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClassStreamTable", "SchoolUser");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.ClassSubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClassCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassCategoryId");

                    b.HasIndex("SubjectId");

                    b.ToTable("ClassSubjectTable", "SchoolUser");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.ClassSubjectStudent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassSubjectId");

                    b.HasIndex("StudentId");

                    b.ToTable("ClassSubjectStudentTable", "SchoolUser");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.ClassSubjectTeacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassSubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ClassSubjectTeacherTable", "SchoolUser");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleTable", "SchoolUser");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EntranceYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstimatedExitYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExitReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RealExitYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassCategoryId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("StudentTable", "SchoolUser");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SubjectTable", "SchoolUser");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("ServiceStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassCategoryId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("TeacherTable", "SchoolUser");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirmedEmail")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenExpiration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VerificationExpiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTable", "SchoolUser");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoleTable", "SchoolUser");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.ClassCategory", b =>
                {
                    b.HasOne("SchoolUser.Domain.Models.Batch", "Batch")
                        .WithMany("ClassCategories")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolUser.Domain.Models.ClassStream", "ClassStream")
                        .WithMany("ClassCategories")
                        .HasForeignKey("ClassStreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("ClassStream");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.ClassSubject", b =>
                {
                    b.HasOne("SchoolUser.Domain.Models.ClassCategory", "ClassCategory")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("ClassCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolUser.Domain.Models.Subject", "Subject")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassCategory");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.ClassSubjectStudent", b =>
                {
                    b.HasOne("SchoolUser.Domain.Models.ClassSubject", "ClassSubject")
                        .WithMany("ClassSubjectStudents")
                        .HasForeignKey("ClassSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolUser.Domain.Models.Student", "Student")
                        .WithMany("ClassSubjectStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassSubject");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.ClassSubjectTeacher", b =>
                {
                    b.HasOne("SchoolUser.Domain.Models.ClassSubject", "ClassSubject")
                        .WithMany("ClassSubjectTeachers")
                        .HasForeignKey("ClassSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolUser.Domain.Models.Teacher", "Teacher")
                        .WithMany("ClassSubjectTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassSubject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.Student", b =>
                {
                    b.HasOne("SchoolUser.Domain.Models.ClassCategory", "ClassCategory")
                        .WithMany("Students")
                        .HasForeignKey("ClassCategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SchoolUser.Domain.Models.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("SchoolUser.Domain.Models.Student", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.Teacher", b =>
                {
                    b.HasOne("SchoolUser.Domain.Models.ClassCategory", "ClassCategory")
                        .WithMany("Teachers")
                        .HasForeignKey("ClassCategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SchoolUser.Domain.Models.User", "User")
                        .WithOne("Teacher")
                        .HasForeignKey("SchoolUser.Domain.Models.Teacher", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.UserRole", b =>
                {
                    b.HasOne("SchoolUser.Domain.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolUser.Domain.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.Batch", b =>
                {
                    b.Navigation("ClassCategories");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.ClassCategory", b =>
                {
                    b.Navigation("ClassSubjects");

                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.ClassStream", b =>
                {
                    b.Navigation("ClassCategories");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.ClassSubject", b =>
                {
                    b.Navigation("ClassSubjectStudents");

                    b.Navigation("ClassSubjectTeachers");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.Student", b =>
                {
                    b.Navigation("ClassSubjectStudents");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.Subject", b =>
                {
                    b.Navigation("ClassSubjects");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.Teacher", b =>
                {
                    b.Navigation("ClassSubjectTeachers");
                });

            modelBuilder.Entity("SchoolUser.Domain.Models.User", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Teacher");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
