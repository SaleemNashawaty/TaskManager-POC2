using TaskManager.Client.Core.Models;
using MediatR;

namespace TaskManager.Client.Core.Queries
{
    public class GetTasksQuery: IRequest<IList<TaskModel>>
    {
        public int CreatedById { get; set; }
        public GetTasksQuery(int createdById)
        {
            CreatedById = createdById;
        }
    }
}
