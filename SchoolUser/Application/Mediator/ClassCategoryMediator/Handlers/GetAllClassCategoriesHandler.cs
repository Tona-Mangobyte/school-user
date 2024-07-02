using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Handlers
{
    public class GetAllClassCategoriesHandler : IRequestHandler<GetAllClassCategoriesQuery, IEnumerable<ClassCategory>>
    {
        private readonly IClassCategoryRepository _classRepository;

        public GetAllClassCategoriesHandler(IClassCategoryRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<IEnumerable<ClassCategory>> Handle(GetAllClassCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _classRepository.GetAllAsync();
        }
    }
}