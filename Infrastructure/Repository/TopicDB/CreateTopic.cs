using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.TopicDB
{
    public class CreateTopic : ICreateDB<Topic>
    {
        private readonly ApiContext Context;

        public CreateTopic()
        {
            Context = new ApiContext();
        }

        public void CreateNewRegister(Topic topic)
        {
            Context.Topics.Add(topic);
            Context.SaveChanges();
        }
    }
}
