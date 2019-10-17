using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Publication
    {
        public Guid Id { get; set; }
        public User Autor { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Comment> Comments { get; set; }
        public Topic Topic { get; set; }
    }
}
