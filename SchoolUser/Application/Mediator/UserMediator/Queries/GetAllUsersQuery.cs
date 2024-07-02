using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Queries;

public record GetAllUsersQuery () : IRequest<IEnumerable<Domain.Models.User?>>;