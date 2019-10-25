using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class RegisterPublication : IRegisterDB<Publication>
    {
        private readonly ApiContext Context;

        public RegisterPublication()
        {
            Context = new ApiContext();
        }

        public void CreateNew(Publication publication)
        {
            Context.Users.Attach(publication.Autor);
            Context.Topics.Attach(publication.Topic);
            Context.Publications.Add(publication);
            Context.SaveChanges();
        }
    }
}
