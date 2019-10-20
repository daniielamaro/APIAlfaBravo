using System;
using System.Collections.Generic;
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

        public PublicationsController()
        {
            publicationRepository = new PublicationRepository();
            userRepository = new UserRepository();
            topicRepository = new TopicRepository();
        }

        [HttpGet]
        public IEnumerable<Publication> Get()
        {
            return publicationRepository.GetAll();
        }

        [HttpPost]
        public ActionResult<Publication> Post(Guid autorId, string title, string content, Guid topicId)
        {
            var autor = userRepository.GetById(autorId);
            var topic = topicRepository.GetById(topicId);

            Publication publication = new Publication(autor, title, content, topic);

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
            return publicationRepository.Update(publication);
        }

        [HttpDelete("{id}")]
        public Publication Delete(Guid id)
        {
            return publicationRepository.Delete(id);
        }
    }
}