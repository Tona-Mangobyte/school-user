using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Queries
{
    public record GetAllClassSubjectStudentsQuery() : IRequest<IEnumerable<ClassSubjectStudent>>;
}