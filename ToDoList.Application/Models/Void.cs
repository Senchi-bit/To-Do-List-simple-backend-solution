namespace ToDoList.Application.Models;

public class Void
{
    private Void()
    {
    }
    public static Void Value()
    {
        return new Void();
    }
}