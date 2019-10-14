using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
