using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.TestViewModels
{
    public static class ToDoListTestViewModels
    {
        public static ToDos DefaultToDoListViewModel()
        {
            var toDoList = new List<ToDo>
                   {
                        new ToDo(1, "Take Out Garbage", false),
                        new ToDo(2, "Go Shopping", false),
                        new ToDo(3, "Prepare Dinner", true)
                   };

            return new ToDos(toDoList);
        }

        public static ToDo ToDoListItemCheckedViewModel()
        {
            return new ToDo(1, "Take Out Garbage", true);
        }

        public static ToDo ToDoListItemUncheckedViewModel()
        {
            return new ToDo(1, "Take Out Garbage", false);
        }
    }
}
