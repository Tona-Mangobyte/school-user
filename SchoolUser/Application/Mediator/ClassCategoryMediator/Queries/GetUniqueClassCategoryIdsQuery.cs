using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Queries
{
    public record GetUniqueClassCategoryIdsQuery() : IRequest<IEnumerable<Guid>>;
}