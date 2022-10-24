using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ToDoApi.IServices;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public class CategoryService : IServiceCategory
    {
        public void AddCategory(CategoryDTO category)
        {
            string fromJson = File.ReadAllText(@"Json/Category.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);
            if (root != null && root.categories != null)
            {
                root.categories.Add(category);
            }
            string resultJson = JsonConvert.SerializeObject(root);
            File.WriteAllText(@"Json/Category.json", resultJson);
        }

        public List<CategoryDTO> GetCategory()
        {
            string categoryJson = File.ReadAllText(@"Json/Category.json");
            List<CategoryDTO> categoryList = JObject.Parse(categoryJson)["categories"].ToObject<List<CategoryDTO>>();
            return categoryList;

        }

        public CategoryDTO  getCategoryById(int id)
        {

            string fromJson = File.ReadAllText(@"Json/Category.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);

            CategoryDTO? categoryDTO = root.categories.Find(c => c.Id == id);
            return categoryDTO;
        }


        public bool RemoveCategory(int id)
        {
            bool result = false;
            string fromJson = File.ReadAllText(@"Json/Category.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);
            if (root != null && root.categories != null)
            {
                result = root.categories.RemoveAll(x => x.Id == id) > 0 ? true : false;
            }
            string resultJson = JsonConvert.SerializeObject(root);
            File.WriteAllText(@"Json/Category.json", resultJson);
            return result;
        }

        public void UpdateCategory(CategoryDTO category)
        {
            string fromJson = File.ReadAllText(@"Json/Category.json");
            RootDTO root = JsonConvert.DeserializeObject<RootDTO>(fromJson);
            if (root != null && root.categories != null)
            {
                CategoryDTO categoryDTO=root.categories.Find(c=> c.Id == category.Id);
                if (categoryDTO != null)
                {
                    categoryDTO.CategoryType=category.CategoryType;
                    categoryDTO.CategoryOverview=category.CategoryOverview;
                }
            }
            string resultJson = JsonConvert.SerializeObject(root);
            File.WriteAllText(@"Json/Category.json", resultJson);
        }
    }
}
