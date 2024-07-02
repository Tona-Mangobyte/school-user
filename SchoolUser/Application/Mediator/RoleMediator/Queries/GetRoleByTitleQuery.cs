using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.RoleMediator.Queries;

public record GetRoleByTitleQuery (string title) : IRequest<Role>;
