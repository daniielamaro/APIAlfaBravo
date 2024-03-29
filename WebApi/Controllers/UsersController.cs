﻿using System;
using System.Collections.Generic;
using Application.BusinessRules;
using Application.ConfigAutofac;
using Application.Entity;
using Application.Repository;
using Autofac;
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
        private readonly ConfigAutofacApplication ConfigInjection;

        /// <summary>
        /// Controller do usuário
        /// </summary>
        public UsersController()
        {
            ConfigInjection = new ConfigAutofacApplication();

            userRepository = ConfigInjection.Container.Resolve<IUserRepository>();
        }

        /// <summary>
        /// Buscar todos os usuários
        /// </summary>
        /// <response code="200">Sucesso ao buscar usuários</response>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            List<User> listUsers = userRepository.GetAll();

            if (listUsers.Count == 0)
                return NoContent();

            return Ok(listUsers);
        }

        /// <summary>
        /// Buscar usuário
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <response code="200">Sucesso ao buscar usuário</response>
        /// <response code="400">Erro ao buscar usuário</response>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> Get(Guid id)
        {
            var resultValidation = new UserExistValidator().Validate(id);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return Ok(userRepository.GetById(id));
        }

        /// <summary>
        /// Criar usuário
        /// </summary>
        /// <param name="name">Nome do usuário</param>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="password">Senha do usuário</param>
        /// <response code="200">Usuário criado com sucesso</response>
        /// <response code="400">Erro ao criar usuário</response>
        /// <returns></returns>
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

        /// <summary>
        /// Atualizar dados do usuário
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <param name="name">Nome do usuário</param>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="password">Senha do usuário</param>
        /// <response code="200">Alteração realizada com sucesso</response>
        /// <response code="400">Erro ao atualizar usuário</response>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<User> Put(Guid id, string name, string email, string password)
        {
            var resultValidation = new UserExistValidator().Validate(id);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            User user = new User(id, name, email, password);
            resultValidation = new UserValidator().Validate(user);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return Ok(userRepository.Update(user));
        }

        /// <summary>
        /// Deletar usuário
        /// </summary>
        /// <param name="id">Idenfiticador do usuário</param>
        /// <response code="200">Sucesso ao deletar usuário</response>
        /// <response code="400">Erro ao deletar usuário</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(Guid id)
        {
            var resultValidation = new UserExistValidator().Validate(id);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            User user = userRepository.GetById(id);

            return Ok(userRepository.Delete(user));
        }
    }
}