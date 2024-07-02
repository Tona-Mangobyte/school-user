using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Queries;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Handlers
{
    public class GetUniqueClassCategoryIdsHandler : IRequestHandler<GetUniqueClassCategoryIdsQuery, IEnumerable<Guid>>
    {
        private readonly IClassCategoryRepository _classCategoryRepository;

        public GetUniqueClassCategoryIdsHandler(IClassCategoryRepository classCategoryRepository)
        {
            _classCategoryRepository = classCategoryRepository;
        }

        public async Task<IEnumerable<Guid>> Handle(GetUniqueClassCategoryIdsQuery request, CancellationToken cancellationToken)
        {
            return await _classCategoryRepository.GetUniqueClassCategoryIdsAsync();
        }
    }
}