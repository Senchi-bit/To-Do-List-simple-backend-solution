using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;
using ToDoList.Application.Interfaces.CQRS;
using Void = ToDoList.Application.Models.Void;

namespace ToDoList.Application.CQRS.Command.Tasks;

public class UpdateMainInformTaskCommand : ICommand<Void>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

public class UpdateMainInformTaskCommandHandler(ILazyLoadingContext _context) : ICommandHandler<UpdateMainInformTaskCommand, Void>
{
    public async Task<Void> Handle(UpdateMainInformTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (task is null) throw new Exception($"Задачи с id {request.Id} не найдена!");
        
        task.Title = request.Title;
        task.Description = request.Description;
        await _context.SaveChangesAsync(cancellationToken);
        return Void.Value();
    }

}