using Application.Entity;
using Application.Repository;
using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessRules
{
    public class TopicValidator : AbstractValidator<Topic>
    {
        private readonly ITopicRepository topicRepository;

        public TopicValidator()
        {
            topicRepository = new TopicRepository();

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O Id não pode ser nulo.")
                .Must(IdNotEmpty)
                .WithMessage("O Id não pode ser um Guid vazio (zerado)");


            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O Nome não pode estar em branco.")
                .Must(NameNotExists)
                .WithMessage("Este nome de tópico já existe na base de dados.");
        }

        private bool IdNotEmpty(Guid id)
        {
            return (id != Guid.Empty);
        }

        private bool NameNotExists(string name)
        {
            List<Topic> topics = topicRepository.GetAll();

            return !(topics.Exists(x => x.Name == name));
        }
    }
}
