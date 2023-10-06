using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Client.Core.SignalR.Models;

namespace TaskManager.Client.Core.SignalR
{
    public interface ITaskManagerSignalRHubClient
    {
        Task OnTaskAdded(TaskChanged obj);
        Task OnTaskRemoved(TaskChanged obj);
        Task OnTaskChanged(TaskChanged obj);
    }
}
