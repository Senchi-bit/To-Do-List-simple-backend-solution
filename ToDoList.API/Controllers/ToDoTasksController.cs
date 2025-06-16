using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.CQRS.Command.Tasks;
using ToDoList.Application.CQRS.Query.Tasks;

namespace ToDoList.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ToDoTasksController(ISender sender) : Controller
{
    private readonly ISender _sender = sender;

    [HttpGet("AllTasks")]
    public async Task<IActionResult> GetAllTasks([FromQuery]GetAllTasksQuery query, CancellationToken cancellationToken)
    {
        var tasks = await _sender.Send(query, cancellationToken);
        return Ok(tasks);
    }

    [HttpGet("AllInWorkTasks")]
    public async Task<IActionResult> GetAllInWorkTasks([FromQuery] GetAllInWorkTasksQuery query,
        CancellationToken cancellationToken)
    {
        var tasks = await _sender.Send(query, cancellationToken);
        return Ok(tasks);
    }

    [HttpPost("CreateTask")]
    public async Task<IActionResult> Create([FromBody]CreateTaskCommand command, CancellationToken cancellationToken)
    {
        var taskId = await _sender.Send(command, cancellationToken);
        return Ok(taskId);
    }

    [HttpPut("UpdateTask")]
    public async Task<IActionResult> UpdateTask([FromBody] UpdateMainInformTaskCommand command,
        CancellationToken cancellationToken)
    {
        await _sender.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpPatch("CompleteTask")]
    public async Task<IActionResult> CompleteTask([FromBody] SwitchTaskStatusCommand command,
        CancellationToken cancellationToken)
    {
        await _sender.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("DeleteTask")]
    public async Task<IActionResult> DeleteTask([FromBody] DeleteTaskCommand command,
        CancellationToken cancellationToken)
    {
        await _sender.Send(command, cancellationToken);
        return NoContent();
    }
}