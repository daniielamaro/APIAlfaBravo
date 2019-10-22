using System;
using System.Collections.Generic;
using Domain;
using Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Application.Entity;
using Application.BusinessRules;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly ICommentRepository commentRepository;
        private readonly IUserRepository userRepository;

        public CommentsController()
        {
            commentRepository = new CommentRepository();
            userRepository = new UserRepository();
        }

        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return commentRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetComment")]
        public Comment Get(Guid id)
        {
            return commentRepository.GetById(id);
        }

        [HttpPost]
        public ActionResult<Comment> Post(Guid autorId, string content, Guid publicationId)
        {
            var autor = userRepository.GetById(autorId);

            Comment comment = new Comment(autor, content, publicationId);

            var resultValidation = new CommentValidator().Validate(comment);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);
            
            commentRepository.Create(comment);

            return comment;
        }

        [HttpPut("{id}")]
        public ActionResult<Comment> Put(Guid id, string content)
        {
            Comment oldComment = commentRepository.GetById(id);
            Comment newComment = new Comment(id, oldComment.Autor, content, oldComment.PublicationId);

            var resultValidation = new CommentValidator().Validate(newComment);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return commentRepository.Update(newComment);
        }

        [HttpDelete("{id}")]
        public Comment Delete(Guid id)
        {
            return commentRepository.Delete(id);
        }
    }
}
