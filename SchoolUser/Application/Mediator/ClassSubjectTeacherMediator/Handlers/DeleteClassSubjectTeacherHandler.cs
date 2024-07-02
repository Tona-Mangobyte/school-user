using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Handlers
{
    public class DeleteClassSubjectTeacherHandler : IRequestHandler<DeleteClassSubjectTeacherCommand, bool>
    {
        private readonly IClassSubjectTeacherRepository _classSubjectTeacherRepository;

        public DeleteClassSubjectTeacherHandler(IClassSubjectTeacherRepository classSubjectTeacherRepository)
        {
            _classSubjectTeacherRepository = classSubjectTeacherRepository;
        }

        public async Task<bool> Handle(DeleteClassSubjectTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectTeacherRepository.DeleteAsync(request.id);
        }
    }
}