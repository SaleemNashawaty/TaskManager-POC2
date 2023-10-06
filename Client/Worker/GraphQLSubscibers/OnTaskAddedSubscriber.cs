using GraphQL;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Client.Core.Constants;
using TaskManager.Client.Core.Notifications;
using TaskManager.Client.GraphQL.Lib;
using TaskManager.Client.GraphQL.Lib.Factory;

namespace TaskManager.Client.Worker
{
    public class OnTaskAddedSubscriber: BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public OnTaskAddedSubscriber(IServiceProvider serviceProvider)
        {
            _serviceProvider= serviceProvider;
        }
        
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var subscriptionStream = GetSubscriptionStream();
            subscriptionStream.Subscribe(HandleChanges, stoppingToken);
            return Task.CompletedTask;
        }

        private void HandleChanges(GraphQLResponse<OnTaskAddedResponse> response)
        {
            try
            {
                if (response.Errors != null && response.Errors.Length > 0)
                {
                   // Log error
                    return;
                }

                if (response?.Data?.Id == null)
                {
                    //Log Received invalid response for the NewTaskAdded subscription.
                    return;
                }

                // Log Processing NewTaskAdded response with {0} changes.", response.Data.NewTaskIds.Count);
                using (var scope = _serviceProvider.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    var changedRequests = response.Data.Id;
                    var notification = new OnTaskAddedNotification(changedRequests);
                    mediator.Publish(notification).Wait();
                }
            }
            catch (Exception ex)
            {
                // Log Exception "An error occured processing NewTaskAdded response"
            }
        }

        private IObservable<GraphQLResponse<OnTaskAddedResponse>> GetSubscriptionStream()
        {
            var client = GetGraphQLClient();
            var variables = new { } ;
            var subscriptionStream = client.CreateSubscription<OnTaskAddedResponse>(OnTaskAddedSubscriberGraphQL.OnTaskAddedSubscription, variables, HandleSubscriptionException, "OnTaskAdded");
            return subscriptionStream;
        }

        private IGatewayGraphQLClient GetGraphQLClient()
        {
            var factory = _serviceProvider.GetRequiredService<IGraphQLClientFactory>();
            var client = factory.GetInstance(AppConstants.GatewayApiKey, "OnTaskAdded");
            return client;
        }

        private void HandleSubscriptionException(Exception exception)
        {
            throw new Exception(exception.Message);
            // Log "An error occurred in Add New Task subscriber."
        }


    }
}
