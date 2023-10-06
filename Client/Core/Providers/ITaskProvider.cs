using TaskManager.Client.Core.Models;

namespace TaskManager.Client.Core.Providers
{
    public interface ITaskProvider
    {
        Task<IList<TaskModel>> GetList();
        Task<int> AddNewTask(AddTaskModel payload);
    }
}
