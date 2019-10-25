<<<<<<< HEAD
﻿using Infrastructure.Repository;
=======
﻿using Infrastructure.Context;
using Infrastructure.Repository;
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entity
{
    public sealed class ConfigMigration
    {
<<<<<<< HEAD
        // Somente para banco relacional em produção
        /*
=======
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
        public static void Apply()
        {
            using (var context = new ApiContext())
            {
                context.Database.Migrate();
            };
        }
<<<<<<< HEAD
        */
=======
        
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
    }
}
