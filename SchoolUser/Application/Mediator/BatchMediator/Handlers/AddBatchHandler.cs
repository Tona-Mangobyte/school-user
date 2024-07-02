using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.BatchMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.BatchMediator.Handlers
{
    public class AddBatchHandler : IRequestHandler<AddBatchCommand, Batch>
    {
        private readonly IBatchRepository _batchRepository;

        public AddBatchHandler(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public async Task<Batch> Handle(AddBatchCommand request, CancellationToken cancellationToken)
        {
            return await _batchRepository.CreateAsync(request.Batch);
        }
    }
}