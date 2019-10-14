using Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases
{
    public class RemoveUser
    {
        public static User Execute(Guid id)
        {
            var db = new ApiContext();

            User userToRemove = db.Users.Find(id);

            db.Users.Remove(userToRemove);
            db.SaveChanges();

            return userToRemove;
        }
    }
}
