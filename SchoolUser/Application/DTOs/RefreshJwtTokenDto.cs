namespace SchoolUser.Application.DTOs
{
    public class RefreshJwtTokenDto
    {
        public string EmailAddress { get; set; }
        public string RefreshToken { get; set; }
    }
}