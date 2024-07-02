using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.RoleMediator.Queries;

namespace SchoolUser.Application.Mediator.RoleMediator.Handlers;

public class GetRoleByTitleHandler : IRequestHandler<GetRoleByTitleQuery, Role?>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleByTitleHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Role?> Handle(GetRoleByTitleQuery request, CancellationToken cancellationToken)
    {
        return await _roleRepository.GetByTitleAsync(request.title);
    }
}
