namespace SchoolUser.Application.DTOs
{
    public class MailDataDto
    {
        public string EmailToId { get; set; }
        public string EmailToName { get; set; }
        public string? EmailCcId { get; set; }
        public string? EmailCcName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
}