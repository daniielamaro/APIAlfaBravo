using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessRules
{
    public sealed class ValidateUser
    {
        public bool Validate(User user)
        {
            return (
                ValidateID.Execute(user.Id) && 
                !IsStringEmpty.Execute(user.Name)
            );
        }
    }
}
