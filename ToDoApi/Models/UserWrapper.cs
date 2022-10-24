namespace ToDoApi.Models
{
    public class UserWrapper
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public List<ToDoDTO>? ToDoList { get; set; }

    }
}
