using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Repository;
using Domain;
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

        public CommentRepository()
        {
            Register = new CreateComment();
            Remove = new DeleteComment();
            Get = new GetComment();
            Alter = new UpdateComment();
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
