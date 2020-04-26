using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.ToDos
{
    public class ToDoListViewModel
    {
        public IEnumerable<ToDoListItemViewModel> ToDoList { get; private set; }

        public ToDoListViewModel(IEnumerable<ToDoListItemViewModel> toDoList)
        {
            ToDoList = toDoList;
        }     
    }
}