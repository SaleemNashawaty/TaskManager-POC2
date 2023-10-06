using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using TaskManager.Client.GraphQL.Lib.Exceptions;
using TaskManager.Client.GraphQL.Lib.Extension;
using Microsoft.Extensions.Configuration;


namespace TaskManager.Client.GraphQL.Lib.Factory
{
    public class GraphQLClientFactory : IGraphQLClientFactory
    {
        private readonly IConfiguration _configurations;
        public GraphQLClientFactory(IConfiguration configurations)
        {
            _configurations = configurations ?? throw new ArgumentNullException(nameof(configurations));
        }

        /// <summary>
        /// Returns GatewayGraphQLClient instance provided with GraphQLClient, Ready to execute queries and mutations
        /// </summary>
        /// <param name="endpoint">name of the endpoint of graphQL queries and mutations </param>
        /// <returns></returns>
        public IGatewayGraphQLClient GetInstance(string configurationKey, string endpoint = "")
        {
           var settings= _configurations.GetSection(configurationKey).Get<GraphQLGatewaySettings>();

            var graphQLHttpClient = InitializeGraphQLHttpClient(settings);
            return new GatewayGraphQLClient(graphQLHttpClient, endpoint);
        }

        private GraphQLHttpClient InitializeGraphQLHttpClient(GraphQLGatewaySettings settings)
        {
            try
            {
                var _graphQLHttpClient = new GraphQLHttpClient(settings.EndpointUrl, new NewtonsoftJsonSerializer());

                var timeout = Int32.Parse(settings.Timeout);
                _graphQLHttpClient.HttpClient.Timeout = TimeSpan.FromSeconds(timeout);

                return _graphQLHttpClient;
            }
            catch (Exception ex)
            {
                throw new GraphQLClientException(ex.Message, ex.InnerException);
            }
        }
    }
}
