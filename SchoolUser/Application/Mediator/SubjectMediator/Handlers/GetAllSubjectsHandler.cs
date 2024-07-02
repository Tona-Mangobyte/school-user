using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.SubjectMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.SubjectMediator.Handlers
{
    public class GetAllSubjectsHandler : IRequestHandler<GetAllSubjectsQuery, IEnumerable<Subject>>
    {
        private readonly ISubjectRepository _subjectRepository;

        public GetAllSubjectsHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<IEnumerable<Subject>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
        {
            return await _subjectRepository.GetAllAsync();
        }
    }
}