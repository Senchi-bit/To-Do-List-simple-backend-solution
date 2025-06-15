using Microsoft.EntityFrameworkCore;

namespace ToDoList.Application.Interfaces.Context;
public interface ILazyLoadingContext : IApplicationContext
{
    public DbSet<TEntity> Set<TEntity>() where TEntity : class;
}