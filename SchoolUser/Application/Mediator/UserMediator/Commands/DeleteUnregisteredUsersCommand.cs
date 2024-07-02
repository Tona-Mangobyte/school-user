using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Commands
{
    public record DeleteUnregisteredUsersCommand : IRequest<Unit>;
}