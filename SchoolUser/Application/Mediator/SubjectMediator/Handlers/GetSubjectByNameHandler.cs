using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.SubjectMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.SubjectMediator.Handlers
{
    public class GetSubjectByNameHandler : IRequestHandler<GetSubjectByNameQuery, Subject?>
    {
        private readonly ISubjectRepository _subjectRepository;

        public GetSubjectByNameHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Subject?> Handle(GetSubjectByNameQuery request, CancellationToken cancellationToken)
        {
            return await _subjectRepository.GetByNameAsync(request.Name);
        }
    }
}