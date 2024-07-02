namespace SchoolUser.Application.DTOs
{
    public class PaginatedUsersResponseDto
    {
        public int TotalUsers { get; set; }
        public int ReturnedUsers { get; set; }
        public IEnumerable<GetUserResponseDto>? PaginationList { get; set; }
    }
}