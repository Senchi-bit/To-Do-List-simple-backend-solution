using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;

namespace ToDoList.Application.CQRS.Command.Tasks;

public class DeleteTaskCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteTaskCommandHandler(ILazyLoadingContext _context) : IRequestHandler<DeleteTaskCommand>
{
    public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (task is null) throw new Exception($"Задачи с id {request.Id} не найдена!");
        
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync(cancellationToken);
    }
}