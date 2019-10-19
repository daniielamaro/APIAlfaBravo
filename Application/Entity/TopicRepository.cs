using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Repository;
using Domain;
using Domain.Repository;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Application.Entity
{
    public class TopicRepository : ITopicRepository
    {
        protected readonly ApiContext ApiContext;

        public TopicRepository()
        {
            ApiContext = new ApiContext();
        }

        public Topic Create(Topic topic)
        {
            ApiContext.Topics.Add(topic);
            ApiContext.SaveChanges();

            return topic;
        }

        public Topic Delete(Guid id)
        {
            Topic topic = ApiContext.Topics.Find(id);
            ApiContext.Remove(topic);
            ApiContext.SaveChanges();

            return topic;
        }

        public IEnumerable<Topic> GetAll()
        {
            return ApiContext.Topics.ToList();
        }

        public Topic GetById(Guid id)
        {
            return ApiContext.Topics.Find(id);
        }

        public Topic Update(Guid id, Topic topic)
        {
            ApiContext.Entry(topic).State = EntityState.Modified;
            ApiContext.SaveChanges();

            return topic;
        }
    }
}
