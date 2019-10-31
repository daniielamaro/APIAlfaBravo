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
            var pub = PublicationBuilder.New().Build();

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
            var pub = PublicationBuilder.New().Build();

            var mockTeste = new Mock<IUpdateDB<Publication>>();

            var publicationRepository = new PublicationRepository(mockTeste.Object);

            publicationRepository.Update(pub);

            mockTeste.Verify(x => x.UpdateRegister(It.IsAny<Publication>()));
        }

        [Fact]
        public void TestEntityDelete()
        {
            var pub = PublicationBuilder.New().Build();

            var mockTeste = new Mock<IDeleteDB<Publication>>();

            var publicationRepository = new PublicationRepository(mockTeste.Object);

            publicationRepository.Delete(pub);

            mockTeste.Verify(x => x.DeleteRegister(It.IsAny<Publication>()));
        }

        [Fact]
        public void TestValidationPublication()
        {
            var okPublication = PublicationBuilder.New().Build();

            var resultValidation = new PublicationValidator().Validate(okPublication);

            Assert.True(resultValidation.IsValid);
        }

        [Fact]
        public void TestValidationPublicationBadUser()
        {
            var badUser = UserBuilder.New().WithEmail("emailemail.com").Build();
            
            var badPublication = PublicationBuilder.New().WithAutor(badUser).Build();

            var resultValidation2 = new PublicationValidator().Validate(badPublication);

            Assert.False(resultValidation2.IsValid);
        }

        [Fact]
        public void TestValidationPublicationBadContent()
        {
            var badPublication = PublicationBuilder.New().WithContent("  ").Build();

            var resultValidation = new PublicationValidator().Validate(badPublication);

            Assert.False(resultValidation.IsValid);
        }

        [Fact]
        public void TestValidationPublicationBadTitle()
        {
            var badPublication = PublicationBuilder.New().WithTitle("  ").Build();

            var resultValidation = new PublicationValidator().Validate(badPublication);

            Assert.False(resultValidation.IsValid);
        }

        [Fact]
        public void TestValidationPublicationBadTopic()
        {
            var badTopic = TopicBuilder.New().WithName("  ").Build();

            var badPublication = PublicationBuilder.New().WithTopic(badTopic).Build();

            var resultValidation = new PublicationValidator().Validate(badPublication);

            Assert.False(resultValidation.IsValid);
        }


        [Fact]
        public void TestValidationPublicationExistOnDB()
        {
            var okPublication = PublicationBuilder.New().Build();
            new PublicationRepository().Create(okPublication);

            var resultValidation = new PublicationExistValidator().Validate(okPublication.Id);

            Assert.True(resultValidation.IsValid);
        }

        [Fact]
        public void TestValidationPublicationNotExistOnDB()
        {
            var badPublication = PublicationBuilder.New().Build();

            var resultValidation = new PublicationExistValidator().Validate(badPublication.Id);

            Assert.False(resultValidation.IsValid);
        }
    }
}
