using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Queries;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Handlers
{
    public class GetAllClassSubjectStudentsHandler : IRequestHandler<GetAllClassSubjectStudentsQuery, IEnumerable<ClassSubjectStudent>>
    {
        private readonly IClassSubjectStudentRepository _classSubjectStudentRepository;

        public GetAllClassSubjectStudentsHandler(IClassSubjectStudentRepository classSubjectStudentRepository)
        {
            _classSubjectStudentRepository = classSubjectStudentRepository;
        }

        public async Task<IEnumerable<ClassSubjectStudent>> Handle(GetAllClassSubjectStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectStudentRepository.GetAllAsync();
        }
    }
}