using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.StreamMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Handlers
{
    public class GetClassStreamByIdHandler : IRequestHandler<GetClassStreamByIdQuery, ClassStream?>
    {
        private readonly IClassStreamRepository _streamRepository;

        public GetClassStreamByIdHandler(IClassStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }
        public async Task<ClassStream?> Handle(GetClassStreamByIdQuery request, CancellationToken cancellationToken)
        {
            return await _streamRepository.GetByIdAsync(request.id);
        }
    }
}