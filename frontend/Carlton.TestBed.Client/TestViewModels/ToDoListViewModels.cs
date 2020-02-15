using Carlton.Dashboard.ViewModels.ToDos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class ToDoListViewModels
    {
        public static ToDoListViewModel DefaultToDoList()
        {
            return new ToDoListViewModel
            {
                ToDoList = new List<ToDo>
                   {
                        new ToDo(1, "Take Out Garbage", false),
                        new ToDo(2, "Go Shopping", false),
                        new ToDo(3, "Prepare Dinner", true)
                   }
            };
        }
    }
}
