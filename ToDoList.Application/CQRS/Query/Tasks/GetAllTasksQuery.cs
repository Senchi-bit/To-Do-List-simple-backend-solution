using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;
using ToDoList.Domain.Models;

namespace ToDoList.Application.CQRS.Query.Tasks;

public class GetAllTasksQuery : IRequest<List<ToDoTask>>
{
}

public class GetAllTasksQueryHandler(ILazyLoadingContext lazyLoadingContext) : IRequestHandler<GetAllTasksQuery, List<ToDoTask>>
{
    public async Task<List<ToDoTask>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await lazyLoadingContext.Tasks.ToListAsync(cancellationToken);
        return tasks;
    }
}