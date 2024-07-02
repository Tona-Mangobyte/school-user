using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Handlers
{
    public class GetClassCategoryByIdHandler : IRequestHandler<GetClassCategoryByIdQuery, ClassCategory?>
    {
        private readonly IClassCategoryRepository _classRepository;

        public GetClassCategoryByIdHandler(IClassCategoryRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ClassCategory?> Handle(GetClassCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _classRepository.GetByIdAsync(request.id);
        }
    }
}