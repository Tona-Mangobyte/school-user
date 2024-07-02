using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Queries
{
    public record GetPaginatedUsersQuery(int pageNumber, int pageSize, string? roleTitle) : IRequest<(IEnumerable<User?>, int)>;
}