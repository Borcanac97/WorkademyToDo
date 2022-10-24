using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoApi.IServices;
using ToDoApi.Models;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        ToDoService toDoService =new ToDoService();

        [HttpGet]
        [ResponseCache(Duration = 30)]
        [Route("getToDo")]
        public async Task<IActionResult> getAllToDos()
        {
            return Ok(toDoService.GetToDo());
        }


        [HttpPost]
        [Route("addToDo")]
        public async Task<ActionResult<ToDoDTO>> addToDo([FromBody] ToDoDTO request)
        {
            toDoService.AddToDo(request);
            return Ok();
        }

        [HttpPut]
        [Route("updateToDo")]
        public async Task<ActionResult<ToDoDTO>> updateToDo(ToDoDTO request)
        {
            toDoService.UpdateToDo(request);

            return Ok();

        }

        [HttpDelete]
        [Route("deleteToDo")]
        public async Task<ActionResult<ToDoDTO>> deleteToDo(int id)
        {
            toDoService.RemoveToDo(id);
            return Ok();
        }
    }
}
