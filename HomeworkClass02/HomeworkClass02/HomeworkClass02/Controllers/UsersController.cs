using HomeworkClass02;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkClass02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetAll()
        {
            return Ok(StaticDb.Users);
        }
        
        [HttpGet("{id}")]
        public ActionResult<string> GetUserById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Id can't be negative.");
                }
                if( id > StaticDb.Users.Count)
                {
                    return NotFound($"User with id {id} can not be found.");
                }
                return Ok(StaticDb.Users[id]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }
    }
}
