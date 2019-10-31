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
            Publication publication = PublicationBuilder.New().Build();

            Assert.True(publication.Id != Guid.Empty && publication.Id != null);
            Assert.True(publication.Autor.Id != Guid.Empty && publication.Autor.Id != null);
            Assert.True(publication.Title == "TestPost");
            Assert.True(publication.Content == "Test Post Builder");
            Assert.True(publication.DateCreated.Date == DateTime.Today);
            Assert.True(publication.Comments != null && publication.Comments.Count == 0);
            Assert.True(publication.Topic.Id != Guid.Empty && publication.Topic.Id != null);
        }

        [Fact]
        public void TestCreateWithId()
        {
            Publication publication = PublicationBuilder.New().Build();

            Assert.True(publication.Id != null && publication.Id != Guid.Empty);
            Assert.True(publication.Autor.Id != Guid.Empty && publication.Autor.Id != null);
            Assert.True(publication.Title == "TestPost");
            Assert.True(publication.Content == "Test Post Builder");
            Assert.True(publication.DateCreated.Date == DateTime.Today);
            Assert.True(publication.Comments != null && publication.Comments.Count == 0);
            Assert.True(publication.Topic.Id != Guid.Empty && publication.Topic.Id != null);
        }
    }
}
