using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Domain.Services
{
    public class HeaderService : IHeaderServices
    {
        public string? GetAuthorizationHeader(HttpContext context)
        {
            if (context != null && context.Request.Headers.ContainsKey("Authorization"))
            {
                string tokenHeader = context.Request.Headers["Authorization"].ToString();
                return tokenHeader;
            }
            return null;
        }
    }
}