using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Commands
{
    public record DeleteInactiveUsersCommand : IRequest<Unit>;
}