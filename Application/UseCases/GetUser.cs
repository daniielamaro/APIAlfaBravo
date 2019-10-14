using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Infrastructure.Repository;

namespace Application.UseCases
{
    public class GetUser
    {
        public static List<User> All()
        {
            return new ApiContext().Users.ToList();
        }

        public static User ById(Guid Id)
        {
            var db = new ApiContext();

            return db.Users.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
