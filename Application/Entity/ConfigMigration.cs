using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity
{
    public sealed class ConfigMigration
    {
        public static void Apply()
        {
            using (var context = new ApiContext())
            {
                context.Database.Migrate();
            };
        }
        
    }
}
