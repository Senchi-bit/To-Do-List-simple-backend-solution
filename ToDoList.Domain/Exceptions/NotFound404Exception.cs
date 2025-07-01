namespace ToDoList.Domain.Exceptions;

public class NotFound404Exception : BaseException
{
    public NotFound404Exception(string? message, int statusCode = 404) : base(message, statusCode)
    {
        StatusCode = statusCode;
    }

    public int StatusCode {get; set; }
}