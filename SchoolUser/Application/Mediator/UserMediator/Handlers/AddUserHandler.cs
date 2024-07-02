using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers;

public class AddUserHandler : IRequestHandler<AddUserCommand, Domain.Models.User?>
{
    private readonly IUserRepository _userRepository;

    public AddUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Domain.Models.User?> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.CreateAsync(request.User);
    }
}
