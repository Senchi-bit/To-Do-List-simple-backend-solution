using ToDoList.Application.Extensions;
using ToDoList.Infrastructure.Extensions.Services;

namespace ToDoList.API.Extensions.Services;

public static class BuilderExtensions
{
    public static void AddCommonServices(this IHostApplicationBuilder builder)
    {
        builder.AddInfrastructureServices();
        builder.AddApplicationServices();
    }
}