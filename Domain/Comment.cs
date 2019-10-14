using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
<<<<<<< HEAD
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
=======
>>>>>>> 1663df37d85607dc3e4d6364c3e9bfdc812f8514
   public  class Comment
   {
        public Guid Id { get; protected set; }
        public User Autor { get; protected set; }
        public string Content { get; protected set; }
   }
<<<<<<< HEAD
>>>>>>> ce1d59a9cf740e900a1d9df67b9f5993da6f1a7b
=======
>>>>>>> 1663df37d85607dc3e4d6364c3e9bfdc812f8514
}
