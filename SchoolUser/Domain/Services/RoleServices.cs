using AutoMapper;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Mediator.RoleMediator.Commands;
using SchoolUser.Application.Mediator.RoleMediator.Queries;
using SchoolUser.Domain.Models;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Domain.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly string EntityName = "Role";

        public RoleServices(ISender sender, IMapper mapper, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _mapper = mapper;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<Role>> GetAllRolesService()
        {
            return await _sender.Send(new GetAllRolesQuery());
        }

        public async Task<Role?> GetRoleService(Guid id)
        {
            var role = await _sender.Send(new GetRoleByIdQuery(id));

            if (role == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            return role;
        }

        public async Task<List<Role>?> CheckExistingRolesService(List<string> roles)
        {
            List<Role> createdUserRoleList = new List<Role>();

            for (int i = 0; i < roles.Count; i++)
            {
                var existingRole = await _sender.Send(new GetRoleByTitleQuery(roles[i]));

                if (existingRole == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
                }

                createdUserRoleList.Add(existingRole);
            }

            return createdUserRoleList;
        }

        public async Task<Role?> CreateRoleService(RoleDto roleDto)
        {
            try
            {
                var existingRole = await _sender.Send(new GetRoleByTitleQuery(roleDto.Title));

                if (existingRole != null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, $"{roleDto.Title}"));
                }

                var newRole = _mapper.Map<Role>(roleDto);
                newRole.Id = Guid.NewGuid();

                return await _sender.Send(new AddRoleCommand(newRole));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<string> UpdateRoleService(Guid id, RoleDto roleDto)
        {

            var existing = await _sender.Send(new GetRoleByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            if (existing.Title != roleDto.Title)
            {
                existing.Title = roleDto.Title;

                var result = await _sender.Send(new UpdateRoleCommand(existing));

                if (!result)
                {
                    throw new Exception(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
                }
            }
            else
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, EntityName));
            }

            return string.Format(_returnValueConstants.SUCCESSFUL_UPDATE, EntityName);
        }

        public async Task<string> DeleteRoleService(Guid id)
        {
            var result = await _sender.Send(new DeleteRoleCommand(id));

            if (!result)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_DELETE, EntityName));
            }

            return string.Format(_returnValueConstants.SUCCESSFUL_DELETE, EntityName);
        }
    }
}