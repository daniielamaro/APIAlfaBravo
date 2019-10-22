using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessRules
{
    public class UserExistValidator : AbstractValidator<User>
    {
        public UserExistValidator()
        {
            RuleFor(x => x.Id)
                .Must(VerifyUser)
                .WithMessage("Este usuario não existe.");
        }

        private bool VerifyUser(Guid id)
        {

        }
    }
}
