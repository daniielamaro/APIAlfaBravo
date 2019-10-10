using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public sealed class Posts
    {
        public readonly Guid Id;
        public readonly User Autor;
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public readonly DateTime DateCreated;
    }
}
