using Application.Entity;
using Application.Repository;
using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        private readonly IPublicationRepository publicationRepository;

        public CommentValidator()
        {
            publicationRepository = new PublicationRepository();

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O Id não pode ser nulo.");

            RuleFor(x => x.Autor)
                .SetValidator(new UserValidator());

            RuleFor(x => x.Content)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O comentario não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O comentario não pode estar vazio.");

            RuleFor(x => x.PublicationId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O Id da publicação não pode ser nulo.")
                .Must(IdNotEmpty)
                .WithMessage("O Id da publicação não pode ser um Guid vazio (zerado)")
                .Must(PublicationExists)
                .WithMessage("Esta publicação não existe");
        }

        private bool IdNotEmpty(Guid id)
        {
            return (id != Guid.Empty);
        }

        private bool PublicationExists(Guid id)
        {
            List<Publication> listPublications = publicationRepository.GetAll();

            return (listPublications.Exists(x => x.Id == id));
        }
    }
}
