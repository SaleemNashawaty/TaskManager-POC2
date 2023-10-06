using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.Worker
{
    public static class OnTaskAddedSubscriberGraphQL
    {
        public static string OnTaskAddedSubscription = @"subscription OnTaskAdded { onTaskAdded }";
    }
}
