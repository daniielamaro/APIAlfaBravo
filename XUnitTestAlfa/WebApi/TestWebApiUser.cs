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
        public void TestGetById()
        {
            User user1 = new User("nome primeiro", "email1@email.com", "123456789");
            new CreateUser().CreateNewRegister(user1);

            var controller = new UsersController();

            var result = controller.Get(user1.Id);

            Assert.IsType<User>(result.Result);
            //Assert.True(result.Value == null);
        }

        [Fact]
        public void TestPost()
        {
            var controller = new UsersController();

            var result1 = controller.Post("nome", "email@email.com", "123456897");
            var result2 = controller.Post("  ", "email2@email.com", "123456897");
            var result3 = controller.Post("nome", "email3email.com", "123456897");
            var result4 = controller.Post("nome", "email4@email.com", "123");

            Assert.IsType<CreatedAtActionResult>(result1.Result);
            Assert.IsType<BadRequestObjectResult>(result2.Result);
            Assert.IsType<BadRequestObjectResult>(result3.Result);
            Assert.IsType<BadRequestObjectResult>(result4.Result);
        }
    }
}
