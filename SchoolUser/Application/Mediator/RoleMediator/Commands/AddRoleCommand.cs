using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.RoleMediator.Commands;

public record AddRoleCommand (Role Role) : IRequest<Role>; 
