using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using TaskManager.Client.GraphQL.Lib.Exceptions;
using TaskManager.Client.GraphQL.Lib.Extension;
using Microsoft.Extensions.Configuration;


namespace TaskManager.Client.GraphQL.Lib.Factory
{
    /// <summary>
    /// Read the configurations settings of GraphQLGateway for getting IGatewayGraphQLClient instance
    /// </summary>
    public class GraphQLClientFactory : IGraphQLClientFactory
    {
        private readonly IConfiguration _configurations;

        /// <summary>
        /// Read the configurations settings and Initialize GraphQL Http Client
        /// </summary>
        /// <param name="settings">Get Gateway settings from App configurations</param>
        public GraphQLClientFactory(IConfiguration configurations)
        {
            _configurations = configurations ?? throw new ArgumentNullException(nameof(configurations));
        }

        /// <summary>
        /// Returns PrismGraphClient instance provided with GraphQLClient, Ready to execute queries and mutations
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
                //var plainTextBytes = Encoding.UTF8.GetBytes($"{settings.Username}:{settings.Password}");

                //var basicAuthValue = Convert.ToBase64String(plainTextBytes);
                //_graphQLHttpClient.HttpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + basicAuthValue);

                var timeout = Int32.Parse(settings.Timeout);
                _graphQLHttpClient.HttpClient.Timeout = TimeSpan.FromSeconds(timeout);

                // set web socket security payload. This is needed for subscriptions.
                //_graphQLHttpClient.Options.ConfigureWebSocketConnectionInitPayload = (opt) => CreateConnectionInitPayLoad(basicAuthValue);

                return _graphQLHttpClient;
            }
            catch (Exception ex)
            {
                throw new GraphQLClientException(ex.Message, ex.InnerException);
            }
        }

        // Use this part to authorize the request 
        //private object CreateConnectionInitPayLoad(string basicAuthValue, string accessToken)
        //{
        //    var payload = new Dictionary<string, object>();
        //    var headers = new Dictionary<string, string>();
        //    payload.Add("headers", headers);
        //    headers.Add("Authorization", $"Basic {basicAuthValue}");
        //    if (!string.IsNullOrWhiteSpace(accessToken))
        //    {
        //        headers.Add("access_token", accessToken);
        //    }

        //    return payload;
        //}
    }
}
