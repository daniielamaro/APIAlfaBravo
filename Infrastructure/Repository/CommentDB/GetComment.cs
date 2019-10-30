using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository.CommentDB
{
    public class GetComment : IGetDB<Comment>
    {
        private readonly ApiContext Context;

        public GetComment()
        {
            Context = new ApiContext();
        }

        public List<Comment> GetAllRegister()
        {
            return Context.Comments
                .Include(x => x.Autor)
                .ToList();
        }

        public Comment GetRegisterById(Guid id)
        {
            return Context.Comments
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Autor)
                .FirstOrDefault();
        }
    }
}
