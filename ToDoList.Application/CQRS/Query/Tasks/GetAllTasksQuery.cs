using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;
using ToDoList.Domain.Enumerations;
using ToDoList.Domain.Models;

namespace ToDoList.Application.CQRS.Query.Tasks;

public class GetAllTasksQuery : IRequest<List<ToDoTaskDto>>
{
}

public class GetAllTasksQueryHandler(ILazyLoadingContext lazyLoadingContext) : IRequestHandler<GetAllTasksQuery, List<ToDoTaskDto>>
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