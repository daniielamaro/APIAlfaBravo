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
        private MemoryCache memoryCache;

        public InfrastructureTestUser()
        {            
            memoryCache = MemoryCache.Default;
        }

        [Fact]
        public void TestCreate()
        {
            var user = UserBuilder.New().Build();
            
            // Conhecimento MemoryCache
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30);
            Assert.IsTrue(memoryCache.Add("user", user, policy));

            // Produção através dos métodos
            new CreateUser().CreateNewRegister(user);
            var idGet = new GetUser().GetRegisterById(user.Id);                
            Assert.IsNotNull(idGet);
            Assert.IsTrue(idGet.Id.ToString() == user.Id.ToString());
        }

        [Fact]
        public void TestDelete()
        {
            User user = new User("Raul F Santiago", "raulf@gmail.com", "11203456789");
            var resultValidation = new UserValidator().Validate(user);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30);
                memoryCache.Add("userRevome", user, policy);
                User userGet = (User)memoryCache["userRevome"];
                Assert.AreEqual(user.ToString(), userGet.ToString());
                memoryCache.Remove("userRevome");
                userGet = (User)memoryCache["userRevome"];
                Assert.IsNull(userGet);

                // Produção através dos métodos
                new CreateUser().CreateNewRegister(user);
                new DeleteUser().DeleteRegister(user);
                var idGet = new GetUser().GetRegisterById(user.Id);
                Assert.IsNull(idGet);
            }
        }

        [Fact]
        public void TestGetById()
        {
            User user = new User(Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a"), "Raul P Santiago", "raulp@gmail.com", "112034567809");
            var resultValidation = new UserValidator().Validate(user);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30);
                memoryCache.Add("userGetId", user, policy);
                User userGet = (User)memoryCache["userGetId"];                
                Assert.IsTrue(Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a") == userGet.Id);

                // Produção através dos métodos
                new CreateUser().CreateNewRegister(user);
                var idGet = new GetUser().GetRegisterById(user.Id);               
                Assert.IsNotNull(idGet);
            }
        }

        [Fact]
        public void TestUpdate()
        {
            User user = new User(Guid.Parse("57ffdf20-ea87-4e72-9b80-fa3d77aef2b7"),"Raul Lu Santiago", "raullu@gmail.com", "1133203456546789");
            var resultValidation = new UserValidator().Validate(user);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30);
                memoryCache.Add("userUpdate", user, policy);
                User userGet = (User)memoryCache["userUpdate"];
                Assert.AreEqual(user.ToString(), userGet.ToString());
                User userSecond = new User("Raul Lual Santiago", "raulluar@gmail.com", "123011203456789");
                memoryCache.Set("userUpdate", userSecond, policy);
                userGet = (User)memoryCache["userUpdate"];                
                Assert.IsTrue(user.Name.ToString() != userGet.Name.ToString());

                // Produção através dos métodos
                new CreateUser().CreateNewRegister(user);
                var userCopia = new GetUser().GetRegisterById(user.Id);
                User userThird = new User(Guid.Parse("57ffdf20-ea87-4e72-9b80-fa3d77aef2b7"), "Raul Notato Santiago", "raulnotato@gmail.com", "012334561131456789");
                new UpdateUser().UpdateRegister(userThird);
                Assert.IsTrue(userCopia.Email.ToString() != userThird.Email.ToString());
                Assert.IsTrue(userCopia.Id.ToString() == user.Id.ToString() & userCopia.Id.ToString() == userThird.Id.ToString());
                
            }
        }

        [Fact]
        public void TestGetAll()
        {
            User userPrimeiro = new User("Raul Freitas Santiago", "raula@gmail.com", "01234567890");
            User userSecond = new User("Raul Fre Santiago", "raulb@gmail.com", "111123456789");
            User userThird = new User("Raul Mar Santiago", "raulc@gmail.com", "0123789999999");
            var resultValidationPrimeiro = new UserValidator().Validate(userPrimeiro);
            var resultValidationSecond = new UserValidator().Validate(userSecond);
            var resultValidationThird = new UserValidator().Validate(userThird);
            if (resultValidationPrimeiro.IsValid & resultValidationSecond.IsValid & resultValidationThird.IsValid)
            {
                // Conhecimento MemoryCache 
                CacheItemPolicy policyDif = new CacheItemPolicy();
                policyDif.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("userPrimeiro", userPrimeiro, policyDif);
                memoryCache.Add("userSecond", userSecond, policyDif);
                memoryCache.Add("userThird", userThird, policyDif);
                Assert.IsTrue(memoryCache.GetCount() == 3);

                // Produção através dos métodos
                new CreateUser().CreateNewRegister(userPrimeiro);
                new CreateUser().CreateNewRegister(userSecond);
                new CreateUser().CreateNewRegister(userThird);
                List<User> listUsers = new GetUser().GetAllRegister();
                Assert.IsTrue(listUsers.Count == 3);
            }
        }
    }
}