using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Handlers
{
    public class DeleteClassSubjectHandler : IRequestHandler<DeleteClassSubjectCommand, bool>
    {
        private readonly IClassSubjectRepository _classSubjectRepository;

        public DeleteClassSubjectHandler(IClassSubjectRepository classSubjectRepository)
        {
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<bool> Handle(DeleteClassSubjectCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectRepository.DeleteAsync(request.id);
        }
    }
}