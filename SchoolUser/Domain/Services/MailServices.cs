using MailKit.Net.Smtp;
using MailKit.Security;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using MimeKit;

namespace SchoolUser.Domain.Services
{
    public class MailServices : IMailServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _senderName;
        private readonly string _senderEmail;
        private readonly string _server;
        private readonly int _port;
        private readonly string _userName;
        private readonly string _password;

        public MailServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _senderName = _configuration.GetValue<string>("MailSettings:SenderName")!;
            _senderEmail = _configuration.GetValue<string>("MailSettings:SenderEmail")!;
            _server = _configuration.GetValue<string>("MailSettings:Server")!;
            _port = _configuration.GetValue<int>("MailSettings:Port");
            _userName = _configuration.GetValue<string>("MailSettings:UserName")!;
            _password = _configuration.GetValue<string>("MailSettings:Password")!;
        }

        public bool SendMailService(MailDataDto mailData)
        {

            try
            {

                using (MimeMessage emailMessage = new MimeMessage())
                {

                    MailboxAddress emailFrom = new MailboxAddress(_senderName, _senderEmail);
                    emailMessage.From.Add(emailFrom);

                    MailboxAddress emailTo = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
                    emailMessage.To.Add(emailTo);

                    if (!string.IsNullOrWhiteSpace(mailData.EmailCcName) && !string.IsNullOrWhiteSpace(mailData.EmailCcId))
                    {
                        MailboxAddress emailCc = new MailboxAddress(mailData.EmailCcName, mailData.EmailCcId);
                        emailMessage.Cc.Add(emailCc);
                    }

                    emailMessage.Subject = mailData.EmailSubject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder
                    {
                        HtmlBody = mailData.EmailBody
                    };

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();

                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        mailClient.Connect(_server, _port, SecureSocketOptions.StartTls);
                        mailClient.Authenticate(_userName, _password);
                        mailClient.Send(emailMessage);
                        mailClient.Disconnect(true);
                    }

                }


                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error here {ex}");
                return false;
            }
        }
    }
}