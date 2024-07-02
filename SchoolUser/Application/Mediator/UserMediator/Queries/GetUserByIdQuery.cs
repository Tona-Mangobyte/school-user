using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Queries;

public record GetUserByIdQuery (Guid id) : IRequest<Domain.Models.User>;