using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Publications
{
    public class CreatePublication : ICreateDB<Publication>
    {
        private readonly ApiContext Context;

        public CreatePublication()
        {
            Context = new ApiContext();
        }

        public void CreateNewRegister(Publication publication)
        {
            Context.Users.Attach(publication.Autor);
            Context.Topics.Attach(publication.Topic);
            Context.Publications.Add(publication);
            Context.SaveChanges();
        }
    }
}
