using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.RoleMediator.Commands;
public record UpdateRoleCommand (Role Role) : IRequest<bool>;
