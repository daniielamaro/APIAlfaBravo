using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Comment
   {
        public Guid Id { get; set; }
        public User Autor { get; set; }
        public string Content { get; set; }
   }
}
