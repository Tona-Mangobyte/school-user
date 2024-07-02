namespace SchoolUser.Application.DTOs
{
    public class GetUserResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<string> Roles { get; set; }
        public StudentResponseDto? Student { get; set; }
        public TeacherResponseDto? Teacher { get; set; }
    }
}