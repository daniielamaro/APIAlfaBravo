using Application.BusinessRules;
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

        [Fact]
        public void TestValidationPublication()
        {
            var okUser = new User("Nome teste", "email123@email.com", "123456789");
            new UserRepository().Create(okUser);

            var badUser = new User("Nome teste", "", "12345");

            var okTopic = new Topic("topico");
            new TopicRepository().Create(okTopic);

            var badTopic = new Topic("  ");

            var okPublication = new Publication(
                okUser,
                "Titulo",
                "Conteudo",
                okTopic
            );

            var badPublication1 = new Publication(
                badUser,
                "Titulo",
                "Conteudo",
                okTopic
            );

            var badPublication2 = new Publication(
                okUser,
                "  ",
                "Conteudo",
                okTopic
            );

            var badPublication3 = new Publication(
                okUser,
                "Titulo",
                "  ",
                okTopic
            );

            var badPublication4 = new Publication(
                okUser,
                "Titulo",
                "Conteudo",
                badTopic
            );

            var resultValidation1 = new PublicationValidator().Validate(okPublication);
            var resultValidation2 = new PublicationValidator().Validate(badPublication1);
            var resultValidation3 = new PublicationValidator().Validate(badPublication2);
            var resultValidation4 = new PublicationValidator().Validate(badPublication3);
            var resultValidation5 = new PublicationValidator().Validate(badPublication4);

            Assert.True(resultValidation1.IsValid);
            Assert.False(resultValidation2.IsValid);
            Assert.False(resultValidation3.IsValid);
            Assert.False(resultValidation4.IsValid);
            Assert.False(resultValidation5.IsValid);
        }

        [Fact]
        public void TestValidationPublicationExist()
        {
            var okUser = new User("Nome teste", "email123@email.com", "123456789");
            new UserRepository().Create(okUser);

            var okTopic = new Topic("topico");
            new TopicRepository().Create(okTopic);

            var okPublication = new Publication(
                okUser,
                "Titulo",
                "Conteudo",
                okTopic
            );

            var badPublication = new Publication(
                okUser,
                "Titulo",
                "Conteudo",
                okTopic
            );

            new PublicationRepository().Create(okPublication);

            var resultValidation1 = new PublicationExistValidator().Validate(okPublication.Id);
            var resultValidation2 = new PublicationExistValidator().Validate(badPublication.Id);

            Assert.True(resultValidation1.IsValid);
            Assert.False(resultValidation2.IsValid);
        }
    }
}
