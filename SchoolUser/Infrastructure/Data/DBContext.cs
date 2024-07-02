using SchoolUser.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolUser.Infrastructure.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        #region User
        public DbSet<User>? UserTable { get; set; }
        public DbSet<Role>? RoleTable { get; set; }
        public DbSet<UserRole>? UserRoleTable { get; set; }
        public DbSet<Student>? StudentTable { get; set; }
        public DbSet<Teacher>? TeacherTable { get; set; }
        #endregion

        #region School
        public DbSet<Batch>? BatchTable { get; set; }
        public DbSet<ClassStream>? ClassStreamTable { get; set; }
        public DbSet<ClassCategory>? ClassCategoryTable { get; set; }
        public DbSet<Subject>? SubjectTable { get; set; }
        public DbSet<ClassSubject>? ClassSubjectTable { get; set; }
        public DbSet<ClassSubjectTeacher>? ClassSubjectTeacherTable { get; set; }
        public DbSet<ClassSubjectStudent>? ClassSubjectStudentTable { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SetTableSchema<User>("UserTable", modelBuilder);
            SetTableSchema<Role>("RoleTable", modelBuilder);
            SetTableSchema<UserRole>("UserRoleTable", modelBuilder);
            SetTableSchema<Student>("StudentTable", modelBuilder);
            SetTableSchema<Teacher>("TeacherTable", modelBuilder);
            SetTableSchema<Batch>("BatchTable", modelBuilder);
            SetTableSchema<ClassStream>("ClassStreamTable", modelBuilder);
            SetTableSchema<ClassCategory>("ClassCategoryTable", modelBuilder);
            SetTableSchema<Subject>("SubjectTable", modelBuilder);
            SetTableSchema<ClassSubject>("ClassSubjectTable", modelBuilder);
            SetTableSchema<ClassSubjectTeacher>("ClassSubjectTeacherTable", modelBuilder);
            SetTableSchema<ClassSubjectStudent>("ClassSubjectStudentTable", modelBuilder);

            // Batch - ClassCategory - ClassStream
            modelBuilder.Entity<ClassCategory>()
                .HasOne(cc => cc.Batch)
                .WithMany(b => b.ClassCategories)
                .HasForeignKey(cc => cc.BatchId);

            // ClassStream - ClassCategory - Batch
            modelBuilder.Entity<ClassCategory>()
                .HasOne(cc => cc.ClassStream)
                .WithMany(ss => ss.ClassCategories)
                .HasForeignKey(cc => cc.ClassStreamId);

            // ClassCategory - Student
            modelBuilder.Entity<ClassCategory>()
                .HasMany(cc => cc.Students)
                .WithOne(s => s.ClassCategory)
                .HasForeignKey(s => s.ClassCategoryId)
                .OnDelete(DeleteBehavior.SetNull); ;

            // ClassCategory - Teacher
            modelBuilder.Entity<ClassCategory>()
                .HasMany(cc => cc.Teachers)
                .WithOne(t => t.ClassCategory)
                .HasForeignKey(t => t.ClassCategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            // Subject - ClassSubject - ClassCategory
            modelBuilder.Entity<ClassSubject>()
                .HasOne(cc => cc.Subject)
                .WithMany(s => s.ClassSubjects)
                .HasForeignKey(cs => cs.SubjectId);

            // ClassCategory - ClassSubject - Subject
            modelBuilder.Entity<ClassSubject>()
                .HasOne(cc => cc.ClassCategory)
                .WithMany(s => s.ClassSubjects)
                .HasForeignKey(cs => cs.ClassCategoryId);

            // ClassSubject - ClassSubjectTeacher - Teacher
            modelBuilder.Entity<ClassSubjectTeacher>()
                .HasOne(cst => cst.ClassSubject)
                .WithMany(cs => cs.ClassSubjectTeachers)
                .HasForeignKey(cst => cst.ClassSubjectId);

            // Teacher - ClassSubjectTeacher - ClassSubject
            modelBuilder.Entity<ClassSubjectTeacher>()
                .HasOne(cst => cst.Teacher)
                .WithMany(t => t.ClassSubjectTeachers)
                .HasForeignKey(cst => cst.TeacherId);

            // ClassSubject - ClassSubjectStudent - Student
            modelBuilder.Entity<ClassSubjectStudent>()
                .HasOne(css => css.ClassSubject)
                .WithMany(s => s.ClassSubjectStudents)
                .HasForeignKey(css => css.ClassSubjectId);

            // Student - ClassSubjectStudent - ClassSubject 
            modelBuilder.Entity<ClassSubjectStudent>()
                .HasOne(css => css.Student)
                .WithMany(s => s.ClassSubjectStudents)
                .HasForeignKey(css => css.StudentId);

            // User - Student
            modelBuilder.Entity<User>()
                .HasOne(u => u.Student)
                .WithOne(s => s.User)
                .HasForeignKey<Student>(s => s.UserId);

            // User - Teacher
            modelBuilder.Entity<User>()
                .HasOne(u => u.Teacher)
                .WithOne(t => t.User)
                .HasForeignKey<Teacher>(t => t.UserId);

            // User - UserRole - Role
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            // Role - UserRole - User
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

        }

        private void SetTableSchema<T>(string tableName, ModelBuilder modelBuilder) where T : class
        {
            modelBuilder.Entity<T>().ToTable(tableName, "SchoolUser");
        }
    }
}