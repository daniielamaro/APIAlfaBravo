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
    public class WebApiTestUser
    {
        private readonly UsersController controller;
        private readonly CreateUser creator;

        public WebApiTestUser()
        {
            creator = new CreateUser();
            controller = new UsersController();
        }

        [Fact]
        public void GetReturnsNoContent()
        {
            var result = controller.Get();

            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public void GetReturnsOk()
        {
            var user = UserBuilder.New().Build();

            creator.CreateNewRegister(user);

            var result = controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetByIdReturnsBadRequest()
        {
            var user = UserBuilder.New().Build();

            var result = controller.Get(user.Id);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void GetByIdReturnsOk()
        {
            var user = UserBuilder.New().Build();

            creator.CreateNewRegister(user);

            var result = controller.Get(user.Id);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void PostReturnsBadRequest()
        {
            var result = controller.Post("Nome segundo", "emailemail.com", "123456789");

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void PostReturnsOk()
        {
            var result = controller.Post("Nome segundo", "email@email.com", "123456789");

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void PutReturnsBadRequest()
        {
            var user = UserBuilder.New().Build();
            creator.CreateNewRegister(user);

            var result = controller.Put(user.Id, "nome primeiro", "danieldaniel.com", "123456789");

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void PutReturnsOk()
        {
            var user = UserBuilder.New().Build();
            creator.CreateNewRegister(user);

            var result = controller.Put(user.Id, "nome primeiro", "daniel@daniel.com", "123456789");

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void DeleteReturnsBadRequest()
        {
            var result = controller.Delete(Guid.NewGuid());

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void DeleteReturnsOk()
        {
            var user = UserBuilder.New().Build();

            creator.CreateNewRegister(user);

            var result = controller.Delete(user.Id);

            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
