using TaskManager.Client.Core.Models;
using TaskManager.Client.Core.Providers;
using TaskManager.Client.GraphQL.Lib.Factory;
using TaskManager.Client.Providers.Tasks;

namespace TaskManager.Client.Providers
{
    public class TaskProvider: GatewayProvider,ITaskProvider
    {
        public TaskProvider(IGraphQLClientFactory clientFactory):base(clientFactory) {}

        protected override string UrlPrefix => "Tasks";

        public async Task<int> AddNewTask(AddTaskModel payload)
        {
            var variables = new
            {
                title = payload.Title,
                description = payload.Description,
                dateCreated = payload.DateCreated,
                dueDate = payload.DueDate,
                statusId = payload.StatusId,
                assigneeId = payload.AssigneeId,
                createdUserId = payload.CreatedUserId
            };
            var data = await Client.ExecuteMutationAsync<AddNewTaskResponse>(TaskQueries.AddTaskMutation, variables);
            return data.Response.Id;
        }

        public async Task<IList<TaskModel>> GetList()
        {
            var data = await Client.ExecuteQueryAsync<GetTaskResponse>(TaskQueries.GetTasks,null);
            return data?.ToTaskModelList();
        }
    }
}
