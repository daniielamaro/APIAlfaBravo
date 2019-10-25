using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository.Publications
{
    public class GetPublication : IGetDB<Publication>
    {
        private readonly ApiContext Context;

        public GetPublication()
        {
            Context = new ApiContext();
        }

        public List<Publication> GetAllRegister()
        {
            List<Publication> publications = Context.Publications
                .Include(x => x.Autor)
                .Include(x => x.Comments)
                .Include(x => x.Topic)
                .ToList();

            return publications;
        }

        public Publication GetRegisterById(Guid id)
        {
            return Context.Publications.Find(id);
        }
    }
}
