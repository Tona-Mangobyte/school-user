using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Queries;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Domain.Models.User?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Domain.Models.User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByIdAsync(request.id);
    }
}
