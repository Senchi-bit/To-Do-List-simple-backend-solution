using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Interfaces.Context;

namespace ToDoList.Infrastructure.Context;

public class LazyLoadingContext : ApplicationContext, ILazyLoadingContext
{
    public LazyLoadingContext(DbContextOptions<LazyLoadingContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies();
    }
}