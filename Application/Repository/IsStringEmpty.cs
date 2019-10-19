using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public class IsStringEmpty
    {
        public static bool Execute(string data)
        {
            return (data == string.Empty);
        }
    }
}
