using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.BatchMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.BatchMediator.Handlers
{
    public class GetBatchByNameHandler : IRequestHandler<GetBatchByNameQuery, Batch?>
    {
        private readonly IBatchRepository _batchRepository;

        public GetBatchByNameHandler(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public async Task<Batch?> Handle(GetBatchByNameQuery request, CancellationToken cancellationToken)
        {
            return await _batchRepository.GetByNameAsync(request.Name);
        }
    }
}