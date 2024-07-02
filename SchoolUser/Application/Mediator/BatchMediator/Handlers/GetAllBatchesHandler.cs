using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.BatchMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.BatchMediator.Handlers
{
    public class GetAllBatchesHandler : IRequestHandler<GetAllBatchesQuery, IEnumerable<Batch>>
    {
        private readonly IBatchRepository _batchRepository;

        public GetAllBatchesHandler(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public async Task<IEnumerable<Batch>> Handle(GetAllBatchesQuery request, CancellationToken cancellationToken)
        {
            return await _batchRepository.GetAllAsync();
        }
    }
}