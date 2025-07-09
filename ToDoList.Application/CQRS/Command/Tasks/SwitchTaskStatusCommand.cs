
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;
using ToDoList.Application.Interfaces.CQRS;
using ToDoList.Domain.Enumerations;
using ToDoList.Domain.Exceptions;
using Void = ToDoList.Application.Models.Void;

namespace ToDoList.Application.CQRS.Command.Tasks;

public class SwitchTaskStatusCommand : ICommand<Void>
{
    public int Id { get; set; }
    public ToDoTaskStates StatusId { get; set; }
}

public class SwitchTaskStatusCommandHandler(ILazyLoadingContext context) : ICommandHandler<SwitchTaskStatusCommand, Void>
{
    public async Task<Void> Handle(SwitchTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (task is null) throw new NotFound404Exception($"Задачи с id {request.Id} не найдена!");
        if (request.StatusId is > ToDoTaskStates.Completed or < ToDoTaskStates.Created)
        {
            throw new BaseException("Неверный запрос!",400);
        }
        task.TaskState = request.StatusId;
        task.IsCompleted = task.TaskState == ToDoTaskStates.Completed;
        
        await context.SaveChangesAsync(cancellationToken);
        return Void.Value();
    }
}