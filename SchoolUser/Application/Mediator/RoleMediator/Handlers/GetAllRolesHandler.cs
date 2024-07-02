using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.RoleMediator.Queries;

namespace SchoolUser.Application.Mediator.RoleMediator.Handlers;
public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<Role>>
{
    private readonly IRoleRepository _roleRepository;
    public GetAllRolesHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task<IEnumerable<Role>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        return await _roleRepository.GetAllAsync();
    }
}
