using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManager.Services.Worker.AzureServiceBusSubscribers;

namespace TaskManager.Services.Worker
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddWorkers(this IServiceCollection services)
        {
            services.AddTransient<IHostedService, AddingTaskSubscriber>();
        }
    }
}
