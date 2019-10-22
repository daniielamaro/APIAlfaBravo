using Application.Entity;
using Application.Repository;
using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessRules
{
    public class TopicExistValidator : AbstractValidator<Guid>
    {
        private readonly ITopicRepository topicRepository;
        
        public TopicExistValidator()
        {
            topicRepository = new TopicRepository();

            RuleFor(x => x)
                .Must(VerifyTopic)
                .WithMessage("Este tópico não existe."); 
        }

        private bool VerifyTopic(Guid id)
        {
            Topic topic = topicRepository.GetById(id);
            return (topic != null);
        }
    }
}
