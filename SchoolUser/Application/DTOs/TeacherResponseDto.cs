using SchoolUser.Domain.Models;

namespace SchoolUser.Application.DTOs
{
    public class TeacherResponseDto
    {
        public Guid Id { get; set; }
        public string? ServiceStatus { get; set; }
        public bool? IsAvailable { get; set; }
        public Guid UserId { get; set; }
        public List<ClassSubject>? ClassSubjects { get; set; }
        public Guid? ClassCategoryId { get; set; }
    }
}