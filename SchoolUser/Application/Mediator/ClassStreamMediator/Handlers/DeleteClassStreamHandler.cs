using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.StreamMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Handlers
{
    public class DeleteClassStreamHandler : IRequestHandler<DeleteClassStreamCommand, bool>
    {
        private readonly IClassStreamRepository _streamRepository;

        public DeleteClassStreamHandler(IClassStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }
        public async Task<bool> Handle(DeleteClassStreamCommand request, CancellationToken cancellationToken)
        {
            return await _streamRepository.DeleteAsync(request.id);
        }
    }
}