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
            var user = UserBuilder.New().Build();
            new CreateUser().CreateNewRegister(user);

            var comment = CommentBuilder.New().Build();
            new CreateComment().CreateNewRegister(comment);

            Assert.True(comment.Id != Guid.Empty && comment.Id != null);
            Assert.True(comment.Autor.Id != Guid.Empty && comment.Autor.Id != null);
            Assert.True(comment.Content == "conteudo");
            Assert.True(comment.PublicationId == Guid.Parse("00000000-0000-0000-0000-000000000000"));
        }

        [Fact]
        public void TestCreateWithId()
        {
            var user = UserBuilder.New().Build();

            var comment = CommentBuilder.New().WithId(new Guid()).Build();

            Assert.True(comment.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"));
            Assert.True(comment.Autor.Id != Guid.Empty && comment.Autor.Id != null);
            Assert.True(comment.Content == "TestContent");
            Assert.True(comment.PublicationId != null && comment.PublicationId != Guid.Empty);
        }
    }
}