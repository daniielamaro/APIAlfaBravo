using Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class RegisterUser
    {
        public static User Execute(User user)
        {
            using (var db = new ApiContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return user;
        }
    }
}
