using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.BusinessRules
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
