using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string? ServiceStatus { get; set; }
        public bool? IsAvailable { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        public Guid UserId { get; set; }

        #region Teacher - ClassSubject
        [JsonIgnore]
        public List<ClassSubjectTeacher>? ClassSubjectTeachers { get; set; }

        [NotMapped]
        public List<ClassSubject>? ClassSubjects { get; set; }
        #endregion

        #region Teacher - ClassCategory
        [JsonIgnore]
        public ClassCategory? ClassCategory { get; set; }
        public Guid? ClassCategoryId { get; set; }
        #endregion
    }
}