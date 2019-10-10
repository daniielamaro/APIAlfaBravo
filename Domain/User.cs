using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public sealed class User
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime Birthdate { get; protected set; }
        public string Email { get; protected set; }
    }
}
