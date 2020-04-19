using System;

namespace Carlton.Dashboard.ViewModels.ToDos
{
    public class ToDoListItemViewModel
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public bool IsCompleted { get; internal set; }
        public DateTime ExpirationDate { get; internal set; }

        public ToDoListItemViewModel(int id, string name, bool isCompleted)
            : this(id, name, isCompleted, DateTime.Today.AddDays(7))
        {
        }

        public ToDoListItemViewModel(int id, string name, bool isCompleted, DateTime expirationDate)
        {
            Id = id;
            Name = name;
            IsCompleted = isCompleted;
            ExpirationDate = expirationDate;
        }
    }
}
