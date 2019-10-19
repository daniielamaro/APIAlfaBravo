using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Publication
    {
        public Guid Id { get; private set; }
        public User Autor { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; private set; }
        public List<Comment> Comments { get; private set; }
        public Topic Topic { get; private set; }

        public Publication(User autor, string title, string content, Topic topic)
        {
            Id = Guid.NewGuid();
            Autor = autor;
            Title = title;
            Content = content;
            DateCreated = DateTime.Now;
            Comments = new List<Comment>();
            Topic = topic;
        }

        public Publication() { }
    }
}
