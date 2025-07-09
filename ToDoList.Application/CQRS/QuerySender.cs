using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Interfaces.CQRS;

namespace ToDoList.Application.CQRS;

public class QuerySender(IServiceProvider serviceProvider) : IQuerySender
{
    public Task<TResult> Send<TSource, TResult>(TSource query, CancellationToken cancellationToken) where TSource : IQuery<TResult>
    {
        var handler = serviceProvider.GetRequiredService<IQueryHandler<TSource, TResult>>();
        
        var result = handler.Handle(query, cancellationToken);
        return result;
    }
}