using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases;
using Domain;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Domain.Repository;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepository userRepository;

        public UsersController()
        {
            userRepository = new UserRepository(new ApiContext());
        }       
        /// <summary>
        /// Retorna todos os usuários
        /// </summary>
        /// <returns>Retorna todos os usuarios</returns>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userRepository.ListAll();
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

        //birthdate.ToString("dd MMMM yyyy")

        /// <summary>
        /// Regista um novo usuário
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthdate"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        [HttpPost]
        public ActionResult<User> Post(string name, DateTime birthdate, string email, string password)
        {
            User user = RegisterUser.Execute(name, birthdate, email, password);
            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] User user)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public User Delete(Guid id)
        {
            return RemoveUser.Execute(id);
        }
    }
}
