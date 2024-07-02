using MediatR;

namespace SchoolUser.Application.Mediator.UserRoleMediator.Queries;

public record GetUserRolesByUserIdQuery (Guid id) : IRequest<IEnumerable<Domain.Models.UserRole>>;