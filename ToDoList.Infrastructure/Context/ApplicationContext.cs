using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Context;

public class ApplicationContext : DbContext, IApplicationContext
{
    public ApplicationContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<ToDoTask> Tasks { get; set; }
}