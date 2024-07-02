using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Queries
{
    public record GetListByTeacherIdQuery(Guid TeacherId) : IRequest<IEnumerable<ClassSubjectTeacher>>;
}