using Newtonsoft.Json;

namespace ToDoApi.Models
{
    public class ToDoWrapper
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ScheludedFor { get; set; }

        public List<CommentDTO> CommentsList { get; set; }

        public CategoryDTO Category { get; set; }

    }
}
