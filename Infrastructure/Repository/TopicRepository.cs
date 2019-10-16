using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class TopicRepository : ITopicRepository
    {
        /// <summary>
        /// Aqui entra os metodos para acesso ao DB com linq a serem chamados pelas interfaces Domain.Repository
        /// </summary>
        /// 

        protected readonly ApiContext ApiContext;
        public TopicRepository(ApiContext apiContext)
        {
            ApiContext = apiContext;
        }

        Topic IDeleteRegister<Topic>.Delete(Guid id)
        {
            Topic topic = ApiContext.Topics.Find(id);
            ApiContext.Remove(topic);
            ApiContext.SaveChanges();

            return topic;
        }
    }
}
