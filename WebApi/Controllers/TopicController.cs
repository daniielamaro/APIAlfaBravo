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

        public TopicController()
        {
            topicRepository = new TopicRepository();
        }

        [HttpGet]
        public IEnumerable<Topic> Get()
        {
            return topicRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTopic")]
        public ActionResult<Topic> Get(Guid id)
        {
            var resultValidation = new TopicExistValidator().Validate(id);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return topicRepository.GetById(id);
        }

        [HttpPost]
        public ActionResult<Topic> Post(string name)
        {
            Topic topic = new Topic(name);

            var resultValidation = new TopicValidator().Validate(topic);

            if(!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);
            
            topicRepository.Create(topic);

            return CreatedAtAction("Get", new { id = topic.Id }, topic);
        }

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

        [HttpDelete("{id}")]
        public ActionResult<Topic> Delete(Guid id)
        {
            var resultValidation = new TopicExistValidator().Validate(id);

            if (!resultValidation.IsValid)
                return BadRequest(resultValidation.Errors);

            return topicRepository.Delete(id);
        }
    }
}
