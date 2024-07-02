namespace SchoolUser.Application.DTOs
{
    public class ClassCategoryDto
    {
        public Guid BatchId { get; set; }
        public Guid ClassStreamId { get; set; }
        public string? Code { get; set; }
    }
}