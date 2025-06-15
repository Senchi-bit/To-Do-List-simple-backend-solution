using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ToDoList.Application.Interfaces.Context;
using ToDoList.Infrastructure.Context;

namespace ToDoList.Infrastructure.Extensions.Services;

public static class BuilderExtensions
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        
        builder.Services.AddDbContext<LazyLoadingContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("ToDoList.Infrastructure"))
                .UseSnakeCaseNamingConvention();
        });
        
        builder.Services.AddScoped<ILazyLoadingContext, LazyLoadingContext>();
    } 
}