using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository.TopicDB
{
    public class GetTopic : IGetDB<Topic>
    {
        private readonly ApiContext Context;

        public GetTopic()
        {
            Context = new ApiContext();
        }

        public List<Topic> GetAllRegister()
        {
            return Context.Topics.ToList();
        }

        public Topic GetRegisterById(Guid id)
        {
            return Context.Topics.Find(id);
        }
    }
}
