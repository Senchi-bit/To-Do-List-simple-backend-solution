using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;
using ToDoList.Domain.Enumerations;
using ToDoList.Domain.Exceptions;

namespace ToDoList.Application.CQRS.Command.Tasks;

public class SwitchTaskStatusCommand : IRequest
{
    public int Id { get; set; }
    public int StatusId { get; set; }
}

public class SwitchTaskStatusCommandHandler(ILazyLoadingContext context) : IRequestHandler<SwitchTaskStatusCommand>
{
    public async Task Handle(SwitchTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (task is null) throw new NotFound404Exception($"Задачи с id {request.Id} не найдена!");
        
        task.TaskStateId = request.StatusId;
        task.IsCompleted = task.TaskState == ToDoTaskStates.Completed;
        await context.SaveChangesAsync(cancellationToken);
    }
}