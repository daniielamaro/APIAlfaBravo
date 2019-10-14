using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Um Usuario Pode ter nenhum ou muitos publicação
        /// </summary>
        public virtual ICollection<Publication> Publications { get; set; }

        /// <summary>
        /// Um Usuario Pode ter nenhum ou muitos comentários
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
