using System;
using System.Collections.Generic;
using Domain;
using Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Application.Entity;

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
        public Comment Post(Guid autorId, string content, Guid publicationId)
        {
            var autor = userRepository.GetById(autorId);

            Comment comment = new Comment(autor, content, publicationId);
            
            commentRepository.Create(comment);

            return comment;
        }

        [HttpPut("{id}")]
        public Comment Put(Guid id, [FromBody] Comment comment)
        {
            return commentRepository.Update(comment);
        }

        [HttpDelete("{id}")]
        public Comment Delete(Guid id)
        {
            return commentRepository.Delete(id);
        }
    }
}
