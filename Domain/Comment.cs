using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public  class Comment
   {
        public Guid Id { get; protected set; }
        public User Autor { get; protected set; }
        public string Content { get; protected set; }
   }
}
