using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.StreamMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Handlers
{
    public class AddClassStreamHandler : IRequestHandler<AddClassStreamCommand, ClassStream>
    {
        private readonly IClassStreamRepository _streamRepository;

        public AddClassStreamHandler(IClassStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public async Task<ClassStream> Handle(AddClassStreamCommand request, CancellationToken cancellationToken)
        {
            return await _streamRepository.CreateAsync(request.ClassStream);
        }
    }
}