using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public class ValidateID
    {
        public static bool Execute(Guid id)
        {
            return (id != Guid.Empty && id != null);
        }
    }
}
