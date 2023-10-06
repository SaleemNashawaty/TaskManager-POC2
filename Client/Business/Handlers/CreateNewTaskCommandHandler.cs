using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Client.App.SignalR;
using TaskManager.Client.Core.Commands;
using TaskManager.Client.Core.Models;
using TaskManager.Client.Core.Providers;

namespace TaskManager.Client.Business.Handlers
{
    public class CreateNewTaskCommandHandler : IRequestHandler<CreateNewTaskCommand,int>
    {
        private readonly ITaskProvider _taskProvider;
        private readonly IHubContext<TaskManagerSignalRHub> _taskManagerSignalRHubClient;
        public CreateNewTaskCommandHandler(ITaskProvider taskProvider, IHubContext<TaskManagerSignalRHub> hubContext) {
            _taskProvider = taskProvider;
            _taskManagerSignalRHubClient = hubContext;
        }
        public async Task<int> Handle(CreateNewTaskCommand request, CancellationToken cancellationToken)
        {

            var payload = new AddTaskModel();
            payload.Title = request.Title;
            payload.Description = request.Description;
            payload.DueDate = request.DueDate;
            payload.DateCreated = DateTime.UtcNow;
            payload.CreatedUserId= request.CreatedUserId;
            payload.AssigneeId =  request.AssigneeId;
            payload.StatusId = 1;
            var results= await _taskProvider.AddNewTask(payload);
            await _taskManagerSignalRHubClient.Clients.All.SendAsync("OnTaskAdded", results);
            return results;
        }
    }
}
