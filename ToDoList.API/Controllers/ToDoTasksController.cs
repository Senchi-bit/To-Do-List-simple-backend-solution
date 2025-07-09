using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.CQRS.Command.Tasks;
using ToDoList.Application.CQRS.Query.Tasks;
using ToDoList.Application.Interfaces.CQRS;
using ToDoList.Domain.Models;
using Void = ToDoList.Application.Models.Void;

namespace ToDoList.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ToDoTasksController(IQuerySender querySender, ICommandSender commandSender) : Controller
{

    [HttpGet("AllTasks")]
    public async Task<IActionResult> GetAllTasks([FromQuery]GetAllTasksQuery query, CancellationToken cancellationToken)
    {
        var tasks = await querySender.Send<GetAllTasksQuery, List<ToDoTaskDto>>(query, cancellationToken);
        return Ok(tasks);
    }

    [HttpGet("AllInWorkTasks")]
    public async Task<IActionResult> GetAllInWorkTasks([FromQuery] GetAllInWorkTasksQuery query,
        CancellationToken cancellationToken)
    {
        var tasks = await querySender.Send<GetAllInWorkTasksQuery, List<ToDoTaskDto>>(query, cancellationToken);
        return Ok(tasks);
    }

    [HttpPost("CreateTask")]
    public async Task<IActionResult> Create([FromBody]CreateTaskCommand command, CancellationToken cancellationToken)
    {
        var taskId = await commandSender.Send<CreateTaskCommand, int>(command, cancellationToken);
        return Ok(taskId);
    }

    [HttpPut("UpdateTask")]
    public async Task<IActionResult> UpdateTask([FromBody] UpdateMainInformTaskCommand command,
        CancellationToken cancellationToken)
    {
        await commandSender.Send<UpdateMainInformTaskCommand, Void>(command, cancellationToken);
        return NoContent();
    }

    [HttpPatch("SwitchTaskStatus")]
    public async Task<IActionResult> SwitchTaskStatus([FromBody] SwitchTaskStatusCommand command,
        CancellationToken cancellationToken)
    {
        await commandSender.Send<SwitchTaskStatusCommand, Void>(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("DeleteTask")]
    public async Task<IActionResult> DeleteTask([FromBody] DeleteTaskCommand command,
        CancellationToken cancellationToken)
    {
        await commandSender.Send<DeleteTaskCommand, Void>(command, cancellationToken);
        return NoContent();
    }
}