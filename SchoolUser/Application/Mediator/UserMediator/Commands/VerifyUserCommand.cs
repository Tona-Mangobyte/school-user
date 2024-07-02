using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Commands;

public record VerifyUserCommand (Domain.Models.User User) : IRequest<bool>; 