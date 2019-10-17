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
    public class PublicationsController : ControllerBase
    {
        private readonly IPublicationRepository publicationRepository;
        private readonly IUserRepository userRepository;
        private readonly ITopicRepository topicRepository;

        public PublicationsController()
        {
            publicationRepository = new PublicationRepository(new ApiContext());
            userRepository = new UserRepository(new ApiContext());
            topicRepository = new TopicRepository(new ApiContext());
        }

        [HttpGet]
        public IEnumerable<Publication> Get()
        {
            return publicationRepository.GetAll();
        }

        [HttpPost]
        public ActionResult<Publication> Post(Guid autorId, string title, string content, Guid topicId)
        {
            var user = userRepository.GetById(autorId);
            var topic = topicRepository.GetById(topicId);

            Publication publication = new Publication()
            {
                Autor = user,
                Title = title,
                Content = content,
                Comments = new List<Comment>(),
                DateCreated = DateTime.Now,
                Topic = topic
            };

            return publicationRepository.Create(publication);
        }

        [HttpGet("{name}", Name = "GetPubName")]
        public List<Publication> Get(string name)
        {
            return publicationRepository.GetByName(name);
        }

        [HttpPut("{id}")]
        public Publication Put(Guid id, [FromBody] Publication publication)
        {
            return publicationRepository.Update(id, publication);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Publication Delete(Guid id)
        {
            return publicationRepository.Delete(id);
        }
    }
}