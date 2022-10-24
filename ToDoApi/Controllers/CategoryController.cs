using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService categoryService = new CategoryService();
        
        [HttpGet]
        [ResponseCache(Duration = 30)]
        [Route("getCategory")]
        public async Task<IActionResult> getCategores()
        {   
            return Ok(categoryService.GetCategory());
        }

        [HttpPost]
        [Route("addCategory")]
        public async Task<ActionResult<CategoryDTO>> addCategory([FromBody] CategoryDTO request)
        {
            categoryService.AddCategory(request);
            return Ok();
        }
        [HttpPut]
        [Route("putCategory")]
        public async Task<ActionResult<CategoryDTO>> updateCategory(CategoryDTO request)
        {
            categoryService.UpdateCategory(request);
            return Ok();

        }
        [HttpDelete]
        [Route("deleteCategory")]
        public async Task<ActionResult<CategoryDTO>> deleteCategory(int id)
        {
            return Ok(categoryService.RemoveCategory(id));
        }
    }
}
