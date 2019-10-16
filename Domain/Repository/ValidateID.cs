using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public class ValidateID
    {
        public static bool Execute(Guid id)
        {
            return (id != Guid.Empty && id != null);
        }
    }
}
