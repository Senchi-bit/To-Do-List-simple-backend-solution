using ToDoList.Application.Interfaces.Context;
using ToDoList.Application.Interfaces.CQRS;
using ToDoList.Domain.Enumerations;
using ToDoList.Domain.Models;

namespace ToDoList.Application.CQRS.Command.Tasks;

public class CreateTaskCommand : ICommand<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
}

public class CreateTaskCommandHandler(ILazyLoadingContext _context) : ICommandHandler<CreateTaskCommand, int>
{
    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new ToDoTask()
        {
            Title = request.Title,
            Description = request.Description,
            IsCompleted = false,
            TaskState = ToDoTaskStates.Created
        };
        
        await _context.Tasks.AddAsync(task, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return task.Id;
    }
}