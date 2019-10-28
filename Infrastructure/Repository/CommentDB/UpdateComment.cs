using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.CommentDB
{
    public class UpdateComment : IUpdateDB<Comment>
    {
        private readonly ApiContext Context;

        public UpdateComment()
        {
            Context = new ApiContext();
        }

        public void UpdateRegister(Comment comment)
        {
            Context.Update(comment);
            Context.SaveChanges();
        }
    }
}
