using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.SubjectMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.SubjectMediator.Handlers
{
    public class AddSubjectHandler : IRequestHandler<AddSubjectCommand, Subject>
    {
        private readonly ISubjectRepository _subjectRepository;

        public AddSubjectHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Subject> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            return await _subjectRepository.CreateAsync(request.Subject);
        }
    }
}