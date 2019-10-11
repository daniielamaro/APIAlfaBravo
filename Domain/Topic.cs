using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public sealed class Topic
    {
        public readonly Guid Id;
        public string Name { get; protected set; }
        public List<Publication> RelatedPublications { get; protected set;}
    }
}
