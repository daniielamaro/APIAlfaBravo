using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.BusinessRules;
using Application.UseCases;
using Domain;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return GetUser.All();
        }

        [HttpGet("{id}", Name = "Get")]
        public User Get(Guid id)
        {
            return GetUser.ById(id);
        }

        [HttpPost]
        public ActionResult<User> Post(string name, string birthdate, string email, string password)
        {
            User user = RegisterUser.Execute(name, birthdate, email, password);
            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] User user)
        {
            if (UserNotFound.Execute(id))
            {
                return NotFound();
            }

            if (!ValidId.Execute(id))
            {
                return BadRequest();
            }

            AlterUser.Execute(id, user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public User Delete(Guid id)
        {
            return RemoveUser.Execute(id);
        }
    }
}
