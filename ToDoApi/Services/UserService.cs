using System.Text.Json.Nodes;
using ToDoApi.IServices;
using ToDoApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Text.Unicode;


namespace ToDoApi.Services
{
    public class UserService: IServiceUser
    {
        public void AddUser(UserDTO user)
        {
            string fromJson = File.ReadAllText(@"Json/Users.json");
            RootDTO root =JsonConvert.DeserializeObject<RootDTO>(fromJson);           
            if (root!=null&& root.users != null)
            {
                root.users.Add(user);
            }
            string resultJson = JsonConvert.SerializeObject(root);
            File.WriteAllText(@"Json/Users.json", resultJson);
        }

        public List<UserDTO> GetUser()
        {
            string userJson = File.ReadAllText(@"Json/Users.json");
            List<UserDTO> users = JObject.Parse(userJson)["users"].ToObject<List<UserDTO>>();
            return users;


           /* List<UserWrapper> usersWrapper = new List<UserWrapper>();
            foreach (UserDTO userdto in users)
            {
               UserWrapper userWrapper = new UserWrapper();
                userWrapper.Name = userdto.Name;
                userWrapper.Id = userdto.Id;

                List<ToDoDTO> toDoDTOList = new List<ToDoDTO>();
                foreach(int todoId in userdto.ToDoList)
                {
                    ToDoDTO toDoDTO = ToDoService.getToDoById(todoId);
                    toDoDTOList.Add(toDoDTO);
                }
                
                usersWrapper.Add(userWrapper);

            }*/
           

        }
        public bool RemoveUser(int id)
        {
            bool result = false;
            string fromJson = File.ReadAllText(@"Json/Users.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);
            if (root != null && root.users != null)
            {
               result = root.users.RemoveAll(x => x.Id == id) > 0 ? true : false;
            }
            string resultJson = JsonConvert.SerializeObject(root);
            File.WriteAllText(@"Json/Users.json", resultJson);
            return result;
        }

        public void UpdateUser(UserDTO user)
        {
            string fromJson = File.ReadAllText(@"Json/Users.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);
            if (root != null && root.users != null)
            {
                UserDTO? userDTO = root.users.Find(u => u.Id == user.Id);
                if(userDTO != null)
                {
                    userDTO.Name = user.Name;
                    userDTO.ToDoList = user.ToDoList;
                }

            }
            string resultJson = JsonConvert.SerializeObject(root);
            File.WriteAllText(@"Json/Users.json", resultJson);

        }

        List<UserDTO> IServiceUser.GetUser()
        {
            throw new NotImplementedException();
        }
    }
}