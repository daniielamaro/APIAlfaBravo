using Domain;
using Infrastructure.Repository.TopicDB;
using Infrastructure.Repository.UserDB;
using System;
using System.Collections.Generic;
using System.Text;

    public class PublicationBuilder
    {
        public Guid Id;
        public User Autor;
        public string Title;
        public string Content;
        public DateTime DateCreated;
        public List<Comment> Comments;
        public Topic Topic;

        public static PublicationBuilder New()
        {
            var user = UserBuilder.New().Build();  

            new CreateUser().CreateNewRegister(user);

            var topic = TopicBuilder.New().Build();  

            new CreateTopic().CreateNewRegister(topic);

        return new PublicationBuilder()
        {
                Id = Guid.NewGuid(),
                Autor = user,
                Title = "TestPost",
                Content = "Test Post Builder",
                DateCreated = DateTime.Now,
                Comments = new List<Comment>(),
                Topic = topic
            };
        }

        public PublicationBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public PublicationBuilder WithAutor(User user)
        {
            Autor = user;
            return this;
        }

        public PublicationBuilder WithTitle(string title)
        {
            Title = title;
            return this;
        }

        public PublicationBuilder WithContent(string content)
        {
            Content = content;
            return this;
        }

        public PublicationBuilder WithDate(DateTime date)
        {
            DateCreated = date;
            return this;
        }

        public PublicationBuilder WithComments(List<Comment> comments)
        {
            Comments = comments;
            return this;
        }

        public PublicationBuilder WithTopic(Topic topic)
        {
            Topic = topic;
            return this;
        }

        public Publication Build()
        {
            return new Publication(Id, Autor, Title, Content, DateCreated, Comments, Topic);
        }

    }
