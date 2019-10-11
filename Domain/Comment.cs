using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
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
}
