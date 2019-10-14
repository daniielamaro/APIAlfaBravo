using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
<<<<<<< HEAD
<<<<<<< HEAD
    public sealed class Publication
=======
    public class Publication
>>>>>>> 1663df37d85607dc3e4d6364c3e9bfdc812f8514
    {
        public Guid Id { get; protected set; }
        public User Autor { get; protected set; }
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public DateTime DateCreated { get; protected set; }
        public List<Comment> Comments { get; protected set; }
<<<<<<< HEAD

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
=======
>>>>>>> 1663df37d85607dc3e4d6364c3e9bfdc812f8514
    }
}
