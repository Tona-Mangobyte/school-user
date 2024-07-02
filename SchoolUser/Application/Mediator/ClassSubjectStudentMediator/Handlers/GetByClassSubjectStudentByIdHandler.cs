using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Queries;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Handlers
{
    public class GetByClassSubjectStudentByIdHandler : IRequestHandler<GetClassSubjectStudentByIdQuery, ClassSubjectStudent?>
    {
        private readonly IClassSubjectStudentRepository _classSubjectStudentRepository;

        public GetByClassSubjectStudentByIdHandler(IClassSubjectStudentRepository classSubjectStudentRepository)
        {
            _classSubjectStudentRepository = classSubjectStudentRepository;
        }

        public async Task<ClassSubjectStudent?> Handle(GetClassSubjectStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectStudentRepository.GetByIdAsync(request.id);
        }
    }
}