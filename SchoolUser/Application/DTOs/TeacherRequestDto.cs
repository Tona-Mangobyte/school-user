namespace SchoolUser.Application.DTOs
{
    public class TeacherRequestDto
    {
        public Guid UserId { get; set; }
        public string? ServiceStatus { get; set; }
        public bool? IsAvailable { get; set; }
        public Guid? ClassCategoryId { get; set; }
        public List<Guid>? ClassSubjectIds { get; set; }
    }
}