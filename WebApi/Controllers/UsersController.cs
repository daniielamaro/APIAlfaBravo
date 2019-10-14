using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases;
using Domain;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Retorna todos os usuários
        /// </summary>
        /// <returns>Retorna todos os usuarios</returns>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return GetUser.All();
        }

        /// <summary>
        /// Retorna um usuário especifico
        /// </summary>
        /// <param name="id">O ID do usuário que deseja retornar</param>
        /// <remarks>Retorna um usuário usando um ID como parametro</remarks>
        [HttpGet("{id}", Name = "Get")]
        public User Get(Guid id)
        {
            return GetUser.ById(id);
        }

        /// <summary>
        /// Regista um novo usuário
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthdate"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        [HttpPost]
        public ActionResult<User> Post(string name, string birthdate, string email, string password)
        {
            return Ok(RegisterUser.Execute(name, birthdate, email, password));
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
