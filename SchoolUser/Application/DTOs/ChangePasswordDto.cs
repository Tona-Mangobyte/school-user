namespace SchoolUser.Application.DTOs
{
    public class ChangePasswordDto
    {
        public string EmailAddress { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}