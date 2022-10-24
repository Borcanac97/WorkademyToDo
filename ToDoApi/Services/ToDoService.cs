using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ToDoApi.IServices;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public class ToDoService : IServiceToDo
    {

        public void AddToDo(ToDoDTO toDo)
        {
            string fromJson = File.ReadAllText(@"Json/ToDo.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);
            if (root != null && root.toDo != null)
            {
                root.toDo.Add(toDo);
            }
            string resultJson = JsonConvert.SerializeObject(root);
            File.WriteAllText(@"Json/ToDo.json", resultJson);
        }
         
        CommentService commentService = new CommentService();
        CategoryService categoryService = new CategoryService();
        public List<ToDoWrapper> GetToDo()
        {
            string toDoJson = File.ReadAllText(@"Json/ToDo.json");
            List<ToDoDTO> toDoList = JObject.Parse(toDoJson)["toDo"].ToObject<List<ToDoDTO>>();
         
            List<ToDoWrapper> toDoWrappers = new List<ToDoWrapper>();
            foreach (ToDoDTO td in toDoList)
            {                
                ToDoWrapper todoWrapper = new ToDoWrapper();
                todoWrapper.Title = td.Title;
                todoWrapper.Id = td.Id;
                todoWrapper.ScheludedFor = td.ScheludedFor;

                List<CommentDTO> commentdtoList = new List<CommentDTO>();
                foreach (int commentId in td.CommentsList)
                {
                    CommentDTO comment = commentService.getCommentById(commentId);
                    commentdtoList.Add(comment);
                }

                todoWrapper.Category = categoryService.getCategoryById(td.Category);                
                todoWrapper.CommentsList = commentdtoList;
                toDoWrappers.Add(todoWrapper);
            }
            return toDoWrappers;

        }

        public ToDoDTO getToDoById(int id)
        {

            string fromJson = File.ReadAllText(@"Json/ToDo.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);

            ToDoDTO toDoDTO = root.toDo.Find(t => t.Id == id);
            return toDoDTO;
        }


        public bool RemoveToDo(int id)
        {
            bool result = false;
            string fromJson = File.ReadAllText(@"Json/ToDo.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);
            if (root != null && root.toDo != null)
            {
                result = root.toDo.RemoveAll(x => x.Id == id) > 0 ? true : false;
            }
            string resultJson = JsonConvert.SerializeObject(root);
            File.WriteAllText(@"Json/ToDo.json", resultJson);
            return result;
        }

        public void UpdateToDo(ToDoDTO toDo)
        {
            string fromJson = File.ReadAllText(@"Json/ToDo.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);
            if (root != null && root.toDo != null)
            {
                ToDoDTO? toDoDTO = root.toDo.Find(t => t.Id == toDo.Id);
                if (toDoDTO != null)
                {
                    toDoDTO.Title=toDo.Title != null? toDo.Title:toDoDTO.Title;
                    toDoDTO.Description = toDo.Description != null ? toDo.Description : toDoDTO.Description;
                    toDoDTO.ScheludedFor = toDo.ScheludedFor;
                    toDoDTO.Category = toDo.Category != null ? toDo.Category : toDoDTO.Category;
                    toDoDTO.CommentsList = toDo.CommentsList != null ? toDo.CommentsList : toDoDTO.CommentsList;
                }

            }
            string resultJson = JsonConvert.SerializeObject(root);
            File.WriteAllText(@"Json/ToDo.json", resultJson);

        }

        List<ToDoDTO> IServiceToDo.GetToDo()
        {
            throw new NotImplementedException();
        }
    }
}

