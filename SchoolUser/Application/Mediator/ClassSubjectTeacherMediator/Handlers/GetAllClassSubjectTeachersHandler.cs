using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Handlers
{
    public class GetAllClassSubjectTeachersHandler : IRequestHandler<GetAllClassSubjectTeachersQuery, IEnumerable<ClassSubjectTeacher>>
    {
        private readonly IClassSubjectTeacherRepository _classSubjectTeacherRepository;

        public GetAllClassSubjectTeachersHandler(IClassSubjectTeacherRepository classSubjectTeacherRepository)
        {
            _classSubjectTeacherRepository = classSubjectTeacherRepository;
        }
        public async Task<IEnumerable<ClassSubjectTeacher>> Handle(GetAllClassSubjectTeachersQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectTeacherRepository.GetAllAsync();
        }
    }
}