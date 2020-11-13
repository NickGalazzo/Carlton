using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.ToDos
{
    public class ToDos
    {
        public IEnumerable<ToDo> ToDoList { get; private set; }

        public ToDos(IEnumerable<ToDo> toDoList)
        {
            ToDoList = toDoList;
        }     
    }
}