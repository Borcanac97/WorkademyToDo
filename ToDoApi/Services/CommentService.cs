using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ToDoApi.IServices;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public class CommentService : IServiceComment
    {

        public CommentDTO getCommentById(int id)
        {

            string fromJson = File.ReadAllText(@"Json/Comment.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);

            CommentDTO? commentDTO = root.comments.Find(c => c.Id == id);
            return commentDTO;
        }


        public void AddComment(CommentDTO comment)
        {
            string fromJson = File.ReadAllText(@"Json/Comment.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);
            if (root != null && root.comments != null)
            {
                root.comments.Add(comment);
            }
            string resultJson = JsonConvert.SerializeObject(root);
            File.WriteAllText(@"Json/Comment.json", resultJson);
        }

        public List<CommentDTO> GetComment()
        {
            string commentJson = File.ReadAllText(@"Json/Comment.json");
            List<CommentDTO> commentList = JObject.Parse(commentJson)["comments"].ToObject<List<CommentDTO>>();
            return commentList;
        }

        public bool RemoveComment(int id)
        {
            bool result = false;
            string fromJson = File.ReadAllText(@"Json/Comment.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);
            if (root != null && root.comments != null)
            {
                result = root.comments.RemoveAll(x => x.Id == id) > 0 ? true : false;
            }
            string resultJson = JsonConvert.SerializeObject(root);
            File.WriteAllText(@"Json/Comment.json", resultJson);
            return result;
        }

        public void UpdateComment(CommentDTO comment)
        {
            string fromJson = File.ReadAllText(@"Json/Comment.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);
            if (root != null && root.comments != null)
            {
                CommentDTO commentDTO = root.comments.Find(c => c.Id == comment.Id);
                if (commentDTO != null)
                {
                    commentDTO.CommentDescription = comment.CommentDescription;
                }
            }
            string resultJson = JsonConvert.SerializeObject(root);
            File.WriteAllText(@"Json/Comment.json", resultJson);
        }
    }
}
