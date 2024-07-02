using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers
{
    public class DeleteUnregisteredUsersHandler : IRequestHandler<DeleteUnregisteredUsersCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUnregisteredUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUnregisteredUsersCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUnregisteredUsersAsync();
            return Unit.Value;
        }
    }
}