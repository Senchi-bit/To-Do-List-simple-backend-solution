namespace ToDoList.Application.Interfaces.CQRS;

public interface IQuery<TResult>
{
    
}

public interface IQueryHandler<in TSource, TResult> where TSource : IQuery<TResult>
{
    public Task<TResult> Handle(TSource source, CancellationToken cancellationToken);
}