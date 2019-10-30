using Domain;
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
            User user = new User("nome", "email@email.com", "senha");

            Comment comment = new Comment(user, "conteudo", new Guid());

            Assert.True(comment.Id != Guid.Empty && comment.Id != null);
            Assert.True(comment.Autor.Id != Guid.Empty && comment.Autor.Id != null);
            Assert.True(comment.Content == "conteudo");
            Assert.True(comment.PublicationId == Guid.Parse("00000000-0000-0000-0000-000000000000"));
        }

        [Fact]
        public void TestCreateWithId()
        {
            User user = new User("nome", "email@email.com", "senha");

            Comment comment = new Comment(new Guid(), user, "conteudo", new Guid());

            Assert.True(comment.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"));
            Assert.True(comment.Autor.Id != Guid.Empty && comment.Autor.Id != null);
            Assert.True(comment.Content == "conteudo");
            Assert.True(comment.PublicationId == Guid.Parse("00000000-0000-0000-0000-000000000000"));
        }
    }
}
