using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.SubjectMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.SubjectMediator.Handlers
{
    public class DeleteSubjectHandler : IRequestHandler<DeleteSubjectCommand, bool>
    {
        private readonly ISubjectRepository _subjectRepository;

        public DeleteSubjectHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<bool> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            return await _subjectRepository.DeleteAsync(request.id);
        }
    }
}