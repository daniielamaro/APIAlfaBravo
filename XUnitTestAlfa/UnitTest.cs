using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Caching;
using Xunit;
using Application.Repository;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Application.BusinessRules;
using Application.Entity;

namespace XUnitTestAlfa
{
    public class UnitTest
    {
        private readonly IUserRepository userRepository;
        private MemoryCache memoryCache;

        public UnitTest()
        {
            userRepository = new UserRepository();
            memoryCache = MemoryCache.Default;
        }       

        [Fact]
        public void TestAdd()
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
    }
}
