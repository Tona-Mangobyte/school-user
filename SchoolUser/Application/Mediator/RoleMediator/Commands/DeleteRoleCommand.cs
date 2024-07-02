using MediatR;

namespace SchoolUser.Application.Mediator.RoleMediator.Commands;
public record DeleteRoleCommand(Guid id) : IRequest<bool>;
