using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository.UserDB
{
    public class GetUser : IGetDB<User>
    {
        private readonly ApiContext Context;

        public GetUser()
        {
            Context = new ApiContext();
        }

        public List<User> GetAllRegister()
        {
            return Context.Users.ToList();
        }

        public User GetRegisterById(Guid id)
        {
            return Context.Users.Find(id);
        }
    }
}
