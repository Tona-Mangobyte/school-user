using System.Globalization;
using Hangfire;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using MediatR;
using Newtonsoft.Json;

namespace SchoolUser.Domain.Services
{
    public class HangfireServices
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public HangfireServices(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }

        public void ConfigureHangfire()
        {
            SetCultureInfo();

            RecurringJob.AddOrUpdate("DeleteInActiveUsers", () => DeleteInactiveUsersService(), Cron.Weekly);
            RecurringJob.AddOrUpdate("DeleteUnregisterUsers", () => DeleteUnregisteredUsersService(), Cron.Weekly);
            RecurringJob.AddOrUpdate("AutoUpdateUsersAge", () => AutoUpdateUsersAgeService(), Cron.Daily);
        }

        public async Task DeleteInactiveUsersService()
        {
            await ExecuteCommandAsync(new DeleteInactiveUsersCommand());
        }

        public async Task DeleteUnregisteredUsersService()
        {
            await ExecuteCommandAsync(new DeleteUnregisteredUsersCommand());
        }

        public async Task AutoUpdateUsersAgeService()
        {
            await ExecuteCommandAsync(new AutoUpdateUsersAgeCommand());
        }

        private async Task ExecuteCommandAsync(IRequest<Unit> request)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sender = scope.ServiceProvider.GetRequiredService<ISender>();
                await sender.Send(request);
            }
        }

        private void SetCultureInfo()
        {
            var cultureInfo = new CultureInfo("en-US"); // Specify the desired culture, e.g., "en-US"
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            GlobalConfiguration.Configuration
                .UseSerializerSettings(new JsonSerializerSettings { Culture = cultureInfo });
        }
    }
}