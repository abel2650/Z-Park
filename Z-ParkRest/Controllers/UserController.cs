using Microsoft.AspNetCore.Mvc;
using Z_ParkLib;
using Z_ParkLib.Model;
using Z_ParkLib.repositories;
using Z_ParkRest.Model;

namespace Z_ParkRest.Controllers

{
    [Route("api/[controller]")]
    [ApiController]   
    public class UsersControllerDb : ControllerBase
    {
        private readonly UserRepositoryDB _repo;

        public UsersControllerDb(UserRepositoryDB repo)
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
        [HttpGet("{licensePlate}")]
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

        //NY POST METODE til handle url, fp og hente data databse login og true eller false  return true eller false bolean
        public IActionResult Post([FromBody] UserDTO userdto)
        {
            try
            {
                User newUser = UserConverter.DTO2User(userdto);
                
                newUser = _repo.Add(newUser);
                //return Created($"api/Users/{newUser.Licenseplate}", newUser);
                return Ok(newUser);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        } 

        // PUT api/<UsersController>/ABC1234
        [HttpPut("{licensePlate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(string licensePlate, [FromBody] UserDTO dto)
        {
            try
            {
                User updatedUser = UserConverter.DTO2User(dto);
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
        [HttpDelete("{licensePlate}")]
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

// POST api/<UsersController>/login
        [HttpPost("login")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public IActionResult Login([FromBody] UserDTO userdto)
{
    try
    {
        // Hent brugeren baseret på nummerpladen
        User user = _repo.GetById(userdto.licenseplate);

        // Valider adgangskoden
        if (user != null && user.Password == userdto.password)
        {
            // Returner brugerdetaljer som JSON
            return Ok(new
            {
                username = user.Username,
                name = user.Name,
                surname = user.Surname,
                mail = user.Mail,
                licenseplate = user.Licenseplate
            });
        }

        // Returner Unauthorized, hvis adgangskoden er forkert
        return Unauthorized("Forkert brugernavn eller kodeord");
    }
    catch (KeyNotFoundException)
    {
        // Hvis nummerpladen ikke findes
        return NotFound("Ingen bruger tilknyttet den nummerplade");
    }
    catch (ArgumentException ae)
    {
        // Hvis nummerplade ikke er angivet
        return BadRequest("Du skal skrive en nummerplade");
    }
}

    }
}
