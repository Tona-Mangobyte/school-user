using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.BatchMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.BatchMediator.Handlers
{
    public class UpdateBatchHandler : IRequestHandler<UpdateBatchCommand, bool>
    {
        private readonly IBatchRepository _batchRepository;

        public UpdateBatchHandler(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public async Task<bool> Handle(UpdateBatchCommand request, CancellationToken cancellationToken)
        {
            return await _batchRepository.UpdateAsync(request.Batch);
        }
    }
}