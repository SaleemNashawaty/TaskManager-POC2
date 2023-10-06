using GraphQL.Client.Http;
using TaskManager.Client.GraphQL.Lib.Exceptions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GraphQLStringExtensions = GraphQL.Client.Abstractions.Utilities.StringUtils;
using GraphQL.Client.Abstractions;
using TaskManager.Client.GraphQL.Lib.Extension;
using GraphQL;

namespace TaskManager.Client.GraphQL.Lib
{
    public class GatewayGraphQLClient:IGatewayGraphQLClient
    {
        #region Fields
        private readonly IGraphQLClient _graphQLHttpClient;
        private readonly string _endpoint;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates an instance of GraphQLClient
        /// </summary>
        /// <param name="graphQLHttpClient"></param>
        /// <param name="endpoint"></param>
        public GatewayGraphQLClient(IGraphQLClient graphQLHttpClient, string endpoint)
        {
            _graphQLHttpClient = graphQLHttpClient;
            if (!string.IsNullOrEmpty(endpoint))
            {
                _endpoint = GraphQLStringExtensions.ToSnakeCase(endpoint);
            }
        }
        #endregion

        #region Interfaces
        public async Task<TResponse> ExecuteQueryAsync<TResponse>(string query, object variables)
        {
            var request = new GraphQLRequest(query: query, variables: variables);
            var response = await _graphQLHttpClient.SendQueryAsync<TResponse>(request);
            VerifySuccess(response, request);
            return response.Data;
        }

        public async Task<TResponse> ExecuteMutationAsync<TResponse>(string mutation, object variables)
        {
            var request = new GraphQLRequest(query: mutation, variables: variables);
            var response = await _graphQLHttpClient.SendMutationAsync<TResponse>(request);
            VerifySuccess(response, request);
            return response.Data;
        }

        public IObservable<GraphQLResponse<TResponse>> CreateSubscription<TResponse>(string query, object variables, Action<Exception> exceptionHandler, string operationName)
        {
            var request = new GraphQLRequest(query: query, variables: variables, operationName: operationName);
            var subscriptionStream = _graphQLHttpClient.CreateSubscriptionStream<TResponse>(request, exceptionHandler);
            return subscriptionStream;
        }

        private void VerifySuccess<T>(GraphQLResponse<T> response, GraphQLRequest request)
        {
            if (response.Errors != null && response.Errors.Length > 0)
            {

                LogErrors(response.Errors, request.Query);
                var formattedRequestQuery = FormatGraphQLQuery(request.Query);
                var message = $"One or more errors returned for query: {formattedRequestQuery}";
                var errors = response.Errors.Select(err => new GraphQLClientException(err.Message));
                throw new AggregateException(message, errors);
            }
        }

        private void LogErrors(GraphQLError[]? errors, string query)
        {
            string exceptions = string.Empty;
            if (errors != null)
            {
                if (errors.Any())
                {
                    foreach (var item in errors)
                    {
                        var formattedQuery = FormatGraphQLQuery(query);
                        throw new Exception($"{item.Message} while executing the following query: \n{formattedQuery}");
                    }
                }
            }
        }

        private string FormatGraphQLQuery(string query)
        {
            // Use JSON formatting to make the GraphQL query more readable
            try
            {
                dynamic parsedQuery = JObject.Parse("{\"query\": " + query + "}");
                string formattedQuery = parsedQuery.query.ToString();

                // Remove extra whitespace and newlines between brackets
                formattedQuery = Regex.Replace(query, @"{\s+", "{ ", RegexOptions.Multiline);
                formattedQuery = Regex.Replace(formattedQuery, @"\s+}\s+", " } ", RegexOptions.Multiline);

                return formattedQuery.Trim();
            }
            catch (Exception)
            {
                return query;
            }
        }
        #endregion
       
    }
}