using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Repository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


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
            return userRepository.SelectId(id);
        }

        /// <summary>
        /// Regista um novo usuário
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        [HttpPost]
        public ActionResult<User> Post(string name, string email, string password)
        {
            User user = new User()
            {
                Name = name,
                Email = email,
                Password = password
            };
            
            userRepository.Create(user);

            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public User Put(Guid id, [FromBody] User user)
        {
            return userRepository.Update(id, user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public User Delete(Guid id)
        {
            return userRepository.Delete(id);
        }
    }
}
