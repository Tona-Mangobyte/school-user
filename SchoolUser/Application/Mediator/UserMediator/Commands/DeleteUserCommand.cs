using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Commands;
public record DeleteUserCommand(Guid id) : IRequest<bool>;