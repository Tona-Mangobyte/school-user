using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers
{
    public class DeleteInactiveUsersHandler : IRequestHandler<DeleteInactiveUsersCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteInactiveUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteInactiveUsersCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteInactiveUsersAsync();
            return Unit.Value;
        }
    }
}