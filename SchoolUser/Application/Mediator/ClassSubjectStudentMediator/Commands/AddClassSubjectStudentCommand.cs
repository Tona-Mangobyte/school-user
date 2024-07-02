using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands
{
    public record AddClassSubjectStudentCommand(ClassSubjectStudent ClassSubjectStudent) : IRequest<ClassSubjectStudent>;
}