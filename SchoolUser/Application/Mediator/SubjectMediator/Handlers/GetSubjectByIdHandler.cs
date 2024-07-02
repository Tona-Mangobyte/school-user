using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.SubjectMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.SubjectMediator.Handlers
{
    public class GetSubjectByIdHandler : IRequestHandler<GetSubjectByIdQuery, Subject?>
    {
        private readonly ISubjectRepository _subjectRepository;

        public GetSubjectByIdHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<Subject?> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            return await _subjectRepository.GetByIdAsync(request.id);
        }
    }
}