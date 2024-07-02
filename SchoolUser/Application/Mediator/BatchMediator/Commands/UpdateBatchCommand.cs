using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.BatchMediator.Commands
{
    public record UpdateBatchCommand (Batch Batch) : IRequest<bool>;
}