using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Publications
{
    public class UpdatePublication : IUpdateDB<Publication>
    {
        private readonly ApiContext Context;

        public UpdatePublication()
        {
            Context = new ApiContext();
        }
        public void UpdateRegister(Publication publication)
        {
            Context.Update(publication);
            Context.SaveChanges();
        }
    }
}
