using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessRules
{
    public class UserNotFound
    {
        public static bool Execute(Guid id)
        {
            return (new ApiContext().Users.Find(id) == null);
        }
    }
}
