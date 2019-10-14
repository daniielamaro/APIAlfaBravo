using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Domain.Repository;
using Infrastructure.Repository;

namespace Application.UseCases
{
    public class GetUser : IBaseRepository<User>
    {
        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ListAll()
        {
            return new ApiContext().Set<User>().ToList();
        }

        public User SelectId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
