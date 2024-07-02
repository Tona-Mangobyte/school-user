namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IHeaderServices
    {
        string? GetAuthorizationHeader(HttpContext context);
    }
}