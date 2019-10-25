using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Users
{
    public class CreateUser : ICreateDB<User>
    {
        private readonly ApiContext Context;

        public CreateUser()
        {
            Context = new ApiContext();
        }

        public void CreateNewRegister(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
