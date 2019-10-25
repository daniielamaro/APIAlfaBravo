using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestAlfa.Domain
{
    public class DomainTestUser
    {
        [Fact]
        public void TestCreateWithoutId()
        {
            User user = new User("Nome teste", "email@email.com", "senha");

            Assert.True(user.Id != Guid.Empty && user.Id != null);
            Assert.True(user.Name == "Nome teste");
            Assert.True(user.Email == "email@email.com");
            Assert.True(user.Password == "senha");
        }

        [Fact]
        public void TestCreateWithId()
        {
            User user = new User(new Guid(), "Nome teste", "email@email.com", "senha");

            Assert.True(user.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"));
            Assert.True(user.Name == "Nome teste");
            Assert.True(user.Email == "email@email.com");
            Assert.True(user.Password == "senha");
        }
    }
}