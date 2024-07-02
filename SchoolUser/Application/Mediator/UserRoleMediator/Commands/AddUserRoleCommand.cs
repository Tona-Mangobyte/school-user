using MediatR;

namespace SchoolUser.Application.Mediator.UserRoleMediator.Commands;

public record AddUserRoleCommand (Domain.Models.UserRole UserRole) : IRequest<Domain.Models.UserRole>;
