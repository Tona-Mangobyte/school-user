using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class ClassSubject
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string AcademicYear { get; set; }

        #region ClassCategory - Subject
        [JsonIgnore]
        public ClassCategory? ClassCategory { get; set; }
        public Guid ClassCategoryId { get; set; }

        [JsonIgnore]
        public Subject? Subject { get; set; }
        public Guid SubjectId { get; set; }
        #endregion

        #region ClassSubject - Teacher
        [JsonIgnore]
        public List<ClassSubjectTeacher>? ClassSubjectTeachers { get; set; }

        [NotMapped]
        public List<Teacher>? Teachers { get; set; }
        #endregion

        #region  ClassSubject - Student
        [JsonIgnore]
        public List<ClassSubjectStudent>? ClassSubjectStudents { get; set; }

        [NotMapped]
        public List<Student>? Students { get; set; }
        #endregion
    }
}