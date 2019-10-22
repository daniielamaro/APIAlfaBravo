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

            var resultValidator = new PublicationValidator().Validate(publication);

            if (!resultValidator.IsValid)
                return BadRequest(resultValidator.Errors);

            return publicationRepository.Create(publication);
        }

        [HttpGet("{name}", Name = "GetPubName")]
        public List<Publication> Get(string name)
        {
            return publicationRepository.GetByName(name);
        }

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