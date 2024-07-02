using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Handlers
{
    public class AddClassSubjectTeacherHandler : IRequestHandler<AddClassSubjectTeacherCommand, ClassSubjectTeacher>
    {
        private readonly IClassSubjectTeacherRepository _classSubjectTeacherRepository;

        public AddClassSubjectTeacherHandler(IClassSubjectTeacherRepository classSubjectTeacherRepository)
        {
            _classSubjectTeacherRepository = classSubjectTeacherRepository;
        }

        public async Task<ClassSubjectTeacher> Handle(AddClassSubjectTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectTeacherRepository.CreateAsync(request.ClassSubjectTeacher);
        }
    }
}