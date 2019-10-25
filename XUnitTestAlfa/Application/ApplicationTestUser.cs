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
    }
}
