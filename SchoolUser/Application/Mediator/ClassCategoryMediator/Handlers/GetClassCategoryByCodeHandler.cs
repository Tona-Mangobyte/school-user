using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Handlers
{
    public class GetClassCategoryByCodeHandler : IRequestHandler<GetClassCategoryByCodeQuery, ClassCategory?>
    {
        private readonly IClassCategoryRepository _classRepository;

        public GetClassCategoryByCodeHandler(IClassCategoryRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ClassCategory?> Handle(GetClassCategoryByCodeQuery request, CancellationToken cancellationToken)
        {
            return await _classRepository.GetByCodeAsync(request.Code);
        }
    }
}