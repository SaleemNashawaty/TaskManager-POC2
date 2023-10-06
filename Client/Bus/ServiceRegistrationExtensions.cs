using Microsoft.Extensions.DependencyInjection;
using TaskManager.Client.Core.Bus;

namespace TaskManager.Client.Bus
{
    public static class ServiceRegistrationExtension
    {
        public static IServiceCollection AddServiceBus(this IServiceCollection services)
        {
            services.AddTransient<IBusMessagePublisher, BusMessagePublisher>();
            return services;
        }
    }
}
