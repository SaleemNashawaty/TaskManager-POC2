using Azure.Messaging.ServiceBus;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TaskManager.Services.Core;

namespace TaskManager.Services.Worker.AzureServiceBusSubscribers
{
    public class AddingTaskSubscriber : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        public AddingTaskSubscriber(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var queueClient = new ServiceBusClient(_configuration.GetConnectionString("AzureServiceBus"));
            var processor = queueClient.CreateProcessor("addingtasksqueue");
            // add handler to process messages
            processor.ProcessMessageAsync += MessageHandler;

            // add handler to process any errors
            processor.ProcessErrorAsync += ErrorHandler;

            // start processing 
            await processor.StartProcessingAsync();
        }
        async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            await _mediator.Send(new SendEmailQuery(new List<string>(),body));
            // complete the message. message is deleted from the queue. 
            await args.CompleteMessageAsync(args.Message);
        }

        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            // log exceptions
            return Task.CompletedTask;
        }

    }
}
