using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.BatchMediator.Queries
{
    public record GetBatchByIdQuery (Guid id) : IRequest<Batch>;
}