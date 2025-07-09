namespace ToDoList.Application.Interfaces.CQRS;

public interface ICommand<TResult>
{
    
}

public interface ICommandHandler<in TSource, TResult> where TSource : ICommand<TResult>
{
    public Task<TResult> Handle(TSource source, CancellationToken cancellationToken);
}