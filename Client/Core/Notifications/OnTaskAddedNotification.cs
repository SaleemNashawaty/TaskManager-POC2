using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.Core.Notifications
{
    public class OnTaskAddedNotification : INotification
    {
        public OnTaskAddedNotification(int newTaskId)
        {
            
            NewTaskId = newTaskId;
        }

        public int NewTaskId { get; private set; }
    }
}