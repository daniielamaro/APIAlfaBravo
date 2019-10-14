using Domain;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class AlterUser
    {
        public static void Execute(Guid id, User user)
        {
            var db = new ApiContext();

            db.Entry(user).State = EntityState.Modified;

            db.SaveChanges();
        }

    }
}
