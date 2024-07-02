using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.StreamMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Handlers
{
    public class GetAllClassStreamsHandler : IRequestHandler<GetAllClassStreamsQuery, IEnumerable<ClassStream>>
    {
        private readonly IClassStreamRepository _streamRepository;

        public GetAllClassStreamsHandler(IClassStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public async Task<IEnumerable<ClassStream>> Handle(GetAllClassStreamsQuery request, CancellationToken cancellationToken)
        {
            return await _streamRepository.GetAllAsync();
        }
    }
}