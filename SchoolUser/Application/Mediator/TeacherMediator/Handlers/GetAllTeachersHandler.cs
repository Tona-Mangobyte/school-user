using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.TeacherMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Handlers
{
    public class GetAllTeachersHandler : IRequestHandler<GetAllTeachersQuery, IEnumerable<Teacher>>
    {
        private readonly ITeacherRepository _teacherRepository;

        public GetAllTeachersHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<Teacher>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            return await _teacherRepository.GetAllAsync();
        }
    }
}