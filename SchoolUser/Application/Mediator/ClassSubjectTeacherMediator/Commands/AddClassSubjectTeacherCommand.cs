using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands
{
    public record AddClassSubjectTeacherCommand (ClassSubjectTeacher ClassSubjectTeacher) : IRequest<ClassSubjectTeacher>;
}