using System;
using System.Collections.Generic;
using Domain;
using Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Application.Entity;
using Application.BusinessRules;
using Application.ConfigAutofac;
using Autofac;

namespace WebApi.Controllers
{
    /// <summary>
    /// Classe Controller do Comentário
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly ICommentRepository commentRepository;
        private readonly IUserRepository userRepository;

        private readonly ConfigAutofacApplication ConfigInjection;

        /// <summary>
        /// Controller dos comentários
        /// </summary>
        public CommentsController()
        {
            ConfigInjection = new ConfigAutofacApplication();

            commentRepository = ConfigInjection.Container.Resolve<ICommentRepository>();
            userRepository = ConfigInjection.Container.Resolve<IUserRepository>();
        }

        /// <summary>
        /// Listar todos os comentários
        /// </summary>
        /// <response code="200">Lista de comentários encontrada</response>
        /// <response code="400">Nenhuma lista de comentários encontrada</response>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Comment>> Get()
        {
            List<Comment> listComment = commentRepository.GetAll();

            if (listComment.Count == 0)
                return NoContent();

            return Ok(commentRepository.GetAll());
        }

        /// <summary>
        /// Buscar comentário
        /// </summary>
        /// <param name="id">Identificador do comentário</param>
        /// <response code="200">Sucesso na busca por um comentário específico</response>
        /// <response code="400">Erro ao buscar comentário</response>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetComment")]
        public ActionResult<Comment> Get(Guid id)
        {
            var resultValidation = new CommentExistValidator().Validate(id);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return Ok(commentRepository.GetById(id));
        }

        /// <summary>
        /// Criar comentário
        /// </summary>
        /// <param name="autorId">Identificador do autor</param>
        /// <param name="content">Conteúdo do comentário</param>
        /// <param name="publicationId">Identificador da publicação ao qual o comentário pertence</param>
        /// <response code="200">Comentário criado com sucesso</response>
        /// <response code="400">Erro na criação do comentário</response>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Comment> Post(Guid autorId, string content, Guid publicationId)
        {
            var resultValidation = new UserExistValidator().Validate(autorId);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            var autor = userRepository.GetById(autorId);

            resultValidation = new PublicationExistValidator().Validate(publicationId);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            Comment comment = new Comment(autor, content, publicationId);

            resultValidation = new CommentValidator().Validate(comment);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            commentRepository.Create(comment);

            return CreatedAtAction("Get", new { id = comment.Id }, comment);
        }

        /// <summary>
        /// Alterar comentário
        /// </summary>
        /// <param name="id">Indentificador do comentário</param>
        /// <param name="content">Conteúdo do comentário</param>
        /// <response code="200">Alteração feita com sucesso</response>
        /// <response code="400">Erro na alteração do comentário</response>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<Comment> Put(Guid id, string content)
        {
            var resultValidation = new CommentExistValidator().Validate(id);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            Comment oldComment = commentRepository.GetById(id);
            Comment newComment = new Comment(id, oldComment.Autor, content, oldComment.PublicationId);

            resultValidation = new CommentValidator().Validate(newComment);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return Ok(commentRepository.Update(newComment));
        }

        /// <summary>
        /// Deletar comentário
        /// </summary>
        /// <param name="id">Identificador do comentário</param>
        /// <response code="200">Sucesso ao excluir comentário</response>
        /// <response code="400">Erro ao deletar comentário</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<Comment> Delete(Guid id)
        {
            var resultValidation = new CommentExistValidator().Validate(id);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            Comment comment = commentRepository.GetById(id);

            return Ok(commentRepository.Delete(comment));
        }
    }
}