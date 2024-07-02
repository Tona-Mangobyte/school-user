using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.SubjectMediator.Queries
{
    public record GetSubjectByNameQuery(string Name) : IRequest<Subject?>;
}