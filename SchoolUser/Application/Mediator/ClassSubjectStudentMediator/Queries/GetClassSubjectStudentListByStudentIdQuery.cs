using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Queries
{
    public record GetClassSubjectStudentListByStudentIdQuery(Guid StudentId) : IRequest<IEnumerable<ClassSubjectStudent>>;
}