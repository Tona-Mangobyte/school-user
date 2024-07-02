using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Handlers
{
    public class AddClassSubjectHandler : IRequestHandler<AddClassSubjectCommand, ClassSubject>
    {
        private readonly IClassSubjectRepository _classSubjectRepository;

        public AddClassSubjectHandler(IClassSubjectRepository classSubjectRepository)
        {
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<ClassSubject> Handle(AddClassSubjectCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectRepository.CreateAsync(request.ClassSubject);
        }
    }
}