using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.TeacherMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Handlers
{
    public class GetTeacherByIdHandler : IRequestHandler<GetTeacherByIdQuery, Teacher?>
    {
        private readonly ITeacherRepository _teacherRepository;
        public GetTeacherByIdHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher?> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            return await _teacherRepository.GetByIdAsync(request.id);
        }
    }
}