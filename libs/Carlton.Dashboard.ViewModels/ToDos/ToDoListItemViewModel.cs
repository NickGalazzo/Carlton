namespace Carlton.Dashboard.ViewModels.ToDos
{
    public class ToDoListItemViewModel
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public bool IsCompleted { get; internal set; }


        public ToDoListItemViewModel(int id, string name, bool isCompleted)
        {
            Id = id;
            Name = name;
            IsCompleted = isCompleted;
        }
    }
}
