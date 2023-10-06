using HotChocolate.Subscriptions;
using TaskManager.Server.Core.Entities;
using TaskManager.Server.Core.Tasks;
using TaskManager.Server.DataAccess;

namespace TaskManager.Server.App.Web.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(TaskManagerDBContext))]
        public async Task<AddTaskPayload> AddTaskAsync(AddTaskInput input, 
            [ScopedService] TaskManagerDBContext context,
            [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var task = new TaskManager.Server.Core.Entities.Task
            {
                Title = input.Title,
                Description = input.Description,
                DueDate = input.DueDate,
                CreatedUserId = input.CreatedUserId,
                AssigneeId = input.AssigneeId,
                DateCreated = input.DateCreated,
                StatusId =input.StatusId
            };
            context.Task.Add(task);
            await context.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(nameof(Subscription.OnTaskAdded), task.Id,cancellationToken);
            return new AddTaskPayload(task.Id);
        }
    }
}
