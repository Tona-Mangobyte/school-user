using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Queries
{
    public record GetAllClassStreamsQuery() : IRequest<IEnumerable<ClassStream>>;
}