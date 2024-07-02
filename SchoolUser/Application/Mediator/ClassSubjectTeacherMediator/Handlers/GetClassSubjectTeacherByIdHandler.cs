using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Handlers
{
    public class GetClassSubjectTeacherByIdHandler : IRequestHandler<GetClassSubjectTeacherByIdQuery, ClassSubjectTeacher?>
    {
        private readonly IClassSubjectTeacherRepository _classSubjectTeacherRepository;

        public GetClassSubjectTeacherByIdHandler(IClassSubjectTeacherRepository classSubjectTeacherRepository)
        {
            _classSubjectTeacherRepository = classSubjectTeacherRepository;
        }

        public async Task<ClassSubjectTeacher?> Handle(GetClassSubjectTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectTeacherRepository.GetByIdAsync(request.id);
        }
    }
}