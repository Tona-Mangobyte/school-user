using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Commands;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers;

public class VerifyUserHandler : IRequestHandler<VerifyUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public VerifyUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(VerifyUserCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.VerifyUserAsync(request.User);
    }
}
