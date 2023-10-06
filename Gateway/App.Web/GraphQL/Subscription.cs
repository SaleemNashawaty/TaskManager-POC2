using TaskManager.Server.Core.Entities;
using Task = TaskManager.Server.Core.Entities.Task;

namespace TaskManager.Server.App.Web.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public int OnTaskAdded([EventMessage] int Id)
        {
            return Id;
        }
    }
}
