using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Handlers
{
    public class AddClassCategoryHandler : IRequestHandler<AddClassCategoryCommand, ClassCategory>
    {
        private readonly IClassCategoryRepository _classRepository;

        public AddClassCategoryHandler(IClassCategoryRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ClassCategory> Handle(AddClassCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _classRepository.CreateAsync(request.ClassCategory);
        }
    }
}