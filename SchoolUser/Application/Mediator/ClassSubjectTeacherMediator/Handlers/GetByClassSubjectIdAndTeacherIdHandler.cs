using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Handlers
{
    public class GetByClassSubjectIdAndTeacherIdHandler : IRequestHandler<GetByClassSubjectIdAndTeacherIdQuery, ClassSubjectTeacher?>
    {
        private readonly IClassSubjectTeacherRepository _classSubjectTeacherRepository;

        public GetByClassSubjectIdAndTeacherIdHandler(IClassSubjectTeacherRepository classSubjectTeacherRepository)
        {
            _classSubjectTeacherRepository = classSubjectTeacherRepository;
        }

        public async Task<ClassSubjectTeacher?> Handle(GetByClassSubjectIdAndTeacherIdQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectTeacherRepository.GetByClassSubjectIdAndTeacherIdAsync(request.ClassSubjectId, request.TeacherId);
        }
    }
}