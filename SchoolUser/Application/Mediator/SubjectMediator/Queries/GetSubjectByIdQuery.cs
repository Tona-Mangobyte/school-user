using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.SubjectMediator.Queries
{
    public record GetSubjectByIdQuery (Guid id) : IRequest<Subject?>;
}