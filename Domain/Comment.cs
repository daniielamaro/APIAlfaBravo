using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public sealed class Comment
    {
        public readonly Guid Id;
        public readonly User User;
        public string Content { get; set; }
    }
}
