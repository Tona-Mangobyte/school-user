using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.TeacherMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Handlers
{
    public class GetTeacherListBySubjectIdHandler : IRequestHandler<GetTeacherListBySubjectIdQuery, IEnumerable<Teacher>?>
    {
        private readonly ITeacherRepository _teacherRepository;

        public GetTeacherListBySubjectIdHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }


        public async Task<IEnumerable<Teacher>?> Handle(GetTeacherListBySubjectIdQuery request, CancellationToken cancellationToken)
        {
            return await _teacherRepository.GetListBySubjectIdAsync(request.SubjectId);
        }
    }
}