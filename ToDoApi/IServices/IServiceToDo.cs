using ToDoApi.Models;

namespace ToDoApi.IServices
{
    public interface IServiceToDo
    {
        public List<ToDoDTO> GetToDo();
        public void AddToDo(ToDoDTO toDo);
        public void UpdateToDo(ToDoDTO toDo);
        public bool RemoveToDo(int id);

    }
}
