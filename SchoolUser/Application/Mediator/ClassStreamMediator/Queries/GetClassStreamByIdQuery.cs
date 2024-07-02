using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Queries
{
    public record GetClassStreamByIdQuery(Guid id) : IRequest<ClassStream>;
}