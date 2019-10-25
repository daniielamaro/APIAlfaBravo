using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository.Topics
{
    public class DeleteTopic : IDeleteDB<Topic>
    {
        private readonly ApiContext Context;

        public DeleteTopic()
        {
            Context = new ApiContext();
        }

        public void DeleteRegister(Topic topic)
        {
            List<Publication> RelatedPublications = Context.Publications.Where(x => x.Topic.Id == topic.Id).ToList();
            foreach (Publication publication in RelatedPublications)
            {
                Context.Publications.Remove(publication);
            }

            Context.Remove(topic);
            Context.SaveChanges();
        }
    }
}
