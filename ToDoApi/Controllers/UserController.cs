using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService userService = new UserService();

        [HttpGet]
        [ResponseCache(Duration = 30)]
        [Route("getUsers")]
        public async Task<IActionResult> getUsers()
        {

            return Ok(userService.GetUser());
        }


        [HttpPost]
        [Route("addUser")]
        public async Task<ActionResult<UserDTO>> addUser([FromBody] UserDTO request)
        {
            userService.AddUser(request);
            return Ok();
        }

        [HttpPut]
        [Route("putUser")]
        public async Task<ActionResult<UserDTO>> updateUser(UserDTO request)
        {
            userService.UpdateUser(request);
            return Ok();

        }

        [HttpDelete]
        [Route("deleteUser")]
        public async Task<ActionResult<UserDTO>> deleteUser(int id)
        {
            return Ok(userService.RemoveUser(id));
        }
    }
}
