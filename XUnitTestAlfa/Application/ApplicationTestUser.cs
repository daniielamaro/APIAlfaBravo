using Application.BusinessRules;
using Application.Entity;
using Domain;
using Infrastructure.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestAlfa.Application
{
    public class ApplicationTestUser
    {
        [Fact]
        public void TestEntityCreate()
        {
            var user = new User("Nome teste", "email@email.com", "dsdsadasdas");

            var mockTeste = new Mock<ICreateDB<User>>();

            var userRepository = new UserRepository(mockTeste.Object);

            userRepository.Create(user);

            mockTeste.Verify(x => x.CreateNewRegister(It.IsAny<User>()));
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
            var mockTeste = new Mock<IGetDB<User>>();

            var userRepository = new UserRepository(mockTeste.Object);

            userRepository.GetById(Guid.NewGuid());

            mockTeste.Verify(x => x.GetRegisterById(It.IsAny<Guid>()));
        }

        [Fact]
        public void TestEntityUpdate()
        {
            var user = new User("Nome teste", "email@email.com", "dsdsadasdas");

            var mockTeste = new Mock<IUpdateDB<User>>();

            var userRepository = new UserRepository(mockTeste.Object);

            userRepository.Update(user);

            mockTeste.Verify(x => x.UpdateRegister(It.IsAny<User>()));
        }

        [Fact]
        public void TestEntityDelete()
        {
            var user = new User("Nome teste", "email@email.com", "dsdsadasdas");

            var mockTeste = new Mock<IDeleteDB<User>>();

            var userRepository = new UserRepository(mockTeste.Object);

            userRepository.Delete(user);

            mockTeste.Verify(x => x.DeleteRegister(It.IsAny<User>()));
        }

        [Fact]
        public void TestValidationUser()
        {
            var okUser = new User("Nome teste", "email@email.com", "dsdsadasdas");
            var badUser1 = new User(" ", "email@email.com", "dsdsadasdas");
            var badUser2 = new User("Nome teste", "email", "dsdsadasdas");
            var badUser3 = new User("Nome teste", "email@email.com", "dsds");

            var resultValidation1 = new UserValidator().Validate(okUser);
            var resultValidation2 = new UserValidator().Validate(badUser1);
            var resultValidation3 = new UserValidator().Validate(badUser2);
            var resultValidation4 = new UserValidator().Validate(badUser3);

            Assert.True(resultValidation1.IsValid);
            Assert.False(resultValidation2.IsValid);
            Assert.False(resultValidation3.IsValid);
            Assert.False(resultValidation4.IsValid);
        }
    }
}
