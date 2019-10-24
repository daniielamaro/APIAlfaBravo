using Application.Entity;
using Application.Repository;
using Domain;
using Infrastructure.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestAlfa.Application
{
    public class ApplicationTextPublication
    {
        [Fact]
        public void TestEntityCreate()
        {
            var pub1 = new Publication(
                new User("teste", "teste", "teste"),
                "Primeiro",
                "Conteudo",
                new Topic("topico")
            );

            var mockTeste = new Mock<IPublicationRepository>();

            var publicationRepository = new PublicationRepository(mockTeste.Object);

            publicationRepository.Create(pub1);

            mockTeste.Verify(x => x.CreateNew(It.IsAny<Publication>()));
        }
    }
}
