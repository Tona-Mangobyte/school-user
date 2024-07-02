using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Handlers
{
    public class AddClassSubjectStudentHandler : IRequestHandler<AddClassSubjectStudentCommand, ClassSubjectStudent>
    {
        private readonly IClassSubjectStudentRepository _classSubjectStudentRepository;

        public AddClassSubjectStudentHandler(IClassSubjectStudentRepository classSubjectStudentRepository)
        {
            _classSubjectStudentRepository = classSubjectStudentRepository;
        }

        public async Task<ClassSubjectStudent> Handle(AddClassSubjectStudentCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectStudentRepository.CreateAsync(request.ClassSubjectStudent);
        }
    }
}