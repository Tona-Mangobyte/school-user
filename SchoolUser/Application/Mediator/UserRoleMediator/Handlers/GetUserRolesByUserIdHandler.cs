using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserRoleMediator.Queries;

namespace SchoolUser.Application.Mediator.UserRoleMediator.Handlers
{
    public class GetUserRolesByUserIdHandler : IRequestHandler<GetUserRolesByUserIdQuery, IEnumerable<Domain.Models.UserRole?>>
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public GetUserRolesByUserIdHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<IEnumerable<Domain.Models.UserRole?>> Handle(GetUserRolesByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRoleRepository.GetByUserIdAsync(request.id);
        }
    }
}