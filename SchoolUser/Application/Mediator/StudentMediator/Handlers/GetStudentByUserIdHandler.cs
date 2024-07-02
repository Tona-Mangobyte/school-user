using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.StudentMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.StudentMediator.Handlers
{
    public class GetStudentByUserIdHandler : IRequestHandler<GetStudentByUserIdQuery, Student?>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByUserIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student?> Handle(GetStudentByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetByUserIdAsync(request.UserId);
        }
    }
}