using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Queries
{
    public record GetByClassSubjectIdAndStudentIdQuery(Guid ClassSubjectId, Guid StudentId) : IRequest<ClassSubjectStudent?>;
}