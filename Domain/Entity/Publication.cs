using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Publication
    {
        public Guid Id { get; protected set; }
        public User Autor { get; protected set; }
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public DateTime DateCreated { get; protected set; }
        public List<Comment> Comments { get; protected set; }
        public Topic Topic { get; protected set; }
    }
}
