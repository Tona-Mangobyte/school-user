using System.Text.Json.Serialization;

namespace SchoolUser.Application.DTOs
{
    public class AddUserRequestDto
    {
        public string RegisterFor { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string? ServiceStatus { get; set; }
        public bool? IsAvailable { get; set; }
        public string? EntranceYear { get; set; }
        public string? EstimatedExitYear { get; set; }

        [JsonIgnore]
        public string? RealExitYear { get; set; }

        [JsonIgnore]
        public string? ExitReason { get; set; }
        public Guid? ClassCategoryId { get; set; }
        public List<Guid>? ClassSubjectIds { get; set; }
    }
}