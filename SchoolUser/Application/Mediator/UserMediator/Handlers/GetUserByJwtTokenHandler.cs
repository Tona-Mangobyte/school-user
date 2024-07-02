using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers
{
    public class GetUserByJwtTokenHandler : IRequestHandler<GetUserByJwtTokenQuery, User?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByJwtTokenHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(GetUserByJwtTokenQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByJwtTokenAsync(request.jwtToken);
        }
    }
}