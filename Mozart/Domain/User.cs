using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : IEquatable<User>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Equals(User other)
        {
            return (Id == other.Id);
        }
    }
}
