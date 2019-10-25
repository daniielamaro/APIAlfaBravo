using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Repository;
using Domain;
using Infrastructure.Context;
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

        public Comment Delete(Comment comment)
        {
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