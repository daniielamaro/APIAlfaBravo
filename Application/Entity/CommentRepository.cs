using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Repository;
using Autofac;
using Domain;
using Infrastructure.ConfigAutofac;
using Infrastructure.Context;
using Infrastructure.Repository;
using Infrastructure.Repository.CommentDB;
using Microsoft.EntityFrameworkCore;

namespace Application.Entity
{
    public class CommentRepository : ICommentRepository
    {
        public ICreateDB<Comment> Register;
        public IDeleteDB<Comment> Remove;
        public IGetDB<Comment> Get;
        public IUpdateDB<Comment> Alter;

        private readonly ConfigAutofacInfrastructure ConfigInjection;

        public CommentRepository()
        {
            ConfigInjection = new ConfigAutofacInfrastructure();

            Register = ConfigInjection.Container.Resolve<ICreateDB<Comment>>();
            Remove = ConfigInjection.Container.Resolve<IDeleteDB<Comment>>();
            Get = ConfigInjection.Container.Resolve<IGetDB<Comment>>();
            Alter = ConfigInjection.Container.Resolve<IUpdateDB<Comment>>();
        }

        public CommentRepository(ICreateDB<Comment> register)
        {
            Register = register;
        }

        public CommentRepository(IDeleteDB<Comment> remove)
        {
            Remove = remove;
        }

        public CommentRepository(IGetDB<Comment> get)
        {
            Get = get;
        }

        public CommentRepository(IUpdateDB<Comment> alter)
        {
            Alter = alter;
        }

        public Comment Create(Comment comment)
        {
            Register.CreateNewRegister(comment);

            return comment;
        }

        public Comment Delete(Comment comment)
        {
            Remove.DeleteRegister(comment);

            return comment;
        }

        public List<Comment> GetAll()
        {
            return Get.GetAllRegister();
        }

        public Comment GetById(Guid id)
        {
            return Get.GetRegisterById(id);
        }

        public Comment Update(Comment comment)
        {
            Alter.UpdateRegister(comment);

            return comment;
        }
    }
}
