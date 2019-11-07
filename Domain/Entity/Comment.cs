using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class Comment
   {
        public Guid Id { get; private set; }
        public User Autor { get; private set; }
        public string Content { get; private set; }

        [ForeignKey("PublicationId")]
        public Guid PublicationId { get; set; }

        public Comment(User autor, string content, Guid publicationId)
        {
            Id = Guid.NewGuid();
            Autor = autor;
            Content = content;
            PublicationId = publicationId;
        }
        
        public Comment(Guid id, User autor, string content, Guid publicationId)
        {
            Id = id;
            Autor = autor;
            Content = content;
            PublicationId = publicationId;
        }

        public Comment() { }
   }
}
