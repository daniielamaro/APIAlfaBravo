using Domain;
using Infrastructure.Repository.PublicationDB;
using Infrastructure.Repository.UserDB;
using System;

public class CommentBuilder
{
    public Guid Id;
    public User Autor;
    public string Content;
    public Guid PublicationId;
        
    public static CommentBuilder New()
    {
        var user = UserBuilder.New().Build();
        new CreateUser().CreateNewRegister(user);

        var publication = PublicationBuilder.New().Build();
        new CreatePublication().CreateNewRegister(publication);

        return new CommentBuilder()
        {
            Id = Guid.NewGuid(),
            Autor = user,
            Content = "TestContent",
            PublicationId = publication.Id
        };
    }

    public CommentBuilder WithId(Guid id)
    {
        Id = id;
        return this;
    }

    public CommentBuilder WithAutor(User autor)
    {
        Autor = autor;
        return this;
    }

    public CommentBuilder WithContent(string content)
    {
        Content = content;
        return this;
    }

    public CommentBuilder WithPublicationId(Guid publicationId)
    {
        PublicationId = publicationId;
        return this;
    }

    public Comment Build()
    {
        return new Comment(Id, Autor, Content, PublicationId);
    }

}