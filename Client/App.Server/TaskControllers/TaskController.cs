using TaskManager.Client.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Client.Core.Commands;
using TaskManager.Client.App.Server.Dto;
using TaskManager.Client.Core.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace TaskManager.Client.App.Server.TaskControllers
{
    [Route(BaseUrl +"Task")]
    public class TaskController:BaseController
    {
        private readonly IMediator _mediator;
        
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _mediator.Send(new GetTasksQuery(4));
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTaskDto dto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            var results = await _mediator.Send(new CreateNewTaskCommand(dto.Title,dto.Description,dto.DueDate,dto.CreatedUserId,dto.AssigneeId));
    
            return Ok(results);
        }
    }
}
