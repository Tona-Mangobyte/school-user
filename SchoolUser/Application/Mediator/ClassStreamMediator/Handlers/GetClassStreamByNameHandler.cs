using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.StreamMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Handlers
{
    public class GetClassStreamByNameHandler : IRequestHandler<GetClassStreamByNameQuery, ClassStream?>
    {
        private readonly IClassStreamRepository _ClassStreamRepository;

        public GetClassStreamByNameHandler(IClassStreamRepository ClassStreamRepository)
        {
            _ClassStreamRepository = ClassStreamRepository;
        }

        public async Task<ClassStream?> Handle(GetClassStreamByNameQuery request, CancellationToken cancellationToken)
        {
            return await _ClassStreamRepository.GetByNameAsync(request.Name);
        }
    }
}