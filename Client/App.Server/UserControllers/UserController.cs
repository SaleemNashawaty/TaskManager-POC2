using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Client.Core.Queries;

namespace TaskManager.Client.App.Server.UserControllers
{
    [Route(BaseUrl + "User")]
    public class UserController: BaseController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var results = await _mediator.Send(new ListUserQuery());
            return Ok(results);
        }
    }
}
