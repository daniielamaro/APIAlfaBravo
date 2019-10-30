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
    public class TopicController : ControllerBase
    {

        private readonly ITopicRepository topicRepository;

        /// <summary>
        /// Criação de uma nova categoria
        /// </summary>
        public TopicController()
        {
            topicRepository = new TopicRepository();
        }

        /// <summary>
        /// Listar todas as categorias
        /// </summary>
        /// <response code="200">Lista de tópicos encontrada</response>
        /// <returns></returns>
        [HttpGet]
        public List<Topic> Get()
        {
            return topicRepository.GetAll();
        }

        /// <summary>
        /// Buscar categoria
        /// </summary>
        /// <param name="id">Identificador da categoria</param>
        /// <response code="200">Sucesso na busca da categoria</response>
        /// <response code="400">Erro ao tentar buscar a categoria</response>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTopic")]
        public ActionResult<Topic> Get(Guid id)
        {
            var resultValidation = new TopicExistValidator().Validate(id);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return topicRepository.GetById(id);
        }

        /// <summary>
        /// Criar categoria
        /// </summary>
        /// <param name="name">Nome da categoria</param>
        /// <response code="200">Sucesso ao criar cateogria</response>
        /// <response code="400">Erro ao tentar criar categoria</response>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Topic> Post(string name)
        {
            Topic topic = new Topic(name);

            var resultValidation = new TopicValidator().Validate(topic);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            topicRepository.Create(topic);

            return CreatedAtAction("Get", new { id = topic.Id }, topic);
        }

        /// <summary>
        /// Alterar categoria
        /// </summary>
        /// <param name="id">Identificador </param>
        /// <param name="name">Nome </param>
        /// <response code="200">Sucesso ao buscar categoria</response>
        /// <response code="400">Erro ao tentar buscar a categoria</response>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<Topic> Put(Guid id, string name)
        {
            var resultValidation = new TopicExistValidator().Validate(id);
            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            Topic topic = new Topic(id, name);
            resultValidation = new TopicValidator().Validate(topic);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return Ok(topicRepository.Update(topic));
        }

        /// <summary>
        /// Deletar categoria
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Sucesso ao deletar categoria</response>
        /// <response code="400">Erro ao tentar deletar a categoria</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<Topic> Delete(Guid id)
        {
            var resultValidation = new TopicExistValidator().Validate(id);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            Topic topic = topicRepository.GetById(id);

            return topicRepository.Delete(topic);
        }
    }
}