using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
<<<<<<< HEAD
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
=======
    public class Publication
    {
        public Guid Id { get; protected set; }
        public User Autor { get; protected set; }
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public DateTime DateCreated { get; protected set; }
        public List<Comment> Comments { get; protected set; }
        public Topic Topic { get; protected set; }
>>>>>>> ce1d59a9cf740e900a1d9df67b9f5993da6f1a7b
    }
}
