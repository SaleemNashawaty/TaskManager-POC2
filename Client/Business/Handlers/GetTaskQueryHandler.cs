using TaskManager.Client.Core.Models;
using TaskManager.Client.Core.Providers;
using TaskManager.Client.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.Business.Handlers
{
    public class GetTaskQueryHandler : IRequestHandler<GetTasksQuery, IList<TaskModel>>
    {
        private readonly ITaskProvider _taskProvider;
        public GetTaskQueryHandler(ITaskProvider taskProvider)
        {
            _taskProvider = taskProvider;
        }
        public async Task<IList<TaskModel>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {

            return await _taskProvider.GetList();
        }
    }
}
