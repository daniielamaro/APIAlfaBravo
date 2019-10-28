using Application.BusinessRules;
using Application.Entity;
using Application.Repository;
using Domain;
using System;
using System.Collections.Generic;
using Xunit;
using System.Runtime.Caching;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace XUnitTestAlfa.Infrastructure
{
    public class InfrastructureTestUser
    {
        private readonly IUserRepository userRepository;
        private MemoryCache memoryCache;

        public InfrastructureTestUser()
        {
            userRepository = new UserRepository();
            memoryCache = MemoryCache.Default;
        }

        [Fact]
        public void TestCreate()
        {
            User user = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            var resultValidation = new UserValidator().Validate(user);
            if (resultValidation.IsValid)
            {
                userRepository.Create(user);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                Assert.IsTrue(memoryCache.Add("user", user, policy));
            }
        }

        [Fact]
        public void TestDelete()
        {
            User user = new User("Raul F Santiago", "raulf@gmail.com", "11203456789");
            var resultValidation = new UserValidator().Validate(user);
            if (resultValidation.IsValid)
            {
                userRepository.Create(user);                
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("userRevome", user, policy);
                User userGet = (User)memoryCache["userRevome"];
                Assert.AreEqual(user.ToString(), userGet.ToString());
                memoryCache.Remove("userRevome");
                userGet = (User)memoryCache["userRevome"];
                Assert.IsNull(userGet);

            }
        }

        [Fact]
        public void TestGetById()
        {
            User user = new User(Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a"), "Raul P Santiago", "raulp@gmail.com", "112034567809");
            var resultValidation = new UserValidator().Validate(user);
            if (resultValidation.IsValid)
            {
                userRepository.Create(user);
                var id = user.Id;
                var idGet = userRepository.GetById(id);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("userGetId", user, policy);
                User userGet = (User)memoryCache["userGetId"];                
                Assert.IsTrue(idGet.Id == userGet.Id);
            }
        }

        [Fact]
        public void TestUpdate()
        {
            User user = new User("Raul L Santiago", "raull@gmail.com", "1133203456789");
            var resultValidation = new UserValidator().Validate(user);
            if (resultValidation.IsValid)
            {
                userRepository.Create(user);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("userUpdate", user, policy);
                User userGet = (User)memoryCache["userUpdate"];
                Assert.AreEqual(user.ToString(), userGet.ToString());
                User user2 = new User("Raul SF Santiago", "raulfs@gmail.com", "011203456789");
                memoryCache.Set("userUpdate", user2, policy);
                userGet = (User)memoryCache["userUpdate"];                
                Assert.IsTrue(user.Name != userGet.Name);
            }
        }

        [Fact]
        public void TestGetAll()
        {
            User user1 = new User("Raul F Santiago", "raulddf@gmail.com", "1120345671089");
            User user2 = new User("Raul D Santiago", "rauldf@gmail.com", "112034567189");
            User user3 = new User("Raul G Santiago", "rauldf@gmail.com", "112034567989");
            var resultValidation1 = new UserValidator().Validate(user1);
            var resultValidation2 = new UserValidator().Validate(user2);
            var resultValidation3 = new UserValidator().Validate(user3);
            if (resultValidation1.IsValid & resultValidation2.IsValid & resultValidation3.IsValid)
            {
                userRepository.Create(user1);
                userRepository.Create(user2);
                userRepository.Create(user3);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("user1", user1, policy);
                memoryCache.Add("user2", user2, policy);
                memoryCache.Add("user3", user3, policy);
                List<User> listUsers = userRepository.GetAll();
                Assert.IsTrue(memoryCache.GetCount() == listUsers.Count);
            }
        }

    }
}