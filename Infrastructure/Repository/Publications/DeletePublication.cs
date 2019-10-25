using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Publications
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
            Context.Remove(publication);
            Context.SaveChanges();
        }
    }
}
