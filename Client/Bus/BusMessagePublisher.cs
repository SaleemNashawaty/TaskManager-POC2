using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text;
using TaskManager.Client.Core.Bus;
using Azure.Messaging.ServiceBus;

namespace TaskManager.Client.Bus
{
    public class BusMessagePublisher: IBusMessagePublisher
    {
        private readonly IConfiguration _configuration;
        public BusMessagePublisher(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMessageAsync<T>(T serviceBusMessage, string queueName)
        {
            var queueClient = new ServiceBusClient(_configuration.GetConnectionString("AzureServiceBus"));
            var sender= queueClient.CreateSender(queueName);
            var messageBody = JsonSerializer.Serialize(serviceBusMessage);
            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));
            await sender.SendMessageAsync(message);
        }
    }
}
