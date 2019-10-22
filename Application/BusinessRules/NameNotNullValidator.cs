using Application.Entity;
using Application.Repository;
using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessRules
{
    public class NameNotNullValidator : AbstractValidator<string>
    {
        public NameNotNullValidator()
        {
            RuleFor(x => x)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O nome do autor não pode estar nulo.")
                .NotEmpty()
                .WithMessage("O nome do autor não pode estar em branco.");
        }
    }
}
