using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Repository;
using Domain;
using Domain.Repository;
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

        public Comment Delete(Guid id)
        {
            Comment comment = ApiContext.Comments.Find(id);
            ApiContext.Remove(comment);
            ApiContext.SaveChanges();

            return comment;
        }

        public IEnumerable<Comment> GetAll()
        {
            return ApiContext.Comments
                .Include(x => x.Autor)
                .ToList();
        }

        public Comment GetById(Guid id)
        {
            return ApiContext.Comments
                .Where(x => x.Id == id)
                .Include(x => x.Autor)
                .FirstOrDefault();
        }

        public Comment Update(Guid id, Comment comment)
        {
            ApiContext.Entry(comment).State = EntityState.Modified;
            ApiContext.SaveChanges();

            return comment;
        }
    }
}
