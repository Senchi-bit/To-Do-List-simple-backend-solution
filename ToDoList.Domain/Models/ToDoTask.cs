using ToDoList.Domain.Enumerations;

namespace ToDoList.Domain.Models;

public class ToDoTask
{
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public bool IsCompleted { get; set; }
    
    public int TaskStateId { get; set; }
    public ToDoTaskStates TaskState { get; set; }
}

public class ToDoTaskDto
{
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public ToDoTaskStates TaskState { get; set; }

}