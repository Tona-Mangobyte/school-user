using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.StudentMediator.Commands;

namespace SchoolUser.Application.Mediator.StudentMediator.Handlers
{
    public class UpdateBulkStudentsHandler : IRequestHandler<UpdateBulkStudentsCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateBulkStudentsHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(UpdateBulkStudentsCommand request, CancellationToken cancellationToken)
        {
            return await _studentRepository.UpdateBulkAsync(request.UpdateStudentsDto);
        }
    }
}