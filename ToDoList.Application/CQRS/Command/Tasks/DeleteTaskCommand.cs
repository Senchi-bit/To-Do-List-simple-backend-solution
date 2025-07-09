
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;
using ToDoList.Application.Interfaces.CQRS;
using ToDoList.Domain.Exceptions;
using Void = ToDoList.Application.Models.Void;

namespace ToDoList.Application.CQRS.Command.Tasks;

public class DeleteTaskCommand : ICommand<Void>
{
    public int Id { get; set; }
}

public class DeleteTaskCommandHandler(ILazyLoadingContext context) : ICommandHandler<DeleteTaskCommand, Void>
{
    public async Task<Void> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (task is null) throw new NotFound404Exception($"Задачи с id {request.Id} не найдена!");
        
        context.Tasks.Remove(task);
        await context.SaveChangesAsync(cancellationToken);
        return Void.Value();
    }
}