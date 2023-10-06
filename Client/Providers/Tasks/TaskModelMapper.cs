using TaskManager.Client.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.Providers.Tasks
{
    public static class TaskModelMapper
    {
        public static IList<TaskModel> ToTaskModelList(this GetTaskResponse response)
        {

            if (response is null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            if (response.Tasks == null || !response.Tasks.Any())
            {
                return new List<TaskModel>();
            }

            return response.Tasks.Select(item => new TaskModel {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    DateCreated = item.DateCreated,
                    DueDate = item.DueDate,
                    AssignedToName = item.Assignee.Name,
                    CreatedByName = item.CreatedUser.Name,
                    Status = item.Status.Name
                }).ToList();
        }
    }
}