using Application.Entity;
using Domain;
using Infrastructure.Repository;
using Moq;
using System;
using Xunit;

namespace XUnitTestAlfa.Application
{
    public class ApplicationTestPublication
    {
        [Fact]
        public void TestEntityCreate()
        {
            var pub = new Publication(
                new User("teste", "teste", "teste"),
                "Primeiro",
                "Conteudo",
                new Topic("topico")
            );

            var mockTeste = new Mock<ICreateDB<Publication>>();

            var publicationRepository = new PublicationRepository(mockTeste.Object);

            publicationRepository.Create(pub);

            mockTeste.Verify(x => x.CreateNewRegister(It.IsAny<Publication>()));
        }

        [Fact]
        public void TestEntityGetAll()
        {
            var mockTeste = new Mock<IGetDB<Publication>>();

            var publicationRepository = new PublicationRepository(mockTeste.Object);

            publicationRepository.GetAll();

            mockTeste.Verify(x => x.GetAllRegister());
        }

        [Fact]
        public void TestEntityGetById()
        {
            var mockTeste = new Mock<IGetDB<Publication>>();

            var publicationRepository = new PublicationRepository(mockTeste.Object);

            publicationRepository.GetById(Guid.NewGuid());

            mockTeste.Verify(x => x.GetRegisterById(It.IsAny<Guid>()));
        }

        [Fact]
        public void TestEntityUpdate()
        {
            var pub = new Publication(
                new User("teste", "teste", "teste"),
                "Primeiro",
                "Conteudo",
                new Topic("topico")
            );

            var mockTeste = new Mock<IUpdateDB<Publication>>();

            var publicationRepository = new PublicationRepository(mockTeste.Object);

            publicationRepository.Update(pub);

            mockTeste.Verify(x => x.UpdateRegister(It.IsAny<Publication>()));
        }

        [Fact]
        public void TestEntityDelete()
        {
            var pub = new Publication(
                new User("teste", "teste", "teste"),
                "Primeiro",
                "Conteudo",
                new Topic("topico")
            );

            var mockTeste = new Mock<IDeleteDB<Publication>>();

            var publicationRepository = new PublicationRepository(mockTeste.Object);

            publicationRepository.Delete(pub);

            mockTeste.Verify(x => x.DeleteRegister(It.IsAny<Publication>()));
        }
    }
}
