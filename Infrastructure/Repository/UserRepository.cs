using Domain;
using Domain.Repository;
using System;
using System.Linq;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {

        /// <summary>
        /// Aqui entra os metodos para acesso ao DB com linq a serem chamados pelas interfaces Domain.Repository
        /// </summary>
        /// 
        protected readonly ApiContext ApiContext;
        public UserRepository(ApiContext apiContext)
        {
            ApiContext = apiContext;
        }

        public User Delete(Guid id)
        {
            User user = ApiContext.Users.Find(id);
            ApiContext.Remove(user);
            ApiContext.SaveChanges();

            return user;
        }
    }
}
