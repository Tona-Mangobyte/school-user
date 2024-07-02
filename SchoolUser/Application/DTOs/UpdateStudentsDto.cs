namespace SchoolUser.Application.DTOs
{
    public class UpdateStudentsDto
    {
        public IEnumerable<Guid> StudentIds { get; set; }
        public string EntranceYear { get; set; }
        public string EstimatedExitYear { get; set; }
        public string RealExitYear { get; set; }
        public string ExitReason { get; set; }
        public Guid? ClassCategoryId { get; set; }
    }
}