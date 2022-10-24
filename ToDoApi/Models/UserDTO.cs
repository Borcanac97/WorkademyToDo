namespace ToDoApi.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string?   Name { get; set; }
        public List<int>? ToDoList { get; set; }
    }
}
