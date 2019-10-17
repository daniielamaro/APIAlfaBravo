using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class Comment
   {
        public Guid Id { get; set; }
        public User Autor { get; set; }
        public string Content { get; set; }

        [ForeignKey("PublicationId")]
        public Guid PublicationId { get; set; }
   }
}
