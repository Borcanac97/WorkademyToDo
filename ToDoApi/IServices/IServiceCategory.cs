using ToDoApi.Models;

namespace ToDoApi.IServices
{
    public interface IServiceCategory
    {
        public List<CategoryDTO> GetCategory();
        public void AddCategory(CategoryDTO category);
        public void UpdateCategory(CategoryDTO category);
        public bool RemoveCategory(int id);
    }
}
