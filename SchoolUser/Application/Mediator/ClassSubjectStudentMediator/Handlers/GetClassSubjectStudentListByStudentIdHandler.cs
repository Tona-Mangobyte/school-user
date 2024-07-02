using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Queries;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Handlers
{
    public class GetClassSubjectStudentListByStudentIdHandler : IRequestHandler<GetClassSubjectStudentListByStudentIdQuery, IEnumerable<ClassSubjectStudent>>
    {
        private readonly IClassSubjectStudentRepository _classSubjectStudentRepository;

        public GetClassSubjectStudentListByStudentIdHandler(IClassSubjectStudentRepository classSubjectStudentRepository)
        {
            _classSubjectStudentRepository = classSubjectStudentRepository;
        }

        public async Task<IEnumerable<ClassSubjectStudent>> Handle(GetClassSubjectStudentListByStudentIdQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectStudentRepository.GetListByStudentIdAsync(request.StudentId);
        }
    }
}