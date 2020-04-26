namespace Carlton.Dashboard.ViewModels.ToDos
{
    public class ToDoListItemViewModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsCompleted { get; private set; }


        public ToDoListItemViewModel(int id, string name, bool isCompleted)
        {
            Id = id;
            Name = name;
            IsCompleted = isCompleted;
        }
    }
}
