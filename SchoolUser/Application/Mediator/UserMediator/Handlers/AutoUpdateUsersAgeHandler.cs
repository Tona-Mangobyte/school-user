using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Commands;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers
{
    public class AutoUpdateUsersAgeHandler : IRequestHandler<AutoUpdateUsersAgeCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public AutoUpdateUsersAgeHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AutoUpdateUsersAgeCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.AutoUpdateUserAgeAsync();
            return Unit.Value;
        }
    }
}