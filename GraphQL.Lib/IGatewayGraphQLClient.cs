using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.GraphQL.Lib
{
    public interface IGatewayGraphQLClient
    {
        /// <summary>
        /// Execute the specified <paramref name="query"/> with the provided <paramref name="variables"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type for the response.</typeparam>
        /// <param name="query">The query statement to execute.</param>
        /// <param name="variables">The variable values for the query statement</param>
        /// <exception cref="GraphQLClientException">
        /// Thrown for any exception that occurs while attempting to communicate with the GraphQL endpoint.
        /// </exception>
        /// <returns>Query result mapped to an instance of TResponse.</returns>
        Task<TResponse> ExecuteQueryAsync<TResponse>(string query, object variables);
        /// <summary>
        /// Execute insert, update, or delete GraphQL mutation
        /// </summary>
        /// <typeparam name="TResponse">Type of response</typeparam>
        /// <param name="mutation">Mutation to execute</param>
        /// <param name="variables">The variable values for the mutation statement</param>         
        /// <exception cref="GraphQLClientException">
        /// Thrown for any exception that occurs while attempting to communicate with the GraphQL endpoint.
        /// </exception>
        /// <returns>Mutation result mapped to an instance of TResponse.</returns>
        Task<TResponse> ExecuteMutationAsync<TResponse>(string mutation, object variables);
        /// <summary>
        /// Creates a subscription to a GraphQL server. The connection is not established until the first actual subscription is made.<br/>
        /// All subscriptions made to this stream share the same hot observable.<br/>
        /// All <see cref="WebSocketException"/>s are passed to the <paramref name="webSocketExceptionHandler"/> to be handled externally.<br/>
        /// If the <paramref name="webSocketExceptionHandler"/> completes normally, the subscription is recreated with a new connection attempt.<br/>
        /// Other <see cref="Exception"/>s or any exception thrown by <paramref name="webSocketExceptionHandler"/> will cause the sequence to fail. 
        /// </summary>
        /// <typeparam name="TResponse">The type for the response</typeparam>
        /// <param name="query">The query used for the subscription</param>
        /// <param name="variables">The variable values for the query statement</param>
        /// <param name="exceptionHandler">An external handler for all <see cref="WebSocketException"/>s occurring within the sequence</param></param>
        /// <param name="operationName">The variable used for mentioning which operation is to be executed</param>
        /// <returns>An observable stream for the specified subscription</returns>
        IObservable<GraphQLResponse<TResponse>> CreateSubscription<TResponse>(string query, object variables, Action<Exception> exceptionHandler, string operationName);
    }
}
