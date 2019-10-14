using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
<<<<<<< HEAD
    public sealed class Comment
    {
        public readonly Guid Id;
        public readonly User Autor;
        public string Content { get; set; }

        public Comment(User autor, string content)
        {
            Id = Guid.NewGuid();
            Autor = autor;
            Content = content;
        }
    }
=======
   public  class Comment
   {
        public Guid Id { get; protected set; }
        public User Autor { get; protected set; }
        public string Content { get; protected set; }
   }
>>>>>>> ce1d59a9cf740e900a1d9df67b9f5993da6f1a7b
}
