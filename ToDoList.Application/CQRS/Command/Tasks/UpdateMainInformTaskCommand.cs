using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;

namespace ToDoList.Application.CQRS.Command.Tasks;

public class UpdateMainInformTaskCommand : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

public class UpdateMainInformTaskCommandHandler(ILazyLoadingContext _context) : IRequestHandler<UpdateMainInformTaskCommand>
{
    public async Task Handle(UpdateMainInformTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (task is null) throw new Exception($"Задачи с id {request.Id} не найдена!");
        
        task.Title = request.Title;
        task.Description = request.Description;
        await _context.SaveChangesAsync(cancellationToken);
    }
}