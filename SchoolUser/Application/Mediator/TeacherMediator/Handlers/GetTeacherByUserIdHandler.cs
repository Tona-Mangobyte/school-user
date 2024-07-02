using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.TeacherMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Handlers
{
    public class GetTeacherByUserIdHandler : IRequestHandler<GetTeacherByUserIdQuery, Teacher?>
    {
        private readonly ITeacherRepository _teacherRepository;
        public GetTeacherByUserIdHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher?> Handle(GetTeacherByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _teacherRepository.GetByUserIdAsync(request.userId);
        }
    }
}