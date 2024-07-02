using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Queries
{
    public record GetTeacherListBySubjectIdQuery(Guid SubjectId) : IRequest<IEnumerable<Teacher>?>;
}