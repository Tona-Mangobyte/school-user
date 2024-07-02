using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Queries
{
    public record GetByClassSubjectIdAndTeacherIdQuery(Guid ClassSubjectId, Guid TeacherId) : IRequest<ClassSubjectTeacher?>;
}