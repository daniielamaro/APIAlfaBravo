using Application.BusinessRules;
using Application.Entity;
using Application.Repository;
using Domain;
using System;
using System.Collections.Generic;
using Xunit;
using System.Runtime.Caching;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Infrastructure.Repository.UserDB;

namespace XUnitTestAlfa.Infrastructure
{
    public class InfrastructureTestUser
    {        
        public InfrastructureTestUser()
        {            
        }

        [Fact]
        public void TestCreateUser()
        {
            var user = UserBuilder.New().Build();
            new CreateUser().CreateNewRegister(user);
            var idGet = new GetUser().GetRegisterById(user.Id);
            Assert.IsNotNull(idGet);
            Assert.IsTrue(idGet.Id.ToString() == user.Id.ToString());
        }

        [Fact]
        public void TestDeleteUser()
        {
            var user = UserBuilder.New().Build();            
            new CreateUser().CreateNewRegister(user);
            new DeleteUser().DeleteRegister(user);
            var idGet = new GetUser().GetRegisterById(user.Id);
            Assert.IsNull(idGet);            
        }

        [Fact]
        public void TestGetByIdUser()
        {
            var user = UserBuilder.New().WithId(Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a")).Build();            
            new CreateUser().CreateNewRegister(user);
            var idGet = new GetUser().GetRegisterById(user.Id);               
            Assert.IsNotNull(idGet);
            Assert.IsTrue(Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a") == idGet.Id);
        }

        [Fact]
        public void TestUpdateUser()
        {
            var user = UserBuilder.New().WithId(Guid.Parse("57ffdf20-ea87-4e72-9b80-fa3d77aef2b7")).Build();
            new CreateUser().CreateNewRegister(user);
            var userCopia = new GetUser().GetRegisterById(user.Id);
            User userSecond = UserBuilder.New().WithId(Guid.Parse("57ffdf20-ea87-4e72-9b80-fa3d77aef2b7")).Build(); 
            new UpdateUser().UpdateRegister(userSecond);
            Assert.IsTrue(userCopia.Email.ToString() != userSecond.Email.ToString());
            Assert.IsTrue(userCopia.Id.ToString() == user.Id.ToString() & userCopia.Id.ToString() == userSecond.Id.ToString());                
        }

        [Fact]
        public void TestGetAllUser()
        {
            var userPrimeiro = UserBuilder.New().Build();
            var userSecond = UserBuilder.New().Build();
            var userThird = UserBuilder.New().Build();
            new CreateUser().CreateNewRegister(userPrimeiro);
            new CreateUser().CreateNewRegister(userSecond);
            new CreateUser().CreateNewRegister(userThird);
            List<User> listUsers = new GetUser().GetAllRegister();
            Assert.IsTrue(listUsers.Count == 3);
        }
    }
}