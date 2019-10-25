using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.CommentDB
{
    public class DeleteComment : IDeleteDB<Comment>
    {
        private readonly ApiContext Context;

        public DeleteComment()
        {
            Context = new ApiContext();
        }

        public void DeleteRegister(Comment comment)
        {
            Context.Remove(comment);
            Context.SaveChanges();
        }
    }
}
