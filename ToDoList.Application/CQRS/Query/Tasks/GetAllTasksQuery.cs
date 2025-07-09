using Mapster;

using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;
using ToDoList.Application.Interfaces.CQRS;
using ToDoList.Domain.Enumerations;
using ToDoList.Domain.Models;

namespace ToDoList.Application.CQRS.Query.Tasks;

public class GetAllTasksQuery : IQuery<List<ToDoTaskDto>>
{
}

public class GetAllTasksQueryHandler(ILazyLoadingContext lazyLoadingContext) : IQueryHandler<GetAllTasksQuery, List<ToDoTaskDto>>
{
    public async Task<List<ToDoTaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await lazyLoadingContext.Tasks
            .OrderBy(x => x.TaskState == ToDoTaskStates.Created)
            .ProjectToType<ToDoTaskDto>()
            .ToListAsync(cancellationToken);
        return tasks;
    }
}