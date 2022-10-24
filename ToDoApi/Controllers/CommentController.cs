using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        CommentService CommentService= new CommentService();


        [HttpGet]
        [ResponseCache(Duration = 30)]
        [Route("getComment")]
        public async Task<IActionResult> getComment()
        {
            return Ok(CommentService.GetComment());
        }

        [HttpPost]
        [Route("addComment")]
        public async Task<ActionResult<CommentDTO>> addComment([FromBody] CommentDTO request)
        {
            CommentService.AddComment(request);
            return Ok();
        }
        [HttpPut]
        [Route("putComment")]
        public async Task<ActionResult<CommentDTO>> updateComment(CommentDTO request)
        {
            CommentService.UpdateComment(request);
            return Ok();

        }
        [HttpDelete]
        [Route("deleteComment")]
        public async Task<ActionResult<CategoryDTO>> deleteComment(int id)
        {
            return Ok(CommentService.RemoveComment(id));
        }

    }
}
