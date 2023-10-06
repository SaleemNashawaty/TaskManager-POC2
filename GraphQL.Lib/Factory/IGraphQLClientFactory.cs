namespace TaskManager.Client.GraphQL.Lib.Factory
{

    public interface IGraphQLClientFactory
    {
        /// <summary>
        ///  Create new graphQL http client based on configurations provided in cref="GraphQLGatewaySettings", open the connection and return new cref="IGraphQLClient<TResponse>" instance 
        /// <param name="endpoint"></param>
        /// <returns></returns>
        IGatewayGraphQLClient GetInstance(string configurationKey, string endpoint = "");
    }
}