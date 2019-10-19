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
        public Topic Get(Guid id)
        {
            return topicRepository.GetById(id);
        }

        [HttpPost]
        public ActionResult<Topic> Post(string name)
        {
            Topic topic = new Topic(name);
            
            topicRepository.Create(topic);

            return CreatedAtAction("Get", new { id = topic.Id }, topic);
        }

        [HttpPut("{id}")]
        public Topic Put(Guid id, [FromBody] Topic topic)
        {
            return topicRepository.Update(id, topic);
        }

        [HttpDelete("{id}")]
        public Topic Delete(Guid id)
        {
            return topicRepository.Delete(id);
        }
    }
}
