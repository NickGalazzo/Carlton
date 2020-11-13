using Carlton.Dashboard.ViewModels.ToDos;
using System.Collections.Generic;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class ToDoListTestViewModels
    {
        public static ToDos DefaultToDoList()
        {
            var toDoList = new List<ToDo>
                   {
                        new ToDo(1, "Take Out Garbage", false),
                        new ToDo(2, "Go Shopping", false),
                        new ToDo(3, "Prepare Dinner", true)
                   };

            return new ToDos(toDoList);
        }

        public static ToDo ToDoListItemChecked()
        {
            return new ToDo(1, "Take Out Garbage", true);
        }

        public static ToDo ToDoListItemUnchecked()
        {
            return new ToDo(1, "Take Out Garbage", false);
        }
    }
}
