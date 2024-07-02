using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Handlers
{
    public class UpdateClassSubjectStudentHandler : IRequestHandler<UpdateClassSubjectStudentCommand, bool>
    {
        private readonly IClassSubjectStudentRepository _classSubjectStudentRepository;

        public UpdateClassSubjectStudentHandler(IClassSubjectStudentRepository classSubjectStudentRepository)
        {
            _classSubjectStudentRepository = classSubjectStudentRepository;
        }

        public async Task<bool> Handle(UpdateClassSubjectStudentCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectStudentRepository.UpdateAsync(request.ClassSubjectStudent);
        }
    }
}