using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository.PublicationDB
{
    public class DeletePublication : IDeleteDB<Publication>
    {
        private readonly ApiContext Context;

        public DeletePublication()
        {
            Context = new ApiContext();
        }

        public void DeleteRegister(Publication publication)
        {
            List<Comment> RelatedComment = Context.Comments.Where(x => x.PublicationId == publication.Id).ToList();
            foreach (Comment comment in RelatedComment)
            {
                Context.Comments.Remove(comment);
            }

            Context.Remove(publication);
            Context.SaveChanges();
        }
    }
}
