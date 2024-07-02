using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Queries
{
    public record GetClassStreamByNameQuery(string Name) : IRequest<ClassStream?>;
}