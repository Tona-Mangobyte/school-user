using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.StudentMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.StudentMediator.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentRepository.DeleteAsync(request.id);
        }
    }
}