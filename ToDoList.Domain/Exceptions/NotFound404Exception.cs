namespace ToDoList.Domain.Exceptions;

public class NotFound404Exception : Exception
{
    public NotFound404Exception(string? message, int statusCode = 404) : base(message)
    {
        StatusCode = statusCode;
    }
    public int StatusCode {get; private set; }
}