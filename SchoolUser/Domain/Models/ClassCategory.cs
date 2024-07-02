using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class ClassCategory
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        #region Batch - ClassStream
        [JsonIgnore]
        public Batch? Batch { get; set; }
        public Guid BatchId { get; set; }

        [JsonIgnore]
        public ClassStream? ClassStream { get; set; }
        public Guid ClassStreamId { get; set; }
        #endregion

        #region ClassCategory - Subject
        [JsonIgnore]
        public List<ClassSubject>? ClassSubjects { get; set; }

        [NotMapped]
        public List<Subject>? Subjects { get; set; }
        #endregion

        [NotMapped]
        public List<Student>? Students { get; set; }

        [NotMapped]
        public List<Teacher>? Teachers { get; set; }
    }
}