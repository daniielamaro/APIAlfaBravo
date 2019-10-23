using Application.Entity;
using Application.Repository;
using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessRules
{
    public class CommentExistValidator : AbstractValidator<Guid>
    {
        private readonly ICommentRepository commentRepository;
        
        public CommentExistValidator()
        {
            commentRepository = new CommentRepository();

            RuleFor(x => x)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O id do comentário não pode ser nulo")
                .NotEmpty()
                .WithMessage("O id do comentário não pode ser vazio")
                .Must(VerifyTopic)
                .WithMessage("Este comentário não existe."); 
        }

        private bool VerifyTopic(Guid id)
        {
            Comment comment = commentRepository.GetById(id);
            return (comment != null);
        }
    }
}
