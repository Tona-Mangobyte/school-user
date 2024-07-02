using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Queries;

public record GetUserByEmailQuery (string email) : IRequest<User>;