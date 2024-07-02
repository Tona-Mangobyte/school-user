using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.BatchMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.BatchMediator.Handlers
{
    public class DeleteBatchHandler : IRequestHandler<DeleteBatchCommand, bool>
    {
        private readonly IBatchRepository _batchRepository;

        public DeleteBatchHandler(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public async Task<bool> Handle(DeleteBatchCommand request, CancellationToken cancellationToken)
        {
            return await _batchRepository.DeleteAsync(request.id);
        }
    }
}