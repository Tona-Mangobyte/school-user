using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Commands
{
    public record AutoUpdateUsersAgeCommand : IRequest<Unit>;
}