using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Models;

namespace ToDoList.Application.Interfaces.Context;

public interface IApplicationContext
{
    public DbSet<ToDoTask> Tasks { get; set; }
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}