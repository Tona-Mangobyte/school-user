using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Handlers
{
    public class UpdateClassSubjectHandler : IRequestHandler<UpdateClassSubjectCommand, bool>
    {
        private readonly IClassSubjectRepository _classSubjectRepository;

        public UpdateClassSubjectHandler(IClassSubjectRepository classSubjectRepository)
        {
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<bool> Handle(UpdateClassSubjectCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectRepository.UpdateAsync(request.ClassSubject);
        }
    }
}