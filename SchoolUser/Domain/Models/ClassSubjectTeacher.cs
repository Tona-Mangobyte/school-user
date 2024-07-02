using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class ClassSubjectTeacher
    {
        public Guid Id { get; set; }
        
        [JsonIgnore]
        public ClassSubject? ClassSubject { get; set; }
        public Guid ClassSubjectId { get; set; }

        [JsonIgnore]
        public Teacher? Teacher { get; set; }
        public Guid TeacherId { get; set; }
    }
}