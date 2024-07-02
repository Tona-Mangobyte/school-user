using SchoolUser.Application.DTOs;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IMailServices
    {
        bool SendMailService(MailDataDto mailData);
    }
}