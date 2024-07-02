using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class ClassSubjectStudent
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public ClassSubject? ClassSubject { get; set; }
        public Guid ClassSubjectId { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }
        public Guid StudentId { get; set; }
    }
}