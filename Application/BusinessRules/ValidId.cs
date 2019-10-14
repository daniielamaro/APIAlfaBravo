using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessRules
{
    public class ValidId
    {
        public static bool Execute(Guid id)
        {
            return (id != null && id != Guid.Empty);
        }
    }
}
