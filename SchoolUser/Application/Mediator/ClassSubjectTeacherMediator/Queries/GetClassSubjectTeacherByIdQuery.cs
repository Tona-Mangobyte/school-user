using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Queries
{
    public record GetClassSubjectTeacherByIdQuery (Guid id) : IRequest<ClassSubjectTeacher>;
}