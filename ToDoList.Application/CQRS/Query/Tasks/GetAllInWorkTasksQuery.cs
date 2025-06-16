using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;
using ToDoList.Domain.Enumerations;
using ToDoList.Domain.Models;

namespace ToDoList.Application.CQRS.Query.Tasks;

public class GetAllInWorkTasksQuery : IRequest<List<ToDoTaskDto>>
{
}

public class GetAllInWorkTasksQueryHandler(ILazyLoadingContext _context) 
    : IRequestHandler<GetAllInWorkTasksQuery, List<ToDoTaskDto>>
{
    public async Task<List<ToDoTaskDto>> Handle(GetAllInWorkTasksQuery request, CancellationToken cancellationToken)
    {
        var inWorkTasks = await _context.Tasks
            .Where(x => x.TaskState == ToDoTaskStates.InWork)
            .ProjectToType<ToDoTaskDto>()
            .ToListAsync(cancellationToken);
        return inWorkTasks;
    }
}