using ToDoApi.Models;

namespace ToDoApi.IServices
{
    public interface IServiceUser
    {
        public List<UserDTO> GetUser();
        public void AddUser(UserDTO user);
        public void UpdateUser(UserDTO user);
        public bool RemoveUser(int id);
    }
}
