using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Queries;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Handlers
{
    public class GetByClassSubjectIdAndStudentIdHandler : IRequestHandler<GetByClassSubjectIdAndStudentIdQuery, ClassSubjectStudent?>
    {
        private readonly IClassSubjectStudentRepository _classSubjectStudentRepository;

        public GetByClassSubjectIdAndStudentIdHandler(IClassSubjectStudentRepository classSubjectStudentRepository)
        {
            _classSubjectStudentRepository = classSubjectStudentRepository;
        }

        public async Task<ClassSubjectStudent?> Handle(GetByClassSubjectIdAndStudentIdQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectStudentRepository.GetByClassSubjectIdAndStudentIdAsync(request.ClassSubjectId, request.StudentId);
        }
    }
}