using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Caching;
using Xunit;
using Application.Repository;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Application.BusinessRules;
using Application.Entity;
using Moq;
using Nest;

namespace XUnitTestAlfa
{
    public class ApplicationTestUser
    {
        private readonly IUserRepository userRepository;
        //private readonly IDeleteRegister deleteRegister;
        private UserRepository userRepClass;
        private MemoryCache memoryCache;

        public ApplicationTestUser()
        {
            userRepository = new UserRepository();
            memoryCache = MemoryCache.Default;
            //userRepository = userRep;
            //userRepClass = repository;
            //deleteRegister = ddeleteRegister;
            //deleteRegister = new UserRepository();

        }       

        [Fact]
        public void UserCreater()
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
        public void UserDelete()
        {
            //User u = new User { Id = "dd56d258-daf2-4026-ac1b-13ac23087536", Name = "Luar", Email = "ra@gmail.com", Password = "123456789" };
            var u = new User("Raul F Santiago", "raulfs@gmail.com", "01203456789");
            FluentValidation.Results.ValidationResult resultValidation = new UserValidator().Validate(u);
            if (resultValidation.IsValid)
            {
                userRepository.Create(u);
                var id = u.Id;
                Console.WriteLine(id);
                var mock = new Mock<IUserRepository>();
                var controller = new UserRepository(mock.Object);
                controller.Delete(id);
                mock.VerifyRemove(x => x.Delete(u.Id));
            }
        }

    }
}
