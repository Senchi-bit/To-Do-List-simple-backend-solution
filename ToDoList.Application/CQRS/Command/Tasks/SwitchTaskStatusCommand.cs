using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;
using ToDoList.Domain.Enumerations;

namespace ToDoList.Application.CQRS.Command.Tasks;

public class SwitchTaskStatusCommand : IRequest
{
    public int Id { get; set; }
}

public class SwitchTaskStatusCommandHandler(ILazyLoadingContext _context) : IRequestHandler<SwitchTaskStatusCommand>
{
    public async Task Handle(SwitchTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (task is null) throw new Exception($"Задачи с id {request.Id} не найдена!");
        
        task.TaskState = ToDoTaskStates.Completed;
        await _context.SaveChangesAsync(cancellationToken);
    }
}