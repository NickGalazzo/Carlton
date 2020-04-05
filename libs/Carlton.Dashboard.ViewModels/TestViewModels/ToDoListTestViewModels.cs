using Carlton.Dashboard.ViewModels.ToDos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client.TestViewModels
{
    public static class ToDoListTestViewModels
    {
        public static ToDoListViewModel DefaultToDoList()
        {
            return new ToDoListViewModel
            {
                ToDoList = new List<ToDoListItemViewModel>
                   {
                        new ToDoListItemViewModel(1, "Take Out Garbage", false),
                        new ToDoListItemViewModel(2, "Go Shopping", false),
                        new ToDoListItemViewModel(3, "Prepare Dinner", true)
                   }
            };
        }
    }
}
