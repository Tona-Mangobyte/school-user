using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands
{
    public record UpdateClassSubjectTeacherCommand(ClassSubjectTeacher ClassSubjectTeacher) : IRequest<bool>;
}