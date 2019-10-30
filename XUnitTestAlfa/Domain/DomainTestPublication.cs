using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestAlfa.Domain
{
    public class DomainTestPublication
    {
        [Fact]
        public void TestCreateWithoutId()
        {
            User user = new User("Nome teste", "email@email.com", "senha");
            Topic topic = new Topic("topico");

            Publication publication = new Publication(user, "titulo", "conteudo", topic);

            Assert.True(publication.Id != Guid.Empty && publication.Id != null);
            Assert.True(publication.Autor.Id != Guid.Empty && publication.Autor.Id != null);
            Assert.True(publication.Title == "titulo");
            Assert.True(publication.Content == "conteudo");
            Assert.True(publication.DateCreated.Date == DateTime.Today);
            Assert.True(publication.Comments != null && publication.Comments.Count == 0);
            Assert.True(publication.Topic.Id != Guid.Empty && publication.Topic.Id != null);
        }

        [Fact]
        public void TestCreateWithId()
        {
            User user = new User("Nome teste", "email@email.com", "senha");
            Topic topic = new Topic("topico");

            Publication publication = new Publication(new Guid(), user, "titulo", "conteudo", DateTime.Now, new List<Comment>(), topic);

            Assert.True(publication.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"));
            Assert.True(publication.Autor.Id != Guid.Empty && publication.Autor.Id != null);
            Assert.True(publication.Title == "titulo");
            Assert.True(publication.Content == "conteudo");
            Assert.True(publication.DateCreated.Date == DateTime.Today);
            Assert.True(publication.Comments != null && publication.Comments.Count == 0);
            Assert.True(publication.Topic.Id != Guid.Empty && publication.Topic.Id != null);
        }
    }
}
