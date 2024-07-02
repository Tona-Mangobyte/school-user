using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Commands
{
    public record DeleteClassStreamCommand(Guid id) : IRequest<bool>;
}