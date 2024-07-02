using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers
{
    public class GetPaginatedUsersHandler : IRequestHandler<GetPaginatedUsersQuery, (IEnumerable<User?>, int)>
    {
        private readonly IUserRepository _userRepository;

        public GetPaginatedUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(IEnumerable<User?>, int)> Handle(GetPaginatedUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetPaginatedUsersAsync(request.pageNumber, request.pageSize, request.roleTitle);
        }
    }
}