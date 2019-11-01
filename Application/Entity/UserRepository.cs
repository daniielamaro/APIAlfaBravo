using Application.Repository;
using Autofac;
using Domain;
using Infrastructure.ConfigAutofac;
using Infrastructure.Context;
using Infrastructure.Repository;
using Infrastructure.Repository.UserDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Entity
{
    public class UserRepository : IUserRepository
    {
        public ICreateDB<User> Register;
        public IDeleteDB<User> Remove;
        public IGetDB<User> Get;
        public IUpdateDB<User> Alter;

        private readonly ConfigAutofacInfrastructure ConfigInjection;

        public UserRepository()
        {
            ConfigInjection = new ConfigAutofacInfrastructure();

            Register = ConfigInjection.Container.Resolve<ICreateDB<User>>();
            Remove = ConfigInjection.Container.Resolve<IDeleteDB<User>>();
            Get = ConfigInjection.Container.Resolve<IGetDB<User>>();
            Alter = ConfigInjection.Container.Resolve<IUpdateDB<User>>();
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

            return user;
        }

        public List<User> GetAll()
        {
            return Get.GetAllRegister();
        }

        public User GetById(Guid id)
        {
            return Get.GetRegisterById(id);
        }

        public User Update(User user)
        {
            Alter.UpdateRegister(user);

            return user;
        }
    }
}
