using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers;

public class UpdateTokenHandler : IRequestHandler<UpdateTokenCommand, User?>
{
    private readonly IUserRepository _userRepository;

    public UpdateTokenHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Handle(UpdateTokenCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.UpdateTokenAsync(request.User);
    }
}
