namespace ToDoList.Application.Interfaces.CQRS;

public interface IQuerySender
{
    public Task<TResult> Send<TSource, TResult>(TSource query, CancellationToken cancellationToken) where TSource : IQuery<TResult>;
}