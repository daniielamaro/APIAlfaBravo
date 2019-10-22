using System;
using System.Collections.Generic;
using Application.BusinessRules;
using Application.Entity;
using Application.Repository;
using Domain;
using FluentValidation;
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
            userRepository = new UserRepository();
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public User Get(Guid id)
        {
            return userRepository.GetById(id);
        }

        [HttpPost]
        public ActionResult<User> Post(string name, string email, string password)
        {
            User user = new User(name, email, password);

            var resultValidation = new UserValidator().Validate(user);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            userRepository.Create(user);

            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(Guid id, string name, string email, string password)
        {
            User user = new User(id, name, email, password);

            var resultValidation = new UserValidator().Validate(user);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return Ok(userRepository.Update(user));
        }

        [HttpDelete("{id}")]
        public User Delete(Guid id)
        {
            return userRepository.Delete(id);
        }
    }
}
