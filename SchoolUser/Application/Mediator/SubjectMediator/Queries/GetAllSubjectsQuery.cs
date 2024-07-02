using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.SubjectMediator.Queries
{
    public record GetAllSubjectsQuery() : IRequest<IEnumerable<Subject>>;
}