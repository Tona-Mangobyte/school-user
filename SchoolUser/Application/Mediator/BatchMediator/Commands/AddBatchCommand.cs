using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.BatchMediator.Commands
{
    public record AddBatchCommand (Batch Batch) : IRequest<Batch>;
}