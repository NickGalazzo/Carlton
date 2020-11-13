namespace Carlton.Dashboard.ViewModels.ToDos
{
    public class ToDo
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsCompleted { get; private set; }


        public ToDo(int id, string name, bool isCompleted)
        {
            Id = id;
            Name = name;
            IsCompleted = isCompleted;
        }
    }
}
