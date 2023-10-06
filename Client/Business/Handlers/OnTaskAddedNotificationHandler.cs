using MediatR;
using Microsoft.AspNetCore.SignalR;
using TaskManager.Client.App.SignalR;
using TaskManager.Client.Core.Bus;
using TaskManager.Client.Core.Notifications;
using TaskManager.Client.Core.SignalR;

namespace TaskManager.Client.Business.Handlers
{
    public class OnTaskAddedNotificationHandler : INotificationHandler<OnTaskAddedNotification>
    {
        private readonly IBusMessagePublisher _busMessagePublisher;
        private readonly IHubContext<TaskManagerSignalRHub> _taskManagerSignalRHubClient;
        public OnTaskAddedNotificationHandler(IBusMessagePublisher busMessagePublisher, IHubContext<TaskManagerSignalRHub> taskManagerSignalRHubClient)
        {
            _busMessagePublisher = busMessagePublisher;
            _taskManagerSignalRHubClient = taskManagerSignalRHubClient;
        }
        public async Task Handle(OnTaskAddedNotification notification, CancellationToken cancellationToken)
        {
            await _busMessagePublisher.SendMessageAsync(notification.NewTaskId, "addingtasksqueue");

            try
            {

            
            await _taskManagerSignalRHubClient.Clients.All.SendAsync("OnTaskAdded", notification.NewTaskId); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
