using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Queries;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Handlers
{
    public class GetListByTeacherIdHandler : IRequestHandler<GetListByTeacherIdQuery, IEnumerable<ClassSubjectTeacher>>
    {
        private readonly IClassSubjectTeacherRepository _classSubjectTeacherRepository;

        public GetListByTeacherIdHandler(IClassSubjectTeacherRepository classSubjectTeacherRepository)
        {
            _classSubjectTeacherRepository = classSubjectTeacherRepository;
        }

        public async Task<IEnumerable<ClassSubjectTeacher>> Handle(GetListByTeacherIdQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectTeacherRepository.GetListByTeacherIdAsync(request.TeacherId);
        }
    }
}