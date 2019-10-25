using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.UserDB
{
    public class UpdateUser : IUpdateDB<User>
    {
        private readonly ApiContext Context;

        public UpdateUser()
        {
            Context = new ApiContext();
        }

        public void UpdateRegister(User user)
        {
            Context.Update(user);
            Context.SaveChanges();
        }
    }
}
