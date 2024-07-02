using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.TeacherMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Handlers
{
    public class AddTeacherHandler : IRequestHandler<AddTeacherCommand, Teacher>
    {
        private readonly ITeacherRepository _teacherRepository;

        public AddTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _teacherRepository.CreateAsync(request.Teacher);
        }
    }
}