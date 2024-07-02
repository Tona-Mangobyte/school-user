using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Commands;
public record UpdateUserCommand(Domain.Models.User User) : IRequest<bool>;