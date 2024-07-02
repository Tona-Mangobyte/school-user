using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Handlers
{
    public class UpdateClassSubjectTeacherHandler : IRequestHandler<UpdateClassSubjectTeacherCommand, bool>
    {
        private readonly IClassSubjectTeacherRepository _classSubjectTeacherRepository;

        public UpdateClassSubjectTeacherHandler(IClassSubjectTeacherRepository classSubjectTeacherRepository)
        {
            _classSubjectTeacherRepository = classSubjectTeacherRepository;
        }
        public async Task<bool> Handle(UpdateClassSubjectTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectTeacherRepository.UpdateAsync(request.ClassSubjectTeacher);
        }
    }
}