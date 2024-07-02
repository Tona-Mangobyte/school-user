using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Commands;

public record ChangePasswordCommand (Domain.Models.User User) : IRequest<bool>; 
