﻿using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessRules
{
    public class PublicationValidator : AbstractValidator<Publication>
    {
        public PublicationValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O Id não pode ser nulo.")
                .Must(IdNotEmpty)
                .WithMessage("O Id não pode ser um Guid vazio (zerado).");

            RuleFor(x => x.Autor)
                .SetValidator(new UserValidator());

            RuleFor(x => x.Title)
                .NotNull()
                .WithMessage("O titulo não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O titulo não pode estar em branco.");

            RuleFor(x => x.Content)
                .NotNull()
                .WithMessage("O conteudo não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O conteudo não pode estar em branco.");

            RuleFor(x => x.Topic)
                .SetValidator(new TopicValidator());
        }

        private bool IdNotEmpty(Guid id)
        {
            return (id != Guid.Empty);
        }
    }
}