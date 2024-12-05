using Microsoft.AspNetCore.Mvc;
using Z_ParkLib;
using Z_ParkLib.repositories;

namespace Z_ParkRest.Controllers

{
    [Route("api/[controller]")]
    [ApiController]   
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _repo;

        public UsersController(UserRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            List<User> users = _repo.GetAll();
            if (users.Count == 0)
            {
                return NoContent();
            }

            return Ok(users);
        }

        // GET api/<UsersController>/ABC1234
        [HttpGet("{licenseplate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string licensePlate)
        {
            try
            {
                User user = _repo.GetById(licensePlate);
                return Ok(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                User newUser = _repo.Add(user);
                return Created($"api/Users/{newUser.Licenseplate}", newUser);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }

        // PUT api/<UsersController>/ABC1234
        [HttpPut("{licenseplate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(string licensePlate, [FromBody] User updatedUser)
        {
            try
            {
                try
                {
                    User user = _repo.Update(licensePlate, updatedUser);
                    return Ok(user);
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }

        // DELETE api/<UsersController>/ABC1234
        [HttpDelete("{licenseplate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(string licensePlate)
        {
            try
            {
                User deleted = _repo.Delete(licensePlate);
                return Ok(new { success = deleted });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
