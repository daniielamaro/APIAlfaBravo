using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
<<<<<<< HEAD
    public sealed class Topic
    {
        public readonly Guid Id;
        public string Name { get; protected set; }
        public List<Publication> RelatedPublications { get; protected set;}

        public Topic(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            RelatedPublications = new List<Publication>();
        }
=======
    public class Topic
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public List<Publication> RelatedPublications { get; protected set; }
>>>>>>> ce1d59a9cf740e900a1d9df67b9f5993da6f1a7b
    }
}
