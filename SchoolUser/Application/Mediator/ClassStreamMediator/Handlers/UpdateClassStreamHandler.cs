using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.StreamMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Handlers
{
    public class UpdateClassStreamHandler : IRequestHandler<UpdateClassStreamCommand, bool>
    {
        private readonly IClassStreamRepository _streamRepository;

        public UpdateClassStreamHandler(IClassStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }
        public async Task<bool> Handle(UpdateClassStreamCommand request, CancellationToken cancellationToken)
        {
            return await _streamRepository.UpdateAsync(request.ClassStream);
        }
    }
}