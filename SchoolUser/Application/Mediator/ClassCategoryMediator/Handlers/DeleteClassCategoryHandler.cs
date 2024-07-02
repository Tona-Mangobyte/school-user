using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Handlers
{
    public class DeleteClassCategoryHandler : IRequestHandler<DeleteClassCategoryCommand, bool>
    {
        private readonly IClassCategoryRepository _classRepository;

        public DeleteClassCategoryHandler(IClassCategoryRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<bool> Handle(DeleteClassCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _classRepository.DeleteAsync(request.id);
        }
    }
}
