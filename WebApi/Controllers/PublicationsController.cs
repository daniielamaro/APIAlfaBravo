using System;
using System.Collections.Generic;
using Application.BusinessRules;
using Application.Entity;
using Application.Repository;
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

        /// <summary>
        /// Controller das publicações
        /// </summary>
        public PublicationsController()
        {
            publicationRepository = new PublicationRepository();
            userRepository = new UserRepository();
            topicRepository = new TopicRepository();
        }

        /// <summary>
        /// Listar todas as publicações
        /// </summary>
        /// <response code="200">Lista de publicações encontrada</response>
        /// <response code="400">Nenhuma lista de publicações encontrada</response>
        /// <returns></returns>
        [HttpGet]
        public List<Publication> Get()
        {
            return publicationRepository.GetAll();
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
            var autor = userRepository.GetById(autorId);
            var topic = topicRepository.GetById(topicId);

            Publication publication = new Publication(autor, title, content, topic);

            var resultValidator = new PublicationValidator().Validate(publication);

            if (!resultValidator.IsValid)
                return BadRequest(resultValidator.Errors);

            return publicationRepository.Create(publication);
        }

        /// <summary>
        /// Buscar publicações
        /// </summary>
        /// <param name="name">Nome do autor</param>
        /// <response code="200">Sucesso na busca da publicação</response>
        /// <response code="400">Erro ao buscar publicação</response>
        /// <returns></returns>
        [HttpGet("{name}", Name = "GetPubName")]
        public ActionResult<List<Publication>> Get(string name)
        {
            var resultValidation = new NameNotNullValidator().Validate(name);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return publicationRepository.GetByName(name);
        }

        /// <summary>
        /// Alterar publicação
        /// </summary>
        /// <param name="id">Identificador do autor</param>
        /// <param name="title">Título da publicação</param>
        /// <param name="content">Conteúdo da publicação</param>
        /// <param name="topicId">Categoria da qual a publicação pertence</param>
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

            return publicationRepository.Update(newPublication);
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

            return publicationRepository.Delete(id);
        }
    }
}