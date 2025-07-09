using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Interfaces.CQRS;

namespace ToDoList.Application.CQRS;

public class CommandSender(IServiceProvider serviceProvider) : ICommandSender
{
    public Task<TResult> Send<TSource, TResult>(TSource command, CancellationToken cancellationToken) where TSource : ICommand<TResult>
    {
        var handler = serviceProvider.GetRequiredService<ICommandHandler<TSource, TResult>>();
        
        var result = handler.Handle(command, cancellationToken);
        return result;
    }
}