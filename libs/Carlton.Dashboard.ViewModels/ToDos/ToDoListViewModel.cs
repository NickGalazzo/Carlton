using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.ToDos
{
    public class ToDoListViewModel
    {
        public List<ToDoListItemViewModel> ToDoList { get; internal set; }

        public ToDoListViewModel()
        {
            ToDoList = new List<ToDoListItemViewModel>();
        }

        public ToDoListViewModel(List<ToDoListItemViewModel> toDos)
        {
            ToDoList = toDos;
        }
    }
}
