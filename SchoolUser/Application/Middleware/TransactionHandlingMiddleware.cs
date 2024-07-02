using SchoolUser.Infrastructure.Data;

namespace SchoolUser.Application.Middleware
{
    public class TransactionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public TransactionHandlingMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<DBContext>();
            if (dbContext.Database.CurrentTransaction != null)
            {
                await dbContext.Database.CurrentTransaction.RollbackAsync();
            }
            await _next(context);
        }
    }
}