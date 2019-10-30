using Domain;
using System;

public class UserBuilder
    {
        public Guid Id;
        public string Name;
        public string Email;
        public string Password;

        public static UserBuilder New()
        {
            var random = new Random();

            return new UserBuilder()
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                Email = "email" + random.Next(1, 9999).ToString() + "@email.com.br",
                Password = "123456789"
            };
        }

        public UserBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public UserBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public UserBuilder WithPassword(string password)
        {
            Password = password;
            return this;
        }

        public User Build()
        {
            return new User(Id, Name, Email, Password);
        }
    }