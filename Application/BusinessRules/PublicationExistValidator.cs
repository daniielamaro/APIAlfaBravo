using Application.Entity;
using Application.Repository;
using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessRules
{
    public class PublicationExistValidator : AbstractValidator<Guid>
    {
        private readonly IPublicationRepository publicationRepository;
        
        public PublicationExistValidator()
        {
            publicationRepository = new PublicationRepository();

            RuleFor(x => x)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O id da publicação não pode ser nulo")
                .NotEmpty()
                .WithMessage("O id da publicação não pode ser vazio")
                .Must(VerifyPublication)
                .WithMessage("Esta publicação não existe.");
        }

        private bool VerifyPublication(Guid id)
        {
            Publication publication = publicationRepository.GetById(id);
            return (publication != null);
        }
    }
}
