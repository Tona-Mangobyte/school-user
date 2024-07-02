using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.BatchMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.BatchMediator.Handlers
{
    public class GetBatchByIdHandler : IRequestHandler<GetBatchByIdQuery, Batch?>
    {
        private readonly IBatchRepository _batchRepository;

        public GetBatchByIdHandler(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public async Task<Batch?> Handle(GetBatchByIdQuery request, CancellationToken cancellationToken)
        {
            return await _batchRepository.GetByIdAsync(request.id);
        }
    }
}