using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;
using ToDoList.Domain.Exceptions;

namespace ToDoList.Application.CQRS.Command.Tasks;

public class DeleteTaskCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteTaskCommandHandler(ILazyLoadingContext context) : IRequestHandler<DeleteTaskCommand>
{
    public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (task is null) throw new NotFound404Exception($"Задачи с id {request.Id} не найдена!");
        
        context.Tasks.Remove(task);
        await context.SaveChangesAsync(cancellationToken);
    }
}