using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Handlers
{
    public class GetClassSubjectByIdHandler : IRequestHandler<GetClassSubjectByIdQuery, ClassSubject?>
    {
        private readonly IClassSubjectRepository _classSubjectRepository;

        public GetClassSubjectByIdHandler(IClassSubjectRepository classSubjectRepository)
        {
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<ClassSubject?> Handle(GetClassSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectRepository.GetByIdAsync(request.id);
        }
    }
}