using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Commands
{
    public record AddClassSubjectCommand (ClassSubject ClassSubject) : IRequest<ClassSubject>;
}