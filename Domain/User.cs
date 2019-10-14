using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
<<<<<<< HEAD
<<<<<<< HEAD
    public sealed class User
=======
    public class User
>>>>>>> 1663df37d85607dc3e4d6364c3e9bfdc812f8514
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Birthdate { get; protected set; }
        public string Email { get; protected set; }
<<<<<<< HEAD
        public string Password { get; protected set; }

        public User(string name, DateTime birthdate, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Birthdate = birthdate;
            Email = email;
            Password = password;
        }
=======
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
>>>>>>> ce1d59a9cf740e900a1d9df67b9f5993da6f1a7b
=======
        public string Senha { get; protected set; }
>>>>>>> 1663df37d85607dc3e4d6364c3e9bfdc812f8514
    }
}
