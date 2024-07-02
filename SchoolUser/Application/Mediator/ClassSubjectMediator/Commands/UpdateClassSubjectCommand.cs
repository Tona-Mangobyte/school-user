using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Commands
{
    public record UpdateClassSubjectCommand (ClassSubject ClassSubject) : IRequest<bool>;
}