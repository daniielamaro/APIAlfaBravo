using System;
using System.Collections.Generic;
using Application.BusinessRules;
using Application.ConfigAutofac;
using Application.Entity;
using Application.Repository;
using Autofac;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationsController : ControllerBase
    {
        private readonly IPublicationRepository publicationRepository;
        private readonly IUserRepository userRepository;
        private readonly ITopicRepository topicRepository;

        private readonly ConfigAutofacApplication ConfigInjection;

        /// <summary>
        /// Controller das publicações
        /// </summary>
        public PublicationsController()
        {
            ConfigInjection = new ConfigAutofacApplication();

            publicationRepository = ConfigInjection.Container.Resolve<IPublicationRepository>();
            userRepository = ConfigInjection.Container.Resolve<IUserRepository>();
            topicRepository = ConfigInjection.Container.Resolve<ITopicRepository>();
        }

        /// <summary>
        /// Listar todas as publicações
        /// </summary>
        /// <response code="200">Lista de publicações encontrada</response>
        /// <response code="400">Nenhuma lista de publicações encontrada</response>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Publication>> Get()
        {
            List<Publication> listPublication = publicationRepository.GetAll();

            if (listPublication.Count == 0)
                return NoContent();

            return Ok(publicationRepository.GetAll());
        }

        /// <summary>
        /// Criar publicação
        /// </summary>
        /// <param name="autorId">Identificador do autor</param>
        /// <param name="title">Título da publicação</param>
        /// <param name="content">Conteúdo da publicação</param>
        /// <param name="topicId">Categoria da qual a publicação pertence</param>
        /// <response code="200">Sucesso na criação da publicação</response>
        /// <response code="400">Erro na criação da publicação</response>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Publication> Post(Guid autorId, string title, string content, Guid topicId)
        {
            var resultValidator = new UserExistValidator().Validate(autorId);
            if (!resultValidator.IsValid)
                return BadRequest(resultValidator.Errors);

            User autor = userRepository.GetById(autorId);

            resultValidator = new TopicExistValidator().Validate(topicId);
            if (!resultValidator.IsValid)
                return BadRequest(resultValidator.Errors);

            Topic topic = topicRepository.GetById(topicId);

            Publication publication = new Publication(autor, title, content, topic);

            resultValidator = new PublicationValidator().Validate(publication);
            if (!resultValidator.IsValid)
                return BadRequest(resultValidator.Errors);

            publicationRepository.Create(publication);

            return CreatedAtAction("Get", new { id = publication.Id }, publication);
        }

        /// <summary>
        /// Buscar uma publicação pelo seu Id
        /// </summary>
        /// <param id="ID">ID da publicação</param>
        /// <response code="200">Sucesso na busca da publicação</response>
        /// <response code="400">Erro ao buscar publicação</response>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetPubId")]
        public ActionResult<Publication> Get(Guid id)
        {
            var resultValidation = new PublicationExistValidator().Validate(id);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return Ok(publicationRepository.GetById(id));
        }

        /// <summary>
        /// Alterar publicação
        /// </summary>
        /// <param name="id">Identificador da publicação</param>
        /// <param name="title">Título da publicação</param>
        /// <param name="content">Conteúdo da publicação</param>
        /// <param name="topicId">Categoria da qual a publicação pertence ou será alterada</param>
        /// <response code="200">Sucesso na alteração da publicação</response>
        /// <response code="400">Erro ao tentar alterar a publicação</response>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<Publication> Put(Guid id, string title, string content, Guid topicId)
        {
            var resultValidation = new PublicationExistValidator().Validate(id);
            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            resultValidation = new TopicExistValidator().Validate(topicId);
            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            Topic topic = topicRepository.GetById(topicId);
            Publication oldPublication = publicationRepository.GetById(id);
            Publication newPublication = new Publication(id, oldPublication.Autor, title, content, oldPublication.DateCreated, oldPublication.Comments, topic);

            resultValidation = new PublicationValidator().Validate(newPublication);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return Ok(publicationRepository.Update(newPublication));
        }

        /// <summary>
        /// Deletar publicação
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Sucesso ao excluir publicação</response>
        /// <response code="400">Erro ao tentar deletar a publicação</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<Publication> Delete(Guid id)
        {
            var resultValidation = new PublicationExistValidator().Validate(id);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            Publication publication = publicationRepository.GetById(id);

            return Ok(publicationRepository.Delete(publication));
        }
    }
}