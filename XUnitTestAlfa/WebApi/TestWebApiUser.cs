using Domain;
using FluentAssertions;
using Infrastructure.Repository.UserDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using WebApi;
using WebApi.Controllers;
using Xunit;

namespace XUnitTestAlfa.WebApi
{
    public class TestWebApiUser
    {
        private readonly UsersController controller;
        private readonly CreateUser creator;

        public TestWebApiUser()
        {
            creator = new CreateUser();
            controller = new UsersController();
        }

        [Fact]
        public void TestGet()
        {
            var result1 = controller.Get();

            var user1 = UserBuilder.New().Build();

            creator.CreateNewRegister(user1);

            var result2 = controller.Get();

            Assert.IsType<NoContentResult>(result1.Result);
            Assert.IsType<OkObjectResult>(result2.Result);
        }

        [Fact]
        public void TestGetById()
        {
            var user = UserBuilder.New().Build();

            var result1 = controller.Get(user.Id);

            creator.CreateNewRegister(user);

            var result2 = controller.Get(user.Id);

            Assert.IsType<BadRequestObjectResult>(result1.Result);
            Assert.IsType<OkObjectResult>(result2.Result);
        }
        
        [Fact]
        public void TestPost()
        {
            var user = UserBuilder.New().Build();

            creator.CreateNewRegister(user);

            var result1 = controller.Post("Nome segundo", user.Email, "123456789");

            var result2 = controller.Post("Nome segundo", "emai2@email.com", "123456789");

            Assert.IsType<BadRequestObjectResult>(result1.Result);
            Assert.IsType<OkObjectResult>(result2.Result);
        }
        
        [Fact]
        public void TestPut()
        {
            var user = UserBuilder.New().Build();
            creator.CreateNewRegister(user);

            var result1 = controller.Put(user.Id, "nome primeiro", "danieldaniel.com", "123456789");

            var result2 = controller.Put(user.Id, "nome primeiro", "daniel@daniel.com", "123456789");

            Assert.IsType<BadRequestObjectResult>(result1.Result);
            Assert.IsType<OkObjectResult>(result2.Result);
        }
        
        [Fact]
        public void TestDelete()
        {
            var user = UserBuilder.New().Build();

            creator.CreateNewRegister(user);

            var result1 = controller.Delete(Guid.NewGuid());

            var result2 = controller.Delete(user.Id);

            Assert.IsType<BadRequestObjectResult>(result1.Result);
            Assert.IsType<OkObjectResult>(result2.Result);
        }
    }
}
