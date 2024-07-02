using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Handlers
{
    public class UpdateClassCategoryHandler : IRequestHandler<UpdateClassCategoryCommand, bool>
    {
        private readonly IClassCategoryRepository _classRepository;

        public UpdateClassCategoryHandler(IClassCategoryRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<bool> Handle(UpdateClassCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _classRepository.UpdateAsync(request.ClassCategory);
        }
    }
}