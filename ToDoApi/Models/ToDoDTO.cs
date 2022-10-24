using Newtonsoft.Json;

namespace ToDoApi.Models
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime ScheludedFor { get; set; }

        public List<int>? CommentsList { get; set; }
        public int Category { get; set; }

    }
}
