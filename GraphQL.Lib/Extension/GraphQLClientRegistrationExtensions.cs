using TaskManager.Client.GraphQL.Lib.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.GraphQL.Lib.Extension
{  
    /// <summary>
   /// Register GraphQLClient to services collections of target app
   /// </summary>
    public static class GraphQLClientRegistrationExtensions
    {
        /// <summary>
        /// Add Singleton instance of <see cref="GraphQLClientFactory"/> to service collection container 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurations"></param>
        public static void AddGraphQLClient(this IServiceCollection services, IConfiguration configurations, string configurationKey)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));
            if (configurations is null)
                throw new ArgumentNullException(nameof(configurations));
            services.Configure<GraphQLGatewaySettings>((options) => configurations.GetSection(configurationKey).Bind(options));
            services.AddSingleton<IGraphQLClientFactory, GraphQLClientFactory>();
        }
    }
}
