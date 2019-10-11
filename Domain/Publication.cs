using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public sealed class Publication
    {
        public readonly Guid Id;
        public readonly User Autor;
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public readonly DateTime DateCreated;
        public List<Comment> Comments { get; protected set; }

        public Publication(User autor, string title, string content)
        {
            Id = Guid.NewGuid();
            Autor = autor;
            Title = title;
            Content = content;
            DateCreated = DateTime.Now;
            Comments = new List<Comment>();
        }
    }
}
