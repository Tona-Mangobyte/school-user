using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.BatchMediator.Queries
{
    public record GetAllBatchesQuery () : IRequest<IEnumerable<Batch>>;
}