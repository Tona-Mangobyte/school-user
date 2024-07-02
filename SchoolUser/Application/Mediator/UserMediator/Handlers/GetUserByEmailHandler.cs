using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using MediatR;


namespace SchoolUser.Application.Mediator.UserMediator.Handlers;

public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, Domain.Models.User?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Domain.Models.User?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByEmailAsync(request.email);
    }
}
