using SchoolUser.Domain.Models;

namespace SchoolUser.Application.DTOs
{
    public class StudentResponseDto
    {
        public Guid Id { get; set; }
        public string? EntranceYear { get; set; }
        public string? EstimatedExitYear { get; set; }
        public string? RealExitYear { get; set; }
        public string? ExitReason { get; set; }
        public Guid UserId { get; set; }
        public List<ClassSubject>? ClassSubjects { get; set; }
        public ClassCategory? ClassCategory { get; set; }
    }
}