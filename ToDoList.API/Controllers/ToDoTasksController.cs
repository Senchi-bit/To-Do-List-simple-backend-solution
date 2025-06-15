using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.CQRS.Query.Tasks;

namespace ToDoList.API.Controllers;
[ApiController]
public class ToDoTasksController(ISender sender) : Controller
{
    private readonly ISender _sender = sender;

    [HttpGet("AllTasks")]
    public async Task<IActionResult> GetAllTasks([FromQuery]GetAllTasksQuery query, CancellationToken cancellationToken)
    {
        var tasks = await _sender.Send(new GetAllTasksQuery(), cancellationToken);
        return Ok(tasks);
    }
}