using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Topic
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public List<Publication> RelatedPublications { get; protected set; }
    }
}
