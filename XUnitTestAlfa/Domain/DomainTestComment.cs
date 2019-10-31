using Domain;
using Infrastructure.Repository.UserDB;
using Infrastructure.Repository.CommentDB;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestAlfa.Domain
{
    public class DomainTestComment
    {
        [Fact]
        public void TestCreateWithoutId()
        {
            var comment = CommentBuilder.New()
                .WithId(new Guid())
                .WithAutor(UserBuilder.New().Build())
                .WithContent("Content")
                .WithPublicationId(new Guid())
                .Build();
            new CreateComment().CreateNewRegister(comment);

            Assert.True(comment.Id != Guid.Empty && comment.Id != null);
            Assert.True(comment.Autor.Id != Guid.Empty && comment.Autor.Id != null);
            Assert.True(comment.Content == "Content");
            Assert.True(comment.PublicationId == Guid.Parse("00000000-0000-0000-0000-000000000000"));
        }

        [Fact]
        public void TestCreateWithId()
        {
            var comment = CommentBuilder.New().WithId(new Guid()).Build();

            Assert.True(comment.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"));
            Assert.True(comment.Autor.Id != Guid.Empty && comment.Autor.Id != null);
            Assert.True(comment.Content == "TestContent");
            Assert.True(comment.PublicationId != null && comment.PublicationId != Guid.Empty);
        }
    }
}