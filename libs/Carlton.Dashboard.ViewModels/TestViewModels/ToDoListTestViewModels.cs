using Carlton.Dashboard.ViewModels.ToDos;
using System.Collections.Generic;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class ToDoListTestViewModels
    {
        public static ToDoListViewModel DefaultToDoList()
        {
            var toDoList = new List<ToDoListItemViewModel>
                   {
                        new ToDoListItemViewModel(1, "Take Out Garbage", false),
                        new ToDoListItemViewModel(2, "Go Shopping", false),
                        new ToDoListItemViewModel(3, "Prepare Dinner", true)
                   };

            return new ToDoListViewModel(toDoList);
        }

        public static ToDoListItemViewModel ToDoListItemChecked()
        {
            return new ToDoListItemViewModel(1, "Take Out Garbage", true);
        }

        public static ToDoListItemViewModel ToDoListItemUnchecked()
        {
            return new ToDoListItemViewModel(1, "Take Out Garbage", false);
        }
    }
}
