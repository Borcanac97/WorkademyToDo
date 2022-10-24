using ToDoApi.Models;

namespace ToDoApi.IServices
{
    public interface IServiceComment
    {
        public List<CommentDTO> GetComment();
        public void AddComment(CommentDTO comment);
        public void UpdateComment(CommentDTO comment);
        public bool RemoveComment(int id);
    }
}
