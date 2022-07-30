using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return userService.Get();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var user = userService.GetById(id);

            if ( user == null )
            {
                return NotFound($"User with Id = {id} was not found");
            }

            return user;

        }

        // GET api/<UsersController>/shad
        //[HttpGet("{name}")]
        //public ActionResult<List<User>> GetByName(string name)
        //{
        //    var users = userService.GetByName(name).ToList();

        //    if (users == null)
        //    {
        //        return NotFound($"User with Name = {name} was not found");
        //    }

        //    return users;

        //}

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            userService.CreateUser(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User user)
        {
            var existingUser = userService.GetById(id);

            if (existingUser == null)
            {
                return NotFound($"User with Id = {id} was not found");
            }

            userService.UpdateUser(id, user);
            return NoContent();

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingUser = userService.GetById(id);

            if (existingUser == null)
            {
                return NotFound($"User with Id = {id} was not found");
            }

            userService.RemoveUser(existingUser.Id);

            return Ok($"User with Id = {id} has been removed");

        }
    }
}
