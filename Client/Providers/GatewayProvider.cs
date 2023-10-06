using TaskManager.Client.Core.Constants;
using TaskManager.Client.GraphQL.Lib;
using TaskManager.Client.GraphQL.Lib.Factory;

namespace TaskManager.Client.Providers
{
    public abstract class GatewayProvider
    {
        protected GatewayProvider(IGraphQLClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }

            Client = clientFactory.GetInstance(AppConstants.GatewayApiKey, UrlPrefix);
        }

        protected abstract string UrlPrefix { get; }

        protected IGatewayGraphQLClient Client { get; }
    }
}
