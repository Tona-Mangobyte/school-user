using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.TeacherMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Handlers
{
    public class UpdateTeacherHandler : IRequestHandler<UpdateTeacherCommand, bool>
    {
        private readonly ITeacherRepository _teacherRepository;

        public UpdateTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<bool> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _teacherRepository.UpdateAsync(request.Teacher);
        }
    }
}