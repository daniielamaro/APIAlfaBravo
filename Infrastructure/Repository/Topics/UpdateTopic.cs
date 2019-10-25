using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Topics
{
    public class UpdateTopic : IUpdateDB<Topic>
    {
        private readonly ApiContext Context;

        public UpdateTopic()
        {
            Context = new ApiContext();
        }

        public void UpdateRegister(Topic topic)
        {
            Context.Update(topic);
            Context.SaveChanges();
        }
    }
}
