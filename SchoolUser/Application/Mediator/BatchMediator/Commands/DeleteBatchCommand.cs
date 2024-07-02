using MediatR;

namespace SchoolUser.Application.Mediator.BatchMediator.Commands
{
    public record DeleteBatchCommand (Guid id) : IRequest<bool>; 
}