using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Commands;

public record UpdateTokenCommand (User User) : IRequest<User?>; 