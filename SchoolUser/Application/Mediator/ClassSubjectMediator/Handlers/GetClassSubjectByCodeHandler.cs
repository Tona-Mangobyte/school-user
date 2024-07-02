using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Handlers
{
    public class GetClassSubjectByCodeHandler : IRequestHandler<GetClassSubjectByCodeQuery, ClassSubject?>
    {
        private readonly IClassSubjectRepository _classSubjectRepository;

        public GetClassSubjectByCodeHandler(IClassSubjectRepository classSubjectRepository)
        {
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<ClassSubject?> Handle(GetClassSubjectByCodeQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectRepository.GetByCodeAsync(request.Code);
        }
    }
}