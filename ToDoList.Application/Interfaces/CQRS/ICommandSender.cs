namespace ToDoList.Application.Interfaces.CQRS;

public interface ICommandSender
{
    public Task<TResult> Send<TSource, TResult>(TSource command, CancellationToken cancellationToken) where TSource : ICommand<TResult>;
}