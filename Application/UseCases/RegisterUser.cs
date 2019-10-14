using Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases
{
    public class RegisterUser
    {

        public static User Execute(string name, DateTime birthdate, string email, string password)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Birthdate = birthdate,
                Email = email,
                Password = password
            };

            using (var db = new ApiContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user;
            }
        }
        
    }
}
