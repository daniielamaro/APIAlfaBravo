﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public sealed class User
    {
        public readonly Guid Id;
        public string Name { get; protected set; }
        public DateTime Birthdate { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        public User(string name, DateTime birthdate, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Birthdate = birthdate;
            Email = email;
            Password = password;
        }
    }
}
