using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string name, string email, string password) {

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
        }

        public User(Guid id, string name, string email, string password)
        {

            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public User()
        {

        }
    }
}
