using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ToDoApi.Models
{
    public class RootDTO
    {        
        public List<ToDoDTO>? toDo { get; set; }
        public List<UserDTO>? users { get; set; }

        public List<CategoryDTO>? categories { get; set; }

        public List<CommentDTO>? comments { get; set; }


    }
}
