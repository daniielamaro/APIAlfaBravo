using Domain;
using Infrastructure.Repository.UserDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebApi;
using WebApi.Controllers;
using Xunit;

namespace XUnitTestAlfa.WebApi
{
    public class TestWebApiUser
    {

        [Fact]
        public void TestGet()
        {
            User user1 = new User("nome primeiro", "email@email.com", "123456789");
            User user2 = new User("nome segundo", "email2@email.com", "123456789");
            User user3 = new User("nome terceiro", "email2@email.com", "123456789");
            new CreateUser().CreateNewRegister(user1);
            new CreateUser().CreateNewRegister(user2);
            new CreateUser().CreateNewRegister(user3);

            var controller = new UsersController();

            var result = controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);
            Assert.True(result.Value.Count == 3);
        }

        [Fact]
        public void TestPost()
        {
            var controller = new UsersController();

            var result = controller.Post("nome", "email@email.com", "123456897");

            var user = result.Value;

            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.True(user.Id == Guid.Empty || user.Id == null);
        }
    }
}
