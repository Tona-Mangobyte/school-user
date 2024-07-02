using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Queries
{
    public record GetUserByJwtTokenQuery (string jwtToken) : IRequest<User?>;
}