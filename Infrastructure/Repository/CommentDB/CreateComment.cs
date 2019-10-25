using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.CommentDB
{
    public class CreateComment : ICreateDB<Comment>
    {
        private readonly ApiContext Context;

        public CreateComment()
        {
            Context = new ApiContext();
        }

        public void CreateNewRegister(Comment comment)
        {
            Context.Users.Attach(comment.Autor);
            Context.Comments.Add(comment);
            Context.SaveChanges();
        }
    }
}
