using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TaskManager.Client.Worker
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddWorkers(this IServiceCollection services)
        {
            services.AddSingleton<IHostedService,OnTaskAddedSubscriber>();
        }
    }
}
