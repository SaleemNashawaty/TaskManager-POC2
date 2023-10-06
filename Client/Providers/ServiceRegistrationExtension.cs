using TaskManager.Client.Core.Providers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Client.Providers.Users;

namespace TaskManager.Client.Providers
{
    public static class ServiceRegistrationExtension
    {
        public static IServiceCollection AddProviders(this IServiceCollection services) 
        {
            services.AddTransient<ITaskProvider, TaskProvider>();
            services.AddTransient<IUserProvider, UserProvider>();
            return services;
        }
    }
}
