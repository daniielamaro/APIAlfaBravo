using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Topic
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Topic(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
