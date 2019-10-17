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
    public class CommentsController : ControllerBase
    {

        private readonly ICommentRepository commentRepository;
        private readonly IUserRepository userRepository;

        public CommentsController()
        {
            commentRepository = new CommentRepository(new ApiContext());
            userRepository = new UserRepository(new ApiContext());
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
            Comment comment = new Comment()
            {
                Id = Guid.NewGuid(),
                Autor = userRepository.GetById(autorId),
                Content = content,
                PublicationId = publicationId
            };
            
            commentRepository.Create(comment);

            return comment;
        }

        [HttpPut("{id}")]
        public Comment Put(Guid id, [FromBody] Comment comment)
        {
            return commentRepository.Update(id, comment);
        }

        [HttpDelete("{id}")]
        public Comment Delete(Guid id)
        {
            return commentRepository.Delete(id);
        }
    }
}
