
using TaskManager.Server.Core.Entities;
using TaskManager.Server.DataAccess;
using Task = TaskManager.Server.Core.Entities.Task;
using TaskStatus = TaskManager.Server.Core.Entities.TaskStatus;

namespace TaskManager.Server.App.Web.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(TaskManagerDBContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUserTasks([ScopedService] TaskManagerDBContext context)
        { 
           return context.User; 
        }

        [UseDbContext(typeof(TaskManagerDBContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Task> GetTasks([ScopedService] TaskManagerDBContext context)
        {
            return context.Task;
        }


        [UseDbContext(typeof(TaskManagerDBContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<TaskStatus> GetTaskStatus([ScopedService] TaskManagerDBContext context)
        {
            return context.TaskStatus;
        }
    }
}
