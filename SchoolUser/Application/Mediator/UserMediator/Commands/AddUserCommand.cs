using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Commands;

public record AddUserCommand (User User) : IRequest<User>; 