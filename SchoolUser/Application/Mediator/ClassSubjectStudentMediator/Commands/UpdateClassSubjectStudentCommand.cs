using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands
{
    public record UpdateClassSubjectStudentCommand(ClassSubjectStudent ClassSubjectStudent) : IRequest<bool>;
}