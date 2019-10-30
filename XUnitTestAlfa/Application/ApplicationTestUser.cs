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
            var user = UserBuilder.New().Build();
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
            var user = UserBuilder.New().Build();
            var mockTeste = new Mock<IUpdateDB<User>>();
            var userRepository = new UserRepository(mockTeste.Object);
            userRepository.Update(user);
            mockTeste.Verify(x => x.UpdateRegister(It.IsAny<User>()));
        }

        [Fact]
        public void TestEntityDelete()
        {
            var user = UserBuilder.New().Build();
            var mockTeste = new Mock<IDeleteDB<User>>();
            var userRepository = new UserRepository(mockTeste.Object);
            userRepository.Delete(user);
            mockTeste.Verify(x => x.DeleteRegister(It.IsAny<User>()));
        }

        [Fact]
        public void TestValidationUser()
        {
            var okUser = UserBuilder.New().Build();
            var badUserFirst = UserBuilder.New().WithName(" ").Build();
            var badUserSecond = UserBuilder.New().WithEmail("mail").Build(); 
            var badUserThird = UserBuilder.New().WithPassword("xablau").Build();

            var resultValidationOk = new UserValidator().Validate(okUser);
            var resultValidationFirst = new UserValidator().Validate(badUserFirst);
            var resultValidationSecond = new UserValidator().Validate(badUserSecond);
            var resultValidationThird = new UserValidator().Validate(badUserThird);

            Assert.True(resultValidationOk.IsValid);
            Assert.False(resultValidationFirst.IsValid);
            Assert.False(resultValidationSecond.IsValid);
            Assert.False(resultValidationThird.IsValid);
        }

        [Fact]
        public void TestValidationUserExist()
        {
            var userFirst = UserBuilder.New().Build();
            var userSecond =  UserBuilder.New().Build();
            new UserRepository().Create(userFirst);
            var resultValidationFirst = new UserExistValidator().Validate(userFirst.Id);
            var resultValidationSecond = new UserExistValidator().Validate(userSecond.Id);
            Assert.True(resultValidationFirst.IsValid);
            Assert.False(resultValidationSecond.IsValid);
        }
    }
}
