using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.SubjectMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.SubjectMediator.Handlers
{
    public class UpdateSubjectHandler : IRequestHandler<UpdateSubjectCommand, bool>
    {
        private readonly ISubjectRepository _subjectRepository;

        public UpdateSubjectHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<bool> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            return await _subjectRepository.UpdateAsync(request.Subject);
        }
    }
}