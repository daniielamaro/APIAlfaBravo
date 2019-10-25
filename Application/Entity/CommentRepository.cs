using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Repository;
using Domain;
<<<<<<< HEAD
=======
using Infrastructure.Context;
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Application.Entity
{
    public class CommentRepository : ICommentRepository
    {
        protected readonly ApiContext ApiContext;

        public CommentRepository()
        {
            ApiContext = new ApiContext();
        }

        public Comment Create(Comment comment)
        {
            ApiContext.Users.Attach(comment.Autor);
            ApiContext.Comments.Add(comment);
            ApiContext.SaveChanges();

            return comment;
        }

<<<<<<< HEAD
        public Comment Delete(Guid id)
        {
            Comment comment = GetById(id);
=======
        public Comment Delete(Comment comment)
        {
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
            ApiContext.Remove(comment);
            ApiContext.SaveChanges();

            return comment;
        }

        public List<Comment> GetAll()
        {
            return ApiContext.Comments
                .Include(x => x.Autor)
                .ToList();
        }

        public Comment GetById(Guid id)
        {
            return ApiContext.Comments
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Autor)
                .FirstOrDefault();
        }

        public Comment Update(Comment comment)
        {
            ApiContext.Update(comment);
            ApiContext.SaveChanges();

            return comment;
        }
    }
}
