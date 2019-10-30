using Infrastructure.Repository.TopicDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;
using Xunit;

namespace XUnitTestAlfa.WebApi
{
    public class WebApiTestTopic
    {
        private readonly TopicController controller;
        private readonly CreateTopic creator;

        public WebApiTestTopic()
        {
            creator = new CreateTopic();
            controller = new TopicController();
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
            var topic = TopicBuilder.New().Build();

            creator.CreateNewRegister(topic);

            var result = controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetByIdReturnsBadRequest()
        {
            var topic = TopicBuilder.New().Build();

            var result = controller.Get(topic.Id);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void GetByIdReturnsOk()
        {
            var topic = TopicBuilder.New().Build();

            creator.CreateNewRegister(topic);

            var result = controller.Get(topic.Id);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void PostReturnsBadRequest()
        {
            var result = controller.Post("   ");

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void PostReturnsOk()
        {
            var result = controller.Post("Nome");

            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public void PutReturnsBadRequest_TopicNotExistOnDatabase()
        {
            var result = controller.Put(Guid.NewGuid(), "Nome put");

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void PutReturnsBadRequest_TopicNotValid()
        {
            var topic = TopicBuilder.New().Build();
            creator.CreateNewRegister(topic);

            var result = controller.Put(topic.Id, "  ");

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void PutReturnsOk()
        {
            var topic = TopicBuilder.New().Build();
            creator.CreateNewRegister(topic);

            var result = controller.Put(topic.Id, "Nome Put");

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
            var topic = TopicBuilder.New().Build();

            creator.CreateNewRegister(topic);

            var result = controller.Delete(topic.Id);

            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
