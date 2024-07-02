using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Handlers
{
    public class GetAllClassSubjectsHandler : IRequestHandler<GetAllClassSubjectsQuery, IEnumerable<ClassSubject>>
    {
        private readonly IClassSubjectRepository _classSubjectRepository;

        public GetAllClassSubjectsHandler(IClassSubjectRepository classSubjectRepository)
        {
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<IEnumerable<ClassSubject>> Handle(GetAllClassSubjectsQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectRepository.GetAllAsync();
        }
    }
}