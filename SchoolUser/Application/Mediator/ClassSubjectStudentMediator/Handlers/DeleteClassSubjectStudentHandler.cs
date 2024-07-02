using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Handlers
{
    public class DeleteClassSubjectStudentHandler : IRequestHandler<DeleteClassSubjectStudentCommand, bool>
    {
        private readonly IClassSubjectStudentRepository _classSubjectStudentRepository;

        public DeleteClassSubjectStudentHandler(IClassSubjectStudentRepository classSubjectStudentRepository)
        {
            _classSubjectStudentRepository = classSubjectStudentRepository;
        }

        public async Task<bool> Handle(DeleteClassSubjectStudentCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectStudentRepository.DeleteAsync(request.id);
        }
    }
}