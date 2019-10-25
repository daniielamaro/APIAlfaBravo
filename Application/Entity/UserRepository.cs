using Application.Repository;
using Domain;
<<<<<<< HEAD
using Infrastructure.Repository;
=======
using Infrastructure.Context;
using Infrastructure.Repository;
using Infrastructure.Repository.Users;
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Entity
{
    public class UserRepository : IUserRepository
    {
<<<<<<< HEAD
<<<<<<< HEAD
        protected readonly ApiContext ApiContext;
        private IUserRepository @object;
=======
>>>>>>> parent of c175ea0... Testes

        protected readonly ApiContext ApiContext;

        public UserRepository()
        {
            ApiContext = new ApiContext();
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
=======
        public ICreateDB<User> Register;
        public IDeleteDB<User> Remove;
        public IGetDB<User> Get;
        public IUpdateDB<User> Alter;

        public UserRepository()
        {
            Register = new CreateUser();
            Remove = new DeleteUser();
            Get = new GetUser();
            Alter = new UpdateUser();
        }

        public UserRepository(ICreateDB<User> register)
        {
            Register = register;
        }

        public UserRepository(IDeleteDB<User> remove)
        {
            Remove = remove;
        }

        public UserRepository(IGetDB<User> get)
        {
            Get = get;
        }

        public UserRepository(IUpdateDB<User> alter)
        {
            Alter = alter;
        }

        public User Create(User user)
        {
            Register.CreateNewRegister(user);

            return user;
        }

        public User Delete(User user)
        {
            Remove.DeleteRegister(user);
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b

            return user;
        }

        public List<User> GetAll()
        {
<<<<<<< HEAD
            return ApiContext.Users.ToList();
=======
            return Get.GetAllRegister();
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
        }

        public User GetById(Guid id)
        {
<<<<<<< HEAD
            return ApiContext.Users.Find(id);
=======
            return Get.GetRegisterById(id);
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
        }

        public User Update(User user)
        {
<<<<<<< HEAD
            ApiContext.Entry(user).State = EntityState.Modified;
            ApiContext.SaveChanges();
=======
            Alter.UpdateRegister(user);
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b

            return user;
        }
    }
}
