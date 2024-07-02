using MediatR;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Queries;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Handlers
{
    public class GetClassSubjectListByClassCategoryIdHandler : IRequestHandler<GetClassSubjectListByClassCategoryIdQuery, IEnumerable<ClassSubject>>
    {
        private readonly IClassSubjectRepository _classSubjectRepository;

        public GetClassSubjectListByClassCategoryIdHandler(IClassSubjectRepository classSubjectRepository)
        {
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<IEnumerable<ClassSubject>> Handle(GetClassSubjectListByClassCategoryIdQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectRepository.GetByClassCategoryIdAsync(request.ClassCategoryId);
        }
    }
}