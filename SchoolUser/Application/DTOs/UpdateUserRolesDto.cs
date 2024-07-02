namespace SchoolUser.Application.DTOs
{
    public class UpdateUserRolesDto
    {
        public Guid UserId { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}