using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Data;

namespace PersonalFinance.UI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
        {
            return Ok(UserData.userList);
        }

        [HttpGet("{id:int}", Name ="GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDTO> GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = UserData.userList.FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserDTO> CreateUser([FromBody]UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (UserData.userList.FirstOrDefault(x => x.Email== user.Email) != null) 
            {
                ModelState.AddModelError("CustomError", "This email is already exist");
                return BadRequest(ModelState);
            }

            if (user == null)
            {
                return BadRequest(user);
            }
            if (user.UserId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            user.UserId = UserData.userList.OrderByDescending(x => x.UserId).FirstOrDefault().UserId + 1;
            UserData.userList.Add(user);
            return CreatedAtRoute("GetUser", new { id = user.UserId }, user);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = UserData.userList.FirstOrDefault(x => x.UserId== id);
            if (user == null)
            {
                return NotFound();
            }
            UserData.userList.Remove(user);
            return NoContent();
        }
    }
}
