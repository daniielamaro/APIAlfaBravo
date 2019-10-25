using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository.Users
{
    public class DeleteUser : IDeleteDB<User>
    {
        private readonly ApiContext Context;

        public DeleteUser()
        {
            Context = new ApiContext();
        }

        public void DeleteRegister(User user)
        {
            List<Comment> RelatedComments = Context.Comments.Where(x => x.Autor.Id == user.Id).ToList();
            foreach (Comment comment in RelatedComments)
            {
                Context.Comments.Remove(comment);
            }

            List<Publication> RelatedPublications = Context.Publications.Where(x => x.Autor.Id == user.Id).ToList();
            foreach (Publication publication in RelatedPublications)
            {
                Context.Publications.Remove(publication);
            }

            Context.Remove(user);
            Context.SaveChanges();
        }
    }
}
