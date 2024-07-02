using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.RoleMediator.Queries;

public record GetRoleByIdQuery (Guid id) : IRequest<Role>;