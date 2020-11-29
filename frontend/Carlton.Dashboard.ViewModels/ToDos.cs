using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels
{
    public record ToDos(IEnumerable<ToDo> ToDoList);
    public record ToDo(int Id, string Name, bool IsCompleted);
    public record ToDoStatusChangedEvent(int ToDoID, bool ToDoCompleted);
}