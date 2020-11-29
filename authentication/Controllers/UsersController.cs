using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using authentication.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static readonly List<User> Users = new List<User>
        {
            new User {Email = "anbo@zealand.dk", Password = "secret12"},
            new User {Email = "andersb@hotmail.com", Password = "secret34"}
        };

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{email}")]
        public User Get(string email)
        {
            return Users.FirstOrDefault(user => user.Email == email);
        }

        [HttpGet("{email}/{password}")]
        public User Get(string email, string password)
        {
            return Users.FirstOrDefault(user => user.Email == email && user.Password == password);
        }

        // POST api/<UsersController>
        [HttpPost]
        public bool Post([FromBody] User value)
        {
            User existingUser = Users.FirstOrDefault(user => user.Email == value.Email);
            if (existingUser != null) return false;
            Users.Add(value);
            return true;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{email}")]
        public bool Put(string email, [FromBody] User value)
        {
            User user = Get(email);
            if (user == null) return false;
            user.Email = value.Email;
            return true;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{email}")]
        public bool Delete(string email)
        {
            User user = Get(email);
            if (user == null) return false;
            return Users.Remove(user);
        }
    }
}
