using Application.Repository;
using Domain;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Entity
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApiContext ApiContext;
        private IUserRepository @object;

        //protected readonly IUserRepository userRepository;

        public UserRepository() //IUserRepository uuserRepository
        {
            ApiContext = new ApiContext();
            //userRepository = uuserRepository;
        }

        public UserRepository(IUserRepository @object)
        {
            this.@object = @object;
        }

        public User Create(User user)
        {
            ApiContext.Users.Add(user);
            ApiContext.SaveChanges();

            return user;
        }

        public User Delete(Guid id)
        {
            User user = GetById(id);

            List<Comment> RelatedComments = ApiContext.Comments.Where(x => x.Autor.Id == user.Id).ToList();
            foreach (Comment comment in RelatedComments)
            {
                ApiContext.Comments.Remove(comment);
            }

            List<Publication> RelatedPublications = ApiContext.Publications.Where(x => x.Autor.Id == user.Id).ToList();
            foreach(Publication publication in RelatedPublications)
            {
                ApiContext.Publications.Remove(publication);
            }

            ApiContext.Remove(user);
            ApiContext.SaveChanges();

            return user;
        }

        public List<User> GetAll()
        {
            return ApiContext.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return ApiContext.Users.Find(id);
        }

        public User Update(User user)
        {
            ApiContext.Entry(user).State = EntityState.Modified;
            ApiContext.SaveChanges();

            return user;
        }
    }
}
