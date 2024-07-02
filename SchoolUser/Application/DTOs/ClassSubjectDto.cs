using SchoolUser.Domain.Models;

namespace SchoolUser.Application.DTOs
{
    public class ClassSubjectDto
    {
        public Guid ClassCategoryId { get; set; }
        public Guid SubjectId { get; set; }
        public string? Code { get; set; }
        public string? AcademicYear { get; set; }
    }
}